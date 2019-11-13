using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CustName.AppName.DAL;

namespace CustName.AppName.BL
{
	public abstract class BaseAttachment1 : EntityObject, IAttachment1
	{
		private struct ObjectData
		{
			// Structure for primary key fields.
			public Attachment1Identifier? ObjectId;
			// Structure for foreign key fields associated with the DependentEntity1 owner relationship.
			public DependentEntity1Identifier? ParentOwnerDependentEntity1EntityObjectId;
			public string AttachmentNotes;
			public string AttachmentType;
			public bool? AttrBool1;
			public DateTime? AttrDatetime1;
			public int? AttrInteger1;
			public string AttrString1;
			public string AttrString2;
			public FileAttachment FileAttachment;
			public string Name;
			public string Status;
		}

		private struct ObjectDataChanges
		{
			public bool ObjectIdPropertyChanged;
			public bool ParentOwnerDependentEntity1EntityObjectIdPropertyChanged;
			public bool AttachmentNotesPropertyChanged;
			public bool AttachmentTypePropertyChanged;
			public bool AttrBool1PropertyChanged;
			public bool AttrDatetime1PropertyChanged;
			public bool AttrInteger1PropertyChanged;
			public bool AttrString1PropertyChanged;
			public bool AttrString2PropertyChanged;
			public bool FileAttachmentPropertyChanged;
			public bool NamePropertyChanged;
			public bool StatusPropertyChanged;
		}

		private ObjectData objectData;
		private ObjectData objectDataBackup;
		private ObjectData objectDataToCopy;
		private ObjectDataChanges objectDataChanges;

		#region Inbound Relationships

		// This region contains the collection variables for referencing inbound related entity objects.
		// Inbound related entities are typically dependent entities.

		// This entity has no inbound relationships.

		#endregion Inbound Relationships

		#region Outbound Relationships

		// This region contains the collection variables for referencing outbound related entity objects.
		// Outbound related entities are typically parent entities.

		#region Owner Outbound Relationships

		// DependentEntity1 Relationship
		// References childOwnedAttachment1List collection of DependentEntity1.
		// Alias for EntityObject.ParentList.
		private Attachment1List parentOwnerDependentEntity1_Attachment1List;
		// Indicates if attempt has been made to get a reference to the collection.
		// If attempt fails, collection reference will remain null.
		// Flag applicable only when parentOwnerDependentEntity1_Attachment1List is null.
		private bool parentOwnerDependentEntity1_Attachment1ListPartialLoadAttempted = false;

		#endregion Owner Outbound Relationships

		#region Non-Owner Outbound Relationships

		// This entity has no non-owner outbound relationships.

		#endregion Non-Owned Outbound Relationships

		#endregion Outbound Relationships

		public BaseAttachment1()
			: base()
		{
			Initialize_BaseAttachment1();
		}

		public BaseAttachment1(Guid instanceId)
			: base(instanceId)
		{
			Initialize_BaseAttachment1();
		}

		private void Initialize_BaseAttachment1()
		{
			PostInitialize_BaseAttachment1();
		}

		protected virtual void PostInitialize_BaseAttachment1()
		{
		}

		public override EntityType EntityType
		{
			get
			{
				return CustName.AppName.DAL.EntityType.Dependent;
			}
		}

		public override EntityClass EntityClass
		{
			get
			{
				return CustName.AppName.DAL.EntityClass.Attachment1;
			}
		}

		#region IEntityObjectContextItem Interface

		public override IIdentifier ContextKey
		{
			get
			{
				return (IIdentifier)this.objectData.ObjectId.Value;
			}
		}

		#endregion

		public Attachment1Identifier? ObjectId
		{
			get
			{
				return this.objectData.ObjectId;
			}
			set
			{
				if (this.objectData.ObjectId != value)
				{
					this.objectData.ObjectId = value;
					NotifyPropertyChanged("ObjectId");
				}
			}
		}

		public virtual object ObjectId_DBObjectValue
		{
			get
			{
				return (this.ObjectId.HasValue ? (object)this.ObjectId.Value : (object)DBNull.Value);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.ObjectId = null;
				else
					this.ObjectId = (Attachment1Identifier)value;
			}
		}

		public virtual int? Attachment1Id
		{
			get
			{
				return (this.objectData.ObjectId.HasValue ? (int?)this.objectData.ObjectId.Value.Attachment1Id : (int?)null);
			}
		}

		public virtual object Attachment1Id_DBObjectValue
		{
			get
			{
				return (this.objectData.ObjectId.HasValue ? (object)this.objectData.ObjectId.Value.Attachment1Id : (object)DBNull.Value);
			}
		}

		public override string ObjectPrimaryDescriptor
		{
			get
			{
				string name = null;
				if (this.Name != null)
				{
					name = this.Name.ToString();
				}
				if (name == null)
				{
					if (this.ObjectStatus == ObjectStatus.New)
						name = "<new>";
					else
						name = "<undefined>";
				}
				else if (name.Trim() == "")
				{
					name = "<blank>";
				}
				return name;
			}
		}

		public virtual string AttachmentNotes
		{
			get
			{
				return this.objectData.AttachmentNotes;
			}
			set
			{
				if (this.objectData.AttachmentNotes != value)
				{
					this.objectData.AttachmentNotes = value;
					NotifyPropertyChanged("AttachmentNotes");
				}
			}
		}

		public virtual object AttachmentNotes_DBObjectValue
		{
			get
			{
				return (this.AttachmentNotes == null ? (object)DBNull.Value : (object)this.AttachmentNotes);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.AttachmentNotes = null;
				else
					this.AttachmentNotes = (System.String)value;
			}
		}

		public virtual string AttachmentType
		{
			get
			{
				return this.objectData.AttachmentType;
			}
			set
			{
				if (this.objectData.AttachmentType != value)
				{
					this.objectData.AttachmentType = value;
					NotifyPropertyChanged("AttachmentType");
				}
			}
		}

		public virtual object AttachmentType_DBObjectValue
		{
			get
			{
				return (this.AttachmentType == null ? (object)DBNull.Value : (object)this.AttachmentType);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.AttachmentType = null;
				else
					this.AttachmentType = (System.String)value;
			}
		}

		public virtual bool? AttrBool1
		{
			get
			{
				return this.objectData.AttrBool1;
			}
			set
			{
				if (this.objectData.AttrBool1 != value)
				{
					this.objectData.AttrBool1 = value;
					NotifyPropertyChanged("AttrBool1");
				}
			}
		}

		public virtual object AttrBool1_DBObjectValue
		{
			get
			{
				return (this.AttrBool1.HasValue ? (object)this.AttrBool1.Value : (object)DBNull.Value);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.AttrBool1 = null;
				else
					switch (value.ToString())
					{
						case "Checked":
							this.AttrBool1 = true;
							break;
						case "Indeterminate":
							this.AttrBool1 = null;
							break;
						case "Unchecked":
							this.AttrBool1 = false;
							break;
						case "False":
							this.AttrBool1 = false;
							break;
						case "True":
							this.AttrBool1 = true;
							break;
						default:
							this.AttrBool1 = (System.Boolean?)value;
							break;
					}
			}
		}

		public virtual bool AttrBool1_NoNull
		{
			get
			{
				return this.AttrBool1.GetValueOrDefault();
			}
			set
			{
				this.AttrBool1 = value;
			}
		}

		public virtual DateTime? AttrDatetime1
		{
			get
			{
				return this.objectData.AttrDatetime1;
			}
			set
			{
				DateTime? dateOnly;
				if (value.HasValue)
					dateOnly = value.Value.Date;
				if (this.objectData.AttrDatetime1 != value)
				{
					this.objectData.AttrDatetime1 = value;
					NotifyPropertyChanged("AttrDatetime1");
				}
			}
		}

		public virtual object AttrDatetime1_DBObjectValue
		{
			get
			{
				return (this.AttrDatetime1.HasValue ? (object)this.AttrDatetime1.Value : (object)DBNull.Value);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.AttrDatetime1 = null;
				else
					this.AttrDatetime1 = (System.DateTime?)value;
			}
		}

		public virtual DateTime AttrDatetime1_NoNull
		{
			get
			{
				return this.AttrDatetime1.GetValueOrDefault();
			}
			set
			{
				this.AttrDatetime1 = value;
			}
		}

		public virtual int? AttrInteger1
		{
			get
			{
				return this.objectData.AttrInteger1;
			}
			set
			{
				if (this.objectData.AttrInteger1 != value)
				{
					this.objectData.AttrInteger1 = value;
					NotifyPropertyChanged("AttrInteger1");
				}
			}
		}

		public virtual object AttrInteger1_DBObjectValue
		{
			get
			{
				return (this.AttrInteger1.HasValue ? (object)this.AttrInteger1.Value : (object)DBNull.Value);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.AttrInteger1 = null;
				else
					this.AttrInteger1 = (System.Int32?)value;
			}
		}

		public virtual int AttrInteger1_NoNull
		{
			get
			{
				return this.AttrInteger1.GetValueOrDefault();
			}
			set
			{
				this.AttrInteger1 = value;
			}
		}

		public virtual string AttrString1
		{
			get
			{
				return this.objectData.AttrString1;
			}
			set
			{
				if (this.objectData.AttrString1 != value)
				{
					this.objectData.AttrString1 = value;
					NotifyPropertyChanged("AttrString1");
				}
			}
		}

		public virtual object AttrString1_DBObjectValue
		{
			get
			{
				return (this.AttrString1 == null ? (object)DBNull.Value : (object)this.AttrString1);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.AttrString1 = null;
				else
					this.AttrString1 = (System.String)value;
			}
		}

		public virtual string AttrString2
		{
			get
			{
				return this.objectData.AttrString2;
			}
			set
			{
				if (this.objectData.AttrString2 != value)
				{
					this.objectData.AttrString2 = value;
					NotifyPropertyChanged("AttrString2");
				}
			}
		}

		public virtual object AttrString2_DBObjectValue
		{
			get
			{
				return (this.AttrString2 == null ? (object)DBNull.Value : (object)this.AttrString2);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.AttrString2 = null;
				else
					this.AttrString2 = (System.String)value;
			}
		}

		public virtual FileAttachment FileAttachment
		{
			get
			{
				return this.objectData.FileAttachment;
			}
			set
			{
				this.FileAttachment_IsLoaded = true;
				if (!EntityObject.AreEqual(this.objectData.FileAttachment, value))
				{
					this.objectData.FileAttachment = value;
					NotifyPropertyChanged("FileAttachment");
				}
			}
		}

		public virtual object FileAttachment_DBObjectValue
		{
			get
			{
				return (this.FileAttachment == null ? (object)DBNull.Value : (object)this.FileAttachment);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.FileAttachment = null;
				else
					this.FileAttachment = (FileAttachment)value;
			}
		}

		public virtual bool FileAttachment_IsLoaded
		{
			get
			{
				if (this.objectData.FileAttachment == null)
					return true;
				else
					return this.objectData.FileAttachment.BlobAssigned;
			}
			set
			{
				if (this.objectData.FileAttachment != null)
					this.objectData.FileAttachment.BlobAssigned = true;
			}
		}

		public virtual void FileAttachment_Load()
		{
			if (!FileAttachment_IsLoaded)
			{
				try
				{
					if (this.ObjectId.HasValue)
						this.objectData.FileAttachment.Data = CustName.AppName.BL.Global.ClassFactory.GetDALRepository().GetAttachment1BLOB(this.ObjectId.Value, this.UpdateId, "file_attachment");
					this.FileAttachment_IsLoaded = true;
				}
				catch (SingleCollisionException e)
				{
					// Update the object's status to reflect the collision.
					switch (e.Collision.CollisionType)
					{
						case CollisionType.Delete: // Collision - object physically deleted by another user.
							this.ObjectStatus = CustName.AppName.DAL.ObjectStatus.Deleted;
							break;
						case CollisionType.Update: // Collision - object updated by another user.
							this.ObjectStatus = CustName.AppName.DAL.ObjectStatus.Outdated;
							break;
					}
					// Rethrow the collision exception.
					throw;
				}
			}
		}

		public virtual string Name
		{
			get
			{
				return this.objectData.Name;
			}
			set
			{
				if (this.objectData.Name != value)
				{
					this.objectData.Name = value;
					NotifyPropertyChanged("Name");
				}
			}
		}

		public virtual object Name_DBObjectValue
		{
			get
			{
				return (this.Name == null ? (object)DBNull.Value : (object)this.Name);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.Name = null;
				else
					this.Name = (System.String)value;
			}
		}

		public virtual string Status
		{
			get
			{
				return this.objectData.Status;
			}
			set
			{
				if (this.objectData.Status != value)
				{
					this.objectData.Status = value;
					NotifyPropertyChanged("Status");
				}
			}
		}

		public virtual object Status_DBObjectValue
		{
			get
			{
				return (this.Status == null ? (object)DBNull.Value : (object)this.Status);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.Status = null;
				else
					this.Status = (System.String)value;
			}
		}

		public DependentEntity1Identifier? ParentOwnerDependentEntity1EntityObjectId
		{
			get
			{
				if (this.parentOwnerDependentEntity1_Attachment1List == null)
					return this.objectData.ParentOwnerDependentEntity1EntityObjectId;
				else
					return ((DependentEntity1)this.parentOwnerDependentEntity1_Attachment1List.Parent).ObjectId;
			}
			set
			{
				if (this.parentOwnerDependentEntity1_Attachment1List == null)
				{
					bool valueChanged = false;
					if (this.parentOwnerDependentEntity1_Attachment1ListPartialLoadAttempted)
						// Implies objectData.ParentOwnerDependentEntity1EntityObjectId points to non-existent object in the repository.
						UnloadParentOwnerDependentEntity1_Attachment1List();
					// At this point parentOwnerDependentEntity1_Attachment1List is UNLOADED.
					if (this.objectData.ParentOwnerDependentEntity1EntityObjectId != value)
					{
						this.objectData.ParentOwnerDependentEntity1EntityObjectId = value;
						valueChanged = true;
					}
					if (valueChanged)
						NotifyPropertyChanged("ParentOwnerDependentEntity1EntityObjectId");
				}
				else
				{
					// At this point parentOwnerDependentEntity1_Attachment1List is LOADED.
					if (((DependentEntity1)this.parentOwnerDependentEntity1_Attachment1List.Parent).ObjectId != value)
					{
						// The supplied foreign object id does not match the currently linked entity object.
						// parentOwnerDependentEntity1_Attachment1List must therefore be unloaded.
						UnloadParentOwnerDependentEntity1_Attachment1List();
						this.objectData.ParentOwnerDependentEntity1EntityObjectId = value;
						// NotifyPropertyChanged notification is required because ParentOwnerDependentEntity1EntityObjectId will return a different value.
						NotifyPropertyChanged("ParentOwnerDependentEntity1EntityObjectId");
					}
					else
					{
						// Set objectData.ParentOwnerDependentEntity1EntityObjectId to new value in case parentOwnerDependentEntity1_Attachment1List is unloaded.
						this.objectData.ParentOwnerDependentEntity1EntityObjectId = value;
						// There is no need for a NotifyPropertyChanged notification because ParentOwnerDependentEntity1EntityObjectId will not return a different value.
					}
				}
			}
		}

		public virtual object ParentOwnerDependentEntity1EntityObjectId_DBObjectValue
		{
			get
			{
				return (this.ParentOwnerDependentEntity1EntityObjectId.HasValue ? (object)this.ParentOwnerDependentEntity1EntityObjectId.Value : (object)DBNull.Value);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.ParentOwnerDependentEntity1EntityObjectId = null;
				else
					this.ParentOwnerDependentEntity1EntityObjectId = (DependentEntity1Identifier)value;
			}
		}

		public virtual int? DependentEntity1Id
		{
			get
			{
				DependentEntity1Identifier? identifier = this.ParentOwnerDependentEntity1EntityObjectId;
				return (identifier.HasValue ? (int?)identifier.Value.DependentEntity1Id : (int?)null);
			}
		}

		public virtual object DependentEntity1Id_DBObjectValue
		{
			get
			{
				DependentEntity1Identifier? identifier = this.ParentOwnerDependentEntity1EntityObjectId;
				return (identifier.HasValue ? (object)identifier.Value.DependentEntity1Id : (object)DBNull.Value);
			}
		}

		// Will not work if all on-demand-load BLOB properties are not loaded.
		public override bool SameAs(IEntityObject obj)
		{
			Attachment1 attachment1 = (Attachment1)obj;
			return (base.SameAs(obj) && attachment1.ObjectId == this.objectData.ObjectId && this.objectData.ParentOwnerDependentEntity1EntityObjectId == null && this.objectData.AttachmentNotes == attachment1.objectData.AttachmentNotes && this.objectData.AttachmentType == attachment1.objectData.AttachmentType && this.objectData.AttrBool1 == attachment1.objectData.AttrBool1 && this.objectData.AttrDatetime1 == attachment1.objectData.AttrDatetime1 && this.objectData.AttrInteger1 == attachment1.objectData.AttrInteger1 && this.objectData.AttrString1 == attachment1.objectData.AttrString1 && this.objectData.AttrString2 == attachment1.objectData.AttrString2 && this.objectData.FileAttachment == attachment1.objectData.FileAttachment && this.objectData.Name == attachment1.objectData.Name && this.objectData.Status == attachment1.objectData.Status);
		}

		public bool SameAs(IAttachment1 obj)
		{
			return SameAs((IEntityObject)obj);
		}

		#region IEditableObject Related

		protected override void BackupObjectData()
		{
			base.BackupObjectData();
			this.objectDataBackup = this.objectData;
		}

		protected override void RestoreObjectData()
		{
			base.RestoreObjectData();
			this.objectData = this.objectDataBackup;
		}

		#endregion

		public override void PopulateFrom(IEntityObject source)
		{
			this.objectDataToCopy = ((Attachment1)source).objectData;
			base.PopulateFrom(source);
		}

		protected override void CopySourceObjectDataToActive()
		{
			base.CopySourceObjectDataToActive();
			this.objectData = this.objectDataToCopy;
		}

		protected override void CompareObjectData(ObjectDataSet objectDataSet)
		{
			base.CompareObjectData(objectDataSet);

			ObjectData objectDataToCompare;
			if (objectDataSet == ObjectDataSet.Active)
			{
				this.objectDataChanges.ObjectIdPropertyChanged = false;
				this.objectDataChanges.ParentOwnerDependentEntity1EntityObjectIdPropertyChanged = false;
				this.objectDataChanges.AttachmentNotesPropertyChanged = false;
				this.objectDataChanges.AttachmentTypePropertyChanged = false;
				this.objectDataChanges.AttrBool1PropertyChanged = false;
				this.objectDataChanges.AttrDatetime1PropertyChanged = false;
				this.objectDataChanges.AttrInteger1PropertyChanged = false;
				this.objectDataChanges.AttrString1PropertyChanged = false;
				this.objectDataChanges.AttrString2PropertyChanged = false;
				this.objectDataChanges.FileAttachmentPropertyChanged = false;
				this.objectDataChanges.NamePropertyChanged = false;
				this.objectDataChanges.StatusPropertyChanged = false;
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
				this.objectDataChanges.ObjectIdPropertyChanged = (objectDataToCompare.ObjectId != objectData.ObjectId);
				this.objectDataChanges.ParentOwnerDependentEntity1EntityObjectIdPropertyChanged = (objectDataToCompare.ParentOwnerDependentEntity1EntityObjectId != objectData.ParentOwnerDependentEntity1EntityObjectId);
				this.objectDataChanges.AttachmentNotesPropertyChanged = (objectDataToCompare.AttachmentNotes != objectData.AttachmentNotes);
				this.objectDataChanges.AttachmentTypePropertyChanged = (objectDataToCompare.AttachmentType != objectData.AttachmentType);
				this.objectDataChanges.AttrBool1PropertyChanged = (objectDataToCompare.AttrBool1 != objectData.AttrBool1);
				this.objectDataChanges.AttrDatetime1PropertyChanged = (objectDataToCompare.AttrDatetime1 != objectData.AttrDatetime1);
				this.objectDataChanges.AttrInteger1PropertyChanged = (objectDataToCompare.AttrInteger1 != objectData.AttrInteger1);
				this.objectDataChanges.AttrString1PropertyChanged = (objectDataToCompare.AttrString1 != objectData.AttrString1);
				this.objectDataChanges.AttrString2PropertyChanged = (objectDataToCompare.AttrString2 != objectData.AttrString2);
				this.objectDataChanges.FileAttachmentPropertyChanged = (objectDataToCompare.FileAttachment != objectData.FileAttachment);
				this.objectDataChanges.NamePropertyChanged = (objectDataToCompare.Name != objectData.Name);
				this.objectDataChanges.StatusPropertyChanged = (objectDataToCompare.Status != objectData.Status);
			}
		}

		protected override void SendPropertyChangeNotifications()
		{
			base.SendPropertyChangeNotifications();
			if (this.objectDataChanges.ObjectIdPropertyChanged) OnPropertyChanged("ObjectId");
			if (this.objectDataChanges.ParentOwnerDependentEntity1EntityObjectIdPropertyChanged) OnPropertyChanged("ParentOwnerDependentEntity1EntityObjectId");
			if (this.objectDataChanges.AttachmentNotesPropertyChanged) OnPropertyChanged("AttachmentNotes");
			if (this.objectDataChanges.AttachmentTypePropertyChanged) OnPropertyChanged("AttachmentType");
			if (this.objectDataChanges.AttrBool1PropertyChanged) OnPropertyChanged("AttrBool1");
			if (this.objectDataChanges.AttrDatetime1PropertyChanged) OnPropertyChanged("AttrDatetime1");
			if (this.objectDataChanges.AttrInteger1PropertyChanged) OnPropertyChanged("AttrInteger1");
			if (this.objectDataChanges.AttrString1PropertyChanged) OnPropertyChanged("AttrString1");
			if (this.objectDataChanges.AttrString2PropertyChanged) OnPropertyChanged("AttrString2");
			if (this.objectDataChanges.FileAttachmentPropertyChanged) OnPropertyChanged("FileAttachment");
			if (this.objectDataChanges.NamePropertyChanged) OnPropertyChanged("Name");
			if (this.objectDataChanges.StatusPropertyChanged) OnPropertyChanged("Status");
		}

		#region INotifyPropertyChanged Related

		protected override void NotifyPropertyChanged(string propertyName)
		{
			base.NotifyPropertyChanged(propertyName);
			if (propertyName == "Name")
				base.NotifyPropertyChanged("ObjectPrimaryDescriptor");
		}

		#endregion

		// ========================================================================================================================

		#region Inbound Relationships

		#region Owned Inbound Relationships

		// This entity has no owned inbound relationships.

		#endregion // Owned Inbound Relationships

		#region Non-Owned Inbound Relationships

		// This entity has no non-owned inbound relationships.

		#endregion // Non-Owned Inbound Relationships

		#endregion // Inbound Relationships

		// ========================================================================================================================

		#region Outbound Relationships

		#region Owner Outbound Relationships


		#region DependentEntity1 Relationship

		public bool ParentOwnerDependentEntity1_Attachment1ListPartialLoadAttempted
		{
			get
			{
				if (this.parentOwnerDependentEntity1_Attachment1List == null)
					return this.parentOwnerDependentEntity1_Attachment1ListPartialLoadAttempted;
				else
					return true;
			}
		}

		public Attachment1List ParentOwnerDependentEntity1_Attachment1List
		{
			get
			{
				LoadParentOwnerDependentEntity1_Attachment1List();
				return this.parentOwnerDependentEntity1_Attachment1List;
			}
			internal set
			{
				this.parentOwnerDependentEntity1_Attachment1List = value;
			}
		}

		IAttachment1List IAttachment1.ParentOwnerDependentEntity1_Attachment1List
		{
			get
			{
				return (IAttachment1List)this.ParentOwnerDependentEntity1_Attachment1List;
			}
		}

		public void LoadParentOwnerDependentEntity1_Attachment1List()
		{
			if (!ParentOwnerDependentEntity1_Attachment1ListPartialLoadAttempted)
			{
				if (this.objectData.ParentOwnerDependentEntity1EntityObjectId == null)
				{
					ParentOwnerDependentEntity1_Attachment1List = null;
				}
				else
				{
					DependentEntity1 dependentEntity1 = (DependentEntity1)CustName.AppName.BL.Global.ClassFactory.GetDALRepository().GetDependentEntity1(this.objectData.ParentOwnerDependentEntity1EntityObjectId.Value, this.Context);
					if (dependentEntity1 == null)
						ParentOwnerDependentEntity1_Attachment1List = null;
					else
						ParentOwnerDependentEntity1_Attachment1List = (Attachment1List)dependentEntity1.LoadChildOwnedAttachment1List((Attachment1)this);
				}
				this.parentOwnerDependentEntity1_Attachment1ListPartialLoadAttempted = true;
				NotifyAll_ParentOwnerDependentEntity1EntityObject_PropertiesChanged();
			}
		}

		public void UnloadParentOwnerDependentEntity1_Attachment1List()
		{
			ParentOwnerDependentEntity1_Attachment1List = null;
			this.parentOwnerDependentEntity1_Attachment1ListPartialLoadAttempted = false;
			NotifyAll_ParentOwnerDependentEntity1EntityObject_PropertiesChanged();
		}

		public DependentEntity1 ParentOwnerDependentEntity1EntityObject
		{
			get
			{
				LoadParentOwnerDependentEntity1_Attachment1List();
				if (this.parentOwnerDependentEntity1_Attachment1List == null)
					// Either foreign object id == null or is invalid (i.e. points to non-existent repository object).
					return null;
				else
					return (DependentEntity1)this.parentOwnerDependentEntity1_Attachment1List.Parent;
			}
		}

		IDependentEntity1 IAttachment1.ParentOwnerDependentEntity1EntityObject
		{
			get
			{
				return (IDependentEntity1)this.ParentOwnerDependentEntity1EntityObject;
			}
		}

