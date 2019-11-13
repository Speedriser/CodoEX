using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace CustName.AppName.BL
{
	public abstract class BaseAttachment1BufferedDataSource : IDisposable
	{
		// Track whether Dispose has been called.
		private bool disposed = false;
		private CustName.AppName.DAL.Repository repository;
		private Attachment1List attachment1List = new Attachment1List(); // Init as empty list. This member must never be null.
		private bool autoCommit = true;

		public BaseAttachment1BufferedDataSource()
		{
		}

		// This destructor will run only if the Dispose method does not get called.
		// Do not provide destructors in types derived from this class.
		~BaseAttachment1BufferedDataSource()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
			// Take object off the Finalization queue to prevent finalization code for this object from executing a second time.
			GC.SuppressFinalize(this);
		}

		// Dispose(bool disposing) executes in two distinct scenarios.
		// If disposing equals true, the method has been called directly or indirectly by a user's code.
		// Managed and unmanaged resources can be disposed.
		// If disposing equals false, the method has been called by the runtime from inside the finalizer and should not reference other objects.
		// Only unmanaged resources can be disposed.
		protected virtual void Dispose(bool disposing)
		{
			// Check to see if Dispose has already been called.
			if (!this.disposed)
			{
				// If disposing equals true, dispose all managed and unmanaged resources, otherwise only unmanaged resources.
				if (disposing)
				{
					// Dispose managed resources.
					if (this.repository != null)
					{
						if (!Settings.SingletonRepository)
							this.repository.Close();
						this.repository = null;
					}
				}
				// Release unmanaged resources.
				// If disposing is false, only the following code is executed.

				// Note that this is not thread safe.
				// Another thread could start disposing the object after the managed resources are disposed, but before the disposed flag is set to true.
				// If thread safety is necessary, it must be implemented by the client.
				disposed = true;
			}
		}

		public void Close()
		{
			Dispose();
		}

		public CustName.AppName.DAL.Repository Repository
		{
			get
			{
				if (this.repository == null)
					this.repository = Global.ClassFactory.GetDALRepository();
				return this.repository;
			}
		}

		// Returns the collection of Attachment1 objects managed by this data source.
		public virtual Attachment1List Attachment1List
		{
			get
			{
				return this.attachment1List;
			}
		}

		// When set to true, changes made via insert, update, and delete are committed to the repository automatically without needing to call the commit method.
		public virtual bool AutoCommit
		{
			get
			{
				return this.autoCommit;
			}
			set
			{
				this.autoCommit = value;
			}
		}

		// Clear the data source.
		// Changes pending commit are lost.
		public virtual void Clear()
		{
			this.attachment1List.Clear();
		}

		// Commit changes to the repository.
		public virtual void Commit()
		{
			this.Repository.Save(this.attachment1List);
			// Removed deleted Attachment1 objects from the data source.
			IList<Attachment1> deletedAttachment1List = new List<Attachment1>();
			foreach (Attachment1 attachment1 in this.attachment1List)
			{
				if (attachment1.ObjectStatus == CustName.AppName.DAL.ObjectStatus.Deleted)
					deletedAttachment1List.Add(attachment1);
			}
			foreach (Attachment1 attachment1 in deletedAttachment1List)
				this.attachment1List.Remove(attachment1);
		}

		#region Select and Select Count

		public int Count()
		{
			return this.attachment1List.Count;
		}

		[DataObjectMethod(DataObjectMethodType.Select, true)]
		public virtual Attachment1List Select()
		{
			Attachment1List filteredAttachment1List = (Attachment1List)CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(CustName.AppName.DAL.EntityClass.Attachment1);
			foreach (Attachment1 attachment1 in this.attachment1List)
			{
				if (!attachment1.MarkedForDeletion)
					filteredAttachment1List.Add(attachment1);
			}
			return filteredAttachment1List;
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DataTable SelectDataTable()
		{
			return ExportToDataTable(Select());
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual Attachment1List Select(CustName.AppName.DAL.Attachment1Identifier objectId)
		{
			Attachment1List filteredAttachment1List = (Attachment1List)CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(CustName.AppName.DAL.EntityClass.Attachment1);
			foreach (Attachment1 attachment1 in this.attachment1List)
			{
				if (!attachment1.MarkedForDeletion && attachment1.ObjectId == objectId)
				{
					filteredAttachment1List.Add(attachment1);
					break;
				}
			}
			return filteredAttachment1List;
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DataTable SelectDataTable(CustName.AppName.DAL.Attachment1Identifier objectId)
		{
			return ExportToDataTable(Select(objectId));
		}

		#endregion

		#region Insert using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Insert, true)]
		public virtual Guid Insert(Attachment1 attachment1)
		{
			Attachment1 repositoryAttachment1 = (Attachment1)CustName.AppName.BL.Global.ClassFactory.GetEntityObject(CustName.AppName.DAL.EntityClass.Attachment1);
			repositoryAttachment1.ObjectInstanceId = attachment1.ObjectInstanceId;
			// Sync will also copy ObjectId.
			Sync(attachment1, repositoryAttachment1, DataSourceOperation.Create);
			this.attachment1List.Add(repositoryAttachment1);
			if (this.autoCommit)
				Commit();
			return repositoryAttachment1.ObjectInstanceId;
		}

		[DataObjectMethod(DataObjectMethodType.Insert, false)]
		public virtual Guid Insert()
		{
			return Insert((Attachment1)CustName.AppName.BL.Global.ClassFactory.GetEntityObject(CustName.AppName.DAL.EntityClass.Attachment1));
		}

		#endregion

		#region Update using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Update, true)]
		public int Update(Attachment1 attachment1)
		{
			int index = IndexOf(attachment1, this.attachment1List);
			if (index == -1)
				throw new InvalidOperationException("Entity object not found.");
			Sync(attachment1, this.attachment1List[index], DataSourceOperation.Update);
			if (this.autoCommit)
				Commit();
			return 1;
		}

		#endregion

		#region Delete using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Delete, true)]
		public virtual int Delete(Attachment1 attachment1)
		{
			int index = IndexOf(attachment1, this.attachment1List);
			if (index == -1)
				throw new InvalidOperationException("Entity object not found.");
			if (this.attachment1List[index].MarkedForDeletion)
				this.attachment1List[index].DecrementDeleteCount();
			else
				this.attachment1List[index].IncrementDeleteCount();
			if (this.autoCommit)
				Commit();
			return 1;
		}

		#endregion

		#region Find

		public void Find(CustName.AppName.DAL.Attachment1Identifier objectId)
		{
			Find(objectId, false);
		}

		public virtual void Find(CustName.AppName.DAL.Attachment1Identifier objectId, bool append)
		{
			Attachment1 attachment1 = (Attachment1)this.Repository.GetAttachment1(objectId);
			if (append)
			{
				if (IndexOf(attachment1, this.attachment1List) == -1)
					this.attachment1List.Add(attachment1);
			}
			else
			{
				this.attachment1List = (Attachment1List)CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(CustName.AppName.DAL.EntityClass.Attachment1);
				this.attachment1List.Add(attachment1);
			}
		}

		public void Find(int maxCount, CustName.AppName.DAL.SearchCondition searchCondition)
		{
			Find(maxCount, searchCondition, false);
		}

		public void Find(int maxCount, CustName.AppName.DAL.SearchCondition searchCondition, bool append)
		{
			Find(maxCount, searchCondition, null, append);
		}

		// Populate data source with Attachment1 objects from the Repository.
		public virtual void Find(int maxCount, CustName.AppName.DAL.SearchCondition searchCondition, CustName.AppName.DAL.SortSpecification sortSpecification, bool append)
		{
			Attachment1List attachment1List = (Attachment1List)this.Repository.FindAttachment1(maxCount, searchCondition, sortSpecification);
			if (append)
			{
				foreach (Attachment1 attachment1 in attachment1List)
				{
					if (IndexOf(attachment1, this.attachment1List) == -1)
						this.attachment1List.Add(attachment1);
				}
			}
			else
			{
				this.attachment1List = attachment1List;
			}
		}

		#endregion

		#region Export

		public static DataTable ExportToDataTable(Attachment1List attachment1List)
		{
			DataTable dataTable = new DataTable();

			dataTable.Columns.Add(new DataColumn("Attachment1Id", typeof(System.Int32)));
			dataTable.Columns.Add(new DataColumn("AttachmentNotes", typeof(System.String)));
			dataTable.Columns.Add(new DataColumn("AttachmentType", typeof(System.String)));
			dataTable.Columns.Add(new DataColumn("AttrBool1", typeof(System.Boolean)));
			dataTable.Columns.Add(new DataColumn("AttrDatetime1", typeof(System.DateTime)));
			dataTable.Columns.Add(new DataColumn("AttrInteger1", typeof(System.Int32)));
			dataTable.Columns.Add(new DataColumn("AttrString1", typeof(System.String)));
			dataTable.Columns.Add(new DataColumn("AttrString2", typeof(System.String)));
			dataTable.Columns.Add(new DataColumn("CreateTimestamp", typeof(System.DateTime)));
			dataTable.Columns.Add(new DataColumn("CreateUser", typeof(System.String)));
			dataTable.Columns.Add(new DataColumn("DependentEntity1Id", typeof(System.Int32)));
			dataTable.Columns.Add(new DataColumn("Name", typeof(System.String)));
			dataTable.Columns.Add(new DataColumn("Status", typeof(System.String)));
			dataTable.Columns.Add(new DataColumn("LastUpdateTimestamp", typeof(System.DateTime)));
			dataTable.Columns.Add(new DataColumn("UpdateId", typeof(System.Int32)));
			dataTable.Columns.Add(new DataColumn("LastUpdateUser", typeof(System.String)));

			DataRow dataRow;
			foreach (Attachment1 attachment1 in attachment1List)
			{
				dataRow = dataTable.NewRow();
				dataRow["Attachment1Id"] = attachment1.Attachment1Id_DBObjectValue;
				dataRow["AttachmentNotes"] = attachment1.AttachmentNotes_DBObjectValue;
				dataRow["AttachmentType"] = attachment1.AttachmentType_DBObjectValue;
				dataRow["AttrBool1"] = attachment1.AttrBool1_DBObjectValue;
				dataRow["AttrDatetime1"] = attachment1.AttrDatetime1_DBObjectValue;
				dataRow["AttrInteger1"] = attachment1.AttrInteger1_DBObjectValue;
				dataRow["AttrString1"] = attachment1.AttrString1_DBObjectValue;
				dataRow["AttrString2"] = attachment1.AttrString2_DBObjectValue;
				dataRow["CreateTimestamp"] = attachment1.CreateTimestamp_DBObjectValue;
				dataRow["CreateUser"] = attachment1.CreateUser_DBObjectValue;
				dataRow["DependentEntity1Id"] = attachment1.DependentEntity1Id_DBObjectValue;
				dataRow["Name"] = attachment1.Name_DBObjectValue;
				dataRow["Status"] = attachment1.Status_DBObjectValue;
				dataRow["LastUpdateTimestamp"] = attachment1.LastUpdateTimestamp_DBObjectValue;
				dataRow["UpdateId"] = attachment1.UpdateId_DBObjectValue;
				dataRow["LastUpdateUser"] = attachment1.LastUpdateUser_DBObjectValue;
				dataTable.Rows.Add(dataRow);
			}

			return dataTable;
		}

		public static StringCollection ExportToCSV(Attachment1List attachment1List)
		{
			StringCollection stringCollection = new StringCollection();

			stringCollection.Add("Attachment1Id,AttachmentNotes,AttachmentType,AttrBool1,AttrDatetime1,AttrInteger1,AttrString1,AttrString2,CreateTimestamp,CreateUser,DependentEntity1Id,FileAttachment,Name,Status,LastUpdateTimestamp,UpdateId,LastUpdateUser");

			StringBuilder stringBuilder = new StringBuilder();
			foreach (Attachment1 attachment1 in attachment1List)
			{
				stringBuilder.Length = 0;
				if (attachment1.Attachment1Id != null)
					stringBuilder.Append(Convert.ToString(attachment1.Attachment1Id, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (attachment1.AttachmentNotes != null)
					stringBuilder.Append(attachment1.AttachmentNotes.Replace(',', ' '));
				stringBuilder.Append(",");
				if (attachment1.AttachmentType != null)
					stringBuilder.Append(attachment1.AttachmentType.Replace(',', ' '));
				stringBuilder.Append(",");
				if (attachment1.AttrBool1 != null)
					stringBuilder.Append(Convert.ToString(attachment1.AttrBool1, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (attachment1.AttrDatetime1 != null)
					stringBuilder.Append(Convert.ToString(attachment1.AttrDatetime1, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (attachment1.AttrInteger1 != null)
					stringBuilder.Append(Convert.ToString(attachment1.AttrInteger1, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (attachment1.AttrString1 != null)
					stringBuilder.Append(attachment1.AttrString1.Replace(',', ' '));
				stringBuilder.Append(",");
				if (attachment1.AttrString2 != null)
					stringBuilder.Append(attachment1.AttrString2.Replace(',', ' '));
				stringBuilder.Append(",");
				if (attachment1.CreateTimestamp != null)
					stringBuilder.Append(Convert.ToString(attachment1.CreateTimestamp, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (attachment1.CreateUser != null)
					stringBuilder.Append(attachment1.CreateUser.Replace(',', ' '));
				stringBuilder.Append(",");
				if (attachment1.DependentEntity1Id != null)
					stringBuilder.Append(Convert.ToString(attachment1.DependentEntity1Id, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (attachment1.FileAttachment != null)
					stringBuilder.Append(Convert.ToString(attachment1.FileAttachment, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (attachment1.Name != null)
					stringBuilder.Append(attachment1.Name.Replace(',', ' '));
				stringBuilder.Append(",");
				if (attachment1.Status != null)
					stringBuilder.Append(attachment1.Status.Replace(',', ' '));
				stringBuilder.Append(",");
				if (attachment1.LastUpdateTimestamp != null)
					stringBuilder.Append(Convert.ToString(attachment1.LastUpdateTimestamp, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				stringBuilder.Append(Convert.ToString(attachment1.UpdateId, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (attachment1.LastUpdateUser != null)
					stringBuilder.Append(attachment1.LastUpdateUser.Replace(',', ' '));
				stringCollection.Add(stringBuilder.ToString());
			}

			return stringCollection;
		}

		#endregion

		protected virtual void Sync(Attachment1 sourceAttachment1, Attachment1 targetAttachment1, DataSourceOperation dataSourceOperation)
		{
			targetAttachment1.ParentOwnerDependentEntity1EntityObjectId_DBObjectValue = sourceAttachment1.ParentOwnerDependentEntity1EntityObjectId_DBObjectValue;
			targetAttachment1.AttachmentNotes_DBObjectValue = sourceAttachment1.AttachmentNotes_DBObjectValue;
			targetAttachment1.AttachmentType_DBObjectValue = sourceAttachment1.AttachmentType_DBObjectValue;
			targetAttachment1.AttrBool1_DBObjectValue = sourceAttachment1.AttrBool1_DBObjectValue;
			targetAttachment1.AttrDatetime1_DBObjectValue = sourceAttachment1.AttrDatetime1_DBObjectValue;
			targetAttachment1.AttrInteger1_DBObjectValue = sourceAttachment1.AttrInteger1_DBObjectValue;
			targetAttachment1.AttrString1_DBObjectValue = sourceAttachment1.AttrString1_DBObjectValue;
			targetAttachment1.AttrString2_DBObjectValue = sourceAttachment1.AttrString2_DBObjectValue;
			targetAttachment1.FileAttachment_DBObjectValue = sourceAttachment1.FileAttachment_DBObjectValue;
			targetAttachment1.Name_DBObjectValue = sourceAttachment1.Name_DBObjectValue;
			targetAttachment1.Status_DBObjectValue = sourceAttachment1.Status_DBObjectValue;
		}

		public int IndexOf(Guid objectInstanceId)
		{
			for (int index = 0; index < this.attachment1List.Count; ++index)
			{
				if (this.attachment1List[index].ObjectInstanceId == objectInstanceId)
					return index;
			}
			return -1;
		}

		public int IndexOf(Attachment1 attachment1)
		{
			return IndexOf(attachment1, this.attachment1List);
		}

		private int IndexOf(Attachment1 attachment1, Attachment1List attachment1List)
		{
			if (attachment1.ObjectId.HasValue)
			{
				CustName.AppName.DAL.Attachment1Identifier identifier = attachment1.ObjectId.Value;
				for (int index = 0; index < attachment1List.Count; ++index)
				{
					if (attachment1List[index].ObjectId == identifier)
						return index;
				}
			}
			else
			{
				Guid objectInstanceId = attachment1.ObjectInstanceId;
				for (int index = 0; index < attachment1List.Count; ++index)
				{
					if (attachment1List[index].ObjectInstanceId == objectInstanceId)
						return index;
				}
			}
			return -1;
		}
	}

	public abstract class BaseDependentEntity1BufferedDataSource : IDisposable
	{
		// Track whether Dispose has been called.
		private bool disposed = false;
		private CustName.AppName.DAL.Repository repository;
		private DependentEntity1List dependentEntity1List = new DependentEntity1List(); // Init as empty list. This member must never be null.
		private bool autoCommit = true;

		public BaseDependentEntity1BufferedDataSource()
		{
		}

		// This destructor will run only if the Dispose method does not get called.
		// Do not provide destructors in types derived from this class.
		~BaseDependentEntity1BufferedDataSource()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
			// Take object off the Finalization queue to prevent finalization code for this object from executing a second time.
			GC.SuppressFinalize(this);
		}

		// Dispose(bool disposing) executes in two distinct scenarios.
		// If disposing equals true, the method has been called directly or indirectly by a user's code.
		// Managed and unmanaged resources can be disposed.
		// If disposing equals false, the method has been called by the runtime from inside the finalizer and should not reference other objects.
		// Only unmanaged resources can be disposed.
		protected virtual void Dispose(bool disposing)
		{
			// Check to see if Dispose has already been called.
			if (!this.disposed)
			{
				// If disposing equals true, dispose all managed and unmanaged resources, otherwise only unmanaged resources.
				if (disposing)
				{
					// Dispose managed resources.
					if (this.repository != null)
					{
						if (!Settings.SingletonRepository)
							this.repository.Close();
						this.repository = null;
					}
				}
				// Release unmanaged resources.
				// If disposing is false, only the following code is executed.

				// Note that this is not thread safe.
				// Another thread could start disposing the object after the managed resources are disposed, but before the disposed flag is set to true.
				// If thread safety is necessary, it must be implemented by the client.
				disposed = true;
			}
		}

		public void Close()
		{
			Dispose();
		}

		public CustName.AppName.DAL.Repository Repository
		{
			get
			{
				if (this.repository == null)
					this.repository = Global.ClassFactory.GetDALRepository();
				return this.repository;
			}
		}

		// Returns the collection of DependentEntity1 objects managed by this data source.
		public virtual DependentEntity1List DependentEntity1List
		{
			get
			{
				return this.dependentEntity1List;
			}
		}

		// When set to true, changes made via insert, update, and delete are committed to the repository automatically without needing to call the commit method.
		public virtual bool AutoCommit
		{
			get
			{
				return this.autoCommit;
			}
			set
			{
				this.autoCommit = value;
			}
		}

		// Clear the data source.
		// Changes pending commit are lost.
		public virtual void Clear()
		{
			this.dependentEntity1List.Clear();
		}

		// Commit changes to the repository.
		public virtual void Commit()
		{
			this.Repository.Save(this.dependentEntity1List);
			// Removed deleted DependentEntity1 objects from the data source.
			IList<DependentEntity1> deletedDependentEntity1List = new List<DependentEntity1>();
			foreach (DependentEntity1 dependentEntity1 in this.dependentEntity1List)
			{
				if (dependentEntity1.ObjectStatus == CustName.AppName.DAL.ObjectStatus.Deleted)
					deletedDependentEntity1List.Add(dependentEntity1);
			}
			foreach (DependentEntity1 dependentEntity1 in deletedDependentEntity1List)
				this.dependentEntity1List.Remove(dependentEntity1);
		}

		#region Select and Select Count

		public int Count()
		{
			return this.dependentEntity1List.Count;
		}

		[DataObjectMethod(DataObjectMethodType.Select, true)]
		public virtual DependentEntity1List Select()
		{
			DependentEntity1List filteredDependentEntity1List = (DependentEntity1List)CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(CustName.AppName.DAL.EntityClass.DependentEntity1);
			foreach (DependentEntity1 dependentEntity1 in this.dependentEntity1List)
			{
				if (!dependentEntity1.MarkedForDeletion)
					filteredDependentEntity1List.Add(dependentEntity1);
			}
			return filteredDependentEntity1List;
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DataTable SelectDataTable()
		{
			return ExportToDataTable(Select());
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DependentEntity1List Select(CustName.AppName.DAL.DependentEntity1Identifier objectId)
		{
			DependentEntity1List filteredDependentEntity1List = (DependentEntity1List)CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(CustName.AppName.DAL.EntityClass.DependentEntity1);
			foreach (DependentEntity1 dependentEntity1 in this.dependentEntity1List)
			{
				if (!dependentEntity1.MarkedForDeletion && dependentEntity1.ObjectId == objectId)
				{
					filteredDependentEntity1List.Add(dependentEntity1);
					break;
				}
			}
			return filteredDependentEntity1List;
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DataTable SelectDataTable(CustName.AppName.DAL.DependentEntity1Identifier objectId)
		{
			return ExportToDataTable(Select(objectId));
		}

		#endregion

		#region Insert using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Insert, true)]
		public virtual Guid Insert(DependentEntity1 dependentEntity1)
		{
			DependentEntity1 repositoryDependentEntity1 = (DependentEntity1)CustName.AppName.BL.Global.ClassFactory.GetEntityObject(CustName.AppName.DAL.EntityClass.DependentEntity1);
			repositoryDependentEntity1.ObjectInstanceId = dependentEntity1.ObjectInstanceId;
			// Sync will also copy ObjectId.
			Sync(dependentEntity1, repositoryDependentEntity1, DataSourceOperation.Create);
			this.dependentEntity1List.Add(repositoryDependentEntity1);
			if (this.autoCommit)
				Commit();
			return repositoryDependentEntity1.ObjectInstanceId;
		}

		[DataObjectMethod(DataObjectMethodType.Insert, false)]
		public virtual Guid Insert()
		{
			return Insert((DependentEntity1)CustName.AppName.BL.Global.ClassFactory.GetEntityObject(CustName.AppName.DAL.EntityClass.DependentEntity1));
		}

		#endregion

		#region Update using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Update, true)]
		public int Update(DependentEntity1 dependentEntity1)
		{
			int index = IndexOf(dependentEntity1, this.dependentEntity1List);
			if (index == -1)
				throw new InvalidOperationException("Entity object not found.");
			Sync(dependentEntity1, this.dependentEntity1List[index], DataSourceOperation.Update);
			if (this.autoCommit)
				Commit();
			return 1;
		}

		#endregion

		#region Delete using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Delete, true)]
		public virtual int Delete(DependentEntity1 dependentEntity1)
		{
			int index = IndexOf(dependentEntity1, this.dependentEntity1List);
			if (index == -1)
				throw new InvalidOperationException("Entity object not found.");
			if (this.dependentEntity1List[index].MarkedForDeletion)
				this.dependentEntity1List[index].DecrementDeleteCount();
			else
				this.dependentEntity1List[index].IncrementDeleteCount();
			if (this.autoCommit)
				Commit();
			return 1;
		}

		#endregion

		#region Find

		public void Find(CustName.AppName.DAL.DependentEntity1Identifier objectId)
		{
			Find(objectId, false);
		}

		public virtual void Find(CustName.AppName.DAL.DependentEntity1Identifier objectId, bool append)
		{
			DependentEntity1 dependentEntity1 = (DependentEntity1)this.Repository.GetDependentEntity1(objectId);
			if (append)
			{
				if (IndexOf(dependentEntity1, this.dependentEntity1List) == -1)
					this.dependentEntity1List.Add(dependentEntity1);
			}
			else
			{
				this.dependentEntity1List = (DependentEntity1List)CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(CustName.AppName.DAL.EntityClass.DependentEntity1);
				this.dependentEntity1List.Add(dependentEntity1);
			}
		}

		public void Find(int maxCount, CustName.AppName.DAL.SearchCondition searchCondition)
		{
			Find(maxCount, searchCondition, false);
		}

		public void Find(int maxCount, CustName.AppName.DAL.SearchCondition searchCondition, bool append)
		{
			Find(maxCount, searchCondition, null, append);
		}

		// Populate data source with DependentEntity1 objects from the Repository.
		public virtual void Find(int maxCount, CustName.AppName.DAL.SearchCondition searchCondition, CustName.AppName.DAL.SortSpecification sortSpecification, bool append)
		{
			DependentEntity1List dependentEntity1List = (DependentEntity1List)this.Repository.FindDependentEntity1(maxCount, searchCondition, sortSpecification);
			if (append)
			{
				foreach (DependentEntity1 dependentEntity1 in dependentEntity1List)
				{
					if (IndexOf(dependentEntity1, this.dependentEntity1List) == -1)
						this.dependentEntity1List.Add(dependentEntity1);
				}
			}
			else
			{
				this.dependentEntity1List = dependentEntity1List;
			}
		}

		#endregion

		#region Export

		public static DataTable ExportToDataTable(DependentEntity1List dependentEntity1List)
		{
			DataTable dataTable = new DataTable();

			dataTable.Columns.Add(new DataColumn("AttrBool1", typeof(System.Boolean)));
			dataTable.Columns.Add(new DataColumn("AttrDatetime1", typeof(System.DateTime)));
			dataTable.Columns.Add(new DataColumn("AttrInteger1", typeof(System.Int32)));
			dataTable.Columns.Add(new DataColumn("AttrString1", typeof(System.String)));
			dataTable.Columns.Add(new DataColumn("AttrString2", typeof(System.String)));
			dataTable.Columns.Add(new DataColumn("CreateTimestamp", typeof(System.DateTime)));
			dataTable.Columns.Add(new DataColumn("CreateUser", typeof(System.String)));
			dataTable.Columns.Add(new DataColumn("DependentEntity1Id", typeof(System.Int32)));
			dataTable.Columns.Add(new DataColumn("IndependentEntity1Id", typeof(System.Int32)));
			dataTable.Columns.Add(new DataColumn("Name", typeof(System.String)));
			dataTable.Columns.Add(new DataColumn("Status", typeof(System.String)));
			dataTable.Columns.Add(new DataColumn("LastUpdateTimestamp", typeof(System.DateTime)));
			dataTable.Columns.Add(new DataColumn("UpdateId", typeof(System.Int32)));
			dataTable.Columns.Add(new DataColumn("LastUpdateUser", typeof(System.String)));

			DataRow dataRow;
			foreach (DependentEntity1 dependentEntity1 in dependentEntity1List)
			{
				dataRow = dataTable.NewRow();
				dataRow["AttrBool1"] = dependentEntity1.AttrBool1_DBObjectValue;
				dataRow["AttrDatetime1"] = dependentEntity1.AttrDatetime1_DBObjectValue;
				dataRow["AttrInteger1"] = dependentEntity1.AttrInteger1_DBObjectValue;
				dataRow["AttrString1"] = dependentEntity1.AttrString1_DBObjectValue;
				dataRow["AttrString2"] = dependentEntity1.AttrString2_DBObjectValue;
				dataRow["CreateTimestamp"] = dependentEntity1.CreateTimestamp_DBObjectValue;
				dataRow["CreateUser"] = dependentEntity1.CreateUser_DBObjectValue;
				dataRow["DependentEntity1Id"] = dependentEntity1.DependentEntity1Id_DBObjectValue;
				dataRow["IndependentEntity1Id"] = dependentEntity1.IndependentEntity1Id_DBObjectValue;
				dataRow["Name"] = dependentEntity1.Name_DBObjectValue;
				dataRow["Status"] = dependentEntity1.Status_DBObjectValue;
				dataRow["LastUpdateTimestamp"] = dependentEntity1.LastUpdateTimestamp_DBObjectValue;
				dataRow["UpdateId"] = dependentEntity1.UpdateId_DBObjectValue;
				dataRow["LastUpdateUser"] = dependentEntity1.LastUpdateUser_DBObjectValue;
				dataTable.Rows.Add(dataRow);
			}

			return dataTable;
		}

		public static StringCollection ExportToCSV(DependentEntity1List dependentEntity1List)
		{
			StringCollection stringCollection = new StringCollection();

			stringCollection.Add("AttrBool1,AttrDatetime1,AttrInteger1,AttrString1,AttrString2,CreateTimestamp,CreateUser,DependentEntity1Id,IndependentEntity1Id,Name,Status,LastUpdateTimestamp,UpdateId,LastUpdateUser");

			StringBuilder stringBuilder = new StringBuilder();
			foreach (DependentEntity1 dependentEntity1 in dependentEntity1List)
			{
				stringBuilder.Length = 0;
				if (dependentEntity1.AttrBool1 != null)
					stringBuilder.Append(Convert.ToString(dependentEntity1.AttrBool1, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (dependentEntity1.AttrDatetime1 != null)
					stringBuilder.Append(Convert.ToString(dependentEntity1.AttrDatetime1, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (dependentEntity1.AttrInteger1 != null)
					stringBuilder.Append(Convert.ToString(dependentEntity1.AttrInteger1, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (dependentEntity1.AttrString1 != null)
					stringBuilder.Append(dependentEntity1.AttrString1.Replace(',', ' '));
				stringBuilder.Append(",");
				if (dependentEntity1.AttrString2 != null)
					stringBuilder.Append(dependentEntity1.AttrString2.Replace(',', ' '));
				stringBuilder.Append(",");
				if (dependentEntity1.CreateTimestamp != null)
					stringBuilder.Append(Convert.ToString(dependentEntity1.CreateTimestamp, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (dependentEntity1.CreateUser != null)
					stringBuilder.Append(dependentEntity1.CreateUser.Replace(',', ' '));
				stringBuilder.Append(",");
				if (dependentEntity1.DependentEntity1Id != null)
					stringBuilder.Append(Convert.ToString(dependentEntity1.DependentEntity1Id, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (dependentEntity1.IndependentEntity1Id != null)
					stringBuilder.Append(Convert.ToString(dependentEntity1.IndependentEntity1Id, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (dependentEntity1.Name != null)
					stringBuilder.Append(dependentEntity1.Name.Replace(',', ' '));
				stringBuilder.Append(",");
				if (dependentEntity1.Status != null)
					stringBuilder.Append(dependentEntity1.Status.Replace(',', ' '));
				stringBuilder.Append(",");
				if (dependentEntity1.LastUpdateTimestamp != null)
					stringBuilder.Append(Convert.ToString(dependentEntity1.LastUpdateTimestamp, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				stringBuilder.Append(Convert.ToString(dependentEntity1.UpdateId, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (dependentEntity1.LastUpdateUser != null)
					stringBuilder.Append(dependentEntity1.LastUpdateUser.Replace(',', ' '));
				stringCollection.Add(stringBuilder.ToString());
			}

			return stringCollection;
		}

		#endregion

		protected virtual void Sync(DependentEntity1 sourceDependentEntity1, DependentEntity1 targetDependentEntity1, DataSourceOperation dataSourceOperation)
		{
			targetDependentEntity1.ParentOwnerIndependentEntity1EntityObjectId_DBObjectValue = sourceDependentEntity1.ParentOwnerIndependentEntity1EntityObjectId_DBObjectValue;
			targetDependentEntity1.AttrBool1_DBObjectValue = sourceDependentEntity1.AttrBool1_DBObjectValue;
			targetDependentEntity1.AttrDatetime1_DBObjectValue = sourceDependentEntity1.AttrDatetime1_DBObjectValue;
			targetDependentEntity1.AttrInteger1_DBObjectValue = sourceDependentEntity1.AttrInteger1_DBObjectValue;
			targetDependentEntity1.AttrString1_DBObjectValue = sourceDependentEntity1.AttrString1_DBObjectValue;
			targetDependentEntity1.AttrString2_DBObjectValue = sourceDependentEntity1.AttrString2_DBObjectValue;
			targetDependentEntity1.Name_DBObjectValue = sourceDependentEntity1.Name_DBObjectValue;
			targetDependentEntity1.Status_DBObjectValue = sourceDependentEntity1.Status_DBObjectValue;
		}

		public int IndexOf(Guid objectInstanceId)
		{
			for (int index = 0; index < this.dependentEntity1List.Count; ++index)
			{
				if (this.dependentEntity1List[index].ObjectInstanceId == objectInstanceId)
					return index;
			}
			return -1;
		}

		public int IndexOf(DependentEntity1 dependentEntity1)
		{
			return IndexOf(dependentEntity1, this.dependentEntity1List);
		}

		private int IndexOf(DependentEntity1 dependentEntity1, DependentEntity1List dependentEntity1List)
		{
			if (dependentEntity1.ObjectId.HasValue)
			{
				CustName.AppName.DAL.DependentEntity1Identifier identifier = dependentEntity1.ObjectId.Value;
				for (int index = 0; index < dependentEntity1List.Count; ++index)
				{
					if (dependentEntity1List[index].ObjectId == identifier)
						return index;
				}
			}
			else
			{
				Guid objectInstanceId = dependentEntity1.ObjectInstanceId;
				for (int index = 0; index < dependentEntity1List.Count; ++index)
				{
					if (dependentEntity1List[index].ObjectInstanceId == objectInstanceId)
						return index;
				}
			}
			return -1;
		}
	}

	public abstract class BaseDependentEntity2BufferedDataSource : IDisposable
	{
		// Track whether Dispose has been called.
		private bool disposed = false;
		private CustName.AppName.DAL.Repository repository;
		private DependentEntity2List dependentEntity2List = new DependentEntity2List(); // Init as empty list. This member must never be null.
		private bool autoCommit = true;

		public BaseDependentEntity2BufferedDataSource()
		{
		}

		// This destructor will run only if the Dispose method does not get called.
		// Do not provide destructors in types derived from this class.
		~BaseDependentEntity2BufferedDataSource()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
			// Take object off the Finalization queue to prevent finalization code for this object from executing a second time.
			GC.SuppressFinalize(this);
		}

		// Dispose(bool disposing) executes in two distinct scenarios.
		// If disposing equals true, the method has been called directly or indirectly by a user's code.
		// Managed and unmanaged resources can be disposed.
		// If disposing equals false, the method has been called by the runtime from inside the finalizer and should not reference other objects.
		// Only unmanaged resources can be disposed.
		protected virtual void Dispose(bool disposing)
		{
			// Check to see if Dispose has already been called.
			if (!this.disposed)
			{
				// If disposing equals true, dispose all managed and unmanaged resources, otherwise only unmanaged resources.
				if (disposing)
				{
					// Dispose managed resources.
					if (this.repository != null)
					{
						if (!Settings.SingletonRepository)
							this.repository.Close();
						this.repository = null;
					}
				}
				// Release unmanaged resources.
				// If disposing is false, only the following code is executed.

				// Note that this is not thread safe.
				// Another thread could start disposing the object after the managed resources are disposed, but before the disposed flag is set to true.
				// If thread safety is necessary, it must be implemented by the client.
				disposed = true;
			}
		}

		public void Close()
		{
			Dispose();
		}

		public CustName.AppName.DAL.Repository Repository
		{
			get
			{
				if (this.repository == null)
					this.repository = Global.ClassFactory.GetDALRepository();
				return this.repository;
			}
		}

		// Returns the collection of DependentEntity2 objects managed by this data source.
		public virtual DependentEntity2List DependentEntity2List
		{
			get
			{
				return this.dependentEntity2List;
			}
		}

		// When set to true, changes made via insert, update, and delete are committed to the repository automatically without needing to call the commit method.
		public virtual bool AutoCommit
		{
			get
			{
				return this.autoCommit;
			}
			set
			{
				this.autoCommit = value;
			}
		}

		// Clear the data source.
		// Changes pending commit are lost.
		public virtual void Clear()
		{
			this.dependentEntity2List.Clear();
		}

		// Commit changes to the repository.
		public virtual void Commit()
		{
			this.Repository.Save(this.dependentEntity2List);
			// Removed deleted DependentEntity2 objects from the data source.
			IList<DependentEntity2> deletedDependentEntity2List = new List<DependentEntity2>();
			foreach (DependentEntity2 dependentEntity2 in this.dependentEntity2List)
			{
				if (dependentEntity2.ObjectStatus == CustName.AppName.DAL.ObjectStatus.Deleted)
					deletedDependentEntity2List.Add(dependentEntity2);
			}
			foreach (DependentEntity2 dependentEntity2 in deletedDependentEntity2List)
				this.dependentEntity2List.Remove(dependentEntity2);
		}

		#region Select and Select Count

		public int Count()
		{
			return this.dependentEntity2List.Count;
		}

		[DataObjectMethod(DataObjectMethodType.Select, true)]
		public virtual DependentEntity2List Select()
		{
			DependentEntity2List filteredDependentEntity2List = (DependentEntity2List)CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(CustName.AppName.DAL.EntityClass.DependentEntity2);
			foreach (DependentEntity2 dependentEntity2 in this.dependentEntity2List)
			{
				if (!dependentEntity2.MarkedForDeletion)
					filteredDependentEntity2List.Add(dependentEntity2);
			}
			return filteredDependentEntity2List;
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DataTable SelectDataTable()
		{
			return ExportToDataTable(Select());
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DependentEntity2List Select(CustName.AppName.DAL.DependentEntity2Identifier objectId)
		{
			DependentEntity2List filteredDependentEntity2List = (DependentEntity2List)CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(CustName.AppName.DAL.EntityClass.DependentEntity2);
			foreach (DependentEntity2 dependentEntity2 in this.dependentEntity2List)
			{
				if (!dependentEntity2.MarkedForDeletion && dependentEntity2.ObjectId == objectId)
				{
					filteredDependentEntity2List.Add(dependentEntity2);
					break;
				}
			}
			return filteredDependentEntity2List;
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DataTable SelectDataTable(CustName.AppName.DAL.DependentEntity2Identifier objectId)
		{
			return ExportToDataTable(Select(objectId));
		}

		#endregion

		#region Insert using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Insert, true)]
		public virtual Guid Insert(DependentEntity2 dependentEntity2)
		{
			DependentEntity2 repositoryDependentEntity2 = (DependentEntity2)CustName.AppName.BL.Global.ClassFactory.GetEntityObject(CustName.AppName.DAL.EntityClass.DependentEntity2);
			repositoryDependentEntity2.ObjectInstanceId = dependentEntity2.ObjectInstanceId;
			// Sync will also copy ObjectId.
			Sync(dependentEntity2, repositoryDependentEntity2, DataSourceOperation.Create);
			this.dependentEntity2List.Add(repositoryDependentEntity2);
			if (this.autoCommit)
				Commit();
			return repositoryDependentEntity2.ObjectInstanceId;
		}

		[DataObjectMethod(DataObjectMethodType.Insert, false)]
		public virtual Guid Insert()
		{
			return Insert((DependentEntity2)CustName.AppName.BL.Global.ClassFactory.GetEntityObject(CustName.AppName.DAL.EntityClass.DependentEntity2));
		}

		#endregion

		#region Update using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Update, true)]
		public int Update(DependentEntity2 dependentEntity2)
		{
			int index = IndexOf(dependentEntity2, this.dependentEntity2List);
			if (index == -1)
				throw new InvalidOperationException("Entity object not found.");
			Sync(dependentEntity2, this.dependentEntity2List[index], DataSourceOperation.Update);
			if (this.autoCommit)
				Commit();
			return 1;
		}

		#endregion

		#region Delete using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Delete, true)]
		public virtual int Delete(DependentEntity2 dependentEntity2)
		{
			int index = IndexOf(dependentEntity2, this.dependentEntity2List);
			if (index == -1)
				throw new InvalidOperationException("Entity object not found.");
			if (this.dependentEntity2List[index].MarkedForDeletion)
				this.dependentEntity2List[index].DecrementDeleteCount();
			else
				this.dependentEntity2List[index].IncrementDeleteCount();
			if (this.autoCommit)
				Commit();
			return 1;
		}

		#endregion

		#region Find

		public void Find(CustName.AppName.DAL.DependentEntity2Identifier objectId)
		{
			Find(objectId, false);
		}

		public virtual void Find(CustName.AppName.DAL.DependentEntity2Identifier objectId, bool append)
		{
			DependentEntity2 dependentEntity2 = (DependentEntity2)this.Repository.GetDependentEntity2(objectId);
			if (append)
			{
				if (IndexOf(dependentEntity2, this.dependentEntity2List) == -1)
					this.dependentEntity2List.Add(dependentEntity2);
			}
			else
			{
				this.dependentEntity2List = (DependentEntity2List)CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(CustName.AppName.DAL.EntityClass.DependentEntity2);
				this.dependentEntity2List.Add(dependentEntity2);
			}
		}

		public void Find(int maxCount, CustName.AppName.DAL.SearchCondition searchCondition)
		{
			Find(maxCount, searchCondition, false);
		}

		public void Find(int maxCount, CustName.AppName.DAL.SearchCondition searchCondition, bool append)
		{
			Find(maxCount, searchCondition, null, append);
		}

		// Populate data source with DependentEntity2 objects from the Repository.
		public virtual void Find(int maxCount, CustName.AppName.DAL.SearchCondition searchCondition, CustName.AppName.DAL.SortSpecification sortSpecification, bool append)
		{
			DependentEntity2List dependentEntity2List = (DependentEntity2List)this.Repository.FindDependentEntity2(maxCount, searchCondition, sortSpecification);
			if (append)
			{
				foreach (DependentEntity2 dependentEntity2 in dependentEntity2List)
				{
					if (IndexOf(dependentEntity2, this.dependentEntity2List) == -1)
						this.dependentEntity2List.Add(dependentEntity2);
				}
			}
			else
			{
				this.dependentEntity2List = dependentEntity2List;
			}
		}

		#endregion

		#region Export

		public static DataTable ExportToDataTable(DependentEntity2List dependentEntity2List)
		{
			DataTable dataTable = new DataTable();

			dataTable.Columns.Add(new DataColumn("AttrBool1", typeof(System.Boolean)));
			dataTable.Columns.Add(new DataColumn("AttrDatetime1", typeof(System.DateTime)));
			dataTable.Columns.Add(new DataColumn("AttrInteger1", typeof(System.Int32)));
			dataTable.Columns.Add(new DataColumn("AttrString1", typeof(System.String)));
			dataTable.Columns.Add(new DataColumn("AttrString2", typeof(System.String)));
			dataTable.Columns.Add(new DataColumn("CreateTimestamp", typeof(System.DateTime)));
			dataTable.Columns.Add(new DataColumn("CreateUser", typeof(System.String)));
			dataTable.Columns.Add(new DataColumn("DependentEntity1Id", typeof(System.Int32)));
			dataTable.Columns.Add(new DataColumn("DependentEntity2Id", typeof(System.Int32)));
			dataTable.Columns.Add(new DataColumn("Name", typeof(System.String)));
			dataTable.Columns.Add(new DataColumn("Status", typeof(System.String)));
			dataTable.Columns.Add(new DataColumn("LastUpdateTimestamp", typeof(System.DateTime)));
			dataTable.Columns.Add(new DataColumn("UpdateId", typeof(System.Int32)));
			dataTable.Columns.Add(new DataColumn("LastUpdateUser", typeof(System.String)));

			DataRow dataRow;
			foreach (DependentEntity2 dependentEntity2 in dependentEntity2List)
			{
				dataRow = dataTable.NewRow();
				dataRow["AttrBool1"] = dependentEntity2.AttrBool1_DBObjectValue;
				dataRow["AttrDatetime1"] = dependentEntity2.AttrDatetime1_DBObjectValue;
				dataRow["AttrInteger1"] = dependentEntity2.AttrInteger1_DBObjectValue;
				dataRow["AttrString1"] = dependentEntity2.AttrString1_DBObjectValue;
				dataRow["AttrString2"] = dependentEntity2.AttrString2_DBObjectValue;
				dataRow["CreateTimestamp"] = dependentEntity2.CreateTimestamp_DBObjectValue;
				dataRow["CreateUser"] = dependentEntity2.CreateUser_DBObjectValue;
				dataRow["DependentEntity1Id"] = dependentEntity2.DependentEntity1Id_DBObjectValue;
				dataRow["DependentEntity2Id"] = dependentEntity2.DependentEntity2Id_DBObjectValue;
				dataRow["Name"] = dependentEntity2.Name_DBObjectValue;
				dataRow["Status"] = dependentEntity2.Status_DBObjectValue;
				dataRow["LastUpdateTimestamp"] = dependentEntity2.LastUpdateTimestamp_DBObjectValue;
				dataRow["UpdateId"] = dependentEntity2.UpdateId_DBObjectValue;
				dataRow["LastUpdateUser"] = dependentEntity2.LastUpdateUser_DBObjectValue;
				dataTable.Rows.Add(dataRow);
			}

			return dataTable;
		}

		public static StringCollection ExportToCSV(DependentEntity2List dependentEntity2List)
		{
			StringCollection stringCollection = new StringCollection();

			stringCollection.Add("AttrBool1,AttrDatetime1,AttrInteger1,AttrString1,AttrString2,CreateTimestamp,CreateUser,DependentEntity1Id,DependentEntity2Id,Name,Status,LastUpdateTimestamp,UpdateId,LastUpdateUser");

			StringBuilder stringBuilder = new StringBuilder();
			foreach (DependentEntity2 dependentEntity2 in dependentEntity2List)
			{
				stringBuilder.Length = 0;
				if (dependentEntity2.AttrBool1 != null)
					stringBuilder.Append(Convert.ToString(dependentEntity2.AttrBool1, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (dependentEntity2.AttrDatetime1 != null)
					stringBuilder.Append(Convert.ToString(dependentEntity2.AttrDatetime1, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (dependentEntity2.AttrInteger1 != null)
					stringBuilder.Append(Convert.ToString(dependentEntity2.AttrInteger1, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (dependentEntity2.AttrString1 != null)
					stringBuilder.Append(dependentEntity2.AttrString1.Replace(',', ' '));
				stringBuilder.Append(",");
				if (dependentEntity2.AttrString2 != null)
					stringBuilder.Append(dependentEntity2.AttrString2.Replace(',', ' '));
				stringBuilder.Append(",");
				if (dependentEntity2.CreateTimestamp != null)
					stringBuilder.Append(Convert.ToString(dependentEntity2.CreateTimestamp, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (dependentEntity2.CreateUser != null)
					stringBuilder.Append(dependentEntity2.CreateUser.Replace(',', ' '));
				stringBuilder.Append(",");
				if (dependentEntity2.DependentEntity1Id != null)
					stringBuilder.Append(Convert.ToString(dependentEntity2.DependentEntity1Id, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (dependentEntity2.DependentEntity2Id != null)
					stringBuilder.Append(Convert.ToString(dependentEntity2.DependentEntity2Id, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (dependentEntity2.Name != null)
					stringBuilder.Append(dependentEntity2.Name.Replace(',', ' '));
				stringBuilder.Append(",");
				if (dependentEntity2.Status != null)
					stringBuilder.Append(dependentEntity2.Status.Replace(',', ' '));
				stringBuilder.Append(",");
				if (dependentEntity2.LastUpdateTimestamp != null)
					stringBuilder.Append(Convert.ToString(dependentEntity2.LastUpdateTimestamp, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				stringBuilder.Append(Convert.ToString(dependentEntity2.UpdateId, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (dependentEntity2.LastUpdateUser != null)
					stringBuilder.Append(dependentEntity2.LastUpdateUser.Replace(',', ' '));
				stringCollection.Add(stringBuilder.ToString());
			}

			return stringCollection;
		}

		#endregion

		protected virtual void Sync(DependentEntity2 sourceDependentEntity2, DependentEntity2 targetDependentEntity2, DataSourceOperation dataSourceOperation)
		{
			targetDependentEntity2.ParentOwnerDependentEntity1EntityObjectId_DBObjectValue = sourceDependentEntity2.ParentOwnerDependentEntity1EntityObjectId_DBObjectValue;
			targetDependentEntity2.AttrBool1_DBObjectValue = sourceDependentEntity2.AttrBool1_DBObjectValue;
			targetDependentEntity2.AttrDatetime1_DBObjectValue = sourceDependentEntity2.AttrDatetime1_DBObjectValue;
			targetDependentEntity2.AttrInteger1_DBObjectValue = sourceDependentEntity2.AttrInteger1_DBObjectValue;
			targetDependentEntity2.AttrString1_DBObjectValue = sourceDependentEntity2.AttrString1_DBObjectValue;
			targetDependentEntity2.AttrString2_DBObjectValue = sourceDependentEntity2.AttrString2_DBObjectValue;
			targetDependentEntity2.Name_DBObjectValue = sourceDependentEntity2.Name_DBObjectValue;
			targetDependentEntity2.Status_DBObjectValue = sourceDependentEntity2.Status_DBObjectValue;
		}

		public int IndexOf(Guid objectInstanceId)
		{
			for (int index = 0; index < this.dependentEntity2List.Count; ++index)
			{
				if (this.dependentEntity2List[index].ObjectInstanceId == objectInstanceId)
					return index;
			}
			return -1;
		}

		public int IndexOf(DependentEntity2 dependentEntity2)
		{
			return IndexOf(dependentEntity2, this.dependentEntity2List);
		}

		private int IndexOf(DependentEntity2 dependentEntity2, DependentEntity2List dependentEntity2List)
		{
			if (dependentEntity2.ObjectId.HasValue)
			{
				CustName.AppName.DAL.DependentEntity2Identifier identifier = dependentEntity2.ObjectId.Value;
				for (int index = 0; index < dependentEntity2List.Count; ++index)
				{
					if (dependentEntity2List[index].ObjectId == identifier)
						return index;
				}
			}
			else
			{
				Guid objectInstanceId = dependentEntity2.ObjectInstanceId;
				for (int index = 0; index < dependentEntity2List.Count; ++index)
				{
					if (dependentEntity2List[index].ObjectInstanceId == objectInstanceId)
						return index;
				}
			}
			return -1;
		}
	}

	public abstract class BaseIndependentEntity1BufferedDataSource : IDisposable
	{
		// Track whether Dispose has been called.
		private bool disposed = false;
		private CustName.AppName.DAL.Repository repository;
		private IndependentEntity1List independentEntity1List = new IndependentEntity1List(); // Init as empty list. This member must never be null.
		private bool autoCommit = true;

		public BaseIndependentEntity1BufferedDataSource()
		{
		}

		// This destructor will run only if the Dispose method does not get called.
		// Do not provide destructors in types derived from this class.
		~BaseIndependentEntity1BufferedDataSource()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
			// Take object off the Finalization queue to prevent finalization code for this object from executing a second time.
			GC.SuppressFinalize(this);
		}

		// Dispose(bool disposing) executes in two distinct scenarios.
		// If disposing equals true, the method has been called directly or indirectly by a user's code.
		// Managed and unmanaged resources can be disposed.
		// If disposing equals false, the method has been called by the runtime from inside the finalizer and should not reference other objects.
		// Only unmanaged resources can be disposed.
		protected virtual void Dispose(bool disposing)
		{
			// Check to see if Dispose has already been called.
			if (!this.disposed)
			{
				// If disposing equals true, dispose all managed and unmanaged resources, otherwise only unmanaged resources.
				if (disposing)
				{
					// Dispose managed resources.
					if (this.repository != null)
					{
						if (!Settings.SingletonRepository)
							this.repository.Close();
						this.repository = null;
					}
				}
				// Release unmanaged resources.
				// If disposing is false, only the following code is executed.

				// Note that this is not thread safe.
				// Another thread could start disposing the object after the managed resources are disposed, but before the disposed flag is set to true.
				// If thread safety is necessary, it must be implemented by the client.
				disposed = true;
			}
		}

		public void Close()
		{
			Dispose();
		}

		public CustName.AppName.DAL.Repository Repository
		{
			get
			{
				if (this.repository == null)
					this.repository = Global.ClassFactory.GetDALRepository();
				return this.repository;
			}
		}

		// Returns the collection of IndependentEntity1 objects managed by this data source.
		public virtual IndependentEntity1List IndependentEntity1List
		{
			get
			{
				return this.independentEntity1List;
			}
		}

		// When set to true, changes made via insert, update, and delete are committed to the repository automatically without needing to call the commit method.
		public virtual bool AutoCommit
		{
			get
			{
				return this.autoCommit;
			}
			set
			{
				this.autoCommit = value;
			}
		}

		// Clear the data source.
		// Changes pending commit are lost.
		public virtual void Clear()
		{
			this.independentEntity1List.Clear();
		}

		// Commit changes to the repository.
		public virtual void Commit()
		{
			this.Repository.Save(this.independentEntity1List);
			// Removed deleted IndependentEntity1 objects from the data source.
			IList<IndependentEntity1> deletedIndependentEntity1List = new List<IndependentEntity1>();
			foreach (IndependentEntity1 independentEntity1 in this.independentEntity1List)
			{
				if (independentEntity1.ObjectStatus == CustName.AppName.DAL.ObjectStatus.Deleted)
					deletedIndependentEntity1List.Add(independentEntity1);
			}
			foreach (IndependentEntity1 independentEntity1 in deletedIndependentEntity1List)
				this.independentEntity1List.Remove(independentEntity1);
		}

		#region Select and Select Count

		public int Count()
		{
			return this.independentEntity1List.Count;
		}

		[DataObjectMethod(DataObjectMethodType.Select, true)]
		public virtual IndependentEntity1List Select()
		{
			IndependentEntity1List filteredIndependentEntity1List = (IndependentEntity1List)CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(CustName.AppName.DAL.EntityClass.IndependentEntity1);
			foreach (IndependentEntity1 independentEntity1 in this.independentEntity1List)
			{
				if (!independentEntity1.MarkedForDeletion)
					filteredIndependentEntity1List.Add(independentEntity1);
			}
			return filteredIndependentEntity1List;
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DataTable SelectDataTable()
		{
			return ExportToDataTable(Select());
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual IndependentEntity1List Select(CustName.AppName.DAL.IndependentEntity1Identifier objectId)
		{
			IndependentEntity1List filteredIndependentEntity1List = (IndependentEntity1List)CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(CustName.AppName.DAL.EntityClass.IndependentEntity1);
			foreach (IndependentEntity1 independentEntity1 in this.independentEntity1List)
			{
				if (!independentEntity1.MarkedForDeletion && independentEntity1.ObjectId == objectId)
				{
					filteredIndependentEntity1List.Add(independentEntity1);
					break;
				}
			}
			return filteredIndependentEntity1List;
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DataTable SelectDataTable(CustName.AppName.DAL.IndependentEntity1Identifier objectId)
		{
			return ExportToDataTable(Select(objectId));
		}

		#endregion

		#region Insert using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Insert, true)]
		public virtual Guid Insert(IndependentEntity1 independentEntity1)
		{
			IndependentEntity1 repositoryIndependentEntity1 = (IndependentEntity1)CustName.AppName.BL.Global.ClassFactory.GetEntityObject(CustName.AppName.DAL.EntityClass.IndependentEntity1);
			repositoryIndependentEntity1.ObjectInstanceId = independentEntity1.ObjectInstanceId;
			// Sync will also copy ObjectId.
			Sync(independentEntity1, repositoryIndependentEntity1, DataSourceOperation.Create);
			this.independentEntity1List.Add(repositoryIndependentEntity1);
			if (this.autoCommit)
				Commit();
			return repositoryIndependentEntity1.ObjectInstanceId;
		}

		[DataObjectMethod(DataObjectMethodType.Insert, false)]
		public virtual Guid Insert()
		{
			return Insert((IndependentEntity1)CustName.AppName.BL.Global.ClassFactory.GetEntityObject(CustName.AppName.DAL.EntityClass.IndependentEntity1));
		}

		#endregion

		#region Update using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Update, true)]
		public int Update(IndependentEntity1 independentEntity1)
		{
			int index = IndexOf(independentEntity1, this.independentEntity1List);
			if (index == -1)
				throw new InvalidOperationException("Entity object not found.");
			Sync(independentEntity1, this.independentEntity1List[index], DataSourceOperation.Update);
			if (this.autoCommit)
				Commit();
			return 1;
		}

		#endregion

		#region Delete using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Delete, true)]
		public virtual int Delete(IndependentEntity1 independentEntity1)
		{
			int index = IndexOf(independentEntity1, this.independentEntity1List);
			if (index == -1)
				throw new InvalidOperationException("Entity object not found.");
			if (this.independentEntity1List[index].MarkedForDeletion)
				this.independentEntity1List[index].DecrementDeleteCount();
			else
				this.independentEntity1List[index].IncrementDeleteCount();
			if (this.autoCommit)
				Commit();
			return 1;
		}

		#endregion

		#region Find

		public void Find(CustName.AppName.DAL.IndependentEntity1Identifier objectId)
		{
			Find(objectId, false);
		}

		public virtual void Find(CustName.AppName.DAL.IndependentEntity1Identifier objectId, bool append)
		{
			IndependentEntity1 independentEntity1 = (IndependentEntity1)this.Repository.GetIndependentEntity1(objectId);
			if (append)
			{
				if (IndexOf(independentEntity1, this.independentEntity1List) == -1)
					this.independentEntity1List.Add(independentEntity1);
			}
			else
			{
				this.independentEntity1List = (IndependentEntity1List)CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(CustName.AppName.DAL.EntityClass.IndependentEntity1);
				this.independentEntity1List.Add(independentEntity1);
			}
		}

		public void Find(int maxCount, CustName.AppName.DAL.SearchCondition searchCondition)
		{
			Find(maxCount, searchCondition, false);
		}

		public void Find(int maxCount, CustName.AppName.DAL.SearchCondition searchCondition, bool append)
		{
			Find(maxCount, searchCondition, null, append);
		}

		// Populate data source with IndependentEntity1 objects from the Repository.
		public virtual void Find(int maxCount, CustName.AppName.DAL.SearchCondition searchCondition, CustName.AppName.DAL.SortSpecification sortSpecification, bool append)
		{
			IndependentEntity1List independentEntity1List = (IndependentEntity1List)this.Repository.FindIndependentEntity1(maxCount, searchCondition, sortSpecification);
			if (append)
			{
				foreach (IndependentEntity1 independentEntity1 in independentEntity1List)
				{
					if (IndexOf(independentEntity1, this.independentEntity1List) == -1)
						this.independentEntity1List.Add(independentEntity1);
				}
			}
			else
			{
				this.independentEntity1List = independentEntity1List;
			}
		}

		#endregion

		#region Export

		public static DataTable ExportToDataTable(IndependentEntity1List independentEntity1List)
		{
			DataTable dataTable = new DataTable();

			dataTable.Columns.Add(new DataColumn("AttrBool1", typeof(System.Boolean)));
			dataTable.Columns.Add(new DataColumn("AttrDatetime1", typeof(System.DateTime)));
			dataTable.Columns.Add(new DataColumn("AttrInteger1", typeof(System.Int32)));
			dataTable.Columns.Add(new DataColumn("AttrString1", typeof(System.String)));
			dataTable.Columns.Add(new DataColumn("AttrString2", typeof(System.String)));
			dataTable.Columns.Add(new DataColumn("CreateTimestamp", typeof(System.DateTime)));
			dataTable.Columns.Add(new DataColumn("CreateUser", typeof(System.String)));
			dataTable.Columns.Add(new DataColumn("IndependentEntity1Id", typeof(System.Int32)));
			dataTable.Columns.Add(new DataColumn("Name", typeof(System.String)));
			dataTable.Columns.Add(new DataColumn("Status", typeof(System.String)));
			dataTable.Columns.Add(new DataColumn("LastUpdateTimestamp", typeof(System.DateTime)));
			dataTable.Columns.Add(new DataColumn("UpdateId", typeof(System.Int32)));
			dataTable.Columns.Add(new DataColumn("LastUpdateUser", typeof(System.String)));

			DataRow dataRow;
			foreach (IndependentEntity1 independentEntity1 in independentEntity1List)
			{
				dataRow = dataTable.NewRow();
				dataRow["AttrBool1"] = independentEntity1.AttrBool1_DBObjectValue;
				dataRow["AttrDatetime1"] = independentEntity1.AttrDatetime1_DBObjectValue;
				dataRow["AttrInteger1"] = independentEntity1.AttrInteger1_DBObjectValue;
				dataRow["AttrString1"] = independentEntity1.AttrString1_DBObjectValue;
				dataRow["AttrString2"] = independentEntity1.AttrString2_DBObjectValue;
				dataRow["CreateTimestamp"] = independentEntity1.CreateTimestamp_DBObjectValue;
				dataRow["CreateUser"] = independentEntity1.CreateUser_DBObjectValue;
				dataRow["IndependentEntity1Id"] = independentEntity1.IndependentEntity1Id_DBObjectValue;
				dataRow["Name"] = independentEntity1.Name_DBObjectValue;
				dataRow["Status"] = independentEntity1.Status_DBObjectValue;
				dataRow["LastUpdateTimestamp"] = independentEntity1.LastUpdateTimestamp_DBObjectValue;
				dataRow["UpdateId"] = independentEntity1.UpdateId_DBObjectValue;
				dataRow["LastUpdateUser"] = independentEntity1.LastUpdateUser_DBObjectValue;
				dataTable.Rows.Add(dataRow);
			}

			return dataTable;
		}

		public static StringCollection ExportToCSV(IndependentEntity1List independentEntity1List)
		{
			StringCollection stringCollection = new StringCollection();

			stringCollection.Add("AttrBool1,AttrDatetime1,AttrInteger1,AttrString1,AttrString2,CreateTimestamp,CreateUser,IndependentEntity1Id,Name,Status,LastUpdateTimestamp,UpdateId,LastUpdateUser");

			StringBuilder stringBuilder = new StringBuilder();
			foreach (IndependentEntity1 independentEntity1 in independentEntity1List)
			{
				stringBuilder.Length = 0;
				if (independentEntity1.AttrBool1 != null)
					stringBuilder.Append(Convert.ToString(independentEntity1.AttrBool1, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (independentEntity1.AttrDatetime1 != null)
					stringBuilder.Append(Convert.ToString(independentEntity1.AttrDatetime1, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (independentEntity1.AttrInteger1 != null)
					stringBuilder.Append(Convert.ToString(independentEntity1.AttrInteger1, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (independentEntity1.AttrString1 != null)
					stringBuilder.Append(independentEntity1.AttrString1.Replace(',', ' '));
				stringBuilder.Append(",");
				if (independentEntity1.AttrString2 != null)
					stringBuilder.Append(independentEntity1.AttrString2.Replace(',', ' '));
				stringBuilder.Append(",");
				if (independentEntity1.CreateTimestamp != null)
					stringBuilder.Append(Convert.ToString(independentEntity1.CreateTimestamp, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (independentEntity1.CreateUser != null)
					stringBuilder.Append(independentEntity1.CreateUser.Replace(',', ' '));
				stringBuilder.Append(",");
				if (independentEntity1.IndependentEntity1Id != null)
					stringBuilder.Append(Convert.ToString(independentEntity1.IndependentEntity1Id, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (independentEntity1.Name != null)
					stringBuilder.Append(independentEntity1.Name.Replace(',', ' '));
				stringBuilder.Append(",");
				if (independentEntity1.Status != null)
					stringBuilder.Append(independentEntity1.Status.Replace(',', ' '));
				stringBuilder.Append(",");
				if (independentEntity1.LastUpdateTimestamp != null)
					stringBuilder.Append(Convert.ToString(independentEntity1.LastUpdateTimestamp, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				stringBuilder.Append(Convert.ToString(independentEntity1.UpdateId, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (independentEntity1.LastUpdateUser != null)
					stringBuilder.Append(independentEntity1.LastUpdateUser.Replace(',', ' '));
				stringCollection.Add(stringBuilder.ToString());
			}

			return stringCollection;
		}

		#endregion

		protected virtual void Sync(IndependentEntity1 sourceIndependentEntity1, IndependentEntity1 targetIndependentEntity1, DataSourceOperation dataSourceOperation)
		{
			targetIndependentEntity1.AttrBool1_DBObjectValue = sourceIndependentEntity1.AttrBool1_DBObjectValue;
			targetIndependentEntity1.AttrDatetime1_DBObjectValue = sourceIndependentEntity1.AttrDatetime1_DBObjectValue;
			targetIndependentEntity1.AttrInteger1_DBObjectValue = sourceIndependentEntity1.AttrInteger1_DBObjectValue;
			targetIndependentEntity1.AttrString1_DBObjectValue = sourceIndependentEntity1.AttrString1_DBObjectValue;
			targetIndependentEntity1.AttrString2_DBObjectValue = sourceIndependentEntity1.AttrString2_DBObjectValue;
			targetIndependentEntity1.Name_DBObjectValue = sourceIndependentEntity1.Name_DBObjectValue;
			targetIndependentEntity1.Status_DBObjectValue = sourceIndependentEntity1.Status_DBObjectValue;
		}

		public int IndexOf(Guid objectInstanceId)
		{
			for (int index = 0; index < this.independentEntity1List.Count; ++index)
			{
				if (this.independentEntity1List[index].ObjectInstanceId == objectInstanceId)
					return index;
			}
			return -1;
		}

		public int IndexOf(IndependentEntity1 independentEntity1)
		{
			return IndexOf(independentEntity1, this.independentEntity1List);
		}

		private int IndexOf(IndependentEntity1 independentEntity1, IndependentEntity1List independentEntity1List)
		{
			if (independentEntity1.ObjectId.HasValue)
			{
				CustName.AppName.DAL.IndependentEntity1Identifier identifier = independentEntity1.ObjectId.Value;
				for (int index = 0; index < independentEntity1List.Count; ++index)
				{
					if (independentEntity1List[index].ObjectId == identifier)
						return index;
				}
			}
			else
			{
				Guid objectInstanceId = independentEntity1.ObjectInstanceId;
				for (int index = 0; index < independentEntity1List.Count; ++index)
				{
					if (independentEntity1List[index].ObjectInstanceId == objectInstanceId)
						return index;
				}
			}
			return -1;
		}
	}

	public abstract class BaseIndependentEntity2BufferedDataSource : IDisposable
	{
		// Track whether Dispose has been called.
		private bool disposed = false;
		private CustName.AppName.DAL.Repository repository;
		private IndependentEntity2List independentEntity2List = new IndependentEntity2List(); // Init as empty list. This member must never be null.
		private bool autoCommit = true;

		public BaseIndependentEntity2BufferedDataSource()
		{
		}

		// This destructor will run only if the Dispose method does not get called.
		// Do not provide destructors in types derived from this class.
		~BaseIndependentEntity2BufferedDataSource()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
			// Take object off the Finalization queue to prevent finalization code for this object from executing a second time.
			GC.SuppressFinalize(this);
		}

		// Dispose(bool disposing) executes in two distinct scenarios.
		// If disposing equals true, the method has been called directly or indirectly by a user's code.
		// Managed and unmanaged resources can be disposed.
		// If disposing equals false, the method has been called by the runtime from inside the finalizer and should not reference other objects.
		// Only unmanaged resources can be disposed.
		protected virtual void Dispose(bool disposing)
		{
			// Check to see if Dispose has already been called.
			if (!this.disposed)
			{
				// If disposing equals true, dispose all managed and unmanaged resources, otherwise only unmanaged resources.
				if (disposing)
				{
					// Dispose managed resources.
					if (this.repository != null)
					{
						if (!Settings.SingletonRepository)
							this.repository.Close();
						this.repository = null;
					}
				}
				// Release unmanaged resources.
				// If disposing is false, only the following code is executed.

				// Note that this is not thread safe.
				// Another thread could start disposing the object after the managed resources are disposed, but before the disposed flag is set to true.
				// If thread safety is necessary, it must be implemented by the client.
				disposed = true;
			}
		}

		public void Close()
		{
			Dispose();
		}

		public CustName.AppName.DAL.Repository Repository
		{
			get
			{
				if (this.repository == null)
					this.repository = Global.ClassFactory.GetDALRepository();
				return this.repository;
			}
		}

		// Returns the collection of IndependentEntity2 objects managed by this data source.
		public virtual IndependentEntity2List IndependentEntity2List
		{
			get
			{
				return this.independentEntity2List;
			}
		}

		// When set to true, changes made via insert, update, and delete are committed to the repository automatically without needing to call the commit method.
		public virtual bool AutoCommit
		{
			get
			{
				return this.autoCommit;
			}
			set
			{
				this.autoCommit = value;
			}
		}

		// Clear the data source.
		// Changes pending commit are lost.
		public virtual void Clear()
		{
			this.independentEntity2List.Clear();
		}

		// Commit changes to the repository.
		public virtual void Commit()
		{
			this.Repository.Save(this.independentEntity2List);
			// Removed deleted IndependentEntity2 objects from the data source.
			IList<IndependentEntity2> deletedIndependentEntity2List = new List<IndependentEntity2>();
			foreach (IndependentEntity2 independentEntity2 in this.independentEntity2List)
			{
				if (independentEntity2.ObjectStatus == CustName.AppName.DAL.ObjectStatus.Deleted)
					deletedIndependentEntity2List.Add(independentEntity2);
			}
			foreach (IndependentEntity2 independentEntity2 in deletedIndependentEntity2List)
				this.independentEntity2List.Remove(independentEntity2);
		}

		#region Select and Select Count

		public int Count()
		{
			return this.independentEntity2List.Count;
		}

		[DataObjectMethod(DataObjectMethodType.Select, true)]
		public virtual IndependentEntity2List Select()
		{
			IndependentEntity2List filteredIndependentEntity2List = (IndependentEntity2List)CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(CustName.AppName.DAL.EntityClass.IndependentEntity2);
			foreach (IndependentEntity2 independentEntity2 in this.independentEntity2List)
			{
				if (!independentEntity2.MarkedForDeletion)
					filteredIndependentEntity2List.Add(independentEntity2);
			}
			return filteredIndependentEntity2List;
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DataTable SelectDataTable()
		{
			return ExportToDataTable(Select());
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual IndependentEntity2List Select(CustName.AppName.DAL.IndependentEntity2Identifier objectId)
		{
			IndependentEntity2List filteredIndependentEntity2List = (IndependentEntity2List)CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(CustName.AppName.DAL.EntityClass.IndependentEntity2);
			foreach (IndependentEntity2 independentEntity2 in this.independentEntity2List)
			{
				if (!independentEntity2.MarkedForDeletion && independentEntity2.ObjectId == objectId)
				{
					filteredIndependentEntity2List.Add(independentEntity2);
					break;
				}
			}
			return filteredIndependentEntity2List;
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DataTable SelectDataTable(CustName.AppName.DAL.IndependentEntity2Identifier objectId)
		{
			return ExportToDataTable(Select(objectId));
		}

		#endregion

		#region Insert using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Insert, true)]
		public virtual Guid Insert(IndependentEntity2 independentEntity2)
		{
			IndependentEntity2 repositoryIndependentEntity2 = (IndependentEntity2)CustName.AppName.BL.Global.ClassFactory.GetEntityObject(CustName.AppName.DAL.EntityClass.IndependentEntity2);
			repositoryIndependentEntity2.ObjectInstanceId = independentEntity2.ObjectInstanceId;
			// Sync will also copy ObjectId.
			Sync(independentEntity2, repositoryIndependentEntity2, DataSourceOperation.Create);
			this.independentEntity2List.Add(repositoryIndependentEntity2);
			if (this.autoCommit)
				Commit();
			return repositoryIndependentEntity2.ObjectInstanceId;
		}

		[DataObjectMethod(DataObjectMethodType.Insert, false)]
		public virtual Guid Insert()
		{
			return Insert((IndependentEntity2)CustName.AppName.BL.Global.ClassFactory.GetEntityObject(CustName.AppName.DAL.EntityClass.IndependentEntity2));
		}

		#endregion

		#region Update using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Update, true)]
		public int Update(IndependentEntity2 independentEntity2)
		{
			int index = IndexOf(independentEntity2, this.independentEntity2List);
			if (index == -1)
				throw new InvalidOperationException("Entity object not found.");
			Sync(independentEntity2, this.independentEntity2List[index], DataSourceOperation.Update);
			if (this.autoCommit)
				Commit();
			return 1;
		}

		#endregion

		#region Delete using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Delete, true)]
		public virtual int Delete(IndependentEntity2 independentEntity2)
		{
			int index = IndexOf(independentEntity2, this.independentEntity2List);
			if (index == -1)
				throw new InvalidOperationException("Entity object not found.");
			if (this.independentEntity2List[index].MarkedForDeletion)
				this.independentEntity2List[index].DecrementDeleteCount();
			else
				this.independentEntity2List[index].IncrementDeleteCount();
			if (this.autoCommit)
				Commit();
			return 1;
		}

		#endregion

		#region Find

		public void Find(CustName.AppName.DAL.IndependentEntity2Identifier objectId)
		{
			Find(objectId, false);
		}

		public virtual void Find(CustName.AppName.DAL.IndependentEntity2Identifier objectId, bool append)
		{
			IndependentEntity2 independentEntity2 = (IndependentEntity2)this.Repository.GetIndependentEntity2(objectId);
			if (append)
			{
				if (IndexOf(independentEntity2, this.independentEntity2List) == -1)
					this.independentEntity2List.Add(independentEntity2);
			}
			else
			{
				this.independentEntity2List = (IndependentEntity2List)CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(CustName.AppName.DAL.EntityClass.IndependentEntity2);
				this.independentEntity2List.Add(independentEntity2);
			}
		}

		public void Find(int maxCount, CustName.AppName.DAL.SearchCondition searchCondition)
		{
			Find(maxCount, searchCondition, false);
		}

		public void Find(int maxCount, CustName.AppName.DAL.SearchCondition searchCondition, bool append)
		{
			Find(maxCount, searchCondition, null, append);
		}

		// Populate data source with IndependentEntity2 objects from the Repository.
		public virtual void Find(int maxCount, CustName.AppName.DAL.SearchCondition searchCondition, CustName.AppName.DAL.SortSpecification sortSpecification, bool append)
		{
			IndependentEntity2List independentEntity2List = (IndependentEntity2List)this.Repository.FindIndependentEntity2(maxCount, searchCondition, sortSpecification);
			if (append)
			{
				foreach (IndependentEntity2 independentEntity2 in independentEntity2List)
				{
					if (IndexOf(independentEntity2, this.independentEntity2List) == -1)
						this.independentEntity2List.Add(independentEntity2);
				}
			}
			else
			{
				this.independentEntity2List = independentEntity2List;
			}
		}

		#endregion

		#region Export

		public static DataTable ExportToDataTable(IndependentEntity2List independentEntity2List)
		{
			DataTable dataTable = new DataTable();

			dataTable.Columns.Add(new DataColumn("AttrBool1", typeof(System.Boolean)));
			dataTable.Columns.Add(new DataColumn("AttrDatetime1", typeof(System.DateTime)));
			dataTable.Columns.Add(new DataColumn("AttrInteger1", typeof(System.Int32)));
			dataTable.Columns.Add(new DataColumn("AttrString1", typeof(System.String)));
			dataTable.Columns.Add(new DataColumn("AttrString2", typeof(System.String)));
			dataTable.Columns.Add(new DataColumn("CreateTimestamp", typeof(System.DateTime)));
			dataTable.Columns.Add(new DataColumn("CreateUser", typeof(System.String)));
			dataTable.Columns.Add(new DataColumn("IndependentEntity2Id", typeof(System.Int32)));
			dataTable.Columns.Add(new DataColumn("Name", typeof(System.String)));
			dataTable.Columns.Add(new DataColumn("Status", typeof(System.String)));
			dataTable.Columns.Add(new DataColumn("LastUpdateTimestamp", typeof(System.DateTime)));
			dataTable.Columns.Add(new DataColumn("UpdateId", typeof(System.Int32)));
			dataTable.Columns.Add(new DataColumn("LastUpdateUser", typeof(System.String)));

			DataRow dataRow;
			foreach (IndependentEntity2 independentEntity2 in independentEntity2List)
			{
				dataRow = dataTable.NewRow();
				dataRow["AttrBool1"] = independentEntity2.AttrBool1_DBObjectValue;
				dataRow["AttrDatetime1"] = independentEntity2.AttrDatetime1_DBObjectValue;
				dataRow["AttrInteger1"] = independentEntity2.AttrInteger1_DBObjectValue;
				dataRow["AttrString1"] = independentEntity2.AttrString1_DBObjectValue;
				dataRow["AttrString2"] = independentEntity2.AttrString2_DBObjectValue;
				dataRow["CreateTimestamp"] = independentEntity2.CreateTimestamp_DBObjectValue;
				dataRow["CreateUser"] = independentEntity2.CreateUser_DBObjectValue;
				dataRow["IndependentEntity2Id"] = independentEntity2.IndependentEntity2Id_DBObjectValue;
				dataRow["Name"] = independentEntity2.Name_DBObjectValue;
				dataRow["Status"] = independentEntity2.Status_DBObjectValue;
				dataRow["LastUpdateTimestamp"] = independentEntity2.LastUpdateTimestamp_DBObjectValue;
				dataRow["UpdateId"] = independentEntity2.UpdateId_DBObjectValue;
				dataRow["LastUpdateUser"] = independentEntity2.LastUpdateUser_DBObjectValue;
				dataTable.Rows.Add(dataRow);
			}

			return dataTable;
		}

		public static StringCollection ExportToCSV(IndependentEntity2List independentEntity2List)
		{
			StringCollection stringCollection = new StringCollection();

			stringCollection.Add("AttrBool1,AttrDatetime1,AttrInteger1,AttrString1,AttrString2,CreateTimestamp,CreateUser,IndependentEntity2Id,Name,Status,LastUpdateTimestamp,UpdateId,LastUpdateUser");

			StringBuilder stringBuilder = new StringBuilder();
			foreach (IndependentEntity2 independentEntity2 in independentEntity2List)
			{
				stringBuilder.Length = 0;
				if (independentEntity2.AttrBool1 != null)
					stringBuilder.Append(Convert.ToString(independentEntity2.AttrBool1, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (independentEntity2.AttrDatetime1 != null)
					stringBuilder.Append(Convert.ToString(independentEntity2.AttrDatetime1, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (independentEntity2.AttrInteger1 != null)
					stringBuilder.Append(Convert.ToString(independentEntity2.AttrInteger1, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (independentEntity2.AttrString1 != null)
					stringBuilder.Append(independentEntity2.AttrString1.Replace(',', ' '));
				stringBuilder.Append(",");
				if (independentEntity2.AttrString2 != null)
					stringBuilder.Append(independentEntity2.AttrString2.Replace(',', ' '));
				stringBuilder.Append(",");
				if (independentEntity2.CreateTimestamp != null)
					stringBuilder.Append(Convert.ToString(independentEntity2.CreateTimestamp, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (independentEntity2.CreateUser != null)
					stringBuilder.Append(independentEntity2.CreateUser.Replace(',', ' '));
				stringBuilder.Append(",");
				if (independentEntity2.IndependentEntity2Id != null)
					stringBuilder.Append(Convert.ToString(independentEntity2.IndependentEntity2Id, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (independentEntity2.Name != null)
					stringBuilder.Append(independentEntity2.Name.Replace(',', ' '));
				stringBuilder.Append(",");
				if (independentEntity2.Status != null)
					stringBuilder.Append(independentEntity2.Status.Replace(',', ' '));
				stringBuilder.Append(",");
				if (independentEntity2.LastUpdateTimestamp != null)
					stringBuilder.Append(Convert.ToString(independentEntity2.LastUpdateTimestamp, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				stringBuilder.Append(Convert.ToString(independentEntity2.UpdateId, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (independentEntity2.LastUpdateUser != null)
					stringBuilder.Append(independentEntity2.LastUpdateUser.Replace(',', ' '));
				stringCollection.Add(stringBuilder.ToString());
			}

			return stringCollection;
		}

		#endregion

		protected virtual void Sync(IndependentEntity2 sourceIndependentEntity2, IndependentEntity2 targetIndependentEntity2, DataSourceOperation dataSourceOperation)
		{
			targetIndependentEntity2.AttrBool1_DBObjectValue = sourceIndependentEntity2.AttrBool1_DBObjectValue;
			targetIndependentEntity2.AttrDatetime1_DBObjectValue = sourceIndependentEntity2.AttrDatetime1_DBObjectValue;
			targetIndependentEntity2.AttrInteger1_DBObjectValue = sourceIndependentEntity2.AttrInteger1_DBObjectValue;
			targetIndependentEntity2.AttrString1_DBObjectValue = sourceIndependentEntity2.AttrString1_DBObjectValue;
			targetIndependentEntity2.AttrString2_DBObjectValue = sourceIndependentEntity2.AttrString2_DBObjectValue;
			targetIndependentEntity2.Name_DBObjectValue = sourceIndependentEntity2.Name_DBObjectValue;
			targetIndependentEntity2.Status_DBObjectValue = sourceIndependentEntity2.Status_DBObjectValue;
		}

		public int IndexOf(Guid objectInstanceId)
		{
			for (int index = 0; index < this.independentEntity2List.Count; ++index)
			{
				if (this.independentEntity2List[index].ObjectInstanceId == objectInstanceId)
					return index;
			}
			return -1;
		}

		public int IndexOf(IndependentEntity2 independentEntity2)
		{
			return IndexOf(independentEntity2, this.independentEntity2List);
		}

		private int IndexOf(IndependentEntity2 independentEntity2, IndependentEntity2List independentEntity2List)
		{
			if (independentEntity2.ObjectId.HasValue)
			{
				CustName.AppName.DAL.IndependentEntity2Identifier identifier = independentEntity2.ObjectId.Value;
				for (int index = 0; index < independentEntity2List.Count; ++index)
				{
					if (independentEntity2List[index].ObjectId == identifier)
						return index;
				}
			}
			else
			{
				Guid objectInstanceId = independentEntity2.ObjectInstanceId;
				for (int index = 0; index < independentEntity2List.Count; ++index)
				{
					if (independentEntity2List[index].ObjectInstanceId == objectInstanceId)
						return index;
				}
			}
			return -1;
		}
	}

	public abstract class BaseRelationshipEntity1BufferedDataSource : IDisposable
	{
		// Track whether Dispose has been called.
		private bool disposed = false;
		private CustName.AppName.DAL.Repository repository;
		private RelationshipEntity1List relationshipEntity1List = new RelationshipEntity1List(); // Init as empty list. This member must never be null.
		private bool autoCommit = true;

		public BaseRelationshipEntity1BufferedDataSource()
		{
		}

		// This destructor will run only if the Dispose method does not get called.
		// Do not provide destructors in types derived from this class.
		~BaseRelationshipEntity1BufferedDataSource()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
			// Take object off the Finalization queue to prevent finalization code for this object from executing a second time.
			GC.SuppressFinalize(this);
		}

		// Dispose(bool disposing) executes in two distinct scenarios.
		// If disposing equals true, the method has been called directly or indirectly by a user's code.
		// Managed and unmanaged resources can be disposed.
		// If disposing equals false, the method has been called by the runtime from inside the finalizer and should not reference other objects.
		// Only unmanaged resources can be disposed.
		protected virtual void Dispose(bool disposing)
		{
			// Check to see if Dispose has already been called.
			if (!this.disposed)
			{
				// If disposing equals true, dispose all managed and unmanaged resources, otherwise only unmanaged resources.
				if (disposing)
				{
					// Dispose managed resources.
					if (this.repository != null)
					{
						if (!Settings.SingletonRepository)
							this.repository.Close();
						this.repository = null;
					}
				}
				// Release unmanaged resources.
				// If disposing is false, only the following code is executed.

				// Note that this is not thread safe.
				// Another thread could start disposing the object after the managed resources are disposed, but before the disposed flag is set to true.
				// If thread safety is necessary, it must be implemented by the client.
				disposed = true;
			}
		}

		public void Close()
		{
			Dispose();
		}

		public CustName.AppName.DAL.Repository Repository
		{
			get
			{
				if (this.repository == null)
					this.repository = Global.ClassFactory.GetDALRepository();
				return this.repository;
			}
		}

		// Returns the collection of RelationshipEntity1 objects managed by this data source.
		public virtual RelationshipEntity1List RelationshipEntity1List
		{
			get
			{
				return this.relationshipEntity1List;
			}
		}

		// When set to true, changes made via insert, update, and delete are committed to the repository automatically without needing to call the commit method.
		public virtual bool AutoCommit
		{
			get
			{
				return this.autoCommit;
			}
			set
			{
				this.autoCommit = value;
			}
		}

		// Clear the data source.
		// Changes pending commit are lost.
		public virtual void Clear()
		{
			this.relationshipEntity1List.Clear();
		}

		// Commit changes to the repository.
		public virtual void Commit()
		{
			this.Repository.Save(this.relationshipEntity1List);
			// Removed deleted RelationshipEntity1 objects from the data source.
			IList<RelationshipEntity1> deletedRelationshipEntity1List = new List<RelationshipEntity1>();
			foreach (RelationshipEntity1 relationshipEntity1 in this.relationshipEntity1List)
			{
				if (relationshipEntity1.ObjectStatus == CustName.AppName.DAL.ObjectStatus.Deleted)
					deletedRelationshipEntity1List.Add(relationshipEntity1);
			}
			foreach (RelationshipEntity1 relationshipEntity1 in deletedRelationshipEntity1List)
				this.relationshipEntity1List.Remove(relationshipEntity1);
		}

		#region Select and Select Count

		public int Count()
		{
			return this.relationshipEntity1List.Count;
		}

		[DataObjectMethod(DataObjectMethodType.Select, true)]
		public virtual RelationshipEntity1List Select()
		{
			RelationshipEntity1List filteredRelationshipEntity1List = (RelationshipEntity1List)CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(CustName.AppName.DAL.EntityClass.RelationshipEntity1);
			foreach (RelationshipEntity1 relationshipEntity1 in this.relationshipEntity1List)
			{
				if (!relationshipEntity1.MarkedForDeletion)
					filteredRelationshipEntity1List.Add(relationshipEntity1);
			}
			return filteredRelationshipEntity1List;
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DataTable SelectDataTable()
		{
			return ExportToDataTable(Select());
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual RelationshipEntity1List Select(CustName.AppName.DAL.RelationshipEntity1Identifier objectId)
		{
			RelationshipEntity1List filteredRelationshipEntity1List = (RelationshipEntity1List)CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(CustName.AppName.DAL.EntityClass.RelationshipEntity1);
			foreach (RelationshipEntity1 relationshipEntity1 in this.relationshipEntity1List)
			{
				if (!relationshipEntity1.MarkedForDeletion && relationshipEntity1.ObjectId == objectId)
				{
					filteredRelationshipEntity1List.Add(relationshipEntity1);
					break;
				}
			}
			return filteredRelationshipEntity1List;
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DataTable SelectDataTable(CustName.AppName.DAL.RelationshipEntity1Identifier objectId)
		{
			return ExportToDataTable(Select(objectId));
		}

		#endregion

		#region Insert using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Insert, true)]
		public virtual Guid Insert(RelationshipEntity1 relationshipEntity1)
		{
			RelationshipEntity1 repositoryRelationshipEntity1 = (RelationshipEntity1)CustName.AppName.BL.Global.ClassFactory.GetEntityObject(CustName.AppName.DAL.EntityClass.RelationshipEntity1);
			repositoryRelationshipEntity1.ObjectInstanceId = relationshipEntity1.ObjectInstanceId;
			// Sync will also copy ObjectId.
			Sync(relationshipEntity1, repositoryRelationshipEntity1, DataSourceOperation.Create);
			this.relationshipEntity1List.Add(repositoryRelationshipEntity1);
			if (this.autoCommit)
				Commit();
			return repositoryRelationshipEntity1.ObjectInstanceId;
		}

		[DataObjectMethod(DataObjectMethodType.Insert, false)]
		public virtual Guid Insert()
		{
			return Insert((RelationshipEntity1)CustName.AppName.BL.Global.ClassFactory.GetEntityObject(CustName.AppName.DAL.EntityClass.RelationshipEntity1));
		}

		#endregion

		#region Update using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Update, true)]
		public int Update(RelationshipEntity1 relationshipEntity1)
		{
			int index = IndexOf(relationshipEntity1, this.relationshipEntity1List);
			if (index == -1)
				throw new InvalidOperationException("Entity object not found.");
			Sync(relationshipEntity1, this.relationshipEntity1List[index], DataSourceOperation.Update);
			if (this.autoCommit)
				Commit();
			return 1;
		}

		#endregion

		#region Delete using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Delete, true)]
		public virtual int Delete(RelationshipEntity1 relationshipEntity1)
		{
			int index = IndexOf(relationshipEntity1, this.relationshipEntity1List);
			if (index == -1)
				throw new InvalidOperationException("Entity object not found.");
			if (this.relationshipEntity1List[index].MarkedForDeletion)
				this.relationshipEntity1List[index].DecrementDeleteCount();
			else
				this.relationshipEntity1List[index].IncrementDeleteCount();
			if (this.autoCommit)
				Commit();
			return 1;
		}

		#endregion

		#region Find

		public void Find(CustName.AppName.DAL.RelationshipEntity1Identifier objectId)
		{
			Find(objectId, false);
		}

		public virtual void Find(CustName.AppName.DAL.RelationshipEntity1Identifier objectId, bool append)
		{
			RelationshipEntity1 relationshipEntity1 = (RelationshipEntity1)this.Repository.GetRelationshipEntity1(objectId);
			if (append)
			{
				if (IndexOf(relationshipEntity1, this.relationshipEntity1List) == -1)
					this.relationshipEntity1List.Add(relationshipEntity1);
			}
			else
			{
				this.relationshipEntity1List = (RelationshipEntity1List)CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(CustName.AppName.DAL.EntityClass.RelationshipEntity1);
				this.relationshipEntity1List.Add(relationshipEntity1);
			}
		}

		public void Find(int maxCount, CustName.AppName.DAL.SearchCondition searchCondition)
		{
			Find(maxCount, searchCondition, false);
		}

		public void Find(int maxCount, CustName.AppName.DAL.SearchCondition searchCondition, bool append)
		{
			Find(maxCount, searchCondition, null, append);
		}

		// Populate data source with RelationshipEntity1 objects from the Repository.
		public virtual void Find(int maxCount, CustName.AppName.DAL.SearchCondition searchCondition, CustName.AppName.DAL.SortSpecification sortSpecification, bool append)
		{
			RelationshipEntity1List relationshipEntity1List = (RelationshipEntity1List)this.Repository.FindRelationshipEntity1(maxCount, searchCondition, sortSpecification);
			if (append)
			{
				foreach (RelationshipEntity1 relationshipEntity1 in relationshipEntity1List)
				{
					if (IndexOf(relationshipEntity1, this.relationshipEntity1List) == -1)
						this.relationshipEntity1List.Add(relationshipEntity1);
				}
			}
			else
			{
				this.relationshipEntity1List = relationshipEntity1List;
			}
		}

		#endregion

		#region Export

		public static DataTable ExportToDataTable(RelationshipEntity1List relationshipEntity1List)
		{
			DataTable dataTable = new DataTable();

			dataTable.Columns.Add(new DataColumn("AttrBool1", typeof(System.Boolean)));
			dataTable.Columns.Add(new DataColumn("AttrDatetime1", typeof(System.DateTime)));
			dataTable.Columns.Add(new DataColumn("AttrInteger1", typeof(System.Int32)));
			dataTable.Columns.Add(new DataColumn("AttrString1", typeof(System.String)));
			dataTable.Columns.Add(new DataColumn("AttrString2", typeof(System.String)));
			dataTable.Columns.Add(new DataColumn("CreateTimestamp", typeof(System.DateTime)));
			dataTable.Columns.Add(new DataColumn("CreateUser", typeof(System.String)));
			dataTable.Columns.Add(new DataColumn("DependentEntity2Id", typeof(System.Int32)));
			dataTable.Columns.Add(new DataColumn("IndependentEntity2Id", typeof(System.Int32)));
			dataTable.Columns.Add(new DataColumn("Name", typeof(System.String)));
			dataTable.Columns.Add(new DataColumn("RelationshipEntity1Id", typeof(System.Int32)));
			dataTable.Columns.Add(new DataColumn("Status", typeof(System.String)));
			dataTable.Columns.Add(new DataColumn("LastUpdateTimestamp", typeof(System.DateTime)));
			dataTable.Columns.Add(new DataColumn("UpdateId", typeof(System.Int32)));
			dataTable.Columns.Add(new DataColumn("LastUpdateUser", typeof(System.String)));

			DataRow dataRow;
			foreach (RelationshipEntity1 relationshipEntity1 in relationshipEntity1List)
			{
				dataRow = dataTable.NewRow();
				dataRow["AttrBool1"] = relationshipEntity1.AttrBool1_DBObjectValue;
				dataRow["AttrDatetime1"] = relationshipEntity1.AttrDatetime1_DBObjectValue;
				dataRow["AttrInteger1"] = relationshipEntity1.AttrInteger1_DBObjectValue;
				dataRow["AttrString1"] = relationshipEntity1.AttrString1_DBObjectValue;
				dataRow["AttrString2"] = relationshipEntity1.AttrString2_DBObjectValue;
				dataRow["CreateTimestamp"] = relationshipEntity1.CreateTimestamp_DBObjectValue;
				dataRow["CreateUser"] = relationshipEntity1.CreateUser_DBObjectValue;
				dataRow["DependentEntity2Id"] = relationshipEntity1.DependentEntity2Id_DBObjectValue;
				dataRow["IndependentEntity2Id"] = relationshipEntity1.IndependentEntity2Id_DBObjectValue;
				dataRow["Name"] = relationshipEntity1.Name_DBObjectValue;
				dataRow["RelationshipEntity1Id"] = relationshipEntity1.RelationshipEntity1Id_DBObjectValue;
				dataRow["Status"] = relationshipEntity1.Status_DBObjectValue;
				dataRow["LastUpdateTimestamp"] = relationshipEntity1.LastUpdateTimestamp_DBObjectValue;
				dataRow["UpdateId"] = relationshipEntity1.UpdateId_DBObjectValue;
				dataRow["LastUpdateUser"] = relationshipEntity1.LastUpdateUser_DBObjectValue;
				dataTable.Rows.Add(dataRow);
			}

			return dataTable;
		}

		public static StringCollection ExportToCSV(RelationshipEntity1List relationshipEntity1List)
		{
			StringCollection stringCollection = new StringCollection();

			stringCollection.Add("AttrBool1,AttrDatetime1,AttrInteger1,AttrString1,AttrString2,CreateTimestamp,CreateUser,DependentEntity2Id,IndependentEntity2Id,Name,RelationshipEntity1Id,Status,LastUpdateTimestamp,UpdateId,LastUpdateUser");

			StringBuilder stringBuilder = new StringBuilder();
			foreach (RelationshipEntity1 relationshipEntity1 in relationshipEntity1List)
			{
				stringBuilder.Length = 0;
				if (relationshipEntity1.AttrBool1 != null)
					stringBuilder.Append(Convert.ToString(relationshipEntity1.AttrBool1, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (relationshipEntity1.AttrDatetime1 != null)
					stringBuilder.Append(Convert.ToString(relationshipEntity1.AttrDatetime1, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (relationshipEntity1.AttrInteger1 != null)
					stringBuilder.Append(Convert.ToString(relationshipEntity1.AttrInteger1, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (relationshipEntity1.AttrString1 != null)
					stringBuilder.Append(relationshipEntity1.AttrString1.Replace(',', ' '));
				stringBuilder.Append(",");
				if (relationshipEntity1.AttrString2 != null)
					stringBuilder.Append(relationshipEntity1.AttrString2.Replace(',', ' '));
				stringBuilder.Append(",");
				if (relationshipEntity1.CreateTimestamp != null)
					stringBuilder.Append(Convert.ToString(relationshipEntity1.CreateTimestamp, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (relationshipEntity1.CreateUser != null)
					stringBuilder.Append(relationshipEntity1.CreateUser.Replace(',', ' '));
				stringBuilder.Append(",");
				if (relationshipEntity1.DependentEntity2Id != null)
					stringBuilder.Append(Convert.ToString(relationshipEntity1.DependentEntity2Id, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (relationshipEntity1.IndependentEntity2Id != null)
					stringBuilder.Append(Convert.ToString(relationshipEntity1.IndependentEntity2Id, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (relationshipEntity1.Name != null)
					stringBuilder.Append(relationshipEntity1.Name.Replace(',', ' '));
				stringBuilder.Append(",");
				if (relationshipEntity1.RelationshipEntity1Id != null)
					stringBuilder.Append(Convert.ToString(relationshipEntity1.RelationshipEntity1Id, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (relationshipEntity1.Status != null)
					stringBuilder.Append(relationshipEntity1.Status.Replace(',', ' '));
				stringBuilder.Append(",");
				if (relationshipEntity1.LastUpdateTimestamp != null)
					stringBuilder.Append(Convert.ToString(relationshipEntity1.LastUpdateTimestamp, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				stringBuilder.Append(Convert.ToString(relationshipEntity1.UpdateId, System.Globalization.CultureInfo.InvariantCulture).Replace(',', ' '));
				stringBuilder.Append(",");
				if (relationshipEntity1.LastUpdateUser != null)
					stringBuilder.Append(relationshipEntity1.LastUpdateUser.Replace(',', ' '));
				stringCollection.Add(stringBuilder.ToString());
			}

			return stringCollection;
		}

		#endregion

		protected virtual void Sync(RelationshipEntity1 sourceRelationshipEntity1, RelationshipEntity1 targetRelationshipEntity1, DataSourceOperation dataSourceOperation)
		{
			targetRelationshipEntity1.ParentOwnerDependentEntity2EntityObjectId_DBObjectValue = sourceRelationshipEntity1.ParentOwnerDependentEntity2EntityObjectId_DBObjectValue;
			targetRelationshipEntity1.ParentOwnerIndependentEntity2EntityObjectId_DBObjectValue = sourceRelationshipEntity1.ParentOwnerIndependentEntity2EntityObjectId_DBObjectValue;
			targetRelationshipEntity1.AttrBool1_DBObjectValue = sourceRelationshipEntity1.AttrBool1_DBObjectValue;
			targetRelationshipEntity1.AttrDatetime1_DBObjectValue = sourceRelationshipEntity1.AttrDatetime1_DBObjectValue;
			targetRelationshipEntity1.AttrInteger1_DBObjectValue = sourceRelationshipEntity1.AttrInteger1_DBObjectValue;
			targetRelationshipEntity1.AttrString1_DBObjectValue = sourceRelationshipEntity1.AttrString1_DBObjectValue;
			targetRelationshipEntity1.AttrString2_DBObjectValue = sourceRelationshipEntity1.AttrString2_DBObjectValue;
			targetRelationshipEntity1.Name_DBObjectValue = sourceRelationshipEntity1.Name_DBObjectValue;
			targetRelationshipEntity1.Status_DBObjectValue = sourceRelationshipEntity1.Status_DBObjectValue;
		}

		public int IndexOf(Guid objectInstanceId)
		{
			for (int index = 0; index < this.relationshipEntity1List.Count; ++index)
			{
				if (this.relationshipEntity1List[index].ObjectInstanceId == objectInstanceId)
					return index;
			}
			return -1;
		}

		public int IndexOf(RelationshipEntity1 relationshipEntity1)
		{
			return IndexOf(relationshipEntity1, this.relationshipEntity1List);
		}

		private int IndexOf(RelationshipEntity1 relationshipEntity1, RelationshipEntity1List relationshipEntity1List)
		{
			if (relationshipEntity1.ObjectId.HasValue)
			{
				CustName.AppName.DAL.RelationshipEntity1Identifier identifier = relationshipEntity1.ObjectId.Value;
				for (int index = 0; index < relationshipEntity1List.Count; ++index)
				{
					if (relationshipEntity1List[index].ObjectId == identifier)
						return index;
				}
			}
			else
			{
				Guid objectInstanceId = relationshipEntity1.ObjectInstanceId;
				for (int index = 0; index < relationshipEntity1List.Count; ++index)
				{
					if (relationshipEntity1List[index].ObjectInstanceId == objectInstanceId)
						return index;
				}
			}
			return -1;
		}
	}
}
