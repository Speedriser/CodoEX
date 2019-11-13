using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using CustName.AppName.DAL;

namespace CustName.AppName.BL
{
	public abstract class BaseEntityObject : IEntityObject
	{
		// Structure for storing object properties loaded from the repository, as well as control properties that should be included in any object copy operation.
		private struct ObjectData
		{
			// Data properties.
			// Data properties represent the existing or desired state of the object in the repository.
			// Modifications always require a commit before the repository copy can be considered synchronized.
			public DateTime? createTimestamp;
			public string createUser;
			public DateTime? lastUpdateTimestamp;
			public string lastUpdateUser;
			public int updateId;
			public int deleteCount; // The basis of MarkedForDeletion property exposed by this class.
			// Control properties.
			// Control properties reflect the state of the in-memory object.
			// Changing a control property does not necessarily mean a commit is required in order for the repository copy to be synchronized.
			// As a result, changing a control property does not cause hasUncommittedChanges to be set to true.
			// hasUncommittedChanges = true when one or more data properties have are modified since the in-memory object was created.
			// When a new object instance is created, objectStatus = New and hasUncommittedChanges = false.
			// If a data property is changed, hasUncommittedChanges is automatically set to true.
			// When a object is loaded from the repository, objectStatus = Existing and hasUncommittedChanges = false.
			// If a data property is changed, hasUncommittedChanges = true.
			// When a new or existing object is committed, objectStatus = Existing and hasUncommittedChanges = false.
			// If commit fails, hasUncommittedChanges remains unchanged.
			// objectStatus may change depending upon the type of failure.
			public ObjectStatus objectStatus;
			public bool hasUncommittedChanges;
		}

		public Guid objectInstanceId;
		private IEntityObjectContext context = null;
		// addNewList pointer is set by the overridden BindingList.AddNewCore method of the entity list classes (all are derived from BindingListView<T>).
		// The pointer is reverted back to null if IEditableObject.CancelEdit or EndEdit methods are called, or if the object is removed from the list.
		// Normally, IEditableObject.BeginEdit is called by the list after BindingList.AddNewCore is called.
		// Therefore, addNewList != null (see NewlyAddedToList) implies the object is added to a list but not yet committed so that it is a permanent member of the list.
		// addNewList (through IEditableObject interface) supports transacted additions to collections.
		// It is needed when a data bound control does not support ICancelAddNew.
		private IList addNewList = null;
		private ObjectData objectData;
		private ObjectData objectDataBackup;
		private ObjectData objectDataToCopy;

		public event EventHandler HasUncommittedChangesChanged = null;

		public BaseEntityObject()
		{
			Initialize_BaseEntityObject(Guid.NewGuid());
		}

		public BaseEntityObject(Guid instanceId)
		{
			Initialize_BaseEntityObject(instanceId);
		}

		private void Initialize_BaseEntityObject(Guid instanceId)
		{
			this.objectInstanceId = instanceId;
			this.objectData.objectStatus = CustName.AppName.DAL.ObjectStatus.New;
			this.objectData.hasUncommittedChanges = true;
			PostInitialize_BaseEntityObject();
		}

		protected virtual void PostInitialize_BaseEntityObject()
		{
		}

		#region Entity Information Properties

		public abstract EntityType EntityType
		{
			get;
		}

		public abstract EntityClass EntityClass
		{
			get;
		}

		#endregion Entity Information Properties

		#region IEntityObjectContextItem Interface

		public abstract IIdentifier ContextKey
		{
			get;
		}

		public IEntityObjectContext Context
		{
			get
			{
				return this.context;
			}
			set
			{
				this.context = value;
			}
		}

		#endregion IEntityObjectContextItem Interface

		#region Object Status Properties

		public ObjectStatus ObjectStatus
		{
			get
			{
				return this.objectData.objectStatus;
			}
			set
			{
				if (this.objectData.objectStatus != value)
				{
					this.objectData.objectStatus = value;
					// Call OnPropertyChanged instead of NotifyPropertyChanged because the latter sets hasUncommittedChanges = true,
					// which is undesirable because a change in ObjectStatus does not imply HasUncommittedChanges = true.
					OnPropertyChanged("ObjectStatus");
				}
			}
		}