		public bool HasParentOwnerDependentEntity1Object(bool inMemoryOnly)
		{
			if (inMemoryOnly)
			{
				if (this.parentOwnerDependentEntity1_Attachment1List == null)
					return false;
				else
					return (this.parentOwnerDependentEntity1_Attachment1List.Parent != null);
			}
			else
			{
				if (this.parentOwnerDependentEntity1_Attachment1List == null)
				{
					if (this.parentOwnerDependentEntity1_Attachment1ListPartialLoadAttempted)
						return false;
					else
						return (this.objectData.ParentOwnerDependentEntity1EntityObjectId != null);
				}
				else
					return (this.parentOwnerDependentEntity1_Attachment1List.Parent != null);
			}
		}

		#endregion DependentEntity1 Relationship

		#endregion // Owner Outbound Relationships

		#region Non-Owner Outbound Relationships

		// This entity has no non-owner outbound relationships.

		#endregion // Non-Owner Outbound Relationships

		#endregion // Outbound Relationships

		// ========================================================================================================================

		public override void Load(bool recurse)
		{
			// This entity has no owned inbound relationships.
		}

		public override IList<IEntityObject> GetOwnedObjects(bool loaded, IList<IEntityObject> list)
		{
			return null;
		}

		public Attachment1 Copy(bool recurse)
		{
			return CopyImpl(recurse);
		}

		IAttachment1 IAttachment1.Copy(bool recurse)
		{
			return (IAttachment1)CopyImpl(recurse);
		}

		protected Attachment1 CopyImpl(bool recurse)
		{
			Attachment1 newAttachment1 = (Attachment1)CustName.AppName.BL.Global.ClassFactory.GetEntityObject(CustName.AppName.DAL.EntityClass.Attachment1);
			newAttachment1.PopulateFrom(this);
			newAttachment1.ObjectId = null;
			return newAttachment1;
		}

		// ========================================================================================================================

		#region Outbound Relationships Properties

		#region Owner Outbound Relationships Properties

		#region DependentEntity1 Relationship

		public virtual int? ParentOwnerDependentEntity1EntityObject_IndependentEntity1Id
		{
			get
			{
				IDependentEntity1 obj = ParentOwnerDependentEntity1EntityObject;
				if (obj == null)
					return null;
				else
					return obj.IndependentEntity1Id;
			}
		}

		public virtual bool? ParentOwnerDependentEntity1EntityObject_AttrBool1
		{
			get
			{
				IDependentEntity1 obj = ParentOwnerDependentEntity1EntityObject;
				if (obj == null)
					return null;
				else
					return obj.AttrBool1;
			}
		}

		public virtual DateTime? ParentOwnerDependentEntity1EntityObject_AttrDatetime1
		{
			get
			{
				IDependentEntity1 obj = ParentOwnerDependentEntity1EntityObject;
				if (obj == null)
					return null;
				else
					return obj.AttrDatetime1;
			}
		}

		public virtual int? ParentOwnerDependentEntity1EntityObject_AttrInteger1
		{
			get
			{
				IDependentEntity1 obj = ParentOwnerDependentEntity1EntityObject;
				if (obj == null)
					return null;
				else
					return obj.AttrInteger1;
			}
		}

		public virtual string ParentOwnerDependentEntity1EntityObject_AttrString1
		{
			get
			{
				IDependentEntity1 obj = ParentOwnerDependentEntity1EntityObject;
				if (obj == null)
					return null;
				else
					return obj.AttrString1;
			}
		}

		public virtual string ParentOwnerDependentEntity1EntityObject_AttrString2
		{
			get
			{
				IDependentEntity1 obj = ParentOwnerDependentEntity1EntityObject;
				if (obj == null)
					return null;
				else
					return obj.AttrString2;
			}
		}

		public virtual string ParentOwnerDependentEntity1EntityObject_Name
		{
			get
			{
				IDependentEntity1 obj = ParentOwnerDependentEntity1EntityObject;
				if (obj == null)
					return null;
				else
					return obj.Name;
			}
		}

		public virtual string ParentOwnerDependentEntity1EntityObject_Status
		{
			get
			{
				IDependentEntity1 obj = ParentOwnerDependentEntity1EntityObject;
				if (obj == null)
					return null;
				else
					return obj.Status;
			}
		}

		protected virtual void NotifyAll_ParentOwnerDependentEntity1EntityObject_PropertiesChanged()
		{
			// When this object is in a list that is bound to a DataGridView control containing a ComboBox bound to the FK property (DependentEntity1Id)
			// driving the content of the ParentOwnerDependentEntity1EntityObject_* properties,
			// changing selections in the ComboBox results in a noticeable pause.
			// Delay is cause by something executing FindCore on the list that the ComboBox is bound to (that populates its dropdown) every time OnPropertyChanged is called.
			// Another issue is that any list containing this object raises an event to signal that it has changed, causing owner entity objects to be marked as having changes,
			// which may not be desirable becauses changes to DependentEntity1 may not imply changes to the parent if DependentEntity1 is not owned by the parent.
			// Workaround has been to disable OnPropertyChanged calls below and have the UI listen for changes in the FK property DependentEntity1Id (indirectly through the
			// ListChanged event) and invalidate the DataGridView row so that repaints cells containing values dependent upon the combobox selection i.e. one of the
			// ParentOwnerDependentEntity1EntityObject_* properties.
			//OnPropertyChanged("ParentOwnerDependentEntity1EntityObject_AttrBool1");
			//OnPropertyChanged("ParentOwnerDependentEntity1EntityObject_AttrDatetime1");
			//OnPropertyChanged("ParentOwnerDependentEntity1EntityObject_AttrInteger1");
			//OnPropertyChanged("ParentOwnerDependentEntity1EntityObject_AttrString1");
			//OnPropertyChanged("ParentOwnerDependentEntity1EntityObject_AttrString2");
			//OnPropertyChanged("ParentOwnerDependentEntity1EntityObject_IndependentEntity1Id");
			//OnPropertyChanged("ParentOwnerDependentEntity1EntityObject_Name");
			//OnPropertyChanged("ParentOwnerDependentEntity1EntityObject_Status");
		}

		#endregion DependentEntity1 Relationship Properties

		#endregion // Owner Outbound Relationships Properties

		#region Non-Owner Outbound Relationships Properties

		// This entity has no non-owner outbound relationships.

		#endregion // Non-Owner Outbound Relationships Properties

		#endregion // Outbound Relationships Properties

		// ========================================================================================================================
	}

	public abstract class BaseDependentEntity1 : EntityObject, IDependentEntity1
	{
		private struct ObjectData
		{
			// Structure for primary key fields.
			public DependentEntity1Identifier? ObjectId;
			// Structure for foreign key fields associated with the IndependentEntity1 owner relationship.
			public IndependentEntity1Identifier? ParentOwnerIndependentEntity1EntityObjectId;
			public bool? AttrBool1;
			public DateTime? AttrDatetime1;
			public int? AttrInteger1;
			public string AttrString1;
			public string AttrString2;
			public string Name;
			public string Status;
		}

		private struct ObjectDataChanges
		{
			public bool ObjectIdPropertyChanged;
			public bool ParentOwnerIndependentEntity1EntityObjectIdPropertyChanged;
			public bool AttrBool1PropertyChanged;
			public bool AttrDatetime1PropertyChanged;
			public bool AttrInteger1PropertyChanged;
			public bool AttrString1PropertyChanged;
			public bool AttrString2PropertyChanged;
			public bool NamePropertyChanged;
			public bool StatusPropertyChanged;
		}

		private ObjectData objectData;
		private ObjectData objectDataBackup;
		private ObjectData objectDataToCopy;
		private ObjectDataChanges objectDataChanges;

		#region Inbound Relationships

		// This region contains the collection variables for referencing inbound related entity objects.
		// Inbound related entities are typically dependent entities.

		#region Owned Inbound Relationships

		// Attachment1 Relationship
		private LoadStatus childOwnedAttachment1ListLoadStatus = LoadStatus.NotLoaded;
		private Attachment1List childOwnedAttachment1List = null;
		private System.ComponentModel.ListChangedEventHandler childOwnedAttachment1ListChangedEventHandler = null;
		// DependentEntity2 Relationship
		private LoadStatus childOwnedDependentEntity2ListLoadStatus = LoadStatus.NotLoaded;
		private DependentEntity2List childOwnedDependentEntity2List = null;
		private System.ComponentModel.ListChangedEventHandler childOwnedDependentEntity2ListChangedEventHandler = null;

		#endregion Owned Inbound Relationships

		#region Non-Owned Inbound Relationships

		// This entity has no non-owned inbound relationships.

		#endregion Non-Owned Inbound Relationships

		#endregion Inbound Relationships

		#region Outbound Relationships

		// This region contains the collection variables for referencing outbound related entity objects.
		// Outbound related entities are typically parent entities.

		#region Owner Outbound Relationships

		// IndependentEntity1 Relationship
		// References childOwnedDependentEntity1List collection of IndependentEntity1.
		// Alias for EntityObject.ParentList.
		private DependentEntity1List parentOwnerIndependentEntity1_DependentEntity1List;
		// Indicates if attempt has been made to get a reference to the collection.
		// If attempt fails, collection reference will remain null.
		// Flag applicable only when parentOwnerIndependentEntity1_DependentEntity1List is null.
		private bool parentOwnerIndependentEntity1_DependentEntity1ListPartialLoadAttempted = false;

		#endregion Owner Outbound Relationships

		#region Non-Owner Outbound Relationships

		// This entity has no non-owner outbound relationships.

		#endregion Non-Owned Outbound Relationships

		#endregion Outbound Relationships

		public BaseDependentEntity1()
			: base()
		{
			Initialize_BaseDependentEntity1();
		}

		public BaseDependentEntity1(Guid instanceId)
			: base(instanceId)
		{
			Initialize_BaseDependentEntity1();
		}

		private void Initialize_BaseDependentEntity1()
		{
			PostInitialize_BaseDependentEntity1();
		}

		protected virtual void PostInitialize_BaseDependentEntity1()
		{
		}

		public override EntityType EntityType
		{
			get
			{
				return CustName.AppName.DAL.EntityType.Dependent;
			}
		}

		public override EntityClass EntityClass
		{
			get
			{
				return CustName.AppName.DAL.EntityClass.DependentEntity1;
			}
		}

		#region IEntityObjectContextItem Interface

		public override IIdentifier ContextKey
		{
			get
			{
				return (IIdentifier)this.objectData.ObjectId.Value;
			}
		}

		#endregion

		public DependentEntity1Identifier? ObjectId
		{
			get
			{
				return this.objectData.ObjectId;
			}
			set
			{
				if (this.objectData.ObjectId != value)
				{
					this.objectData.ObjectId = value;
					NotifyPropertyChanged("ObjectId");
				}
			}
		}

		public virtual object ObjectId_DBObjectValue
		{
			get
			{
				return (this.ObjectId.HasValue ? (object)this.ObjectId.Value : (object)DBNull.Value);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.ObjectId = null;
				else
					this.ObjectId = (DependentEntity1Identifier)value;
			}
		}

		public virtual int? DependentEntity1Id
		{
			get
			{
				return (this.objectData.ObjectId.HasValue ? (int?)this.objectData.ObjectId.Value.DependentEntity1Id : (int?)null);
			}
		}

		public virtual object DependentEntity1Id_DBObjectValue
		{
			get
			{
				return (this.objectData.ObjectId.HasValue ? (object)this.objectData.ObjectId.Value.DependentEntity1Id : (object)DBNull.Value);
			}
		}

		public override string ObjectPrimaryDescriptor
		{
			get
			{
				string name = null;
				if (this.Name != null)
				{
					name = this.Name.ToString();
				}
				if (name == null)
				{
					if (this.ObjectStatus == ObjectStatus.New)
						name = "<new>";
					else
						name = "<undefined>";
				}
				else if (name.Trim() == "")
				{
					name = "<blank>";
				}
				return name;
			}
		}

		public virtual bool? AttrBool1
		{
			get
			{
				return this.objectData.AttrBool1;
			}
			set
			{
				if (this.objectData.AttrBool1 != value)
				{
					this.objectData.AttrBool1 = value;
					NotifyPropertyChanged("AttrBool1");
				}
			}
		}

		public virtual object AttrBool1_DBObjectValue
		{
			get
			{
				return (this.AttrBool1.HasValue ? (object)this.AttrBool1.Value : (object)DBNull.Value);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.AttrBool1 = null;
				else
					switch (value.ToString())
					{
						case "Checked":
							this.AttrBool1 = true;
							break;
						case "Indeterminate":
							this.AttrBool1 = null;
							break;
						case "Unchecked":
							this.AttrBool1 = false;
							break;
						case "False":
							this.AttrBool1 = false;
							break;
						case "True":
							this.AttrBool1 = true;
							break;
						default:
							this.AttrBool1 = (System.Boolean?)value;
							break;
					}
			}
		}

		public virtual bool AttrBool1_NoNull
		{
			get
			{
				return this.AttrBool1.GetValueOrDefault();
			}
			set
			{
				this.AttrBool1 = value;
			}
		}

		public virtual DateTime? AttrDatetime1
		{
			get
			{
				return this.objectData.AttrDatetime1;
			}
			set
			{
				DateTime? dateOnly;
				if (value.HasValue)
					dateOnly = value.Value.Date;
				if (this.objectData.AttrDatetime1 != value)
				{
					this.objectData.AttrDatetime1 = value;
					NotifyPropertyChanged("AttrDatetime1");
				}
			}
		}

		public virtual object AttrDatetime1_DBObjectValue
		{
			get
			{
				return (this.AttrDatetime1.HasValue ? (object)this.AttrDatetime1.Value : (object)DBNull.Value);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.AttrDatetime1 = null;
				else
					this.AttrDatetime1 = (System.DateTime?)value;
			}
		}

		public virtual DateTime AttrDatetime1_NoNull
		{
			get
			{
				return this.AttrDatetime1.GetValueOrDefault();
			}
			set
			{
				this.AttrDatetime1 = value;
			}
		}

		public virtual int? AttrInteger1
		{
			get
			{
				return this.objectData.AttrInteger1;
			}
			set
			{
				if (this.objectData.AttrInteger1 != value)
				{
					this.objectData.AttrInteger1 = value;
					NotifyPropertyChanged("AttrInteger1");
				}
			}
		}

		public virtual object AttrInteger1_DBObjectValue
		{
			get
			{
				return (this.AttrInteger1.HasValue ? (object)this.AttrInteger1.Value : (object)DBNull.Value);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.AttrInteger1 = null;
				else
					this.AttrInteger1 = (System.Int32?)value;
			}
		}

		public virtual int AttrInteger1_NoNull
		{
			get
			{
				return this.AttrInteger1.GetValueOrDefault();
			}
			set
			{
				this.AttrInteger1 = value;
			}
		}

		public virtual string AttrString1
		{
			get
			{
				return this.objectData.AttrString1;
			}
			set
			{
				if (this.objectData.AttrString1 != value)
				{
					this.objectData.AttrString1 = value;
					NotifyPropertyChanged("AttrString1");
				}
			}
		}

		public virtual object AttrString1_DBObjectValue
		{
			get
			{
				return (this.AttrString1 == null ? (object)DBNull.Value : (object)this.AttrString1);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.AttrString1 = null;
				else
					this.AttrString1 = (System.String)value;
			}
		}

		public virtual string AttrString2
		{
			get
			{
				return this.objectData.AttrString2;
			}
			set
			{
				if (this.objectData.AttrString2 != value)
				{
					this.objectData.AttrString2 = value;
					NotifyPropertyChanged("AttrString2");
				}
			}
		}

		public virtual object AttrString2_DBObjectValue
		{
			get
			{
				return (this.AttrString2 == null ? (object)DBNull.Value : (object)this.AttrString2);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.AttrString2 = null;
				else
					this.AttrString2 = (System.String)value;
			}
		}

		public virtual string Name
		{
			get
			{
				return this.objectData.Name;
			}
			set
			{
				if (this.objectData.Name != value)
				{
					this.objectData.Name = value;
					NotifyPropertyChanged("Name");
				}
			}
		}

		public virtual object Name_DBObjectValue
		{
			get
			{
				return (this.Name == null ? (object)DBNull.Value : (object)this.Name);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.Name = null;
				else
					this.Name = (System.String)value;
			}
		}

		public virtual string Status
		{
			get
			{
				return this.objectData.Status;
			}
			set
			{
				if (this.objectData.Status != value)
				{
					this.objectData.Status = value;
					NotifyPropertyChanged("Status");
				}
			}
		}

		public virtual object Status_DBObjectValue
		{
			get
			{
				return (this.Status == null ? (object)DBNull.Value : (object)this.Status);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.Status = null;
				else
					this.Status = (System.String)value;
			}
		}

		public IndependentEntity1Identifier? ParentOwnerIndependentEntity1EntityObjectId
		{
			get
			{
				if (this.parentOwnerIndependentEntity1_DependentEntity1List == null)
					return this.objectData.ParentOwnerIndependentEntity1EntityObjectId;
				else
					return ((IndependentEntity1)this.parentOwnerIndependentEntity1_DependentEntity1List.Parent).ObjectId;
			}
			set
			{
				if (this.parentOwnerIndependentEntity1_DependentEntity1List == null)
				{
					bool valueChanged = false;
					if (this.parentOwnerIndependentEntity1_DependentEntity1ListPartialLoadAttempted)
						// Implies objectData.ParentOwnerIndependentEntity1EntityObjectId points to non-existent object in the repository.
						UnloadParentOwnerIndependentEntity1_DependentEntity1List();
					// At this point parentOwnerIndependentEntity1_DependentEntity1List is UNLOADED.
					if (this.objectData.ParentOwnerIndependentEntity1EntityObjectId != value)
					{
						this.objectData.ParentOwnerIndependentEntity1EntityObjectId = value;
						valueChanged = true;
					}
					if (valueChanged)
						NotifyPropertyChanged("ParentOwnerIndependentEntity1EntityObjectId");
				}
				else
				{
					// At this point parentOwnerIndependentEntity1_DependentEntity1List is LOADED.
					if (((IndependentEntity1)this.parentOwnerIndependentEntity1_DependentEntity1List.Parent).ObjectId != value)
					{
						// The supplied foreign object id does not match the currently linked entity object.
						// parentOwnerIndependentEntity1_DependentEntity1List must therefore be unloaded.
						UnloadParentOwnerIndependentEntity1_DependentEntity1List();
						this.objectData.ParentOwnerIndependentEntity1EntityObjectId = value;
						// NotifyPropertyChanged notification is required because ParentOwnerIndependentEntity1EntityObjectId will return a different value.
						NotifyPropertyChanged("ParentOwnerIndependentEntity1EntityObjectId");
					}
					else
					{
						// Set objectData.ParentOwnerIndependentEntity1EntityObjectId to new value in case parentOwnerIndependentEntity1_DependentEntity1List is unloaded.
						this.objectData.ParentOwnerIndependentEntity1EntityObjectId = value;
						// There is no need for a NotifyPropertyChanged notification because ParentOwnerIndependentEntity1EntityObjectId will not return a different value.
					}
				}
			}
		}

		public virtual object ParentOwnerIndependentEntity1EntityObjectId_DBObjectValue
		{
			get
			{
				return (this.ParentOwnerIndependentEntity1EntityObjectId.HasValue ? (object)this.ParentOwnerIndependentEntity1EntityObjectId.Value : (object)DBNull.Value);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.ParentOwnerIndependentEntity1EntityObjectId = null;
				else
					this.ParentOwnerIndependentEntity1EntityObjectId = (IndependentEntity1Identifier)value;
			}
		}

		public virtual int? IndependentEntity1Id
		{
			get
			{
				IndependentEntity1Identifier? identifier = this.ParentOwnerIndependentEntity1EntityObjectId;
				return (identifier.HasValue ? (int?)identifier.Value.IndependentEntity1Id : (int?)null);
			}
		}

		public virtual object IndependentEntity1Id_DBObjectValue
		{
			get
			{
				IndependentEntity1Identifier? identifier = this.ParentOwnerIndependentEntity1EntityObjectId;
				return (identifier.HasValue ? (object)identifier.Value.IndependentEntity1Id : (object)DBNull.Value);
			}
		}

		// Will not work if all on-demand-load BLOB properties are not loaded.
		public override bool SameAs(IEntityObject obj)
		{
			DependentEntity1 dependentEntity1 = (DependentEntity1)obj;
			return (base.SameAs(obj) && dependentEntity1.ObjectId == this.objectData.ObjectId && this.objectData.ParentOwnerIndependentEntity1EntityObjectId == null && this.objectData.AttrBool1 == dependentEntity1.objectData.AttrBool1 && this.objectData.AttrDatetime1 == dependentEntity1.objectData.AttrDatetime1 && this.objectData.AttrInteger1 == dependentEntity1.objectData.AttrInteger1 && this.objectData.AttrString1 == dependentEntity1.objectData.AttrString1 && this.objectData.AttrString2 == dependentEntity1.objectData.AttrString2 && this.objectData.Name == dependentEntity1.objectData.Name && this.objectData.Status == dependentEntity1.objectData.Status);
		}

		public bool SameAs(IDependentEntity1 obj)
		{
			return SameAs((IEntityObject)obj);
		}

		#region IEditableObject Related

		protected override void BackupObjectData()
		{
			base.BackupObjectData();
			this.objectDataBackup = this.objectData;
		}

		protected override void RestoreObjectData()
		{
			base.RestoreObjectData();
			this.objectData = this.objectDataBackup;
		}

		#endregion

		public override void PopulateFrom(IEntityObject source)
		{
			this.objectDataToCopy = ((DependentEntity1)source).objectData;
			base.PopulateFrom(source);
		}

		protected override void CopySourceObjectDataToActive()
		{
			base.CopySourceObjectDataToActive();
			this.objectData = this.objectDataToCopy;
		}

		protected override void CompareObjectData(ObjectDataSet objectDataSet)
		{
			base.CompareObjectData(objectDataSet);

			ObjectData objectDataToCompare;
			if (objectDataSet == ObjectDataSet.Active)
			{
				this.objectDataChanges.ObjectIdPropertyChanged = false;
				this.objectDataChanges.ParentOwnerIndependentEntity1EntityObjectIdPropertyChanged = false;
				this.objectDataChanges.AttrBool1PropertyChanged = false;
				this.objectDataChanges.AttrDatetime1PropertyChanged = false;
				this.objectDataChanges.AttrInteger1PropertyChanged = false;
				this.objectDataChanges.AttrString1PropertyChanged = false;
				this.objectDataChanges.AttrString2PropertyChanged = false;
				this.objectDataChanges.NamePropertyChanged = false;
				this.objectDataChanges.StatusPropertyChanged = false;
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
				this.objectDataChanges.ObjectIdPropertyChanged = (objectDataToCompare.ObjectId != objectData.ObjectId);
				this.objectDataChanges.ParentOwnerIndependentEntity1EntityObjectIdPropertyChanged = (objectDataToCompare.ParentOwnerIndependentEntity1EntityObjectId != objectData.ParentOwnerIndependentEntity1EntityObjectId);
				this.objectDataChanges.AttrBool1PropertyChanged = (objectDataToCompare.AttrBool1 != objectData.AttrBool1);
				this.objectDataChanges.AttrDatetime1PropertyChanged = (objectDataToCompare.AttrDatetime1 != objectData.AttrDatetime1);
				this.objectDataChanges.AttrInteger1PropertyChanged = (objectDataToCompare.AttrInteger1 != objectData.AttrInteger1);
				this.objectDataChanges.AttrString1PropertyChanged = (objectDataToCompare.AttrString1 != objectData.AttrString1);
				this.objectDataChanges.AttrString2PropertyChanged = (objectDataToCompare.AttrString2 != objectData.AttrString2);
				this.objectDataChanges.NamePropertyChanged = (objectDataToCompare.Name != objectData.Name);
				this.objectDataChanges.StatusPropertyChanged = (objectDataToCompare.Status != objectData.Status);
			}
		}

		protected override void SendPropertyChangeNotifications()
		{
			base.SendPropertyChangeNotifications();
			if (this.objectDataChanges.ObjectIdPropertyChanged) OnPropertyChanged("ObjectId");
			if (this.objectDataChanges.ParentOwnerIndependentEntity1EntityObjectIdPropertyChanged) OnPropertyChanged("ParentOwnerIndependentEntity1EntityObjectId");
			if (this.objectDataChanges.AttrBool1PropertyChanged) OnPropertyChanged("AttrBool1");
			if (this.objectDataChanges.AttrDatetime1PropertyChanged) OnPropertyChanged("AttrDatetime1");
			if (this.objectDataChanges.AttrInteger1PropertyChanged) OnPropertyChanged("AttrInteger1");
			if (this.objectDataChanges.AttrString1PropertyChanged) OnPropertyChanged("AttrString1");
			if (this.objectDataChanges.AttrString2PropertyChanged) OnPropertyChanged("AttrString2");
			if (this.objectDataChanges.NamePropertyChanged) OnPropertyChanged("Name");
			if (this.objectDataChanges.StatusPropertyChanged) OnPropertyChanged("Status");
		}

		#region INotifyPropertyChanged Related

		protected override void NotifyPropertyChanged(string propertyName)
		{
			base.NotifyPropertyChanged(propertyName);
			if (propertyName == "Name")
				base.NotifyPropertyChanged("ObjectPrimaryDescriptor");
		}

		#endregion

		// ========================================================================================================================

		#region Inbound Relationships

		#region Owned Inbound Relationships

		#region Attachment1 Relationship

		public LoadStatus ChildOwnedAttachment1ListLoadStatus
		{
			get
			{
				return this.childOwnedAttachment1ListLoadStatus;
			}
		}

		public Attachment1List ChildOwnedAttachment1List
		{
			get
			{
				// If the collection has not been populated, automatically load it.
				// This enables UIs to display without having to issue explicit commands to load related entity objects.
				if (this.childOwnedAttachment1ListLoadStatus == LoadStatus.NotLoaded)
					LoadChildOwnedAttachment1List();
				return this.childOwnedAttachment1List;
			}
		}

		IAttachment1List IDependentEntity1.ChildOwnedAttachment1List
		{
			get
			{
				return (IAttachment1List)this.ChildOwnedAttachment1List;
			}
		}

		// Load a single entity object into the collection.
		public Attachment1List LoadChildOwnedAttachment1List(Attachment1 attachment1)
		{
			// Make sure the collection object has been created.
			if (this.childOwnedAttachment1ListLoadStatus == LoadStatus.NotLoaded)
			{
				SetupChildOwnedAttachment1List(null); // Null instructs SetupChildOwnedAttachment1List to create a new collection object.
				if (this.ObjectId.HasValue)
					// The object exists in the repository. It is possible that more associated entity objects also exist in the repository.
					this.childOwnedAttachment1ListLoadStatus = LoadStatus.Partial;
				else
					// The object has not yet been saved and therefore cannot have associated entity objects in the repository.
					this.childOwnedAttachment1ListLoadStatus = LoadStatus.Full;
			}

			if (attachment1 != null)
			{
				// Append given entity object to the collection if it isn't already a member.
				// List.Contains call is important because this method may be called to load an unsaved entity object.
				// Since unsaved entity objects have no object id assigned, the only way to determine if they already exist in a collection or not is to call List.Contains.
				if (!this.childOwnedAttachment1List.Contains(attachment1))
				{
					bool alreadyInList = false;
					foreach (Attachment1 childOwnedAttachment1 in this.childOwnedAttachment1List)
					{
						if ((childOwnedAttachment1.ObjectId != null) && (childOwnedAttachment1.ObjectId == attachment1.ObjectId))
						{
							alreadyInList = true;
							break;
						}
					}
					if (!alreadyInList) this.childOwnedAttachment1List.Add(attachment1); // Add method automatically sets object's parentList pointer to itself.
				}
			}

			return this.childOwnedAttachment1List;
		}

		IAttachment1List IDependentEntity1.LoadChildOwnedAttachment1List(IAttachment1 attachment1)
		{
			return (IAttachment1List)this.LoadChildOwnedAttachment1List((Attachment1)attachment1);
		}

		// Load collection from repository.
		public Attachment1List LoadChildOwnedAttachment1List()
		{
			LoadStatus loadStatus = this.childOwnedAttachment1ListLoadStatus;
			if (loadStatus == LoadStatus.Partial)
			{
				// The collection object has already been created, complete with ListChanged event handler.
				// It contains zero or more associated Attachment1 entity objects.
				// All that needs to be done here is to add any remaining associated Attachment1 objects that exist in the repository.
				// If this object has not yet been saved, the implication is that there can exist no associated entity objects in the repository.
				if (this.ObjectId != null)
				{
					// Get the associated entity objects from the repository.
					Attachment1List list = (Attachment1List)CustName.AppName.BL.Global.ClassFactory.GetDALRepository().FindAttachment1(-1, new SearchCondition().AppendSearchCondition(Attachment1PropertyName.ParentOwnerDependentEntity1EntityObjectId, SearchConditionExpressionOperator.Equal, this.ObjectId), CustName.AppName.BL.Global.ClassFactory.GetDALRepository().DependentEntity1_ChildOwnedAttachment1SortSpecification, ((IEntityObjectContextItem)this).Context);

					// Append the entity objects just loaded from the repository to the collection, except those already in the collection to begin with.
					int preExistingItemCount = this.childOwnedAttachment1List.Count;
					bool alreadyInList;
					Attachment1Identifier? preExistingObjectId;
					foreach (Attachment1 entityObject in list)
					{
						// Search only the preexisting items in the collection for a match.
						// If no match found, the current entity object can be added to the collection without risk of it being a duplicate.
						alreadyInList = false;
						for (int index = 0; index < preExistingItemCount; ++index)
						{
							// Bypass entity objects that have not been saved.
							// They cannot possibly match an entity from the repository.
							// List.Contains does not need to be used here because the Repository.FindAttachment1 call returns new objects that are guaranteed to have ObjectId set.
							if ((preExistingObjectId = this.childOwnedAttachment1List[index].ObjectId) != null)
								if (alreadyInList = (preExistingObjectId == entityObject.ObjectId))
									break;
						}
						if (!alreadyInList) this.childOwnedAttachment1List.Add(entityObject);
					}
				}
			}
			else if (loadStatus == LoadStatus.NotLoaded)
			{
				// The collection object has not yet been created.
				// Create it and populate it with all the associated Attachment1 entity objects in the repository.
				if (this.ObjectId.HasValue)
				{
					Attachment1List list = (Attachment1List)CustName.AppName.BL.Global.ClassFactory.GetDALRepository().FindAttachment1(-1, new SearchCondition().AppendSearchCondition(Attachment1PropertyName.ParentOwnerDependentEntity1EntityObjectId, SearchConditionExpressionOperator.Equal, this.ObjectId), CustName.AppName.BL.Global.ClassFactory.GetDALRepository().DependentEntity1_ChildOwnedAttachment1SortSpecification, ((IEntityObjectContextItem)this).Context);
					SetupChildOwnedAttachment1List(list);
				}
				else
				{
					// This object has not been saved yet.
					// Therefore, it cannot have any associated entity objects related to it in the repository.
					// Create an empty collection instead.
					SetupChildOwnedAttachment1List(null); // Null instructs SetupChildOwnedAttachment1List to create a new collection object.
				}
			}
			this.childOwnedAttachment1ListLoadStatus = LoadStatus.Full;
			return this.childOwnedAttachment1List;
		}

		IAttachment1List IDependentEntity1.LoadChildOwnedAttachment1List()
		{
			return (IAttachment1List)LoadChildOwnedAttachment1List();
		}

		private void SetupChildOwnedAttachment1List(Attachment1List list)
		{
			// If no collection object specified, create an empty collection.
			Attachment1List _list;
			if ((_list = list) == null) _list = (Attachment1List)CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(CustName.AppName.DAL.EntityClass.Attachment1);

			// Register a ListChanged event handler with the collection.
			// Because the collection holds owned entity objects, the parent needs to be aware of any changes made to them in order to correctly set its own commit status.
			// Changes in an owned entity object imply parent entity object is changed.
			this.childOwnedAttachment1ListChangedEventHandler = new System.ComponentModel.ListChangedEventHandler(ChildOwnedAttachment1List_ListChanged);
			_list.ListChanged += this.childOwnedAttachment1ListChangedEventHandler;

			// Link the collection into the object hierarchy.
			_list.Parent = (IEntityObject)this;
			_list.CollectionName = CollectionName.DependentEntity1_ChildOwnedAttachment1List;
			this.childOwnedAttachment1List = _list;
		}

		public void UnloadChildOwnedAttachment1List()
		{
			if (this.childOwnedAttachment1List != null)
			{
				if (this.childOwnedAttachment1ListChangedEventHandler != null)
					this.childOwnedAttachment1List.ListChanged -= this.childOwnedAttachment1ListChangedEventHandler;
				this.childOwnedAttachment1List.Parent = null;
			}
			this.childOwnedAttachment1List = null;
			this.childOwnedAttachment1ListLoadStatus = LoadStatus.NotLoaded;
		}

		void IDependentEntity1.UnloadChildOwnedAttachment1List()
		{
			UnloadChildOwnedAttachment1List();
		}

		public bool HasChildOwnedAttachment1Objects(bool inMemoryOnly)
		{
			if (this.childOwnedAttachment1List == null)
				return false;
			else
				return (this.childOwnedAttachment1List.Count > 0);
		}

		protected virtual void ChildOwnedAttachment1List_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		{
			this.HasUncommittedChanges = true;
		}

		#endregion Attachment1 Relationship

		#region DependentEntity2 Relationship

		public LoadStatus ChildOwnedDependentEntity2ListLoadStatus
		{
			get
			{
				return this.childOwnedDependentEntity2ListLoadStatus;
			}
		}

		public DependentEntity2List ChildOwnedDependentEntity2List
		{
			get
			{
				// If the collection has not been populated, automatically load it.
				// This enables UIs to display without having to issue explicit commands to load related entity objects.
				if (this.childOwnedDependentEntity2ListLoadStatus == LoadStatus.NotLoaded)
					LoadChildOwnedDependentEntity2List();
				return this.childOwnedDependentEntity2List;
			}
		}

		IDependentEntity2List IDependentEntity1.ChildOwnedDependentEntity2List
		{
			get
			{
				return (IDependentEntity2List)this.ChildOwnedDependentEntity2List;
			}
		}

		// Load a single entity object into the collection.
		public DependentEntity2List LoadChildOwnedDependentEntity2List(DependentEntity2 dependentEntity2)
		{
			// Make sure the collection object has been created.
			if (this.childOwnedDependentEntity2ListLoadStatus == LoadStatus.NotLoaded)
			{
				SetupChildOwnedDependentEntity2List(null); // Null instructs SetupChildOwnedDependentEntity2List to create a new collection object.
				if (this.ObjectId.HasValue)
					// The object exists in the repository. It is possible that more associated entity objects also exist in the repository.
					this.childOwnedDependentEntity2ListLoadStatus = LoadStatus.Partial;
				else
					// The object has not yet been saved and therefore cannot have associated entity objects in the repository.
					this.childOwnedDependentEntity2ListLoadStatus = LoadStatus.Full;
			}

			if (dependentEntity2 != null)
			{
				// Append given entity object to the collection if it isn't already a member.
				// List.Contains call is important because this method may be called to load an unsaved entity object.
				// Since unsaved entity objects have no object id assigned, the only way to determine if they already exist in a collection or not is to call List.Contains.
				if (!this.childOwnedDependentEntity2List.Contains(dependentEntity2))
				{
					bool alreadyInList = false;
					foreach (DependentEntity2 childOwnedDependentEntity2 in this.childOwnedDependentEntity2List)
					{
						if ((childOwnedDependentEntity2.ObjectId != null) && (childOwnedDependentEntity2.ObjectId == dependentEntity2.ObjectId))
						{
							alreadyInList = true;
							break;
						}
					}
					if (!alreadyInList) this.childOwnedDependentEntity2List.Add(dependentEntity2); // Add method automatically sets object's parentList pointer to itself.
				}
			}

			return this.childOwnedDependentEntity2List;
		}

		IDependentEntity2List IDependentEntity1.LoadChildOwnedDependentEntity2List(IDependentEntity2 dependentEntity2)
		{
			return (IDependentEntity2List)this.LoadChildOwnedDependentEntity2List((DependentEntity2)dependentEntity2);
		}

		// Load collection from repository.
		public DependentEntity2List LoadChildOwnedDependentEntity2List()
		{
			LoadStatus loadStatus = this.childOwnedDependentEntity2ListLoadStatus;
			if (loadStatus == LoadStatus.Partial)
			{
				// The collection object has already been created, complete with ListChanged event handler.
				// It contains zero or more associated DependentEntity2 entity objects.
				// All that needs to be done here is to add any remaining associated DependentEntity2 objects that exist in the repository.
				// If this object has not yet been saved, the implication is that there can exist no associated entity objects in the repository.
				if (this.ObjectId != null)
				{
					// Get the associated entity objects from the repository.
					DependentEntity2List list = (DependentEntity2List)CustName.AppName.BL.Global.ClassFactory.GetDALRepository().FindDependentEntity2(-1, new SearchCondition().AppendSearchCondition(DependentEntity2PropertyName.ParentOwnerDependentEntity1EntityObjectId, SearchConditionExpressionOperator.Equal, this.ObjectId), CustName.AppName.BL.Global.ClassFactory.GetDALRepository().DependentEntity1_ChildOwnedDependentEntity2SortSpecification, ((IEntityObjectContextItem)this).Context);

					// Append the entity objects just loaded from the repository to the collection, except those already in the collection to begin with.
					int preExistingItemCount = this.childOwnedDependentEntity2List.Count;
					bool alreadyInList;
					DependentEntity2Identifier? preExistingObjectId;
					foreach (DependentEntity2 entityObject in list)
					{
						// Search only the preexisting items in the collection for a match.
						// If no match found, the current entity object can be added to the collection without risk of it being a duplicate.
						alreadyInList = false;
						for (int index = 0; index < preExistingItemCount; ++index)
						{
							// Bypass entity objects that have not been saved.
							// They cannot possibly match an entity from the repository.
							// List.Contains does not need to be used here because the Repository.FindDependentEntity2 call returns new objects that are guaranteed to have ObjectId set.
							if ((preExistingObjectId = this.childOwnedDependentEntity2List[index].ObjectId) != null)
								if (alreadyInList = (preExistingObjectId == entityObject.ObjectId))
									break;
						}
						if (!alreadyInList) this.childOwnedDependentEntity2List.Add(entityObject);
					}
				}
			}
			else if (loadStatus == LoadStatus.NotLoaded)
			{
				// The collection object has not yet been created.
				// Create it and populate it with all the associated DependentEntity2 entity objects in the repository.
				if (this.ObjectId.HasValue)
				{
					DependentEntity2List list = (DependentEntity2List)CustName.AppName.BL.Global.ClassFactory.GetDALRepository().FindDependentEntity2(-1, new SearchCondition().AppendSearchCondition(DependentEntity2PropertyName.ParentOwnerDependentEntity1EntityObjectId, SearchConditionExpressionOperator.Equal, this.ObjectId), CustName.AppName.BL.Global.ClassFactory.GetDALRepository().DependentEntity1_ChildOwnedDependentEntity2SortSpecification, ((IEntityObjectContextItem)this).Context);
					SetupChildOwnedDependentEntity2List(list);
				}
				else
				{
					// This object has not been saved yet.
					// Therefore, it cannot have any associated entity objects related to it in the repository.
					// Create an empty collection instead.
					SetupChildOwnedDependentEntity2List(null); // Null instructs SetupChildOwnedDependentEntity2List to create a new collection object.
				}
			}
			this.childOwnedDependentEntity2ListLoadStatus = LoadStatus.Full;
			return this.childOwnedDependentEntity2List;
		}

		IDependentEntity2List IDependentEntity1.LoadChildOwnedDependentEntity2List()
		{
			return (IDependentEntity2List)LoadChildOwnedDependentEntity2List();
		}

		private void SetupChildOwnedDependentEntity2List(DependentEntity2List list)
		{
			// If no collection object specified, create an empty collection.
			DependentEntity2List _list;
			if ((_list = list) == null) _list = (DependentEntity2List)CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(CustName.AppName.DAL.EntityClass.DependentEntity2);

			// Register a ListChanged event handler with the collection.
			// Because the collection holds owned entity objects, the parent needs to be aware of any changes made to them in order to correctly set its own commit status.
			// Changes in an owned entity object imply parent entity object is changed.
			this.childOwnedDependentEntity2ListChangedEventHandler = new System.ComponentModel.ListChangedEventHandler(ChildOwnedDependentEntity2List_ListChanged);
			_list.ListChanged += this.childOwnedDependentEntity2ListChangedEventHandler;

			// Link the collection into the object hierarchy.
			_list.Parent = (IEntityObject)this;
			_list.CollectionName = CollectionName.DependentEntity1_ChildOwnedDependentEntity2List;
			this.childOwnedDependentEntity2List = _list;
		}

		public void UnloadChildOwnedDependentEntity2List()
		{
			if (this.childOwnedDependentEntity2List != null)
			{
				if (this.childOwnedDependentEntity2ListChangedEventHandler != null)
					this.childOwnedDependentEntity2List.ListChanged -= this.childOwnedDependentEntity2ListChangedEventHandler;
				this.childOwnedDependentEntity2List.Parent = null;
			}
			this.childOwnedDependentEntity2List = null;
			this.childOwnedDependentEntity2ListLoadStatus = LoadStatus.NotLoaded;
		}

		void IDependentEntity1.UnloadChildOwnedDependentEntity2List()
		{
			UnloadChildOwnedDependentEntity2List();
		}

		public bool HasChildOwnedDependentEntity2Objects(bool inMemoryOnly)
		{
			if (this.childOwnedDependentEntity2List == null)
				return false;
			else
				return (this.childOwnedDependentEntity2List.Count > 0);
		}

		protected virtual void ChildOwnedDependentEntity2List_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		{
			this.HasUncommittedChanges = true;
		}

		#endregion DependentEntity2 Relationship

		#endregion // Owned Inbound Relationships

		#region Non-Owned Inbound Relationships

		// This entity has no non-owned inbound relationships.

		#endregion // Non-Owned Inbound Relationships

		#endregion // Inbound Relationships

		// ========================================================================================================================

		#region Outbound Relationships

		#region Owner Outbound Relationships


		#region IndependentEntity1 Relationship

		public bool ParentOwnerIndependentEntity1_DependentEntity1ListPartialLoadAttempted
		{
			get
			{
				if (this.parentOwnerIndependentEntity1_DependentEntity1List == null)
					return this.parentOwnerIndependentEntity1_DependentEntity1ListPartialLoadAttempted;
				else
					return true;
			}
		}

		public DependentEntity1List ParentOwnerIndependentEntity1_DependentEntity1List
		{
			get
			{
				LoadParentOwnerIndependentEntity1_DependentEntity1List();
				return this.parentOwnerIndependentEntity1_DependentEntity1List;
			}
			internal set
			{
				this.parentOwnerIndependentEntity1_DependentEntity1List = value;
			}
		}

		IDependentEntity1List IDependentEntity1.ParentOwnerIndependentEntity1_DependentEntity1List
		{
			get
			{
				return (IDependentEntity1List)this.ParentOwnerIndependentEntity1_DependentEntity1List;
			}
		}

		public void LoadParentOwnerIndependentEntity1_DependentEntity1List()
		{
			if (!ParentOwnerIndependentEntity1_DependentEntity1ListPartialLoadAttempted)
			{
				if (this.objectData.ParentOwnerIndependentEntity1EntityObjectId == null)
				{
					ParentOwnerIndependentEntity1_DependentEntity1List = null;
				}
				else
				{
					IndependentEntity1 independentEntity1 = (IndependentEntity1)CustName.AppName.BL.Global.ClassFactory.GetDALRepository().GetIndependentEntity1(this.objectData.ParentOwnerIndependentEntity1EntityObjectId.Value, this.Context);
					if (independentEntity1 == null)
						ParentOwnerIndependentEntity1_DependentEntity1List = null;
					else
						ParentOwnerIndependentEntity1_DependentEntity1List = (DependentEntity1List)independentEntity1.LoadChildOwnedDependentEntity1List((DependentEntity1)this);
				}
				this.parentOwnerIndependentEntity1_DependentEntity1ListPartialLoadAttempted = true;
				NotifyAll_ParentOwnerIndependentEntity1EntityObject_PropertiesChanged();
			}
		}

		public void UnloadParentOwnerIndependentEntity1_DependentEntity1List()
		{
			ParentOwnerIndependentEntity1_DependentEntity1List = null;
			this.parentOwnerIndependentEntity1_DependentEntity1ListPartialLoadAttempted = false;
			NotifyAll_ParentOwnerIndependentEntity1EntityObject_PropertiesChanged();
		}

		public IndependentEntity1 ParentOwnerIndependentEntity1EntityObject
		{
			get
			{
				LoadParentOwnerIndependentEntity1_DependentEntity1List();
				if (this.parentOwnerIndependentEntity1_DependentEntity1List == null)
					// Either foreign object id == null or is invalid (i.e. points to non-existent repository object).
					return null;
				else
					return (IndependentEntity1)this.parentOwnerIndependentEntity1_DependentEntity1List.Parent;
			}
		}

		IIndependentEntity1 IDependentEntity1.ParentOwnerIndependentEntity1EntityObject
		{
			get
			{
				return (IIndependentEntity1)this.ParentOwnerIndependentEntity1EntityObject;
			}
		}

		public bool HasParentOwnerIndependentEntity1Object(bool inMemoryOnly)
		{
			if (inMemoryOnly)
			{
				if (this.parentOwnerIndependentEntity1_DependentEntity1List == null)
					return false;
				else
					return (this.parentOwnerIndependentEntity1_DependentEntity1List.Parent != null);
			}
			else
			{
				if (this.parentOwnerIndependentEntity1_DependentEntity1List == null)
				{
					if (this.parentOwnerIndependentEntity1_DependentEntity1ListPartialLoadAttempted)
						return false;
					else
						return (this.objectData.ParentOwnerIndependentEntity1EntityObjectId != null);
				}
				else
					return (this.parentOwnerIndependentEntity1_DependentEntity1List.Parent != null);
			}
		}

		#endregion IndependentEntity1 Relationship

		#endregion // Owner Outbound Relationships

		#region Non-Owner Outbound Relationships

		// This entity has no non-owner outbound relationships.

		#endregion // Non-Owner Outbound Relationships

		#endregion // Outbound Relationships

		// ========================================================================================================================

		public override void Load(bool recurse)
		{
			// Attachment1 Relationship
			if (childOwnedAttachment1ListLoadStatus != LoadStatus.Full)
			{
				LoadChildOwnedAttachment1List();
				if (recurse)
				{
					foreach (Attachment1 attachment1 in childOwnedAttachment1List)
					{
						attachment1.Load(true);
					}
				}
			}
			// DependentEntity2 Relationship
			if (childOwnedDependentEntity2ListLoadStatus != LoadStatus.Full)
			{
				LoadChildOwnedDependentEntity2List();
				if (recurse)
				{
					foreach (DependentEntity2 dependentEntity2 in childOwnedDependentEntity2List)
					{
						dependentEntity2.Load(true);
					}
				}
			}
		}

		public override IList<IEntityObject> GetOwnedObjects(bool loaded, IList<IEntityObject> list)
		{
			return null;
		}

		public DependentEntity1 Copy(bool recurse)
		{
			return CopyImpl(recurse);
		}

		IDependentEntity1 IDependentEntity1.Copy(bool recurse)
		{
			return (IDependentEntity1)CopyImpl(recurse);
		}

		protected DependentEntity1 CopyImpl(bool recurse)
		{
			DependentEntity1 newDependentEntity1 = (DependentEntity1)CustName.AppName.BL.Global.ClassFactory.GetEntityObject(CustName.AppName.DAL.EntityClass.DependentEntity1);
			newDependentEntity1.PopulateFrom(this);
			newDependentEntity1.ObjectId = null;
			if (recurse)
			{
				this.LoadChildOwnedAttachment1List();
				foreach (Attachment1 attachment1 in this.ChildOwnedAttachment1List)
				{
					newDependentEntity1.ChildOwnedAttachment1List.Add(attachment1.Copy(true));
				}
				this.LoadChildOwnedDependentEntity2List();
				foreach (DependentEntity2 dependentEntity2 in this.ChildOwnedDependentEntity2List)
				{
					newDependentEntity1.ChildOwnedDependentEntity2List.Add(dependentEntity2.Copy(true));
				}
			}
			return newDependentEntity1;
		}

		// ========================================================================================================================

		#region Outbound Relationships Properties

		#region Owner Outbound Relationships Properties

		#region IndependentEntity1 Relationship

		public virtual bool? ParentOwnerIndependentEntity1EntityObject_AttrBool1
		{
			get
			{
				IIndependentEntity1 obj = ParentOwnerIndependentEntity1EntityObject;
				if (obj == null)
					return null;
				else
					return obj.AttrBool1;
			}
		}

		public virtual DateTime? ParentOwnerIndependentEntity1EntityObject_AttrDatetime1
		{
			get
			{
				IIndependentEntity1 obj = ParentOwnerIndependentEntity1EntityObject;
				if (obj == null)
					return null;
				else
					return obj.AttrDatetime1;
			}
		}

		public virtual int? ParentOwnerIndependentEntity1EntityObject_AttrInteger1
		{
			get
			{
				IIndependentEntity1 obj = ParentOwnerIndependentEntity1EntityObject;
				if (obj == null)
					return null;
				else
					return obj.AttrInteger1;
			}
		}

		public virtual string ParentOwnerIndependentEntity1EntityObject_AttrString1
		{
			get
			{
				IIndependentEntity1 obj = ParentOwnerIndependentEntity1EntityObject;
				if (obj == null)
					return null;
				else
					return obj.AttrString1;
			}
		}

		public virtual string ParentOwnerIndependentEntity1EntityObject_AttrString2
		{
			get
			{
				IIndependentEntity1 obj = ParentOwnerIndependentEntity1EntityObject;
				if (obj == null)
					return null;
				else
					return obj.AttrString2;
			}
		}

		public virtual string ParentOwnerIndependentEntity1EntityObject_Name
		{
			get
			{
				IIndependentEntity1 obj = ParentOwnerIndependentEntity1EntityObject;
				if (obj == null)
					return null;
				else
					return obj.Name;
			}
		}

		public virtual string ParentOwnerIndependentEntity1EntityObject_Status
		{
			get
			{
				IIndependentEntity1 obj = ParentOwnerIndependentEntity1EntityObject;
				if (obj == null)
					return null;
				else
					return obj.Status;
			}
		}

		protected virtual void NotifyAll_ParentOwnerIndependentEntity1EntityObject_PropertiesChanged()
		{
			// When this object is in a list that is bound to a DataGridView control containing a ComboBox bound to the FK property (IndependentEntity1Id)
			// driving the content of the ParentOwnerIndependentEntity1EntityObject_* properties,
			// changing selections in the ComboBox results in a noticeable pause.
			// Delay is cause by something executing FindCore on the list that the ComboBox is bound to (that populates its dropdown) every time OnPropertyChanged is called.
			// Another issue is that any list containing this object raises an event to signal that it has changed, causing owner entity objects to be marked as having changes,
			// which may not be desirable becauses changes to IndependentEntity1 may not imply changes to the parent if IndependentEntity1 is not owned by the parent.
			// Workaround has been to disable OnPropertyChanged calls below and have the UI listen for changes in the FK property IndependentEntity1Id (indirectly through the
			// ListChanged event) and invalidate the DataGridView row so that repaints cells containing values dependent upon the combobox selection i.e. one of the
			// ParentOwnerIndependentEntity1EntityObject_* properties.
			//OnPropertyChanged("ParentOwnerIndependentEntity1EntityObject_AttrBool1");
			//OnPropertyChanged("ParentOwnerIndependentEntity1EntityObject_AttrDatetime1");
			//OnPropertyChanged("ParentOwnerIndependentEntity1EntityObject_AttrInteger1");
			//OnPropertyChanged("ParentOwnerIndependentEntity1EntityObject_AttrString1");
			//OnPropertyChanged("ParentOwnerIndependentEntity1EntityObject_AttrString2");
			//OnPropertyChanged("ParentOwnerIndependentEntity1EntityObject_Name");
			//OnPropertyChanged("ParentOwnerIndependentEntity1EntityObject_Status");
		}