		public bool HasUncommittedChanges
		{
			get
			{
				return this.objectData.hasUncommittedChanges;
			}
			set
			{
				if (this.objectData.hasUncommittedChanges != value)
				{
					this.objectData.hasUncommittedChanges = value;
					// Call OnPropertyChanged instead of NotifyPropertyChanged because the latter sets HasUncommittedChanges = true,
					// which is undesirable because HasUncommittedChanges would end up always being set to true.
					OnPropertyChanged("HasUncommittedChanges"); // Causing problems with BindingSource when a child is deleted from one of parent's collections. When that happens BindingSource.CurrentChanged is raised by BindingSources for parent and all children except the one where the delete took place, instead of for just the one where the delete took place and its children. As a result, child BindingSources of BindingSource where delete took place are not notified of update because CurrentChanged fails to fire.
					if (HasUncommittedChangesChanged != null) HasUncommittedChangesChanged(this, EventArgs.Empty);
				}
			}
		}

		public bool NewlyAddedToList
		{
			get
			{
				return (this.addNewList != null);
			}
		}

		#endregion Object Status Properties

		#region Base Properties and Methods

		public abstract string ObjectPrimaryDescriptor
		{
			get;
		}

		public Guid ObjectInstanceId
		{
			get
			{
				return this.objectInstanceId;
			}
			set
			{
				this.objectInstanceId = value;
			}
		}

		public DateTime? CreateTimestamp
		{
			get
			{
				return this.objectData.createTimestamp;
			}
			set
			{
				if (this.objectData.createTimestamp != value)
				{
					this.objectData.createTimestamp = value;
					NotifyPropertyChanged("CreateTimestamp");
				}
			}
		}

		public object CreateTimestamp_DBObjectValue
		{
			get
			{
				return (this.objectData.createTimestamp.HasValue ? (object)this.objectData.createTimestamp : (object)DBNull.Value);
			}
		}

		public DateTime CreateTimestamp_NoNull
		{
			get
			{
				return this.CreateTimestamp.GetValueOrDefault();
			}
			set
			{
				this.CreateTimestamp = value;
			}
		}

		public string CreateUser
		{
			get
			{
				return this.objectData.createUser;
			}
			set
			{
				if (this.objectData.createUser != value)
				{
					this.objectData.createUser = value;
					NotifyPropertyChanged("CreateUser");
				}
			}
		}

		public object CreateUser_DBObjectValue
		{
			get
			{
				return (this.objectData.createUser == null ? (object)DBNull.Value : (object)this.objectData.createUser);
			}
		}

		public DateTime? LastUpdateTimestamp
		{
			get
			{
				return this.objectData.lastUpdateTimestamp;
			}
			set
			{
				if (this.objectData.lastUpdateTimestamp != value)
				{
					this.objectData.lastUpdateTimestamp = value;
					NotifyPropertyChanged("LastUpdateTimestamp");
				}
			}
		}

		public object LastUpdateTimestamp_DBObjectValue
		{
			get
			{
				return (this.objectData.lastUpdateTimestamp.HasValue ? (object)this.objectData.lastUpdateTimestamp : (object)DBNull.Value);
			}
		}

		public DateTime LastUpdateTimestamp_NoNull
		{
			get
			{
				return this.LastUpdateTimestamp.GetValueOrDefault();
			}
			set
			{
				this.LastUpdateTimestamp = value;
			}
		}

		public string LastUpdateUser
		{
			get
			{
				return this.objectData.lastUpdateUser;
			}
			set
			{
				if (this.objectData.lastUpdateUser != value)
				{
					this.objectData.lastUpdateUser = value;
					NotifyPropertyChanged("LastUpdateUser");
				}
			}
		}

		public object LastUpdateUser_DBObjectValue
		{
			get
			{
				return (this.objectData.lastUpdateUser == null ? (object)DBNull.Value : (object)this.objectData.lastUpdateUser);
			}
		}

		public int UpdateId
		{
			get
			{
				return this.objectData.updateId;
			}
			set
			{
				if (this.objectData.updateId != value)
				{
					this.objectData.updateId = value;
					NotifyPropertyChanged("UpdateId");
				}
			}
		}

		public object UpdateId_DBObjectValue
		{
			get
			{
				return (object)this.objectData.updateId;
			}
		}

		#endregion Base Properties

		#region Logical Delete Functions

		public bool MarkedForDeletion
		{
			get
			{
				return (this.objectData.deleteCount > 0);
			}
		}

		public virtual void IncrementDeleteCount()
		{
			if (++this.objectData.deleteCount == 1)
				NotifyPropertyChanged("MarkedForDeletion");
		}