		#endregion IndependentEntity1 Relationship Properties

		#endregion // Owner Outbound Relationships Properties

		#region Non-Owner Outbound Relationships Properties

		// This entity has no non-owner outbound relationships.

		#endregion // Non-Owner Outbound Relationships Properties

		#endregion // Outbound Relationships Properties

		// ========================================================================================================================
	}

	public abstract class BaseDependentEntity2 : EntityObject, IDependentEntity2
	{
		private struct ObjectData
		{
			// Structure for primary key fields.
			public DependentEntity2Identifier? ObjectId;
			// Structure for foreign key fields associated with the DependentEntity1 owner relationship.
			public DependentEntity1Identifier? ParentOwnerDependentEntity1EntityObjectId;
			public bool? AttrBool1;
			public DateTime? AttrDatetime1;
			public int? AttrInteger1;
			public string AttrString1;
			public string AttrString2;
			public string Name;
			public string Status;
		}

		private struct ObjectDataChanges
		{
			public bool ObjectIdPropertyChanged;
			public bool ParentOwnerDependentEntity1EntityObjectIdPropertyChanged;
			public bool AttrBool1PropertyChanged;
			public bool AttrDatetime1PropertyChanged;
			public bool AttrInteger1PropertyChanged;
			public bool AttrString1PropertyChanged;
			public bool AttrString2PropertyChanged;
			public bool NamePropertyChanged;
			public bool StatusPropertyChanged;
		}

		private ObjectData objectData;
		private ObjectData objectDataBackup;
		private ObjectData objectDataToCopy;
		private ObjectDataChanges objectDataChanges;

		#region Inbound Relationships

		// This region contains the collection variables for referencing inbound related entity objects.
		// Inbound related entities are typically dependent entities.

		#region Owned Inbound Relationships

		// RelationshipEntity1 Relationship
		private LoadStatus childOwnedRelationshipEntity1ListLoadStatus = LoadStatus.NotLoaded;
		private RelationshipEntity1List childOwnedRelationshipEntity1List = null;
		private System.ComponentModel.ListChangedEventHandler childOwnedRelationshipEntity1ListChangedEventHandler = null;

		#endregion Owned Inbound Relationships

		#region Non-Owned Inbound Relationships

		// This entity has no non-owned inbound relationships.

		#endregion Non-Owned Inbound Relationships

		#endregion Inbound Relationships

		#region Outbound Relationships

		// This region contains the collection variables for referencing outbound related entity objects.
		// Outbound related entities are typically parent entities.

		#region Owner Outbound Relationships

		// DependentEntity1 Relationship
		// References childOwnedDependentEntity2List collection of DependentEntity1.
		// Alias for EntityObject.ParentList.
		private DependentEntity2List parentOwnerDependentEntity1_DependentEntity2List;
		// Indicates if attempt has been made to get a reference to the collection.
		// If attempt fails, collection reference will remain null.
		// Flag applicable only when parentOwnerDependentEntity1_DependentEntity2List is null.
		private bool parentOwnerDependentEntity1_DependentEntity2ListPartialLoadAttempted = false;

		#endregion Owner Outbound Relationships

		#region Non-Owner Outbound Relationships

		// This entity has no non-owner outbound relationships.

		#endregion Non-Owned Outbound Relationships

		#endregion Outbound Relationships

		public BaseDependentEntity2()
			: base()
		{
			Initialize_BaseDependentEntity2();
		}

		public BaseDependentEntity2(Guid instanceId)
			: base(instanceId)
		{
			Initialize_BaseDependentEntity2();
		}

		private void Initialize_BaseDependentEntity2()
		{
			PostInitialize_BaseDependentEntity2();
		}

		protected virtual void PostInitialize_BaseDependentEntity2()
		{
		}

		public override EntityType EntityType
		{
			get
			{
				return CustName.AppName.DAL.EntityType.Dependent;
			}
		}

		public override EntityClass EntityClass
		{
			get
			{
				return CustName.AppName.DAL.EntityClass.DependentEntity2;
			}
		}

		#region IEntityObjectContextItem Interface

		public override IIdentifier ContextKey
		{
			get
			{
				return (IIdentifier)this.objectData.ObjectId.Value;
			}
		}

		#endregion

		public DependentEntity2Identifier? ObjectId
		{
			get
			{
				return this.objectData.ObjectId;
			}
			set
			{
				if (this.objectData.ObjectId != value)
				{
					this.objectData.ObjectId = value;
					NotifyPropertyChanged("ObjectId");
				}
			}
		}

		public virtual object ObjectId_DBObjectValue
		{
			get
			{
				return (this.ObjectId.HasValue ? (object)this.ObjectId.Value : (object)DBNull.Value);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.ObjectId = null;
				else
					this.ObjectId = (DependentEntity2Identifier)value;
			}
		}

		public virtual int? DependentEntity2Id
		{
			get
			{
				return (this.objectData.ObjectId.HasValue ? (int?)this.objectData.ObjectId.Value.DependentEntity2Id : (int?)null);
			}
		}

		public virtual object DependentEntity2Id_DBObjectValue
		{
			get
			{
				return (this.objectData.ObjectId.HasValue ? (object)this.objectData.ObjectId.Value.DependentEntity2Id : (object)DBNull.Value);
			}
		}

		public override string ObjectPrimaryDescriptor
		{
			get
			{
				string name = null;
				if (this.Name != null)
				{
					name = this.Name.ToString();
				}
				if (name == null)
				{
					if (this.ObjectStatus == ObjectStatus.New)
						name = "<new>";
					else
						name = "<undefined>";
				}
				else if (name.Trim() == "")
				{
					name = "<blank>";
				}
				return name;
			}
		}

		public virtual bool? AttrBool1
		{
			get
			{
				return this.objectData.AttrBool1;
			}
			set
			{
				if (this.objectData.AttrBool1 != value)
				{
					this.objectData.AttrBool1 = value;
					NotifyPropertyChanged("AttrBool1");
				}
			}
		}

		public virtual object AttrBool1_DBObjectValue
		{
			get
			{
				return (this.AttrBool1.HasValue ? (object)this.AttrBool1.Value : (object)DBNull.Value);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.AttrBool1 = null;
				else
					switch (value.ToString())
					{
						case "Checked":
							this.AttrBool1 = true;
							break;
						case "Indeterminate":
							this.AttrBool1 = null;
							break;
						case "Unchecked":
							this.AttrBool1 = false;
							break;
						case "False":
							this.AttrBool1 = false;
							break;
						case "True":
							this.AttrBool1 = true;
							break;
						default:
							this.AttrBool1 = (System.Boolean?)value;
							break;
					}
			}
		}

		public virtual bool AttrBool1_NoNull
		{
			get
			{
				return this.AttrBool1.GetValueOrDefault();
			}
			set
			{
				this.AttrBool1 = value;
			}
		}

		public virtual DateTime? AttrDatetime1
		{
			get
			{
				return this.objectData.AttrDatetime1;
			}
			set
			{
				DateTime? dateOnly;
				if (value.HasValue)
					dateOnly = value.Value.Date;
				if (this.objectData.AttrDatetime1 != value)
				{
					this.objectData.AttrDatetime1 = value;
					NotifyPropertyChanged("AttrDatetime1");
				}
			}
		}

		public virtual object AttrDatetime1_DBObjectValue
		{
			get
			{
				return (this.AttrDatetime1.HasValue ? (object)this.AttrDatetime1.Value : (object)DBNull.Value);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.AttrDatetime1 = null;
				else
					this.AttrDatetime1 = (System.DateTime?)value;
			}
		}

		public virtual DateTime AttrDatetime1_NoNull
		{
			get
			{
				return this.AttrDatetime1.GetValueOrDefault();
			}
			set
			{
				this.AttrDatetime1 = value;
			}
		}

		public virtual int? AttrInteger1
		{
			get
			{
				return this.objectData.AttrInteger1;
			}
			set
			{
				if (this.objectData.AttrInteger1 != value)
				{
					this.objectData.AttrInteger1 = value;
					NotifyPropertyChanged("AttrInteger1");
				}
			}
		}

		public virtual object AttrInteger1_DBObjectValue
		{
			get
			{
				return (this.AttrInteger1.HasValue ? (object)this.AttrInteger1.Value : (object)DBNull.Value);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.AttrInteger1 = null;
				else
					this.AttrInteger1 = (System.Int32?)value;
			}
		}

		public virtual int AttrInteger1_NoNull
		{
			get
			{
				return this.AttrInteger1.GetValueOrDefault();
			}
			set
			{
				this.AttrInteger1 = value;
			}
		}

		public virtual string AttrString1
		{
			get
			{
				return this.objectData.AttrString1;
			}
			set
			{
				if (this.objectData.AttrString1 != value)
				{
					this.objectData.AttrString1 = value;
					NotifyPropertyChanged("AttrString1");
				}
			}
		}

		public virtual object AttrString1_DBObjectValue
		{
			get
			{
				return (this.AttrString1 == null ? (object)DBNull.Value : (object)this.AttrString1);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.AttrString1 = null;
				else
					this.AttrString1 = (System.String)value;
			}
		}

		public virtual string AttrString2
		{
			get
			{
				return this.objectData.AttrString2;
			}
			set
			{
				if (this.objectData.AttrString2 != value)
				{
					this.objectData.AttrString2 = value;
					NotifyPropertyChanged("AttrString2");
				}
			}
		}

		public virtual object AttrString2_DBObjectValue
		{
			get
			{
				return (this.AttrString2 == null ? (object)DBNull.Value : (object)this.AttrString2);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.AttrString2 = null;
				else
					this.AttrString2 = (System.String)value;
			}
		}

		public virtual string Name
		{
			get
			{
				return this.objectData.Name;
			}
			set
			{
				if (this.objectData.Name != value)
				{
					this.objectData.Name = value;
					NotifyPropertyChanged("Name");
				}
			}
		}

		public virtual object Name_DBObjectValue
		{
			get
			{
				return (this.Name == null ? (object)DBNull.Value : (object)this.Name);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.Name = null;
				else
					this.Name = (System.String)value;
			}
		}

		public virtual string Status
		{
			get
			{
				return this.objectData.Status;
			}
			set
			{
				if (this.objectData.Status != value)
				{
					this.objectData.Status = value;
					NotifyPropertyChanged("Status");
				}
			}
		}

		public virtual object Status_DBObjectValue
		{
			get
			{
				return (this.Status == null ? (object)DBNull.Value : (object)this.Status);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.Status = null;
				else
					this.Status = (System.String)value;
			}
		}

		public DependentEntity1Identifier? ParentOwnerDependentEntity1EntityObjectId
		{
			get
			{
				if (this.parentOwnerDependentEntity1_DependentEntity2List == null)
					return this.objectData.ParentOwnerDependentEntity1EntityObjectId;
				else
					return ((DependentEntity1)this.parentOwnerDependentEntity1_DependentEntity2List.Parent).ObjectId;
			}
			set
			{
				if (this.parentOwnerDependentEntity1_DependentEntity2List == null)
				{
					bool valueChanged = false;
					if (this.parentOwnerDependentEntity1_DependentEntity2ListPartialLoadAttempted)
						// Implies objectData.ParentOwnerDependentEntity1EntityObjectId points to non-existent object in the repository.
						UnloadParentOwnerDependentEntity1_DependentEntity2List();
					// At this point parentOwnerDependentEntity1_DependentEntity2List is UNLOADED.
					if (this.objectData.ParentOwnerDependentEntity1EntityObjectId != value)
					{
						this.objectData.ParentOwnerDependentEntity1EntityObjectId = value;
						valueChanged = true;
					}
					if (valueChanged)
						NotifyPropertyChanged("ParentOwnerDependentEntity1EntityObjectId");
				}
				else
				{
					// At this point parentOwnerDependentEntity1_DependentEntity2List is LOADED.
					if (((DependentEntity1)this.parentOwnerDependentEntity1_DependentEntity2List.Parent).ObjectId != value)
					{
						// The supplied foreign object id does not match the currently linked entity object.
						// parentOwnerDependentEntity1_DependentEntity2List must therefore be unloaded.
						UnloadParentOwnerDependentEntity1_DependentEntity2List();
						this.objectData.ParentOwnerDependentEntity1EntityObjectId = value;
						// NotifyPropertyChanged notification is required because ParentOwnerDependentEntity1EntityObjectId will return a different value.
						NotifyPropertyChanged("ParentOwnerDependentEntity1EntityObjectId");
					}
					else
					{
						// Set objectData.ParentOwnerDependentEntity1EntityObjectId to new value in case parentOwnerDependentEntity1_DependentEntity2List is unloaded.
						this.objectData.ParentOwnerDependentEntity1EntityObjectId = value;
						// There is no need for a NotifyPropertyChanged notification because ParentOwnerDependentEntity1EntityObjectId will not return a different value.
					}
				}
			}
		}

		public virtual object ParentOwnerDependentEntity1EntityObjectId_DBObjectValue
		{
			get
			{
				return (this.ParentOwnerDependentEntity1EntityObjectId.HasValue ? (object)this.ParentOwnerDependentEntity1EntityObjectId.Value : (object)DBNull.Value);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.ParentOwnerDependentEntity1EntityObjectId = null;
				else
					this.ParentOwnerDependentEntity1EntityObjectId = (DependentEntity1Identifier)value;
			}
		}

		public virtual int? DependentEntity1Id
		{
			get
			{
				DependentEntity1Identifier? identifier = this.ParentOwnerDependentEntity1EntityObjectId;
				return (identifier.HasValue ? (int?)identifier.Value.DependentEntity1Id : (int?)null);
			}
		}

		public virtual object DependentEntity1Id_DBObjectValue
		{
			get
			{
				DependentEntity1Identifier? identifier = this.ParentOwnerDependentEntity1EntityObjectId;
				return (identifier.HasValue ? (object)identifier.Value.DependentEntity1Id : (object)DBNull.Value);
			}
		}

		// Will not work if all on-demand-load BLOB properties are not loaded.
		public override bool SameAs(IEntityObject obj)
		{
			DependentEntity2 dependentEntity2 = (DependentEntity2)obj;
			return (base.SameAs(obj) && dependentEntity2.ObjectId == this.objectData.ObjectId && this.objectData.ParentOwnerDependentEntity1EntityObjectId == null && this.objectData.AttrBool1 == dependentEntity2.objectData.AttrBool1 && this.objectData.AttrDatetime1 == dependentEntity2.objectData.AttrDatetime1 && this.objectData.AttrInteger1 == dependentEntity2.objectData.AttrInteger1 && this.objectData.AttrString1 == dependentEntity2.objectData.AttrString1 && this.objectData.AttrString2 == dependentEntity2.objectData.AttrString2 && this.objectData.Name == dependentEntity2.objectData.Name && this.objectData.Status == dependentEntity2.objectData.Status);
		}

		public bool SameAs(IDependentEntity2 obj)
		{
			return SameAs((IEntityObject)obj);
		}

		#region IEditableObject Related

		protected override void BackupObjectData()
		{
			base.BackupObjectData();
			this.objectDataBackup = this.objectData;
		}

		protected override void RestoreObjectData()
		{
			base.RestoreObjectData();
			this.objectData = this.objectDataBackup;
		}

		#endregion

		public override void PopulateFrom(IEntityObject source)
		{
			this.objectDataToCopy = ((DependentEntity2)source).objectData;
			base.PopulateFrom(source);
		}

		protected override void CopySourceObjectDataToActive()
		{
			base.CopySourceObjectDataToActive();
			this.objectData = this.objectDataToCopy;
		}

		protected override void CompareObjectData(ObjectDataSet objectDataSet)
		{
			base.CompareObjectData(objectDataSet);

			ObjectData objectDataToCompare;
			if (objectDataSet == ObjectDataSet.Active)
			{
				this.objectDataChanges.ObjectIdPropertyChanged = false;
				this.objectDataChanges.ParentOwnerDependentEntity1EntityObjectIdPropertyChanged = false;
				this.objectDataChanges.AttrBool1PropertyChanged = false;
				this.objectDataChanges.AttrDatetime1PropertyChanged = false;
				this.objectDataChanges.AttrInteger1PropertyChanged = false;
				this.objectDataChanges.AttrString1PropertyChanged = false;
				this.objectDataChanges.AttrString2PropertyChanged = false;
				this.objectDataChanges.NamePropertyChanged = false;
				this.objectDataChanges.StatusPropertyChanged = false;
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
				this.objectDataChanges.ObjectIdPropertyChanged = (objectDataToCompare.ObjectId != objectData.ObjectId);
				this.objectDataChanges.ParentOwnerDependentEntity1EntityObjectIdPropertyChanged = (objectDataToCompare.ParentOwnerDependentEntity1EntityObjectId != objectData.ParentOwnerDependentEntity1EntityObjectId);
				this.objectDataChanges.AttrBool1PropertyChanged = (objectDataToCompare.AttrBool1 != objectData.AttrBool1);
				this.objectDataChanges.AttrDatetime1PropertyChanged = (objectDataToCompare.AttrDatetime1 != objectData.AttrDatetime1);
				this.objectDataChanges.AttrInteger1PropertyChanged = (objectDataToCompare.AttrInteger1 != objectData.AttrInteger1);
				this.objectDataChanges.AttrString1PropertyChanged = (objectDataToCompare.AttrString1 != objectData.AttrString1);
				this.objectDataChanges.AttrString2PropertyChanged = (objectDataToCompare.AttrString2 != objectData.AttrString2);
				this.objectDataChanges.NamePropertyChanged = (objectDataToCompare.Name != objectData.Name);
				this.objectDataChanges.StatusPropertyChanged = (objectDataToCompare.Status != objectData.Status);
			}
		}

		protected override void SendPropertyChangeNotifications()
		{
			base.SendPropertyChangeNotifications();
			if (this.objectDataChanges.ObjectIdPropertyChanged) OnPropertyChanged("ObjectId");
			if (this.objectDataChanges.ParentOwnerDependentEntity1EntityObjectIdPropertyChanged) OnPropertyChanged("ParentOwnerDependentEntity1EntityObjectId");
			if (this.objectDataChanges.AttrBool1PropertyChanged) OnPropertyChanged("AttrBool1");
			if (this.objectDataChanges.AttrDatetime1PropertyChanged) OnPropertyChanged("AttrDatetime1");
			if (this.objectDataChanges.AttrInteger1PropertyChanged) OnPropertyChanged("AttrInteger1");
			if (this.objectDataChanges.AttrString1PropertyChanged) OnPropertyChanged("AttrString1");
			if (this.objectDataChanges.AttrString2PropertyChanged) OnPropertyChanged("AttrString2");
			if (this.objectDataChanges.NamePropertyChanged) OnPropertyChanged("Name");
			if (this.objectDataChanges.StatusPropertyChanged) OnPropertyChanged("Status");
		}

		#region INotifyPropertyChanged Related

		protected override void NotifyPropertyChanged(string propertyName)
		{
			base.NotifyPropertyChanged(propertyName);
			if (propertyName == "Name")
				base.NotifyPropertyChanged("ObjectPrimaryDescriptor");
		}

		#endregion

		// ========================================================================================================================

		#region Inbound Relationships

		#region Owned Inbound Relationships

		#region RelationshipEntity1 Relationship

		public LoadStatus ChildOwnedRelationshipEntity1ListLoadStatus
		{
			get
			{
				return this.childOwnedRelationshipEntity1ListLoadStatus;
			}
		}

		public RelationshipEntity1List ChildOwnedRelationshipEntity1List
		{
			get
			{
				// If the collection has not been populated, automatically load it.
				// This enables UIs to display without having to issue explicit commands to load related entity objects.
				if (this.childOwnedRelationshipEntity1ListLoadStatus == LoadStatus.NotLoaded)
					LoadChildOwnedRelationshipEntity1List();
				return this.childOwnedRelationshipEntity1List;
			}
		}

		IRelationshipEntity1List IDependentEntity2.ChildOwnedRelationshipEntity1List
		{
			get
			{
				return (IRelationshipEntity1List)this.ChildOwnedRelationshipEntity1List;
			}
		}

		// Load a single entity object into the collection.
		public RelationshipEntity1List LoadChildOwnedRelationshipEntity1List(RelationshipEntity1 relationshipEntity1)
		{
			// Make sure the collection object has been created.
			if (this.childOwnedRelationshipEntity1ListLoadStatus == LoadStatus.NotLoaded)
			{
				SetupChildOwnedRelationshipEntity1List(null); // Null instructs SetupChildOwnedRelationshipEntity1List to create a new collection object.
				if (this.ObjectId.HasValue)
					// The object exists in the repository. It is possible that more associated entity objects also exist in the repository.
					this.childOwnedRelationshipEntity1ListLoadStatus = LoadStatus.Partial;
				else
					// The object has not yet been saved and therefore cannot have associated entity objects in the repository.
					this.childOwnedRelationshipEntity1ListLoadStatus = LoadStatus.Full;
			}

			if (relationshipEntity1 != null)
			{
				// Append given entity object to the collection if it isn't already a member.
				// List.Contains call is important because this method may be called to load an unsaved entity object.
				// Since unsaved entity objects have no object id assigned, the only way to determine if they already exist in a collection or not is to call List.Contains.
				if (!this.childOwnedRelationshipEntity1List.Contains(relationshipEntity1))
				{
					bool alreadyInList = false;
					foreach (RelationshipEntity1 childOwnedRelationshipEntity1 in this.childOwnedRelationshipEntity1List)
					{
						if ((childOwnedRelationshipEntity1.ObjectId != null) && (childOwnedRelationshipEntity1.ObjectId == relationshipEntity1.ObjectId))
						{
							alreadyInList = true;
							break;
						}
					}
					if (!alreadyInList) this.childOwnedRelationshipEntity1List.Add(relationshipEntity1); // Add method automatically sets object's parentList pointer to itself.
				}
			}

			return this.childOwnedRelationshipEntity1List;
		}

		IRelationshipEntity1List IDependentEntity2.LoadChildOwnedRelationshipEntity1List(IRelationshipEntity1 relationshipEntity1)
		{
			return (IRelationshipEntity1List)this.LoadChildOwnedRelationshipEntity1List((RelationshipEntity1)relationshipEntity1);
		}

		// Load collection from repository.
		public RelationshipEntity1List LoadChildOwnedRelationshipEntity1List()
		{
			LoadStatus loadStatus = this.childOwnedRelationshipEntity1ListLoadStatus;
			if (loadStatus == LoadStatus.Partial)
			{
				// The collection object has already been created, complete with ListChanged event handler.
				// It contains zero or more associated RelationshipEntity1 entity objects.
				// All that needs to be done here is to add any remaining associated RelationshipEntity1 objects that exist in the repository.
				// If this object has not yet been saved, the implication is that there can exist no associated entity objects in the repository.
				if (this.ObjectId != null)
				{
					// Get the associated entity objects from the repository.
					RelationshipEntity1List list = (RelationshipEntity1List)CustName.AppName.BL.Global.ClassFactory.GetDALRepository().FindRelationshipEntity1(-1, new SearchCondition().AppendSearchCondition(RelationshipEntity1PropertyName.ParentOwnerDependentEntity2EntityObjectId, SearchConditionExpressionOperator.Equal, this.ObjectId), CustName.AppName.BL.Global.ClassFactory.GetDALRepository().DependentEntity2_ChildOwnedRelationshipEntity1SortSpecification, ((IEntityObjectContextItem)this).Context);

					// Append the entity objects just loaded from the repository to the collection, except those already in the collection to begin with.
					int preExistingItemCount = this.childOwnedRelationshipEntity1List.Count;
					bool alreadyInList;
					RelationshipEntity1Identifier? preExistingObjectId;
					foreach (RelationshipEntity1 entityObject in list)
					{
						// Search only the preexisting items in the collection for a match.
						// If no match found, the current entity object can be added to the collection without risk of it being a duplicate.
						alreadyInList = false;
						for (int index = 0; index < preExistingItemCount; ++index)
						{
							// Bypass entity objects that have not been saved.
							// They cannot possibly match an entity from the repository.
							// List.Contains does not need to be used here because the Repository.FindRelationshipEntity1 call returns new objects that are guaranteed to have ObjectId set.
							if ((preExistingObjectId = this.childOwnedRelationshipEntity1List[index].ObjectId) != null)
								if (alreadyInList = (preExistingObjectId == entityObject.ObjectId))
									break;
						}
						if (!alreadyInList) this.childOwnedRelationshipEntity1List.Add(entityObject);
					}
				}
			}
			else if (loadStatus == LoadStatus.NotLoaded)
			{
				// The collection object has not yet been created.
				// Create it and populate it with all the associated RelationshipEntity1 entity objects in the repository.
				if (this.ObjectId.HasValue)
				{
					RelationshipEntity1List list = (RelationshipEntity1List)CustName.AppName.BL.Global.ClassFactory.GetDALRepository().FindRelationshipEntity1(-1, new SearchCondition().AppendSearchCondition(RelationshipEntity1PropertyName.ParentOwnerDependentEntity2EntityObjectId, SearchConditionExpressionOperator.Equal, this.ObjectId), CustName.AppName.BL.Global.ClassFactory.GetDALRepository().DependentEntity2_ChildOwnedRelationshipEntity1SortSpecification, ((IEntityObjectContextItem)this).Context);
					SetupChildOwnedRelationshipEntity1List(list);
				}
				else
				{
					// This object has not been saved yet.
					// Therefore, it cannot have any associated entity objects related to it in the repository.
					// Create an empty collection instead.
					SetupChildOwnedRelationshipEntity1List(null); // Null instructs SetupChildOwnedRelationshipEntity1List to create a new collection object.
				}
			}
			this.childOwnedRelationshipEntity1ListLoadStatus = LoadStatus.Full;
			return this.childOwnedRelationshipEntity1List;
		}

		IRelationshipEntity1List IDependentEntity2.LoadChildOwnedRelationshipEntity1List()
		{
			return (IRelationshipEntity1List)LoadChildOwnedRelationshipEntity1List();
		}

		private void SetupChildOwnedRelationshipEntity1List(RelationshipEntity1List list)
		{
			// If no collection object specified, create an empty collection.
			RelationshipEntity1List _list;
			if ((_list = list) == null) _list = (RelationshipEntity1List)CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(CustName.AppName.DAL.EntityClass.RelationshipEntity1);

			// Register a ListChanged event handler with the collection.
			// Because the collection holds owned entity objects, the parent needs to be aware of any changes made to them in order to correctly set its own commit status.
			// Changes in an owned entity object imply parent entity object is changed.
			this.childOwnedRelationshipEntity1ListChangedEventHandler = new System.ComponentModel.ListChangedEventHandler(ChildOwnedRelationshipEntity1List_ListChanged);
			_list.ListChanged += this.childOwnedRelationshipEntity1ListChangedEventHandler;

			// Link the collection into the object hierarchy.
			_list.Parent = (IEntityObject)this;
			_list.CollectionName = CollectionName.DependentEntity2_ChildOwnedRelationshipEntity1List;
			this.childOwnedRelationshipEntity1List = _list;
		}

		public void UnloadChildOwnedRelationshipEntity1List()
		{
			if (this.childOwnedRelationshipEntity1List != null)
			{
				if (this.childOwnedRelationshipEntity1ListChangedEventHandler != null)
					this.childOwnedRelationshipEntity1List.ListChanged -= this.childOwnedRelationshipEntity1ListChangedEventHandler;
				this.childOwnedRelationshipEntity1List.Parent = null;
			}
			this.childOwnedRelationshipEntity1List = null;
			this.childOwnedRelationshipEntity1ListLoadStatus = LoadStatus.NotLoaded;
		}

		void IDependentEntity2.UnloadChildOwnedRelationshipEntity1List()
		{
			UnloadChildOwnedRelationshipEntity1List();
		}

		public bool HasChildOwnedRelationshipEntity1Objects(bool inMemoryOnly)
		{
			if (this.childOwnedRelationshipEntity1List == null)
				return false;
			else
				return (this.childOwnedRelationshipEntity1List.Count > 0);
		}

		protected virtual void ChildOwnedRelationshipEntity1List_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		{
			this.HasUncommittedChanges = true;
		}

		#endregion RelationshipEntity1 Relationship

		#endregion // Owned Inbound Relationships

		#region Non-Owned Inbound Relationships

		// This entity has no non-owned inbound relationships.

		#endregion // Non-Owned Inbound Relationships

		#endregion // Inbound Relationships

		// ========================================================================================================================

		#region Outbound Relationships

		#region Owner Outbound Relationships


		#region DependentEntity1 Relationship

		public bool ParentOwnerDependentEntity1_DependentEntity2ListPartialLoadAttempted
		{
			get
			{
				if (this.parentOwnerDependentEntity1_DependentEntity2List == null)
					return this.parentOwnerDependentEntity1_DependentEntity2ListPartialLoadAttempted;
				else
					return true;
			}
		}

		public DependentEntity2List ParentOwnerDependentEntity1_DependentEntity2List
		{
			get
			{
				LoadParentOwnerDependentEntity1_DependentEntity2List();
				return this.parentOwnerDependentEntity1_DependentEntity2List;
			}
			internal set
			{
				this.parentOwnerDependentEntity1_DependentEntity2List = value;
			}
		}

		IDependentEntity2List IDependentEntity2.ParentOwnerDependentEntity1_DependentEntity2List
		{
			get
			{
				return (IDependentEntity2List)this.ParentOwnerDependentEntity1_DependentEntity2List;
			}
		}

		public void LoadParentOwnerDependentEntity1_DependentEntity2List()
		{
			if (!ParentOwnerDependentEntity1_DependentEntity2ListPartialLoadAttempted)
			{
				if (this.objectData.ParentOwnerDependentEntity1EntityObjectId == null)
				{
					ParentOwnerDependentEntity1_DependentEntity2List = null;
				}
				else
				{
					DependentEntity1 dependentEntity1 = (DependentEntity1)CustName.AppName.BL.Global.ClassFactory.GetDALRepository().GetDependentEntity1(this.objectData.ParentOwnerDependentEntity1EntityObjectId.Value, this.Context);
					if (dependentEntity1 == null)
						ParentOwnerDependentEntity1_DependentEntity2List = null;
					else
						ParentOwnerDependentEntity1_DependentEntity2List = (DependentEntity2List)dependentEntity1.LoadChildOwnedDependentEntity2List((DependentEntity2)this);
				}
				this.parentOwnerDependentEntity1_DependentEntity2ListPartialLoadAttempted = true;
				NotifyAll_ParentOwnerDependentEntity1EntityObject_PropertiesChanged();
			}
		}

		public void UnloadParentOwnerDependentEntity1_DependentEntity2List()
		{
			ParentOwnerDependentEntity1_DependentEntity2List = null;
			this.parentOwnerDependentEntity1_DependentEntity2ListPartialLoadAttempted = false;
			NotifyAll_ParentOwnerDependentEntity1EntityObject_PropertiesChanged();
		}

		public DependentEntity1 ParentOwnerDependentEntity1EntityObject
		{
			get
			{
				LoadParentOwnerDependentEntity1_DependentEntity2List();
				if (this.parentOwnerDependentEntity1_DependentEntity2List == null)
					// Either foreign object id == null or is invalid (i.e. points to non-existent repository object).
					return null;
				else
					return (DependentEntity1)this.parentOwnerDependentEntity1_DependentEntity2List.Parent;
			}
		}

		IDependentEntity1 IDependentEntity2.ParentOwnerDependentEntity1EntityObject
		{
			get
			{
				return (IDependentEntity1)this.ParentOwnerDependentEntity1EntityObject;
			}
		}

		public bool HasParentOwnerDependentEntity1Object(bool inMemoryOnly)
		{
			if (inMemoryOnly)
			{
				if (this.parentOwnerDependentEntity1_DependentEntity2List == null)
					return false;
				else
					return (this.parentOwnerDependentEntity1_DependentEntity2List.Parent != null);
			}
			else
			{
				if (this.parentOwnerDependentEntity1_DependentEntity2List == null)
				{
					if (this.parentOwnerDependentEntity1_DependentEntity2ListPartialLoadAttempted)
						return false;
					else
						return (this.objectData.ParentOwnerDependentEntity1EntityObjectId != null);
				}
				else
					return (this.parentOwnerDependentEntity1_DependentEntity2List.Parent != null);
			}
		}

		#endregion DependentEntity1 Relationship

		#endregion // Owner Outbound Relationships

		#region Non-Owner Outbound Relationships

		// This entity has no non-owner outbound relationships.

		#endregion // Non-Owner Outbound Relationships

		#endregion // Outbound Relationships

		// ========================================================================================================================

		public override void Load(bool recurse)
		{
			// RelationshipEntity1 Relationship
			if (childOwnedRelationshipEntity1ListLoadStatus != LoadStatus.Full)
			{
				LoadChildOwnedRelationshipEntity1List();
				if (recurse)
				{
					foreach (RelationshipEntity1 relationshipEntity1 in childOwnedRelationshipEntity1List)
					{
						relationshipEntity1.Load(true);
					}
				}
			}
		}

		public override IList<IEntityObject> GetOwnedObjects(bool loaded, IList<IEntityObject> list)
		{
			return null;
		}

		public DependentEntity2 Copy(bool recurse)
		{
			return CopyImpl(recurse);
		}

		IDependentEntity2 IDependentEntity2.Copy(bool recurse)
		{
			return (IDependentEntity2)CopyImpl(recurse);
		}

		protected DependentEntity2 CopyImpl(bool recurse)
		{
			DependentEntity2 newDependentEntity2 = (DependentEntity2)CustName.AppName.BL.Global.ClassFactory.GetEntityObject(CustName.AppName.DAL.EntityClass.DependentEntity2);
			newDependentEntity2.PopulateFrom(this);
			newDependentEntity2.ObjectId = null;
			if (recurse)
			{
				this.LoadChildOwnedRelationshipEntity1List();
				foreach (RelationshipEntity1 relationshipEntity1 in this.ChildOwnedRelationshipEntity1List)
				{
					newDependentEntity2.ChildOwnedRelationshipEntity1List.Add(relationshipEntity1.Copy(true));
				}
			}
			return newDependentEntity2;
		}

		// ========================================================================================================================

		#region Outbound Relationships Properties

		#region Owner Outbound Relationships Properties

		#region DependentEntity1 Relationship

		public virtual int? ParentOwnerDependentEntity1EntityObject_IndependentEntity1Id
		{
			get
			{
				IDependentEntity1 obj = ParentOwnerDependentEntity1EntityObject;
				if (obj == null)
					return null;
				else
					return obj.IndependentEntity1Id;
			}
		}

		public virtual bool? ParentOwnerDependentEntity1EntityObject_AttrBool1
		{
			get
			{
				IDependentEntity1 obj = ParentOwnerDependentEntity1EntityObject;
				if (obj == null)
					return null;
				else
					return obj.AttrBool1;
			}
		}

		public virtual DateTime? ParentOwnerDependentEntity1EntityObject_AttrDatetime1
		{
			get
			{
				IDependentEntity1 obj = ParentOwnerDependentEntity1EntityObject;
				if (obj == null)
					return null;
				else
					return obj.AttrDatetime1;
			}
		}

		public virtual int? ParentOwnerDependentEntity1EntityObject_AttrInteger1
		{
			get
			{
				IDependentEntity1 obj = ParentOwnerDependentEntity1EntityObject;
				if (obj == null)
					return null;
				else
					return obj.AttrInteger1;
			}
		}

		public virtual string ParentOwnerDependentEntity1EntityObject_AttrString1
		{
			get
			{
				IDependentEntity1 obj = ParentOwnerDependentEntity1EntityObject;
				if (obj == null)
					return null;
				else
					return obj.AttrString1;
			}
		}

		public virtual string ParentOwnerDependentEntity1EntityObject_AttrString2
		{
			get
			{
				IDependentEntity1 obj = ParentOwnerDependentEntity1EntityObject;
				if (obj == null)
					return null;
				else
					return obj.AttrString2;
			}
		}

		public virtual string ParentOwnerDependentEntity1EntityObject_Name
		{
			get
			{
				IDependentEntity1 obj = ParentOwnerDependentEntity1EntityObject;
				if (obj == null)
					return null;
				else
					return obj.Name;
			}
		}

		public virtual string ParentOwnerDependentEntity1EntityObject_Status
		{
			get
			{
				IDependentEntity1 obj = ParentOwnerDependentEntity1EntityObject;
				if (obj == null)
					return null;
				else
					return obj.Status;
			}
		}

		protected virtual void NotifyAll_ParentOwnerDependentEntity1EntityObject_PropertiesChanged()
		{
			// When this object is in a list that is bound to a DataGridView control containing a ComboBox bound to the FK property (DependentEntity1Id)
			// driving the content of the ParentOwnerDependentEntity1EntityObject_* properties,
			// changing selections in the ComboBox results in a noticeable pause.
			// Delay is cause by something executing FindCore on the list that the ComboBox is bound to (that populates its dropdown) every time OnPropertyChanged is called.
			// Another issue is that any list containing this object raises an event to signal that it has changed, causing owner entity objects to be marked as having changes,
			// which may not be desirable becauses changes to DependentEntity1 may not imply changes to the parent if DependentEntity1 is not owned by the parent.
			// Workaround has been to disable OnPropertyChanged calls below and have the UI listen for changes in the FK property DependentEntity1Id (indirectly through the
			// ListChanged event) and invalidate the DataGridView row so that repaints cells containing values dependent upon the combobox selection i.e. one of the
			// ParentOwnerDependentEntity1EntityObject_* properties.
			//OnPropertyChanged("ParentOwnerDependentEntity1EntityObject_AttrBool1");
			//OnPropertyChanged("ParentOwnerDependentEntity1EntityObject_AttrDatetime1");
			//OnPropertyChanged("ParentOwnerDependentEntity1EntityObject_AttrInteger1");
			//OnPropertyChanged("ParentOwnerDependentEntity1EntityObject_AttrString1");
			//OnPropertyChanged("ParentOwnerDependentEntity1EntityObject_AttrString2");
			//OnPropertyChanged("ParentOwnerDependentEntity1EntityObject_IndependentEntity1Id");
			//OnPropertyChanged("ParentOwnerDependentEntity1EntityObject_Name");
			//OnPropertyChanged("ParentOwnerDependentEntity1EntityObject_Status");
		}

		#endregion DependentEntity1 Relationship Properties

		#endregion // Owner Outbound Relationships Properties

		#region Non-Owner Outbound Relationships Properties

		// This entity has no non-owner outbound relationships.

		#endregion // Non-Owner Outbound Relationships Properties

		#endregion // Outbound Relationships Properties

		// ========================================================================================================================
	}

	public abstract class BaseIndependentEntity1 : EntityObject, IIndependentEntity1
	{
		private struct ObjectData
		{
			// Structure for primary key fields.
			public IndependentEntity1Identifier? ObjectId;
			public bool? AttrBool1;
			public DateTime? AttrDatetime1;
			public int? AttrInteger1;
			public string AttrString1;
			public string AttrString2;
			public string Name;
			public string Status;
		}

		private struct ObjectDataChanges
		{
			public bool ObjectIdPropertyChanged;
			public bool AttrBool1PropertyChanged;
			public bool AttrDatetime1PropertyChanged;
			public bool AttrInteger1PropertyChanged;
			public bool AttrString1PropertyChanged;
			public bool AttrString2PropertyChanged;
			public bool NamePropertyChanged;
			public bool StatusPropertyChanged;
		}

		private ObjectData objectData;
		private ObjectData objectDataBackup;
		private ObjectData objectDataToCopy;
		private ObjectDataChanges objectDataChanges;

		#region Inbound Relationships

		// This region contains the collection variables for referencing inbound related entity objects.
		// Inbound related entities are typically dependent entities.

		#region Owned Inbound Relationships

		// DependentEntity1 Relationship
		private LoadStatus childOwnedDependentEntity1ListLoadStatus = LoadStatus.NotLoaded;
		private DependentEntity1List childOwnedDependentEntity1List = null;
		private System.ComponentModel.ListChangedEventHandler childOwnedDependentEntity1ListChangedEventHandler = null;

		#endregion Owned Inbound Relationships

		#region Non-Owned Inbound Relationships

		// This entity has no non-owned inbound relationships.

		#endregion Non-Owned Inbound Relationships

		#endregion Inbound Relationships

		#region Outbound Relationships

		// This region contains the collection variables for referencing outbound related entity objects.
		// Outbound related entities are typically parent entities.

		// This entity has no outbound relationships.

		#endregion Outbound Relationships

		public BaseIndependentEntity1()
			: base()
		{
			Initialize_BaseIndependentEntity1();
		}

		public BaseIndependentEntity1(Guid instanceId)
			: base(instanceId)
		{
			Initialize_BaseIndependentEntity1();
		}

		private void Initialize_BaseIndependentEntity1()
		{
			PostInitialize_BaseIndependentEntity1();
		}

		protected virtual void PostInitialize_BaseIndependentEntity1()
		{
		}

		public override EntityType EntityType
		{
			get
			{
				return CustName.AppName.DAL.EntityType.Independent;
			}
		}

		public override EntityClass EntityClass
		{
			get
			{
				return CustName.AppName.DAL.EntityClass.IndependentEntity1;
			}
		}

		#region IEntityObjectContextItem Interface

		public override IIdentifier ContextKey
		{
			get
			{
				return (IIdentifier)this.objectData.ObjectId.Value;
			}
		}

		#endregion

		public IndependentEntity1Identifier? ObjectId
		{
			get
			{
				return this.objectData.ObjectId;
			}
			set
			{
				if (this.objectData.ObjectId != value)
				{
					this.objectData.ObjectId = value;
					NotifyPropertyChanged("ObjectId");
				}
			}
		}

		public virtual object ObjectId_DBObjectValue
		{
			get
			{
				return (this.ObjectId.HasValue ? (object)this.ObjectId.Value : (object)DBNull.Value);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.ObjectId = null;
				else
					this.ObjectId = (IndependentEntity1Identifier)value;
			}
		}

		public virtual int? IndependentEntity1Id
		{
			get
			{
				return (this.objectData.ObjectId.HasValue ? (int?)this.objectData.ObjectId.Value.IndependentEntity1Id : (int?)null);
			}
		}

		public virtual object IndependentEntity1Id_DBObjectValue
		{
			get
			{
				return (this.objectData.ObjectId.HasValue ? (object)this.objectData.ObjectId.Value.IndependentEntity1Id : (object)DBNull.Value);
			}
		}

		public override string ObjectPrimaryDescriptor
		{
			get
			{
				string name = null;
				if (this.Name != null)
				{
					name = this.Name.ToString();
				}
				if (name == null)
				{
					if (this.ObjectStatus == ObjectStatus.New)
						name = "<new>";
					else
						name = "<undefined>";
				}
				else if (name.Trim() == "")
				{
					name = "<blank>";
				}
				return name;
			}
		}

		public virtual bool? AttrBool1
		{
			get
			{
				return this.objectData.AttrBool1;
			}
			set
			{
				if (this.objectData.AttrBool1 != value)
				{
					this.objectData.AttrBool1 = value;
					NotifyPropertyChanged("AttrBool1");
				}
			}
		}

		public virtual object AttrBool1_DBObjectValue
		{
			get
			{
				return (this.AttrBool1.HasValue ? (object)this.AttrBool1.Value : (object)DBNull.Value);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.AttrBool1 = null;
				else
					switch (value.ToString())
					{
						case "Checked":
							this.AttrBool1 = true;
							break;
						case "Indeterminate":
							this.AttrBool1 = null;
							break;
						case "Unchecked":
							this.AttrBool1 = false;
							break;
						case "False":
							this.AttrBool1 = false;
							break;
						case "True":
							this.AttrBool1 = true;
							break;
						default:
							this.AttrBool1 = (System.Boolean?)value;
							break;
					}
			}
		}

		public virtual bool AttrBool1_NoNull
		{
			get
			{
				return this.AttrBool1.GetValueOrDefault();
			}
			set
			{
				this.AttrBool1 = value;
			}
		}

		public virtual DateTime? AttrDatetime1
		{
			get
			{
				return this.objectData.AttrDatetime1;
			}
			set
			{
				DateTime? dateOnly;
				if (value.HasValue)
					dateOnly = value.Value.Date;
				if (this.objectData.AttrDatetime1 != value)
				{
					this.objectData.AttrDatetime1 = value;
					NotifyPropertyChanged("AttrDatetime1");
				}
			}
		}

		public virtual object AttrDatetime1_DBObjectValue
		{
			get
			{
				return (this.AttrDatetime1.HasValue ? (object)this.AttrDatetime1.Value : (object)DBNull.Value);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.AttrDatetime1 = null;
				else
					this.AttrDatetime1 = (System.DateTime?)value;
			}
		}

		public virtual DateTime AttrDatetime1_NoNull
		{
			get
			{
				return this.AttrDatetime1.GetValueOrDefault();
			}
			set
			{
				this.AttrDatetime1 = value;
			}
		}

		public virtual int? AttrInteger1
		{
			get
			{
				return this.objectData.AttrInteger1;
			}
			set
			{
				if (this.objectData.AttrInteger1 != value)
				{
					this.objectData.AttrInteger1 = value;
					NotifyPropertyChanged("AttrInteger1");
				}
			}
		}

		public virtual object AttrInteger1_DBObjectValue
		{
			get
			{
				return (this.AttrInteger1.HasValue ? (object)this.AttrInteger1.Value : (object)DBNull.Value);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.AttrInteger1 = null;
				else
					this.AttrInteger1 = (System.Int32?)value;
			}
		}

		public virtual int AttrInteger1_NoNull
		{
			get
			{
				return this.AttrInteger1.GetValueOrDefault();
			}
			set
			{
				this.AttrInteger1 = value;
			}
		}

		public virtual string AttrString1
		{
			get
			{
				return this.objectData.AttrString1;
			}
			set
			{
				if (this.objectData.AttrString1 != value)
				{
					this.objectData.AttrString1 = value;
					NotifyPropertyChanged("AttrString1");
				}
			}
		}

		public virtual object AttrString1_DBObjectValue
		{
			get
			{
				return (this.AttrString1 == null ? (object)DBNull.Value : (object)this.AttrString1);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.AttrString1 = null;
				else
					this.AttrString1 = (System.String)value;
			}
		}

		public virtual string AttrString2
		{
			get
			{
				return this.objectData.AttrString2;
			}
			set
			{
				if (this.objectData.AttrString2 != value)
				{
					this.objectData.AttrString2 = value;
					NotifyPropertyChanged("AttrString2");
				}
			}
		}

		public virtual object AttrString2_DBObjectValue
		{
			get
			{
				return (this.AttrString2 == null ? (object)DBNull.Value : (object)this.AttrString2);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.AttrString2 = null;
				else
					this.AttrString2 = (System.String)value;
			}
		}

		public virtual string Name
		{
			get
			{
				return this.objectData.Name;
			}
			set
			{
				if (this.objectData.Name != value)
				{
					this.objectData.Name = value;
					NotifyPropertyChanged("Name");
				}
			}
		}

		public virtual object Name_DBObjectValue
		{
			get
			{
				return (this.Name == null ? (object)DBNull.Value : (object)this.Name);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.Name = null;
				else
					this.Name = (System.String)value;
			}
		}

		public virtual string Status
		{
			get
			{
				return this.objectData.Status;
			}
			set
			{
				if (this.objectData.Status != value)
				{
					this.objectData.Status = value;
					NotifyPropertyChanged("Status");
				}
			}
		}

		public virtual object Status_DBObjectValue
		{
			get
			{
				return (this.Status == null ? (object)DBNull.Value : (object)this.Status);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.Status = null;
				else
					this.Status = (System.String)value;
			}
		}

		// Will not work if all on-demand-load BLOB properties are not loaded.
		public override bool SameAs(IEntityObject obj)
		{
			IndependentEntity1 independentEntity1 = (IndependentEntity1)obj;
			return (base.SameAs(obj) && independentEntity1.ObjectId == this.objectData.ObjectId && this.objectData.AttrBool1 == independentEntity1.objectData.AttrBool1 && this.objectData.AttrDatetime1 == independentEntity1.objectData.AttrDatetime1 && this.objectData.AttrInteger1 == independentEntity1.objectData.AttrInteger1 && this.objectData.AttrString1 == independentEntity1.objectData.AttrString1 && this.objectData.AttrString2 == independentEntity1.objectData.AttrString2 && this.objectData.Name == independentEntity1.objectData.Name && this.objectData.Status == independentEntity1.objectData.Status);
		}

		public bool SameAs(IIndependentEntity1 obj)
		{
			return SameAs((IEntityObject)obj);
		}

		#region IEditableObject Related

		protected override void BackupObjectData()
		{
			base.BackupObjectData();
			this.objectDataBackup = this.objectData;
		}

		protected override void RestoreObjectData()
		{
			base.RestoreObjectData();
			this.objectData = this.objectDataBackup;
		}

		#endregion

		public override void PopulateFrom(IEntityObject source)
		{
			this.objectDataToCopy = ((IndependentEntity1)source).objectData;
			base.PopulateFrom(source);
		}

		protected override void CopySourceObjectDataToActive()
		{
			base.CopySourceObjectDataToActive();
			this.objectData = this.objectDataToCopy;
		}

		protected override void CompareObjectData(ObjectDataSet objectDataSet)
		{
			base.CompareObjectData(objectDataSet);

			ObjectData objectDataToCompare;
			if (objectDataSet == ObjectDataSet.Active)
			{
				this.objectDataChanges.ObjectIdPropertyChanged = false;
				this.objectDataChanges.AttrBool1PropertyChanged = false;
				this.objectDataChanges.AttrDatetime1PropertyChanged = false;
				this.objectDataChanges.AttrInteger1PropertyChanged = false;
				this.objectDataChanges.AttrString1PropertyChanged = false;
				this.objectDataChanges.AttrString2PropertyChanged = false;
				this.objectDataChanges.NamePropertyChanged = false;
				this.objectDataChanges.StatusPropertyChanged = false;
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
				this.objectDataChanges.ObjectIdPropertyChanged = (objectDataToCompare.ObjectId != objectData.ObjectId);
				this.objectDataChanges.AttrBool1PropertyChanged = (objectDataToCompare.AttrBool1 != objectData.AttrBool1);
				this.objectDataChanges.AttrDatetime1PropertyChanged = (objectDataToCompare.AttrDatetime1 != objectData.AttrDatetime1);
				this.objectDataChanges.AttrInteger1PropertyChanged = (objectDataToCompare.AttrInteger1 != objectData.AttrInteger1);
				this.objectDataChanges.AttrString1PropertyChanged = (objectDataToCompare.AttrString1 != objectData.AttrString1);
				this.objectDataChanges.AttrString2PropertyChanged = (objectDataToCompare.AttrString2 != objectData.AttrString2);
				this.objectDataChanges.NamePropertyChanged = (objectDataToCompare.Name != objectData.Name);
				this.objectDataChanges.StatusPropertyChanged = (objectDataToCompare.Status != objectData.Status);
			}
		}

		protected override void SendPropertyChangeNotifications()
		{
			base.SendPropertyChangeNotifications();
			if (this.objectDataChanges.ObjectIdPropertyChanged) OnPropertyChanged("ObjectId");
			if (this.objectDataChanges.AttrBool1PropertyChanged) OnPropertyChanged("AttrBool1");
			if (this.objectDataChanges.AttrDatetime1PropertyChanged) OnPropertyChanged("AttrDatetime1");
			if (this.objectDataChanges.AttrInteger1PropertyChanged) OnPropertyChanged("AttrInteger1");
			if (this.objectDataChanges.AttrString1PropertyChanged) OnPropertyChanged("AttrString1");
			if (this.objectDataChanges.AttrString2PropertyChanged) OnPropertyChanged("AttrString2");
			if (this.objectDataChanges.NamePropertyChanged) OnPropertyChanged("Name");
			if (this.objectDataChanges.StatusPropertyChanged) OnPropertyChanged("Status");
		}

		#region INotifyPropertyChanged Related