		public virtual void DecrementDeleteCount()
		{
			if (this.objectData.deleteCount > 0)
			{
				if (--this.objectData.deleteCount == 0)
					NotifyPropertyChanged("MarkedForDeletion");
			}
		}

		#endregion Logical Delete Functions

		#region Object Comparison

		public virtual bool SameAs(IEntityObject obj)
		{
			EntityObject entityObject = (EntityObject)obj;
			return
			(
				this.objectData.createTimestamp == entityObject.objectData.createTimestamp &&
				this.objectData.createUser == entityObject.objectData.createUser &&
				this.objectData.lastUpdateTimestamp == entityObject.objectData.lastUpdateTimestamp &&
				this.objectData.lastUpdateUser == entityObject.objectData.lastUpdateUser &&
				this.objectData.updateId == entityObject.objectData.updateId
				// deleteCount, objectStatus, and hasUncommittedChanges deliberately excluded.
			);
		}

		#endregion Object Comparison

		#region Object Copy

		// Structure for recording the changed status of data properties.
		private struct ObjectDataChanges
		{
			public bool CreateTimestampPropertyChanged;
			public bool CreateUserPropertyChanged;
			public bool LastUpdateTimestampPropertyChanged;
			public bool LastUpdateUserPropertyChanged;
			public bool UpdateIdPropertyChanged;
			public bool MarkedForDeletionPropertyChanged; // Associated with deleteCount.
			public bool ObjectStatusPropertyChanged;
			public bool HasUncommittedChangesPropertyChanged;
		}

		private ObjectDataChanges objectDataChanges;

		public virtual void PopulateFrom(IEntityObject source)
		{
			this.objectDataToCopy = ((EntityObject)source).objectData;
			// Compare the data in this.objectDataToCopy with this object.
			// Differences recorded in this.objectDataChanges.
			CompareObjectData(ObjectDataSet.Copy);
			// Copy this.objectDataToCopy to this object.
			CopySourceObjectDataToActive();
			SendPropertyChangeNotifications();
		}

		protected virtual void CompareObjectData(ObjectDataSet objectDataSet)
		{
			ObjectData objectDataToCompare;
			if (objectDataSet == ObjectDataSet.Active)
			{
				this.objectDataChanges.CreateTimestampPropertyChanged = false;
				this.objectDataChanges.CreateUserPropertyChanged = false;
				this.objectDataChanges.LastUpdateTimestampPropertyChanged = false;
				this.objectDataChanges.LastUpdateUserPropertyChanged = false;
				this.objectDataChanges.MarkedForDeletionPropertyChanged = false;
				this.objectDataChanges.UpdateIdPropertyChanged = false;
				this.objectDataChanges.ObjectStatusPropertyChanged = false;
				this.objectDataChanges.HasUncommittedChangesPropertyChanged = false;
			}
			else
			{
				switch (objectDataSet)
				{
					case ObjectDataSet.Backup:
						objectDataToCompare = this.objectDataBackup;
						break;
					default: // ObjectDataSet.Copy
						objectDataToCompare = this.objectDataToCopy;
						break;
				}
				this.objectDataChanges.CreateTimestampPropertyChanged = (objectDataToCompare.createTimestamp != this.objectData.createTimestamp);
				this.objectDataChanges.CreateUserPropertyChanged = (objectDataToCompare.createUser != this.objectData.createUser);
				this.objectDataChanges.LastUpdateTimestampPropertyChanged = (objectDataToCompare.lastUpdateTimestamp != this.objectData.lastUpdateTimestamp);
				this.objectDataChanges.LastUpdateUserPropertyChanged = (objectDataToCompare.lastUpdateUser != this.objectData.lastUpdateUser);
				this.objectDataChanges.MarkedForDeletionPropertyChanged = (objectDataToCompare.deleteCount != this.objectData.deleteCount);
				this.objectDataChanges.UpdateIdPropertyChanged = (objectDataToCompare.updateId != this.objectData.updateId);
				this.objectDataChanges.ObjectStatusPropertyChanged = (objectDataToCompare.objectStatus != this.objectData.objectStatus);
				this.objectDataChanges.HasUncommittedChangesPropertyChanged = (objectDataToCompare.hasUncommittedChanges != this.objectData.hasUncommittedChanges);
			}
		}