		protected override void NotifyPropertyChanged(string propertyName)
		{
			base.NotifyPropertyChanged(propertyName);
			if (propertyName == "Name")
				base.NotifyPropertyChanged("ObjectPrimaryDescriptor");
		}

		#endregion

		// ========================================================================================================================

		#region Inbound Relationships

		#region Owned Inbound Relationships

		#region DependentEntity1 Relationship

		public LoadStatus ChildOwnedDependentEntity1ListLoadStatus
		{
			get
			{
				return this.childOwnedDependentEntity1ListLoadStatus;
			}
		}

		public DependentEntity1List ChildOwnedDependentEntity1List
		{
			get
			{
				// If the collection has not been populated, automatically load it.
				// This enables UIs to display without having to issue explicit commands to load related entity objects.
				if (this.childOwnedDependentEntity1ListLoadStatus == LoadStatus.NotLoaded)
					LoadChildOwnedDependentEntity1List();
				return this.childOwnedDependentEntity1List;
			}
		}

		IDependentEntity1List IIndependentEntity1.ChildOwnedDependentEntity1List
		{
			get
			{
				return (IDependentEntity1List)this.ChildOwnedDependentEntity1List;
			}
		}

		// Load a single entity object into the collection.
		public DependentEntity1List LoadChildOwnedDependentEntity1List(DependentEntity1 dependentEntity1)
		{
			// Make sure the collection object has been created.
			if (this.childOwnedDependentEntity1ListLoadStatus == LoadStatus.NotLoaded)
			{
				SetupChildOwnedDependentEntity1List(null); // Null instructs SetupChildOwnedDependentEntity1List to create a new collection object.
				if (this.ObjectId.HasValue)
					// The object exists in the repository. It is possible that more associated entity objects also exist in the repository.
					this.childOwnedDependentEntity1ListLoadStatus = LoadStatus.Partial;
				else
					// The object has not yet been saved and therefore cannot have associated entity objects in the repository.
					this.childOwnedDependentEntity1ListLoadStatus = LoadStatus.Full;
			}

			if (dependentEntity1 != null)
			{
				// Append given entity object to the collection if it isn't already a member.
				// List.Contains call is important because this method may be called to load an unsaved entity object.
				// Since unsaved entity objects have no object id assigned, the only way to determine if they already exist in a collection or not is to call List.Contains.
				if (!this.childOwnedDependentEntity1List.Contains(dependentEntity1))
				{
					bool alreadyInList = false;
					foreach (DependentEntity1 childOwnedDependentEntity1 in this.childOwnedDependentEntity1List)
					{
						if ((childOwnedDependentEntity1.ObjectId != null) && (childOwnedDependentEntity1.ObjectId == dependentEntity1.ObjectId))
						{
							alreadyInList = true;
							break;
						}
					}
					if (!alreadyInList) this.childOwnedDependentEntity1List.Add(dependentEntity1); // Add method automatically sets object's parentList pointer to itself.
				}
			}

			return this.childOwnedDependentEntity1List;
		}

		IDependentEntity1List IIndependentEntity1.LoadChildOwnedDependentEntity1List(IDependentEntity1 dependentEntity1)
		{
			return (IDependentEntity1List)this.LoadChildOwnedDependentEntity1List((DependentEntity1)dependentEntity1);
		}

		// Load collection from repository.
		public DependentEntity1List LoadChildOwnedDependentEntity1List()
		{
			LoadStatus loadStatus = this.childOwnedDependentEntity1ListLoadStatus;
			if (loadStatus == LoadStatus.Partial)
			{
				// The collection object has already been created, complete with ListChanged event handler.
				// It contains zero or more associated DependentEntity1 entity objects.
				// All that needs to be done here is to add any remaining associated DependentEntity1 objects that exist in the repository.
				// If this object has not yet been saved, the implication is that there can exist no associated entity objects in the repository.
				if (this.ObjectId != null)
				{
					// Get the associated entity objects from the repository.
					DependentEntity1List list = (DependentEntity1List)CustName.AppName.BL.Global.ClassFactory.GetDALRepository().FindDependentEntity1(-1, new SearchCondition().AppendSearchCondition(DependentEntity1PropertyName.ParentOwnerIndependentEntity1EntityObjectId, SearchConditionExpressionOperator.Equal, this.ObjectId), CustName.AppName.BL.Global.ClassFactory.GetDALRepository().IndependentEntity1_ChildOwnedDependentEntity1SortSpecification, ((IEntityObjectContextItem)this).Context);

					// Append the entity objects just loaded from the repository to the collection, except those already in the collection to begin with.
					int preExistingItemCount = this.childOwnedDependentEntity1List.Count;
					bool alreadyInList;
					DependentEntity1Identifier? preExistingObjectId;
					foreach (DependentEntity1 entityObject in list)
					{
						// Search only the preexisting items in the collection for a match.
						// If no match found, the current entity object can be added to the collection without risk of it being a duplicate.
						alreadyInList = false;
						for (int index = 0; index < preExistingItemCount; ++index)
						{
							// Bypass entity objects that have not been saved.
							// They cannot possibly match an entity from the repository.
							// List.Contains does not need to be used here because the Repository.FindDependentEntity1 call returns new objects that are guaranteed to have ObjectId set.
							if ((preExistingObjectId = this.childOwnedDependentEntity1List[index].ObjectId) != null)
								if (alreadyInList = (preExistingObjectId == entityObject.ObjectId))
									break;
						}
						if (!alreadyInList) this.childOwnedDependentEntity1List.Add(entityObject);
					}
				}
			}
			else if (loadStatus == LoadStatus.NotLoaded)
			{
				// The collection object has not yet been created.
				// Create it and populate it with all the associated DependentEntity1 entity objects in the repository.
				if (this.ObjectId.HasValue)
				{
					DependentEntity1List list = (DependentEntity1List)CustName.AppName.BL.Global.ClassFactory.GetDALRepository().FindDependentEntity1(-1, new SearchCondition().AppendSearchCondition(DependentEntity1PropertyName.ParentOwnerIndependentEntity1EntityObjectId, SearchConditionExpressionOperator.Equal, this.ObjectId), CustName.AppName.BL.Global.ClassFactory.GetDALRepository().IndependentEntity1_ChildOwnedDependentEntity1SortSpecification, ((IEntityObjectContextItem)this).Context);
					SetupChildOwnedDependentEntity1List(list);
				}
				else
				{
					// This object has not been saved yet.
					// Therefore, it cannot have any associated entity objects related to it in the repository.
					// Create an empty collection instead.
					SetupChildOwnedDependentEntity1List(null); // Null instructs SetupChildOwnedDependentEntity1List to create a new collection object.
				}
			}
			this.childOwnedDependentEntity1ListLoadStatus = LoadStatus.Full;
			return this.childOwnedDependentEntity1List;
		}

		IDependentEntity1List IIndependentEntity1.LoadChildOwnedDependentEntity1List()
		{
			return (IDependentEntity1List)LoadChildOwnedDependentEntity1List();
		}

		private void SetupChildOwnedDependentEntity1List(DependentEntity1List list)
		{
			// If no collection object specified, create an empty collection.
			DependentEntity1List _list;
			if ((_list = list) == null) _list = (DependentEntity1List)CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(CustName.AppName.DAL.EntityClass.DependentEntity1);

			// Register a ListChanged event handler with the collection.
			// Because the collection holds owned entity objects, the parent needs to be aware of any changes made to them in order to correctly set its own commit status.
			// Changes in an owned entity object imply parent entity object is changed.
			this.childOwnedDependentEntity1ListChangedEventHandler = new System.ComponentModel.ListChangedEventHandler(ChildOwnedDependentEntity1List_ListChanged);
			_list.ListChanged += this.childOwnedDependentEntity1ListChangedEventHandler;

			// Link the collection into the object hierarchy.
			_list.Parent = (IEntityObject)this;
			_list.CollectionName = CollectionName.IndependentEntity1_ChildOwnedDependentEntity1List;
			this.childOwnedDependentEntity1List = _list;
		}

		public void UnloadChildOwnedDependentEntity1List()
		{
			if (this.childOwnedDependentEntity1List != null)
			{
				if (this.childOwnedDependentEntity1ListChangedEventHandler != null)
					this.childOwnedDependentEntity1List.ListChanged -= this.childOwnedDependentEntity1ListChangedEventHandler;
				this.childOwnedDependentEntity1List.Parent = null;
			}
			this.childOwnedDependentEntity1List = null;
			this.childOwnedDependentEntity1ListLoadStatus = LoadStatus.NotLoaded;
		}

		void IIndependentEntity1.UnloadChildOwnedDependentEntity1List()
		{
			UnloadChildOwnedDependentEntity1List();
		}

		public bool HasChildOwnedDependentEntity1Objects(bool inMemoryOnly)
		{
			if (this.childOwnedDependentEntity1List == null)
				return false;
			else
				return (this.childOwnedDependentEntity1List.Count > 0);
		}

		protected virtual void ChildOwnedDependentEntity1List_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		{
			this.HasUncommittedChanges = true;
		}

		#endregion DependentEntity1 Relationship

		#endregion // Owned Inbound Relationships

		#region Non-Owned Inbound Relationships

		// This entity has no non-owned inbound relationships.

		#endregion // Non-Owned Inbound Relationships

		#endregion // Inbound Relationships

		// ========================================================================================================================

		#region Outbound Relationships

		#region Owner Outbound Relationships

		// This entity has no owner outbound relationships.

		#endregion // Owner Outbound Relationships

		#region Non-Owner Outbound Relationships

		// This entity has no non-owner outbound relationships.

		#endregion // Non-Owner Outbound Relationships

		#endregion // Outbound Relationships

		// ========================================================================================================================

		public override void Load(bool recurse)
		{
			// DependentEntity1 Relationship
			if (childOwnedDependentEntity1ListLoadStatus != LoadStatus.Full)
			{
				LoadChildOwnedDependentEntity1List();
				if (recurse)
				{
					foreach (DependentEntity1 dependentEntity1 in childOwnedDependentEntity1List)
					{
						dependentEntity1.Load(true);
					}
				}
			}
		}

		public override IList<IEntityObject> GetOwnedObjects(bool loaded, IList<IEntityObject> list)
		{
			return null;
		}

		public IndependentEntity1 Copy(bool recurse)
		{
			return CopyImpl(recurse);
		}

		IIndependentEntity1 IIndependentEntity1.Copy(bool recurse)
		{
			return (IIndependentEntity1)CopyImpl(recurse);
		}

		protected IndependentEntity1 CopyImpl(bool recurse)
		{
			IndependentEntity1 newIndependentEntity1 = (IndependentEntity1)CustName.AppName.BL.Global.ClassFactory.GetEntityObject(CustName.AppName.DAL.EntityClass.IndependentEntity1);
			newIndependentEntity1.PopulateFrom(this);
			newIndependentEntity1.ObjectId = null;
			if (recurse)
			{
				this.LoadChildOwnedDependentEntity1List();
				foreach (DependentEntity1 dependentEntity1 in this.ChildOwnedDependentEntity1List)
				{
					newIndependentEntity1.ChildOwnedDependentEntity1List.Add(dependentEntity1.Copy(true));
				}
			}
			return newIndependentEntity1;
		}

		// ========================================================================================================================

		#region Outbound Relationships Properties

		#region Owner Outbound Relationships Properties

		// This entity has no owner outbound relationships.

		#endregion // Owner Outbound Relationships Properties

		#region Non-Owner Outbound Relationships Properties

		// This entity has no non-owner outbound relationships.

		#endregion // Non-Owner Outbound Relationships Properties

		#endregion // Outbound Relationships Properties

		// ========================================================================================================================
	}

	public abstract class BaseIndependentEntity2 : EntityObject, IIndependentEntity2
	{
		private struct ObjectData
		{
			// Structure for primary key fields.
			public IndependentEntity2Identifier? ObjectId;
			public bool? AttrBool1;
			public DateTime? AttrDatetime1;
			public int? AttrInteger1;
			public string AttrString1;
			public string AttrString2;
			public string Name;
			public string Status;
		}

		private struct ObjectDataChanges
		{
			public bool ObjectIdPropertyChanged;
			public bool AttrBool1PropertyChanged;
			public bool AttrDatetime1PropertyChanged;
			public bool AttrInteger1PropertyChanged;
			public bool AttrString1PropertyChanged;
			public bool AttrString2PropertyChanged;
			public bool NamePropertyChanged;
			public bool StatusPropertyChanged;
		}

		private ObjectData objectData;
		private ObjectData objectDataBackup;
		private ObjectData objectDataToCopy;
		private ObjectDataChanges objectDataChanges;

		#region Inbound Relationships

		// This region contains the collection variables for referencing inbound related entity objects.
		// Inbound related entities are typically dependent entities.

		#region Owned Inbound Relationships

		// RelationshipEntity1 Relationship
		private LoadStatus childOwnedRelationshipEntity1ListLoadStatus = LoadStatus.NotLoaded;
		private RelationshipEntity1List childOwnedRelationshipEntity1List = null;
		private System.ComponentModel.ListChangedEventHandler childOwnedRelationshipEntity1ListChangedEventHandler = null;

		#endregion Owned Inbound Relationships

		#region Non-Owned Inbound Relationships

		// This entity has no non-owned inbound relationships.

		#endregion Non-Owned Inbound Relationships

		#endregion Inbound Relationships

		#region Outbound Relationships

		// This region contains the collection variables for referencing outbound related entity objects.
		// Outbound related entities are typically parent entities.

		// This entity has no outbound relationships.

		#endregion Outbound Relationships

		public BaseIndependentEntity2()
			: base()
		{
			Initialize_BaseIndependentEntity2();
		}

		public BaseIndependentEntity2(Guid instanceId)
			: base(instanceId)
		{
			Initialize_BaseIndependentEntity2();
		}

		private void Initialize_BaseIndependentEntity2()
		{
			PostInitialize_BaseIndependentEntity2();
		}

		protected virtual void PostInitialize_BaseIndependentEntity2()
		{
		}

		public override EntityType EntityType
		{
			get
			{
				return CustName.AppName.DAL.EntityType.Independent;
			}
		}

		public override EntityClass EntityClass
		{
			get
			{
				return CustName.AppName.DAL.EntityClass.IndependentEntity2;
			}
		}

		#region IEntityObjectContextItem Interface

		public override IIdentifier ContextKey
		{
			get
			{
				return (IIdentifier)this.objectData.ObjectId.Value;
			}
		}

		#endregion

		public IndependentEntity2Identifier? ObjectId
		{
			get
			{
				return this.objectData.ObjectId;
			}
			set
			{
				if (this.objectData.ObjectId != value)
				{
					this.objectData.ObjectId = value;
					NotifyPropertyChanged("ObjectId");
				}
			}
		}

		public virtual object ObjectId_DBObjectValue
		{
			get
			{
				return (this.ObjectId.HasValue ? (object)this.ObjectId.Value : (object)DBNull.Value);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.ObjectId = null;
				else
					this.ObjectId = (IndependentEntity2Identifier)value;
			}
		}

		public virtual int? IndependentEntity2Id
		{
			get
			{
				return (this.objectData.ObjectId.HasValue ? (int?)this.objectData.ObjectId.Value.IndependentEntity2Id : (int?)null);
			}
		}

		public virtual object IndependentEntity2Id_DBObjectValue
		{
			get
			{
				return (this.objectData.ObjectId.HasValue ? (object)this.objectData.ObjectId.Value.IndependentEntity2Id : (object)DBNull.Value);
			}
		}

		public override string ObjectPrimaryDescriptor
		{
			get
			{
				string name = null;
				if (this.Name != null)
				{
					name = this.Name.ToString();
				}
				if (name == null)
				{
					if (this.ObjectStatus == ObjectStatus.New)
						name = "<new>";
					else
						name = "<undefined>";
				}
				else if (name.Trim() == "")
				{
					name = "<blank>";
				}
				return name;
			}
		}

		public virtual bool? AttrBool1
		{
			get
			{
				return this.objectData.AttrBool1;
			}
			set
			{
				if (this.objectData.AttrBool1 != value)
				{
					this.objectData.AttrBool1 = value;
					NotifyPropertyChanged("AttrBool1");
				}
			}
		}

		public virtual object AttrBool1_DBObjectValue
		{
			get
			{
				return (this.AttrBool1.HasValue ? (object)this.AttrBool1.Value : (object)DBNull.Value);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.AttrBool1 = null;
				else
					switch (value.ToString())
					{
						case "Checked":
							this.AttrBool1 = true;
							break;
						case "Indeterminate":
							this.AttrBool1 = null;
							break;
						case "Unchecked":
							this.AttrBool1 = false;
							break;
						case "False":
							this.AttrBool1 = false;
							break;
						case "True":
							this.AttrBool1 = true;
							break;
						default:
							this.AttrBool1 = (System.Boolean?)value;
							break;
					}
			}
		}

		public virtual bool AttrBool1_NoNull
		{
			get
			{
				return this.AttrBool1.GetValueOrDefault();
			}
			set
			{
				this.AttrBool1 = value;
			}
		}

		public virtual DateTime? AttrDatetime1
		{
			get
			{
				return this.objectData.AttrDatetime1;
			}
			set
			{
				DateTime? dateOnly;
				if (value.HasValue)
					dateOnly = value.Value.Date;
				if (this.objectData.AttrDatetime1 != value)
				{
					this.objectData.AttrDatetime1 = value;
					NotifyPropertyChanged("AttrDatetime1");
				}
			}
		}

		public virtual object AttrDatetime1_DBObjectValue
		{
			get
			{
				return (this.AttrDatetime1.HasValue ? (object)this.AttrDatetime1.Value : (object)DBNull.Value);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.AttrDatetime1 = null;
				else
					this.AttrDatetime1 = (System.DateTime?)value;
			}
		}

		public virtual DateTime AttrDatetime1_NoNull
		{
			get
			{
				return this.AttrDatetime1.GetValueOrDefault();
			}
			set
			{
				this.AttrDatetime1 = value;
			}
		}

		public virtual int? AttrInteger1
		{
			get
			{
				return this.objectData.AttrInteger1;
			}
			set
			{
				if (this.objectData.AttrInteger1 != value)
				{
					this.objectData.AttrInteger1 = value;
					NotifyPropertyChanged("AttrInteger1");
				}
			}
		}

		public virtual object AttrInteger1_DBObjectValue
		{
			get
			{
				return (this.AttrInteger1.HasValue ? (object)this.AttrInteger1.Value : (object)DBNull.Value);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.AttrInteger1 = null;
				else
					this.AttrInteger1 = (System.Int32?)value;
			}
		}

		public virtual int AttrInteger1_NoNull
		{
			get
			{
				return this.AttrInteger1.GetValueOrDefault();
			}
			set
			{
				this.AttrInteger1 = value;
			}
		}

		public virtual string AttrString1
		{
			get
			{
				return this.objectData.AttrString1;
			}
			set
			{
				if (this.objectData.AttrString1 != value)
				{
					this.objectData.AttrString1 = value;
					NotifyPropertyChanged("AttrString1");
				}
			}
		}

		public virtual object AttrString1_DBObjectValue
		{
			get
			{
				return (this.AttrString1 == null ? (object)DBNull.Value : (object)this.AttrString1);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.AttrString1 = null;
				else
					this.AttrString1 = (System.String)value;
			}
		}

		public virtual string AttrString2
		{
			get
			{
				return this.objectData.AttrString2;
			}
			set
			{
				if (this.objectData.AttrString2 != value)
				{
					this.objectData.AttrString2 = value;
					NotifyPropertyChanged("AttrString2");
				}
			}
		}

		public virtual object AttrString2_DBObjectValue
		{
			get
			{
				return (this.AttrString2 == null ? (object)DBNull.Value : (object)this.AttrString2);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.AttrString2 = null;
				else
					this.AttrString2 = (System.String)value;
			}
		}

		public virtual string Name
		{
			get
			{
				return this.objectData.Name;
			}
			set
			{
				if (this.objectData.Name != value)
				{
					this.objectData.Name = value;
					NotifyPropertyChanged("Name");
				}
			}
		}

		public virtual object Name_DBObjectValue
		{
			get
			{
				return (this.Name == null ? (object)DBNull.Value : (object)this.Name);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.Name = null;
				else
					this.Name = (System.String)value;
			}
		}

		public virtual string Status
		{
			get
			{
				return this.objectData.Status;
			}
			set
			{
				if (this.objectData.Status != value)
				{
					this.objectData.Status = value;
					NotifyPropertyChanged("Status");
				}
			}
		}

		public virtual object Status_DBObjectValue
		{
			get
			{
				return (this.Status == null ? (object)DBNull.Value : (object)this.Status);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.Status = null;
				else
					this.Status = (System.String)value;
			}
		}

		// Will not work if all on-demand-load BLOB properties are not loaded.
		public override bool SameAs(IEntityObject obj)
		{
			IndependentEntity2 independentEntity2 = (IndependentEntity2)obj;
			return (base.SameAs(obj) && independentEntity2.ObjectId == this.objectData.ObjectId && this.objectData.AttrBool1 == independentEntity2.objectData.AttrBool1 && this.objectData.AttrDatetime1 == independentEntity2.objectData.AttrDatetime1 && this.objectData.AttrInteger1 == independentEntity2.objectData.AttrInteger1 && this.objectData.AttrString1 == independentEntity2.objectData.AttrString1 && this.objectData.AttrString2 == independentEntity2.objectData.AttrString2 && this.objectData.Name == independentEntity2.objectData.Name && this.objectData.Status == independentEntity2.objectData.Status);
		}

		public bool SameAs(IIndependentEntity2 obj)
		{
			return SameAs((IEntityObject)obj);
		}

		#region IEditableObject Related

		protected override void BackupObjectData()
		{
			base.BackupObjectData();
			this.objectDataBackup = this.objectData;
		}

		protected override void RestoreObjectData()
		{
			base.RestoreObjectData();
			this.objectData = this.objectDataBackup;
		}

		#endregion

		public override void PopulateFrom(IEntityObject source)
		{
			this.objectDataToCopy = ((IndependentEntity2)source).objectData;
			base.PopulateFrom(source);
		}

		protected override void CopySourceObjectDataToActive()
		{
			base.CopySourceObjectDataToActive();
			this.objectData = this.objectDataToCopy;
		}

		protected override void CompareObjectData(ObjectDataSet objectDataSet)
		{
			base.CompareObjectData(objectDataSet);

			ObjectData objectDataToCompare;
			if (objectDataSet == ObjectDataSet.Active)
			{
				this.objectDataChanges.ObjectIdPropertyChanged = false;
				this.objectDataChanges.AttrBool1PropertyChanged = false;
				this.objectDataChanges.AttrDatetime1PropertyChanged = false;
				this.objectDataChanges.AttrInteger1PropertyChanged = false;
				this.objectDataChanges.AttrString1PropertyChanged = false;
				this.objectDataChanges.AttrString2PropertyChanged = false;
				this.objectDataChanges.NamePropertyChanged = false;
				this.objectDataChanges.StatusPropertyChanged = false;
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
				this.objectDataChanges.ObjectIdPropertyChanged = (objectDataToCompare.ObjectId != objectData.ObjectId);
				this.objectDataChanges.AttrBool1PropertyChanged = (objectDataToCompare.AttrBool1 != objectData.AttrBool1);
				this.objectDataChanges.AttrDatetime1PropertyChanged = (objectDataToCompare.AttrDatetime1 != objectData.AttrDatetime1);
				this.objectDataChanges.AttrInteger1PropertyChanged = (objectDataToCompare.AttrInteger1 != objectData.AttrInteger1);
				this.objectDataChanges.AttrString1PropertyChanged = (objectDataToCompare.AttrString1 != objectData.AttrString1);
				this.objectDataChanges.AttrString2PropertyChanged = (objectDataToCompare.AttrString2 != objectData.AttrString2);
				this.objectDataChanges.NamePropertyChanged = (objectDataToCompare.Name != objectData.Name);
				this.objectDataChanges.StatusPropertyChanged = (objectDataToCompare.Status != objectData.Status);
			}
		}

		protected override void SendPropertyChangeNotifications()
		{
			base.SendPropertyChangeNotifications();
			if (this.objectDataChanges.ObjectIdPropertyChanged) OnPropertyChanged("ObjectId");
			if (this.objectDataChanges.AttrBool1PropertyChanged) OnPropertyChanged("AttrBool1");
			if (this.objectDataChanges.AttrDatetime1PropertyChanged) OnPropertyChanged("AttrDatetime1");
			if (this.objectDataChanges.AttrInteger1PropertyChanged) OnPropertyChanged("AttrInteger1");
			if (this.objectDataChanges.AttrString1PropertyChanged) OnPropertyChanged("AttrString1");
			if (this.objectDataChanges.AttrString2PropertyChanged) OnPropertyChanged("AttrString2");
			if (this.objectDataChanges.NamePropertyChanged) OnPropertyChanged("Name");
			if (this.objectDataChanges.StatusPropertyChanged) OnPropertyChanged("Status");
		}

		#region INotifyPropertyChanged Related

		protected override void NotifyPropertyChanged(string propertyName)
		{
			base.NotifyPropertyChanged(propertyName);
			if (propertyName == "Name")
				base.NotifyPropertyChanged("ObjectPrimaryDescriptor");
		}

		#endregion

		// ========================================================================================================================

		#region Inbound Relationships

		#region Owned Inbound Relationships

		#region RelationshipEntity1 Relationship

		public LoadStatus ChildOwnedRelationshipEntity1ListLoadStatus
		{
			get
			{
				return this.childOwnedRelationshipEntity1ListLoadStatus;
			}
		}

		public RelationshipEntity1List ChildOwnedRelationshipEntity1List
		{
			get
			{
				// If the collection has not been populated, automatically load it.
				// This enables UIs to display without having to issue explicit commands to load related entity objects.
				if (this.childOwnedRelationshipEntity1ListLoadStatus == LoadStatus.NotLoaded)
					LoadChildOwnedRelationshipEntity1List();
				return this.childOwnedRelationshipEntity1List;
			}
		}

		IRelationshipEntity1List IIndependentEntity2.ChildOwnedRelationshipEntity1List
		{
			get
			{
				return (IRelationshipEntity1List)this.ChildOwnedRelationshipEntity1List;
			}
		}

		// Load a single entity object into the collection.
		public RelationshipEntity1List LoadChildOwnedRelationshipEntity1List(RelationshipEntity1 relationshipEntity1)
		{
			// Make sure the collection object has been created.
			if (this.childOwnedRelationshipEntity1ListLoadStatus == LoadStatus.NotLoaded)
			{
				SetupChildOwnedRelationshipEntity1List(null); // Null instructs SetupChildOwnedRelationshipEntity1List to create a new collection object.
				if (this.ObjectId.HasValue)
					// The object exists in the repository. It is possible that more associated entity objects also exist in the repository.
					this.childOwnedRelationshipEntity1ListLoadStatus = LoadStatus.Partial;
				else
					// The object has not yet been saved and therefore cannot have associated entity objects in the repository.
					this.childOwnedRelationshipEntity1ListLoadStatus = LoadStatus.Full;
			}

			if (relationshipEntity1 != null)
			{
				// Append given entity object to the collection if it isn't already a member.
				// List.Contains call is important because this method may be called to load an unsaved entity object.
				// Since unsaved entity objects have no object id assigned, the only way to determine if they already exist in a collection or not is to call List.Contains.
				if (!this.childOwnedRelationshipEntity1List.Contains(relationshipEntity1))
				{
					bool alreadyInList = false;
					foreach (RelationshipEntity1 childOwnedRelationshipEntity1 in this.childOwnedRelationshipEntity1List)
					{
						if ((childOwnedRelationshipEntity1.ObjectId != null) && (childOwnedRelationshipEntity1.ObjectId == relationshipEntity1.ObjectId))
						{
							alreadyInList = true;
							break;
						}
					}
					if (!alreadyInList) this.childOwnedRelationshipEntity1List.Add(relationshipEntity1); // Add method automatically sets object's parentList pointer to itself.
				}
			}

			return this.childOwnedRelationshipEntity1List;
		}

		IRelationshipEntity1List IIndependentEntity2.LoadChildOwnedRelationshipEntity1List(IRelationshipEntity1 relationshipEntity1)
		{
			return (IRelationshipEntity1List)this.LoadChildOwnedRelationshipEntity1List((RelationshipEntity1)relationshipEntity1);
		}

		// Load collection from repository.
		public RelationshipEntity1List LoadChildOwnedRelationshipEntity1List()
		{
			LoadStatus loadStatus = this.childOwnedRelationshipEntity1ListLoadStatus;
			if (loadStatus == LoadStatus.Partial)
			{
				// The collection object has already been created, complete with ListChanged event handler.
				// It contains zero or more associated RelationshipEntity1 entity objects.
				// All that needs to be done here is to add any remaining associated RelationshipEntity1 objects that exist in the repository.
				// If this object has not yet been saved, the implication is that there can exist no associated entity objects in the repository.
				if (this.ObjectId != null)
				{
					// Get the associated entity objects from the repository.
					RelationshipEntity1List list = (RelationshipEntity1List)CustName.AppName.BL.Global.ClassFactory.GetDALRepository().FindRelationshipEntity1(-1, new SearchCondition().AppendSearchCondition(RelationshipEntity1PropertyName.ParentOwnerIndependentEntity2EntityObjectId, SearchConditionExpressionOperator.Equal, this.ObjectId), CustName.AppName.BL.Global.ClassFactory.GetDALRepository().IndependentEntity2_ChildOwnedRelationshipEntity1SortSpecification, ((IEntityObjectContextItem)this).Context);

					// Append the entity objects just loaded from the repository to the collection, except those already in the collection to begin with.
					int preExistingItemCount = this.childOwnedRelationshipEntity1List.Count;
					bool alreadyInList;
					RelationshipEntity1Identifier? preExistingObjectId;
					foreach (RelationshipEntity1 entityObject in list)
					{
						// Search only the preexisting items in the collection for a match.
						// If no match found, the current entity object can be added to the collection without risk of it being a duplicate.
						alreadyInList = false;
						for (int index = 0; index < preExistingItemCount; ++index)
						{
							// Bypass entity objects that have not been saved.
							// They cannot possibly match an entity from the repository.
							// List.Contains does not need to be used here because the Repository.FindRelationshipEntity1 call returns new objects that are guaranteed to have ObjectId set.
							if ((preExistingObjectId = this.childOwnedRelationshipEntity1List[index].ObjectId) != null)
								if (alreadyInList = (preExistingObjectId == entityObject.ObjectId))
									break;
						}
						if (!alreadyInList) this.childOwnedRelationshipEntity1List.Add(entityObject);
					}
				}
			}
			else if (loadStatus == LoadStatus.NotLoaded)
			{
				// The collection object has not yet been created.
				// Create it and populate it with all the associated RelationshipEntity1 entity objects in the repository.
				if (this.ObjectId.HasValue)
				{
					RelationshipEntity1List list = (RelationshipEntity1List)CustName.AppName.BL.Global.ClassFactory.GetDALRepository().FindRelationshipEntity1(-1, new SearchCondition().AppendSearchCondition(RelationshipEntity1PropertyName.ParentOwnerIndependentEntity2EntityObjectId, SearchConditionExpressionOperator.Equal, this.ObjectId), CustName.AppName.BL.Global.ClassFactory.GetDALRepository().IndependentEntity2_ChildOwnedRelationshipEntity1SortSpecification, ((IEntityObjectContextItem)this).Context);
					SetupChildOwnedRelationshipEntity1List(list);
				}
				else
				{
					// This object has not been saved yet.
					// Therefore, it cannot have any associated entity objects related to it in the repository.
					// Create an empty collection instead.
					SetupChildOwnedRelationshipEntity1List(null); // Null instructs SetupChildOwnedRelationshipEntity1List to create a new collection object.
				}
			}
			this.childOwnedRelationshipEntity1ListLoadStatus = LoadStatus.Full;
			return this.childOwnedRelationshipEntity1List;
		}

		IRelationshipEntity1List IIndependentEntity2.LoadChildOwnedRelationshipEntity1List()
		{
			return (IRelationshipEntity1List)LoadChildOwnedRelationshipEntity1List();
		}

		private void SetupChildOwnedRelationshipEntity1List(RelationshipEntity1List list)
		{
			// If no collection object specified, create an empty collection.
			RelationshipEntity1List _list;
			if ((_list = list) == null) _list = (RelationshipEntity1List)CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(CustName.AppName.DAL.EntityClass.RelationshipEntity1);

			// Register a ListChanged event handler with the collection.
			// Because the collection holds owned entity objects, the parent needs to be aware of any changes made to them in order to correctly set its own commit status.
			// Changes in an owned entity object imply parent entity object is changed.
			this.childOwnedRelationshipEntity1ListChangedEventHandler = new System.ComponentModel.ListChangedEventHandler(ChildOwnedRelationshipEntity1List_ListChanged);
			_list.ListChanged += this.childOwnedRelationshipEntity1ListChangedEventHandler;

			// Link the collection into the object hierarchy.
			_list.Parent = (IEntityObject)this;
			_list.CollectionName = CollectionName.IndependentEntity2_ChildOwnedRelationshipEntity1List;
			this.childOwnedRelationshipEntity1List = _list;
		}

		public void UnloadChildOwnedRelationshipEntity1List()
		{
			if (this.childOwnedRelationshipEntity1List != null)
			{
				if (this.childOwnedRelationshipEntity1ListChangedEventHandler != null)
					this.childOwnedRelationshipEntity1List.ListChanged -= this.childOwnedRelationshipEntity1ListChangedEventHandler;
				this.childOwnedRelationshipEntity1List.Parent = null;
			}
			this.childOwnedRelationshipEntity1List = null;
			this.childOwnedRelationshipEntity1ListLoadStatus = LoadStatus.NotLoaded;
		}

		void IIndependentEntity2.UnloadChildOwnedRelationshipEntity1List()
		{
			UnloadChildOwnedRelationshipEntity1List();
		}

		public bool HasChildOwnedRelationshipEntity1Objects(bool inMemoryOnly)
		{
			if (this.childOwnedRelationshipEntity1List == null)
				return false;
			else
				return (this.childOwnedRelationshipEntity1List.Count > 0);
		}

		protected virtual void ChildOwnedRelationshipEntity1List_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		{
			this.HasUncommittedChanges = true;
		}

		#endregion RelationshipEntity1 Relationship

		#endregion // Owned Inbound Relationships

		#region Non-Owned Inbound Relationships

		// This entity has no non-owned inbound relationships.

		#endregion // Non-Owned Inbound Relationships

		#endregion // Inbound Relationships

		// ========================================================================================================================

		#region Outbound Relationships

		#region Owner Outbound Relationships

		// This entity has no owner outbound relationships.

		#endregion // Owner Outbound Relationships

		#region Non-Owner Outbound Relationships

		// This entity has no non-owner outbound relationships.

		#endregion // Non-Owner Outbound Relationships

		#endregion // Outbound Relationships

		// ========================================================================================================================

		public override void Load(bool recurse)
		{
			// RelationshipEntity1 Relationship
			if (childOwnedRelationshipEntity1ListLoadStatus != LoadStatus.Full)
			{
				LoadChildOwnedRelationshipEntity1List();
				if (recurse)
				{
					foreach (RelationshipEntity1 relationshipEntity1 in childOwnedRelationshipEntity1List)
					{
						relationshipEntity1.Load(true);
					}
				}
			}
		}

		public override IList<IEntityObject> GetOwnedObjects(bool loaded, IList<IEntityObject> list)
		{
			return null;
		}

		public IndependentEntity2 Copy(bool recurse)
		{
			return CopyImpl(recurse);
		}

		IIndependentEntity2 IIndependentEntity2.Copy(bool recurse)
		{
			return (IIndependentEntity2)CopyImpl(recurse);
		}

		protected IndependentEntity2 CopyImpl(bool recurse)
		{
			IndependentEntity2 newIndependentEntity2 = (IndependentEntity2)CustName.AppName.BL.Global.ClassFactory.GetEntityObject(CustName.AppName.DAL.EntityClass.IndependentEntity2);
			newIndependentEntity2.PopulateFrom(this);
			newIndependentEntity2.ObjectId = null;
			if (recurse)
			{
				this.LoadChildOwnedRelationshipEntity1List();
				foreach (RelationshipEntity1 relationshipEntity1 in this.ChildOwnedRelationshipEntity1List)
				{
					newIndependentEntity2.ChildOwnedRelationshipEntity1List.Add(relationshipEntity1.Copy(true));
				}
			}
			return newIndependentEntity2;
		}

		// ========================================================================================================================

		#region Outbound Relationships Properties

		#region Owner Outbound Relationships Properties

		// This entity has no owner outbound relationships.

		#endregion // Owner Outbound Relationships Properties

		#region Non-Owner Outbound Relationships Properties

		// This entity has no non-owner outbound relationships.

		#endregion // Non-Owner Outbound Relationships Properties

		#endregion // Outbound Relationships Properties

		// ========================================================================================================================
	}

	public abstract class BaseRelationshipEntity1 : EntityObject, IRelationshipEntity1
	{
		private struct ObjectData
		{
			// Structure for primary key fields.
			public RelationshipEntity1Identifier? ObjectId;
			// Structure for foreign key fields associated with the DependentEntity2 owner relationship.
			public DependentEntity2Identifier? ParentOwnerDependentEntity2EntityObjectId;
			// Structure for foreign key fields associated with the IndependentEntity2 owner relationship.
			public IndependentEntity2Identifier? ParentOwnerIndependentEntity2EntityObjectId;
			public bool? AttrBool1;
			public DateTime? AttrDatetime1;
			public int? AttrInteger1;
			public string AttrString1;
			public string AttrString2;
			public string Name;
			public string Status;
		}

		private struct ObjectDataChanges
		{
			public bool ObjectIdPropertyChanged;
			public bool ParentOwnerDependentEntity2EntityObjectIdPropertyChanged;
			public bool ParentOwnerIndependentEntity2EntityObjectIdPropertyChanged;
			public bool AttrBool1PropertyChanged;
			public bool AttrDatetime1PropertyChanged;
			public bool AttrInteger1PropertyChanged;
			public bool AttrString1PropertyChanged;
			public bool AttrString2PropertyChanged;
			public bool NamePropertyChanged;
			public bool StatusPropertyChanged;
		}

		private ObjectData objectData;
		private ObjectData objectDataBackup;
		private ObjectData objectDataToCopy;
		private ObjectDataChanges objectDataChanges;

		#region Inbound Relationships

		// This region contains the collection variables for referencing inbound related entity objects.
		// Inbound related entities are typically dependent entities.

		// This entity has no inbound relationships.

		#endregion Inbound Relationships

		#region Outbound Relationships

		// This region contains the collection variables for referencing outbound related entity objects.
		// Outbound related entities are typically parent entities.

		#region Owner Outbound Relationships

		// DependentEntity2 Relationship
		// References childOwnedRelationshipEntity1List collection of DependentEntity2.
		// Alias for EntityObject.ParentList.
		private RelationshipEntity1List parentOwnerDependentEntity2_RelationshipEntity1List;
		// Indicates if attempt has been made to get a reference to the collection.
		// If attempt fails, collection reference will remain null.
		// Flag applicable only when parentOwnerDependentEntity2_RelationshipEntity1List is null.
		private bool parentOwnerDependentEntity2_RelationshipEntity1ListPartialLoadAttempted = false;
		// IndependentEntity2 Relationship
		// References childOwnedRelationshipEntity1List collection of IndependentEntity2.
		// Alias for EntityObject.ParentList.
		private RelationshipEntity1List parentOwnerIndependentEntity2_RelationshipEntity1List;
		// Indicates if attempt has been made to get a reference to the collection.
		// If attempt fails, collection reference will remain null.
		// Flag applicable only when parentOwnerIndependentEntity2_RelationshipEntity1List is null.
		private bool parentOwnerIndependentEntity2_RelationshipEntity1ListPartialLoadAttempted = false;

		#endregion Owner Outbound Relationships

		#region Non-Owner Outbound Relationships

		// This entity has no non-owner outbound relationships.

		#endregion Non-Owned Outbound Relationships

		#endregion Outbound Relationships

		public BaseRelationshipEntity1()
			: base()
		{
			Initialize_BaseRelationshipEntity1();
		}

		public BaseRelationshipEntity1(Guid instanceId)
			: base(instanceId)
		{
			Initialize_BaseRelationshipEntity1();
		}

		private void Initialize_BaseRelationshipEntity1()
		{
			PostInitialize_BaseRelationshipEntity1();
		}

		protected virtual void PostInitialize_BaseRelationshipEntity1()
		{
		}

		public override EntityType EntityType
		{
			get
			{
				return CustName.AppName.DAL.EntityType.Relationship;
			}
		}

		public override EntityClass EntityClass
		{
			get
			{
				return CustName.AppName.DAL.EntityClass.RelationshipEntity1;
			}
		}

		#region IEntityObjectContextItem Interface

		public override IIdentifier ContextKey
		{
			get
			{
				return (IIdentifier)this.objectData.ObjectId.Value;
			}
		}

		#endregion

		public RelationshipEntity1Identifier? ObjectId
		{
			get
			{
				return this.objectData.ObjectId;
			}
			set
			{
				if (this.objectData.ObjectId != value)
				{
					this.objectData.ObjectId = value;
					NotifyPropertyChanged("ObjectId");
				}
			}
		}

		public virtual object ObjectId_DBObjectValue
		{
			get
			{
				return (this.ObjectId.HasValue ? (object)this.ObjectId.Value : (object)DBNull.Value);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.ObjectId = null;
				else
					this.ObjectId = (RelationshipEntity1Identifier)value;
			}
		}

		public virtual int? RelationshipEntity1Id
		{
			get
			{
				return (this.objectData.ObjectId.HasValue ? (int?)this.objectData.ObjectId.Value.RelationshipEntity1Id : (int?)null);
			}
		}

		public virtual object RelationshipEntity1Id_DBObjectValue
		{
			get
			{
				return (this.objectData.ObjectId.HasValue ? (object)this.objectData.ObjectId.Value.RelationshipEntity1Id : (object)DBNull.Value);
			}
		}

		public override string ObjectPrimaryDescriptor
		{
			get
			{
				string name = null;
				if (this.Name != null)
				{
					name = this.Name.ToString();
				}
				if (name == null)
				{
					if (this.ObjectStatus == ObjectStatus.New)
						name = "<new>";
					else
						name = "<undefined>";
				}
				else if (name.Trim() == "")
				{
					name = "<blank>";
				}
				return name;
			}
		}

		public virtual bool? AttrBool1
		{
			get
			{
				return this.objectData.AttrBool1;
			}
			set
			{
				if (this.objectData.AttrBool1 != value)
				{
					this.objectData.AttrBool1 = value;
					NotifyPropertyChanged("AttrBool1");
				}
			}
		}

		public virtual object AttrBool1_DBObjectValue
		{
			get
			{
				return (this.AttrBool1.HasValue ? (object)this.AttrBool1.Value : (object)DBNull.Value);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.AttrBool1 = null;
				else
					switch (value.ToString())
					{
						case "Checked":
							this.AttrBool1 = true;
							break;
						case "Indeterminate":
							this.AttrBool1 = null;
							break;
						case "Unchecked":
							this.AttrBool1 = false;
							break;
						case "False":
							this.AttrBool1 = false;
							break;
						case "True":
							this.AttrBool1 = true;
							break;
						default:
							this.AttrBool1 = (System.Boolean?)value;
							break;
					}
			}
		}

		public virtual bool AttrBool1_NoNull
		{
			get
			{
				return this.AttrBool1.GetValueOrDefault();
			}
			set
			{
				this.AttrBool1 = value;
			}
		}

		public virtual DateTime? AttrDatetime1
		{
			get
			{
				return this.objectData.AttrDatetime1;
			}
			set
			{
				DateTime? dateOnly;
				if (value.HasValue)
					dateOnly = value.Value.Date;
				if (this.objectData.AttrDatetime1 != value)
				{
					this.objectData.AttrDatetime1 = value;
					NotifyPropertyChanged("AttrDatetime1");
				}
			}
		}

		public virtual object AttrDatetime1_DBObjectValue
		{
			get
			{
				return (this.AttrDatetime1.HasValue ? (object)this.AttrDatetime1.Value : (object)DBNull.Value);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.AttrDatetime1 = null;
				else
					this.AttrDatetime1 = (System.DateTime?)value;
			}
		}

		public virtual DateTime AttrDatetime1_NoNull
		{
			get
			{
				return this.AttrDatetime1.GetValueOrDefault();
			}
			set
			{
				this.AttrDatetime1 = value;
			}
		}

		public virtual int? AttrInteger1
		{
			get
			{
				return this.objectData.AttrInteger1;
			}
			set
			{
				if (this.objectData.AttrInteger1 != value)
				{
					this.objectData.AttrInteger1 = value;
					NotifyPropertyChanged("AttrInteger1");
				}
			}
		}

		public virtual object AttrInteger1_DBObjectValue
		{
			get
			{
				return (this.AttrInteger1.HasValue ? (object)this.AttrInteger1.Value : (object)DBNull.Value);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.AttrInteger1 = null;
				else
					this.AttrInteger1 = (System.Int32?)value;
			}
		}

		public virtual int AttrInteger1_NoNull
		{
			get
			{
				return this.AttrInteger1.GetValueOrDefault();
			}
			set
			{
				this.AttrInteger1 = value;
			}
		}

		public virtual string AttrString1
		{
			get
			{
				return this.objectData.AttrString1;
			}
			set
			{
				if (this.objectData.AttrString1 != value)
				{
					this.objectData.AttrString1 = value;
					NotifyPropertyChanged("AttrString1");
				}
			}
		}

		public virtual object AttrString1_DBObjectValue
		{
			get
			{
				return (this.AttrString1 == null ? (object)DBNull.Value : (object)this.AttrString1);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.AttrString1 = null;
				else
					this.AttrString1 = (System.String)value;
			}
		}

		public virtual string AttrString2
		{
			get
			{
				return this.objectData.AttrString2;
			}
			set
			{
				if (this.objectData.AttrString2 != value)
				{
					this.objectData.AttrString2 = value;
					NotifyPropertyChanged("AttrString2");
				}
			}
		}

		public virtual object AttrString2_DBObjectValue
		{
			get
			{
				return (this.AttrString2 == null ? (object)DBNull.Value : (object)this.AttrString2);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.AttrString2 = null;
				else
					this.AttrString2 = (System.String)value;
			}
		}

		public virtual string Name
		{
			get
			{
				return this.objectData.Name;
			}
			set
			{
				if (this.objectData.Name != value)
				{
					this.objectData.Name = value;
					NotifyPropertyChanged("Name");
				}
			}
		}

		public virtual object Name_DBObjectValue
		{
			get
			{
				return (this.Name == null ? (object)DBNull.Value : (object)this.Name);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.Name = null;
				else
					this.Name = (System.String)value;
			}
		}

		public virtual string Status
		{
			get
			{
				return this.objectData.Status;
			}
			set
			{
				if (this.objectData.Status != value)
				{
					this.objectData.Status = value;
					NotifyPropertyChanged("Status");
				}
			}
		}

		public virtual object Status_DBObjectValue
		{
			get
			{
				return (this.Status == null ? (object)DBNull.Value : (object)this.Status);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.Status = null;
				else
					this.Status = (System.String)value;
			}
		}

		public DependentEntity2Identifier? ParentOwnerDependentEntity2EntityObjectId
		{
			get
			{
				if (this.parentOwnerDependentEntity2_RelationshipEntity1List == null)
					return this.objectData.ParentOwnerDependentEntity2EntityObjectId;
				else
					return ((DependentEntity2)this.parentOwnerDependentEntity2_RelationshipEntity1List.Parent).ObjectId;
			}
			set
			{
				if (this.parentOwnerDependentEntity2_RelationshipEntity1List == null)
				{
					bool valueChanged = false;
					if (this.parentOwnerDependentEntity2_RelationshipEntity1ListPartialLoadAttempted)
						// Implies objectData.ParentOwnerDependentEntity2EntityObjectId points to non-existent object in the repository.
						UnloadParentOwnerDependentEntity2_RelationshipEntity1List();
					// At this point parentOwnerDependentEntity2_RelationshipEntity1List is UNLOADED.
					if (this.objectData.ParentOwnerDependentEntity2EntityObjectId != value)
					{
						this.objectData.ParentOwnerDependentEntity2EntityObjectId = value;
						valueChanged = true;
					}
					if (valueChanged)
						NotifyPropertyChanged("ParentOwnerDependentEntity2EntityObjectId");
				}
				else
				{
					// At this point parentOwnerDependentEntity2_RelationshipEntity1List is LOADED.
					if (((DependentEntity2)this.parentOwnerDependentEntity2_RelationshipEntity1List.Parent).ObjectId != value)
					{
						// The supplied foreign object id does not match the currently linked entity object.
						// parentOwnerDependentEntity2_RelationshipEntity1List must therefore be unloaded.
						UnloadParentOwnerDependentEntity2_RelationshipEntity1List();
						this.objectData.ParentOwnerDependentEntity2EntityObjectId = value;
						// NotifyPropertyChanged notification is required because ParentOwnerDependentEntity2EntityObjectId will return a different value.
						NotifyPropertyChanged("ParentOwnerDependentEntity2EntityObjectId");
					}
					else
					{
						// Set objectData.ParentOwnerDependentEntity2EntityObjectId to new value in case parentOwnerDependentEntity2_RelationshipEntity1List is unloaded.
						this.objectData.ParentOwnerDependentEntity2EntityObjectId = value;
						// There is no need for a NotifyPropertyChanged notification because ParentOwnerDependentEntity2EntityObjectId will not return a different value.
					}
				}
			}
		}

		public virtual object ParentOwnerDependentEntity2EntityObjectId_DBObjectValue
		{
			get
			{
				return (this.ParentOwnerDependentEntity2EntityObjectId.HasValue ? (object)this.ParentOwnerDependentEntity2EntityObjectId.Value : (object)DBNull.Value);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.ParentOwnerDependentEntity2EntityObjectId = null;
				else
					this.ParentOwnerDependentEntity2EntityObjectId = (DependentEntity2Identifier)value;
			}
		}

		public virtual int? DependentEntity2Id
		{
			get
			{
				DependentEntity2Identifier? identifier = this.ParentOwnerDependentEntity2EntityObjectId;
				return (identifier.HasValue ? (int?)identifier.Value.DependentEntity2Id : (int?)null);
			}
		}

		public virtual object DependentEntity2Id_DBObjectValue
		{
			get
			{
				DependentEntity2Identifier? identifier = this.ParentOwnerDependentEntity2EntityObjectId;
				return (identifier.HasValue ? (object)identifier.Value.DependentEntity2Id : (object)DBNull.Value);
			}
		}

		public IndependentEntity2Identifier? ParentOwnerIndependentEntity2EntityObjectId
		{
			get
			{
				if (this.parentOwnerIndependentEntity2_RelationshipEntity1List == null)
					return this.objectData.ParentOwnerIndependentEntity2EntityObjectId;
				else
					return ((IndependentEntity2)this.parentOwnerIndependentEntity2_RelationshipEntity1List.Parent).ObjectId;
			}
			set
			{
				if (this.parentOwnerIndependentEntity2_RelationshipEntity1List == null)
				{
					bool valueChanged = false;
					if (this.parentOwnerIndependentEntity2_RelationshipEntity1ListPartialLoadAttempted)
						// Implies objectData.ParentOwnerIndependentEntity2EntityObjectId points to non-existent object in the repository.
						UnloadParentOwnerIndependentEntity2_RelationshipEntity1List();
					// At this point parentOwnerIndependentEntity2_RelationshipEntity1List is UNLOADED.
					if (this.objectData.ParentOwnerIndependentEntity2EntityObjectId != value)
					{
						this.objectData.ParentOwnerIndependentEntity2EntityObjectId = value;
						valueChanged = true;
					}
					if (valueChanged)
						NotifyPropertyChanged("ParentOwnerIndependentEntity2EntityObjectId");
				}
				else
				{
					// At this point parentOwnerIndependentEntity2_RelationshipEntity1List is LOADED.
					if (((IndependentEntity2)this.parentOwnerIndependentEntity2_RelationshipEntity1List.Parent).ObjectId != value)
					{
						// The supplied foreign object id does not match the currently linked entity object.
						// parentOwnerIndependentEntity2_RelationshipEntity1List must therefore be unloaded.
						UnloadParentOwnerIndependentEntity2_RelationshipEntity1List();
						this.objectData.ParentOwnerIndependentEntity2EntityObjectId = value;
						// NotifyPropertyChanged notification is required because ParentOwnerIndependentEntity2EntityObjectId will return a different value.
						NotifyPropertyChanged("ParentOwnerIndependentEntity2EntityObjectId");
					}
					else
					{
						// Set objectData.ParentOwnerIndependentEntity2EntityObjectId to new value in case parentOwnerIndependentEntity2_RelationshipEntity1List is unloaded.
						this.objectData.ParentOwnerIndependentEntity2EntityObjectId = value;
						// There is no need for a NotifyPropertyChanged notification because ParentOwnerIndependentEntity2EntityObjectId will not return a different value.
					}
				}
			}
		}