		protected virtual void CopySourceObjectDataToActive()
		{
			this.objectData = this.objectDataToCopy;
		}

		protected virtual void SendPropertyChangeNotifications()
		{
			if (this.objectDataChanges.CreateTimestampPropertyChanged) OnPropertyChanged("CreateTimestamp");
			if (this.objectDataChanges.CreateUserPropertyChanged) OnPropertyChanged("CreateUser");
			if (this.objectDataChanges.LastUpdateTimestampPropertyChanged) OnPropertyChanged("LastUpdateTimestamp");
			if (this.objectDataChanges.LastUpdateUserPropertyChanged) OnPropertyChanged("LastUpdateUser");
			if (this.objectDataChanges.MarkedForDeletionPropertyChanged) OnPropertyChanged("MarkedForDeletion");
			if (this.objectDataChanges.UpdateIdPropertyChanged) OnPropertyChanged("UpdateId");
			if (this.objectDataChanges.ObjectStatusPropertyChanged) OnPropertyChanged("ObjectStatus");
			if (this.objectDataChanges.HasUncommittedChangesPropertyChanged)
			{
				OnPropertyChanged("HasUncommittedChanges");
				if (HasUncommittedChangesChanged != null) HasUncommittedChangesChanged(this, EventArgs.Empty);
			}
		}

		#endregion Object Copy

		#region INotifyPropertyChanged Related

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void NotifyPropertyChanged(string propertyName)
		{
			HasUncommittedChanges = true;
			OnPropertyChanged(propertyName);
		}

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				// If this object contained by a BindingList collection, it will in turn raise a ListChanged event.
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		#endregion

		#region IEditableObject Related

		protected bool inTransaction = false;

		void IEditableObject.BeginEdit()
		{
			if (!inTransaction)
			{
				BackupObjectData();
				inTransaction = true;
			}
		}

		void IEditableObject.CancelEdit()
		{
			if (inTransaction)
			{
				CompareObjectData(ObjectDataSet.Backup);
				RestoreObjectData();
				inTransaction = false;
				if (this.addNewList != null)
				{
					this.addNewList.Remove(this);
					this.addNewList = null;
				}
				SendPropertyChangeNotifications();
			}
		}

		void IEditableObject.EndEdit()
		{
			if (inTransaction)
			{
				inTransaction = false;
				this.addNewList = null;
			}
		}

		protected virtual void BackupObjectData()
		{
			this.objectDataBackup = this.objectData;
		}

		protected virtual void RestoreObjectData()
		{
			this.objectData = this.objectDataBackup;
		}

		public IList AddNewList
		{
			get
			{
				return this.addNewList;
			}
			set
			{
				this.addNewList = value;
			}
		}

		#endregion

		#region Miscellaneous

		public abstract void Load(bool recurse);

		public abstract IList<IEntityObject> GetOwnedObjects(bool loaded, IList<IEntityObject> list);

		#endregion Miscellaneous

		#region Utility Functions

		public static bool AreEqual(byte[] objA, byte[] objB)
		{
			bool areEqual = true;
			if (objA != objB)
			{
				// Array object references are different hence the possibility of their content being different.
				if ((objA == null && objB != null) || (objA != null && objB == null))
				{
					// null is considered to be different in value to any non-null array reference because null
					// can be explicitly stored in the database as opposed to a zero-length array.
					areEqual = false;
				}
				else if (objA.GetLongLength(0) != objB.GetLongLength(0))
				{
					// The arrays are different in size.
					areEqual = false;
				}
				else
				{
					// Both arrays exist (no null array references) and have the same length.
					// Now to compare element by element.
					long maxIndex = objB.GetLongLength(0);
					for (long index = 0; index < maxIndex; ++index)
					{
						if (objA[index] != objB[index])
						{
							areEqual = false;
							break;
						}
					}
				}
			}
			return areEqual;
		}

		public static bool AreEqual(FileAttachment objA, FileAttachment objB)
		{
			bool areEqual = true;
			if (objA != objB)
			{
				// Object references are different hence the possibility of their content being different.
				if ((objA == null && objB != null) || (objA != null && objB == null))
				{
					// null is considered to be different in value to any non-null reference because null
					// can be explicitly stored in the database.
					areEqual = false;
				}
				else
				{
					areEqual = (objA.FileName == objB.FileName && AreEqual(objA.Data, objB.Data));
				}
			}
			return areEqual;
		}

		#endregion Utility Functions
	}
}