		public virtual object ParentOwnerIndependentEntity2EntityObjectId_DBObjectValue
		{
			get
			{
				return (this.ParentOwnerIndependentEntity2EntityObjectId.HasValue ? (object)this.ParentOwnerIndependentEntity2EntityObjectId.Value : (object)DBNull.Value);
			}
			set
			{
				if (value == null || value == DBNull.Value)
					this.ParentOwnerIndependentEntity2EntityObjectId = null;
				else
					this.ParentOwnerIndependentEntity2EntityObjectId = (IndependentEntity2Identifier)value;
			}
		}

		public virtual int? IndependentEntity2Id
		{
			get
			{
				IndependentEntity2Identifier? identifier = this.ParentOwnerIndependentEntity2EntityObjectId;
				return (identifier.HasValue ? (int?)identifier.Value.IndependentEntity2Id : (int?)null);
			}
		}

		public virtual object IndependentEntity2Id_DBObjectValue
		{
			get
			{
				IndependentEntity2Identifier? identifier = this.ParentOwnerIndependentEntity2EntityObjectId;
				return (identifier.HasValue ? (object)identifier.Value.IndependentEntity2Id : (object)DBNull.Value);
			}
		}

		// Will not work if all on-demand-load BLOB properties are not loaded.
		public override bool SameAs(IEntityObject obj)
		{
			RelationshipEntity1 relationshipEntity1 = (RelationshipEntity1)obj;
			return (base.SameAs(obj) && relationshipEntity1.ObjectId == this.objectData.ObjectId && this.objectData.ParentOwnerDependentEntity2EntityObjectId == null && this.objectData.ParentOwnerIndependentEntity2EntityObjectId == null && this.objectData.AttrBool1 == relationshipEntity1.objectData.AttrBool1 && this.objectData.AttrDatetime1 == relationshipEntity1.objectData.AttrDatetime1 && this.objectData.AttrInteger1 == relationshipEntity1.objectData.AttrInteger1 && this.objectData.AttrString1 == relationshipEntity1.objectData.AttrString1 && this.objectData.AttrString2 == relationshipEntity1.objectData.AttrString2 && this.objectData.Name == relationshipEntity1.objectData.Name && this.objectData.Status == relationshipEntity1.objectData.Status);
		}

		public bool SameAs(IRelationshipEntity1 obj)
		{
			return SameAs((IEntityObject)obj);
		}

		#region IEditableObject Related

		protected override void BackupObjectData()
		{
			base.BackupObjectData();
			this.objectDataBackup = this.objectData;
		}

		protected override void RestoreObjectData()
		{
			base.RestoreObjectData();
			this.objectData = this.objectDataBackup;
		}

		#endregion

		public override void PopulateFrom(IEntityObject source)
		{
			this.objectDataToCopy = ((RelationshipEntity1)source).objectData;
			base.PopulateFrom(source);
		}

		protected override void CopySourceObjectDataToActive()
		{
			base.CopySourceObjectDataToActive();
			this.objectData = this.objectDataToCopy;
		}

		protected override void CompareObjectData(ObjectDataSet objectDataSet)
		{
			base.CompareObjectData(objectDataSet);

			ObjectData objectDataToCompare;
			if (objectDataSet == ObjectDataSet.Active)
			{
				this.objectDataChanges.ObjectIdPropertyChanged = false;
				this.objectDataChanges.ParentOwnerDependentEntity2EntityObjectIdPropertyChanged = false;
				this.objectDataChanges.ParentOwnerIndependentEntity2EntityObjectIdPropertyChanged = false;
				this.objectDataChanges.AttrBool1PropertyChanged = false;
				this.objectDataChanges.AttrDatetime1PropertyChanged = false;
				this.objectDataChanges.AttrInteger1PropertyChanged = false;
				this.objectDataChanges.AttrString1PropertyChanged = false;
				this.objectDataChanges.AttrString2PropertyChanged = false;
				this.objectDataChanges.NamePropertyChanged = false;
				this.objectDataChanges.StatusPropertyChanged = false;
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
				this.objectDataChanges.ObjectIdPropertyChanged = (objectDataToCompare.ObjectId != objectData.ObjectId);
				this.objectDataChanges.ParentOwnerDependentEntity2EntityObjectIdPropertyChanged = (objectDataToCompare.ParentOwnerDependentEntity2EntityObjectId != objectData.ParentOwnerDependentEntity2EntityObjectId);
				this.objectDataChanges.ParentOwnerIndependentEntity2EntityObjectIdPropertyChanged = (objectDataToCompare.ParentOwnerIndependentEntity2EntityObjectId != objectData.ParentOwnerIndependentEntity2EntityObjectId);
				this.objectDataChanges.AttrBool1PropertyChanged = (objectDataToCompare.AttrBool1 != objectData.AttrBool1);
				this.objectDataChanges.AttrDatetime1PropertyChanged = (objectDataToCompare.AttrDatetime1 != objectData.AttrDatetime1);
				this.objectDataChanges.AttrInteger1PropertyChanged = (objectDataToCompare.AttrInteger1 != objectData.AttrInteger1);
				this.objectDataChanges.AttrString1PropertyChanged = (objectDataToCompare.AttrString1 != objectData.AttrString1);
				this.objectDataChanges.AttrString2PropertyChanged = (objectDataToCompare.AttrString2 != objectData.AttrString2);
				this.objectDataChanges.NamePropertyChanged = (objectDataToCompare.Name != objectData.Name);
				this.objectDataChanges.StatusPropertyChanged = (objectDataToCompare.Status != objectData.Status);
			}
		}

		protected override void SendPropertyChangeNotifications()
		{
			base.SendPropertyChangeNotifications();
			if (this.objectDataChanges.ObjectIdPropertyChanged) OnPropertyChanged("ObjectId");
			if (this.objectDataChanges.ParentOwnerDependentEntity2EntityObjectIdPropertyChanged) OnPropertyChanged("ParentOwnerDependentEntity2EntityObjectId");
			if (this.objectDataChanges.ParentOwnerIndependentEntity2EntityObjectIdPropertyChanged) OnPropertyChanged("ParentOwnerIndependentEntity2EntityObjectId");
			if (this.objectDataChanges.AttrBool1PropertyChanged) OnPropertyChanged("AttrBool1");
			if (this.objectDataChanges.AttrDatetime1PropertyChanged) OnPropertyChanged("AttrDatetime1");
			if (this.objectDataChanges.AttrInteger1PropertyChanged) OnPropertyChanged("AttrInteger1");
			if (this.objectDataChanges.AttrString1PropertyChanged) OnPropertyChanged("AttrString1");
			if (this.objectDataChanges.AttrString2PropertyChanged) OnPropertyChanged("AttrString2");
			if (this.objectDataChanges.NamePropertyChanged) OnPropertyChanged("Name");
			if (this.objectDataChanges.StatusPropertyChanged) OnPropertyChanged("Status");
		}

		#region INotifyPropertyChanged Related

		protected override void NotifyPropertyChanged(string propertyName)
		{
			base.NotifyPropertyChanged(propertyName);
			if (propertyName == "Name")
				base.NotifyPropertyChanged("ObjectPrimaryDescriptor");
		}

		#endregion

		// ========================================================================================================================

		#region Inbound Relationships

		#region Owned Inbound Relationships

		// This entity has no owned inbound relationships.

		#endregion // Owned Inbound Relationships

		#region Non-Owned Inbound Relationships

		// This entity has no non-owned inbound relationships.

		#endregion // Non-Owned Inbound Relationships

		#endregion // Inbound Relationships

		// ========================================================================================================================

		#region Outbound Relationships

		#region Owner Outbound Relationships


		#region DependentEntity2 Relationship

		public bool ParentOwnerDependentEntity2_RelationshipEntity1ListPartialLoadAttempted
		{
			get
			{
				if (this.parentOwnerDependentEntity2_RelationshipEntity1List == null)
					return this.parentOwnerDependentEntity2_RelationshipEntity1ListPartialLoadAttempted;
				else
					return true;
			}
		}

		public RelationshipEntity1List ParentOwnerDependentEntity2_RelationshipEntity1List
		{
			get
			{
				LoadParentOwnerDependentEntity2_RelationshipEntity1List();
				return this.parentOwnerDependentEntity2_RelationshipEntity1List;
			}
			internal set
			{
				this.parentOwnerDependentEntity2_RelationshipEntity1List = value;
			}
		}

		IRelationshipEntity1List IRelationshipEntity1.ParentOwnerDependentEntity2_RelationshipEntity1List
		{
			get
			{
				return (IRelationshipEntity1List)this.ParentOwnerDependentEntity2_RelationshipEntity1List;
			}
		}

		public void LoadParentOwnerDependentEntity2_RelationshipEntity1List()
		{
			if (!ParentOwnerDependentEntity2_RelationshipEntity1ListPartialLoadAttempted)
			{
				if (this.objectData.ParentOwnerDependentEntity2EntityObjectId == null)
				{
					ParentOwnerDependentEntity2_RelationshipEntity1List = null;
				}
				else
				{
					DependentEntity2 dependentEntity2 = (DependentEntity2)CustName.AppName.BL.Global.ClassFactory.GetDALRepository().GetDependentEntity2(this.objectData.ParentOwnerDependentEntity2EntityObjectId.Value, this.Context);
					if (dependentEntity2 == null)
						ParentOwnerDependentEntity2_RelationshipEntity1List = null;
					else
						ParentOwnerDependentEntity2_RelationshipEntity1List = (RelationshipEntity1List)dependentEntity2.LoadChildOwnedRelationshipEntity1List((RelationshipEntity1)this);
				}
				this.parentOwnerDependentEntity2_RelationshipEntity1ListPartialLoadAttempted = true;
				NotifyAll_ParentOwnerDependentEntity2EntityObject_PropertiesChanged();
			}
		}

		public void UnloadParentOwnerDependentEntity2_RelationshipEntity1List()
		{
			ParentOwnerDependentEntity2_RelationshipEntity1List = null;
			this.parentOwnerDependentEntity2_RelationshipEntity1ListPartialLoadAttempted = false;
			NotifyAll_ParentOwnerDependentEntity2EntityObject_PropertiesChanged();
		}

		public DependentEntity2 ParentOwnerDependentEntity2EntityObject
		{
			get
			{
				LoadParentOwnerDependentEntity2_RelationshipEntity1List();
				if (this.parentOwnerDependentEntity2_RelationshipEntity1List == null)
					// Either foreign object id == null or is invalid (i.e. points to non-existent repository object).
					return null;
				else
					return (DependentEntity2)this.parentOwnerDependentEntity2_RelationshipEntity1List.Parent;
			}
		}

		IDependentEntity2 IRelationshipEntity1.ParentOwnerDependentEntity2EntityObject
		{
			get
			{
				return (IDependentEntity2)this.ParentOwnerDependentEntity2EntityObject;
			}
		}

		public bool HasParentOwnerDependentEntity2Object(bool inMemoryOnly)
		{
			if (inMemoryOnly)
			{
				if (this.parentOwnerDependentEntity2_RelationshipEntity1List == null)
					return false;
				else
					return (this.parentOwnerDependentEntity2_RelationshipEntity1List.Parent != null);
			}
			else
			{
				if (this.parentOwnerDependentEntity2_RelationshipEntity1List == null)
				{
					if (this.parentOwnerDependentEntity2_RelationshipEntity1ListPartialLoadAttempted)
						return false;
					else
						return (this.objectData.ParentOwnerDependentEntity2EntityObjectId != null);
				}
				else
					return (this.parentOwnerDependentEntity2_RelationshipEntity1List.Parent != null);
			}
		}

		#endregion DependentEntity2 Relationship

		#region IndependentEntity2 Relationship

		public bool ParentOwnerIndependentEntity2_RelationshipEntity1ListPartialLoadAttempted
		{
			get
			{
				if (this.parentOwnerIndependentEntity2_RelationshipEntity1List == null)
					return this.parentOwnerIndependentEntity2_RelationshipEntity1ListPartialLoadAttempted;
				else
					return true;
			}
		}

		public RelationshipEntity1List ParentOwnerIndependentEntity2_RelationshipEntity1List
		{
			get
			{
				LoadParentOwnerIndependentEntity2_RelationshipEntity1List();
				return this.parentOwnerIndependentEntity2_RelationshipEntity1List;
			}
			internal set
			{
				this.parentOwnerIndependentEntity2_RelationshipEntity1List = value;
			}
		}

		IRelationshipEntity1List IRelationshipEntity1.ParentOwnerIndependentEntity2_RelationshipEntity1List
		{
			get
			{
				return (IRelationshipEntity1List)this.ParentOwnerIndependentEntity2_RelationshipEntity1List;
			}
		}

		public void LoadParentOwnerIndependentEntity2_RelationshipEntity1List()
		{
			if (!ParentOwnerIndependentEntity2_RelationshipEntity1ListPartialLoadAttempted)
			{
				if (this.objectData.ParentOwnerIndependentEntity2EntityObjectId == null)
				{
					ParentOwnerIndependentEntity2_RelationshipEntity1List = null;
				}
				else
				{
					IndependentEntity2 independentEntity2 = (IndependentEntity2)CustName.AppName.BL.Global.ClassFactory.GetDALRepository().GetIndependentEntity2(this.objectData.ParentOwnerIndependentEntity2EntityObjectId.Value, this.Context);
					if (independentEntity2 == null)
						ParentOwnerIndependentEntity2_RelationshipEntity1List = null;
					else
						ParentOwnerIndependentEntity2_RelationshipEntity1List = (RelationshipEntity1List)independentEntity2.LoadChildOwnedRelationshipEntity1List((RelationshipEntity1)this);
				}
				this.parentOwnerIndependentEntity2_RelationshipEntity1ListPartialLoadAttempted = true;
				NotifyAll_ParentOwnerIndependentEntity2EntityObject_PropertiesChanged();
			}
		}

		public void UnloadParentOwnerIndependentEntity2_RelationshipEntity1List()
		{
			ParentOwnerIndependentEntity2_RelationshipEntity1List = null;
			this.parentOwnerIndependentEntity2_RelationshipEntity1ListPartialLoadAttempted = false;
			NotifyAll_ParentOwnerIndependentEntity2EntityObject_PropertiesChanged();
		}

		public IndependentEntity2 ParentOwnerIndependentEntity2EntityObject
		{
			get
			{
				LoadParentOwnerIndependentEntity2_RelationshipEntity1List();
				if (this.parentOwnerIndependentEntity2_RelationshipEntity1List == null)
					// Either foreign object id == null or is invalid (i.e. points to non-existent repository object).
					return null;
				else
					return (IndependentEntity2)this.parentOwnerIndependentEntity2_RelationshipEntity1List.Parent;
			}
		}

		IIndependentEntity2 IRelationshipEntity1.ParentOwnerIndependentEntity2EntityObject
		{
			get
			{
				return (IIndependentEntity2)this.ParentOwnerIndependentEntity2EntityObject;
			}
		}

		public bool HasParentOwnerIndependentEntity2Object(bool inMemoryOnly)
		{
			if (inMemoryOnly)
			{
				if (this.parentOwnerIndependentEntity2_RelationshipEntity1List == null)
					return false;
				else
					return (this.parentOwnerIndependentEntity2_RelationshipEntity1List.Parent != null);
			}
			else
			{
				if (this.parentOwnerIndependentEntity2_RelationshipEntity1List == null)
				{
					if (this.parentOwnerIndependentEntity2_RelationshipEntity1ListPartialLoadAttempted)
						return false;
					else
						return (this.objectData.ParentOwnerIndependentEntity2EntityObjectId != null);
				}
				else
					return (this.parentOwnerIndependentEntity2_RelationshipEntity1List.Parent != null);
			}
		}

		#endregion IndependentEntity2 Relationship

		#endregion // Owner Outbound Relationships

		#region Non-Owner Outbound Relationships

		// This entity has no non-owner outbound relationships.

		#endregion // Non-Owner Outbound Relationships

		#endregion // Outbound Relationships

		// ========================================================================================================================

		public override void Load(bool recurse)
		{
			// This entity has no owned inbound relationships.
		}

		public override IList<IEntityObject> GetOwnedObjects(bool loaded, IList<IEntityObject> list)
		{
			return null;
		}

		public RelationshipEntity1 Copy(bool recurse)
		{
			return CopyImpl(recurse);
		}

		IRelationshipEntity1 IRelationshipEntity1.Copy(bool recurse)
		{
			return (IRelationshipEntity1)CopyImpl(recurse);
		}

		protected RelationshipEntity1 CopyImpl(bool recurse)
		{
			RelationshipEntity1 newRelationshipEntity1 = (RelationshipEntity1)CustName.AppName.BL.Global.ClassFactory.GetEntityObject(CustName.AppName.DAL.EntityClass.RelationshipEntity1);
			newRelationshipEntity1.PopulateFrom(this);
			newRelationshipEntity1.ObjectId = null;
			return newRelationshipEntity1;
		}

		// ========================================================================================================================

		#region Outbound Relationships Properties

		#region Owner Outbound Relationships Properties

		#region DependentEntity2 Relationship

		public virtual int? ParentOwnerDependentEntity2EntityObject_DependentEntity1Id
		{
			get
			{
				IDependentEntity2 obj = ParentOwnerDependentEntity2EntityObject;
				if (obj == null)
					return null;
				else
					return obj.DependentEntity1Id;
			}
		}

		public virtual bool? ParentOwnerDependentEntity2EntityObject_AttrBool1
		{
			get
			{
				IDependentEntity2 obj = ParentOwnerDependentEntity2EntityObject;
				if (obj == null)
					return null;
				else
					return obj.AttrBool1;
			}
		}

		public virtual DateTime? ParentOwnerDependentEntity2EntityObject_AttrDatetime1
		{
			get
			{
				IDependentEntity2 obj = ParentOwnerDependentEntity2EntityObject;
				if (obj == null)
					return null;
				else
					return obj.AttrDatetime1;
			}
		}

		public virtual int? ParentOwnerDependentEntity2EntityObject_AttrInteger1
		{
			get
			{
				IDependentEntity2 obj = ParentOwnerDependentEntity2EntityObject;
				if (obj == null)
					return null;
				else
					return obj.AttrInteger1;
			}
		}

		public virtual string ParentOwnerDependentEntity2EntityObject_AttrString1
		{
			get
			{
				IDependentEntity2 obj = ParentOwnerDependentEntity2EntityObject;
				if (obj == null)
					return null;
				else
					return obj.AttrString1;
			}
		}

		public virtual string ParentOwnerDependentEntity2EntityObject_AttrString2
		{
			get
			{
				IDependentEntity2 obj = ParentOwnerDependentEntity2EntityObject;
				if (obj == null)
					return null;
				else
					return obj.AttrString2;
			}
		}

		public virtual string ParentOwnerDependentEntity2EntityObject_Name
		{
			get
			{
				IDependentEntity2 obj = ParentOwnerDependentEntity2EntityObject;
				if (obj == null)
					return null;
				else
					return obj.Name;
			}
		}

		public virtual string ParentOwnerDependentEntity2EntityObject_Status
		{
			get
			{
				IDependentEntity2 obj = ParentOwnerDependentEntity2EntityObject;
				if (obj == null)
					return null;
				else
					return obj.Status;
			}
		}

		protected virtual void NotifyAll_ParentOwnerDependentEntity2EntityObject_PropertiesChanged()
		{
			// When this object is in a list that is bound to a DataGridView control containing a ComboBox bound to the FK property (DependentEntity2Id)
			// driving the content of the ParentOwnerDependentEntity2EntityObject_* properties,
			// changing selections in the ComboBox results in a noticeable pause.
			// Delay is cause by something executing FindCore on the list that the ComboBox is bound to (that populates its dropdown) every time OnPropertyChanged is called.
			// Another issue is that any list containing this object raises an event to signal that it has changed, causing owner entity objects to be marked as having changes,
			// which may not be desirable becauses changes to DependentEntity2 may not imply changes to the parent if DependentEntity2 is not owned by the parent.
			// Workaround has been to disable OnPropertyChanged calls below and have the UI listen for changes in the FK property DependentEntity2Id (indirectly through the
			// ListChanged event) and invalidate the DataGridView row so that repaints cells containing values dependent upon the combobox selection i.e. one of the
			// ParentOwnerDependentEntity2EntityObject_* properties.
			//OnPropertyChanged("ParentOwnerDependentEntity2EntityObject_AttrBool1");
			//OnPropertyChanged("ParentOwnerDependentEntity2EntityObject_AttrDatetime1");
			//OnPropertyChanged("ParentOwnerDependentEntity2EntityObject_AttrInteger1");
			//OnPropertyChanged("ParentOwnerDependentEntity2EntityObject_AttrString1");
			//OnPropertyChanged("ParentOwnerDependentEntity2EntityObject_AttrString2");
			//OnPropertyChanged("ParentOwnerDependentEntity2EntityObject_DependentEntity1Id");
			//OnPropertyChanged("ParentOwnerDependentEntity2EntityObject_Name");
			//OnPropertyChanged("ParentOwnerDependentEntity2EntityObject_Status");
		}

		#endregion DependentEntity2 Relationship Properties

		#region IndependentEntity2 Relationship

		public virtual bool? ParentOwnerIndependentEntity2EntityObject_AttrBool1
		{
			get
			{
				IIndependentEntity2 obj = ParentOwnerIndependentEntity2EntityObject;
				if (obj == null)
					return null;
				else
					return obj.AttrBool1;
			}
		}

		public virtual DateTime? ParentOwnerIndependentEntity2EntityObject_AttrDatetime1
		{
			get
			{
				IIndependentEntity2 obj = ParentOwnerIndependentEntity2EntityObject;
				if (obj == null)
					return null;
				else
					return obj.AttrDatetime1;
			}
		}

		public virtual int? ParentOwnerIndependentEntity2EntityObject_AttrInteger1
		{
			get
			{
				IIndependentEntity2 obj = ParentOwnerIndependentEntity2EntityObject;
				if (obj == null)
					return null;
				else
					return obj.AttrInteger1;
			}
		}

		public virtual string ParentOwnerIndependentEntity2EntityObject_AttrString1
		{
			get
			{
				IIndependentEntity2 obj = ParentOwnerIndependentEntity2EntityObject;
				if (obj == null)
					return null;
				else
					return obj.AttrString1;
			}
		}

		public virtual string ParentOwnerIndependentEntity2EntityObject_AttrString2
		{
			get
			{
				IIndependentEntity2 obj = ParentOwnerIndependentEntity2EntityObject;
				if (obj == null)
					return null;
				else
					return obj.AttrString2;
			}
		}

		public virtual string ParentOwnerIndependentEntity2EntityObject_Name
		{
			get
			{
				IIndependentEntity2 obj = ParentOwnerIndependentEntity2EntityObject;
				if (obj == null)
					return null;
				else
					return obj.Name;
			}
		}

		public virtual string ParentOwnerIndependentEntity2EntityObject_Status
		{
			get
			{
				IIndependentEntity2 obj = ParentOwnerIndependentEntity2EntityObject;
				if (obj == null)
					return null;
				else
					return obj.Status;
			}
		}

		protected virtual void NotifyAll_ParentOwnerIndependentEntity2EntityObject_PropertiesChanged()
		{
			// When this object is in a list that is bound to a DataGridView control containing a ComboBox bound to the FK property (IndependentEntity2Id)
			// driving the content of the ParentOwnerIndependentEntity2EntityObject_* properties,
			// changing selections in the ComboBox results in a noticeable pause.
			// Delay is cause by something executing FindCore on the list that the ComboBox is bound to (that populates its dropdown) every time OnPropertyChanged is called.
			// Another issue is that any list containing this object raises an event to signal that it has changed, causing owner entity objects to be marked as having changes,
			// which may not be desirable becauses changes to IndependentEntity2 may not imply changes to the parent if IndependentEntity2 is not owned by the parent.
			// Workaround has been to disable OnPropertyChanged calls below and have the UI listen for changes in the FK property IndependentEntity2Id (indirectly through the
			// ListChanged event) and invalidate the DataGridView row so that repaints cells containing values dependent upon the combobox selection i.e. one of the
			// ParentOwnerIndependentEntity2EntityObject_* properties.
			//OnPropertyChanged("ParentOwnerIndependentEntity2EntityObject_AttrBool1");
			//OnPropertyChanged("ParentOwnerIndependentEntity2EntityObject_AttrDatetime1");
			//OnPropertyChanged("ParentOwnerIndependentEntity2EntityObject_AttrInteger1");
			//OnPropertyChanged("ParentOwnerIndependentEntity2EntityObject_AttrString1");
			//OnPropertyChanged("ParentOwnerIndependentEntity2EntityObject_AttrString2");
			//OnPropertyChanged("ParentOwnerIndependentEntity2EntityObject_Name");
			//OnPropertyChanged("ParentOwnerIndependentEntity2EntityObject_Status");
		}

		#endregion IndependentEntity2 Relationship Properties

		#endregion // Owner Outbound Relationships Properties

		#region Non-Owner Outbound Relationships Properties

		// This entity has no non-owner outbound relationships.

		#endregion // Non-Owner Outbound Relationships Properties

		#endregion // Outbound Relationships Properties

		// ========================================================================================================================
	}
}
