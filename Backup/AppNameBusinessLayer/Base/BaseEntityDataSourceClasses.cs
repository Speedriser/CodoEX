using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace CustName.AppName.BL
{

	public abstract class BaseAttachment1DataSource : IDisposable
	{
		// Track whether Dispose has been called.
		private bool disposed;
		private CustName.AppName.DAL.Repository repository;
		private int count = -1;

		public BaseAttachment1DataSource()
		{
		}

		// This destructor will run only if the Dispose method does not get called.
		// Do not provide destructors in types derived from this class.
		~BaseAttachment1DataSource()
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

		#region Select and Select Count

		public int Count()
		{
			return this.count;
		}

		[DataObjectMethod(DataObjectMethodType.Select, true)]
		public virtual Attachment1List Select()
		{
			return Select(-1, null, null);
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual IList<Attachment1> SelectIList()
		{
			return (IList<Attachment1>)Select(-1, null, null);
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DataTable SelectDataTable()
		{
			return ExportToDataTable(Select());
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual Attachment1List Select(CustName.AppName.DAL.Attachment1Identifier objectId)
		{
			Attachment1List attachment1List = (Attachment1List)CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(CustName.AppName.DAL.EntityClass.Attachment1);
			Attachment1 attachment1 = (Attachment1)this.Repository.GetAttachment1(objectId);
			if (attachment1 != null)
				attachment1List.Add(attachment1);
			this.count = attachment1List.Count;
			return attachment1List;
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual IList<Attachment1> SelectIList(CustName.AppName.DAL.Attachment1Identifier objectId)
		{
			return (IList<Attachment1>)Select(objectId);
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DataTable SelectDataTable(CustName.AppName.DAL.Attachment1Identifier objectId)
		{
			return ExportToDataTable(Select(objectId));
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual Attachment1List Select(int maxCount, CustName.AppName.DAL.SearchCondition searchCondition, CustName.AppName.DAL.SortSpecification sortSpecification)
		{
			Attachment1List attachment1List = (Attachment1List)this.Repository.FindAttachment1(maxCount, searchCondition, sortSpecification);
			this.count = attachment1List.Count;
			return attachment1List;
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DataTable SelectDataTable(int maxCount, CustName.AppName.DAL.SearchCondition searchCondition, CustName.AppName.DAL.SortSpecification sortSpecification)
		{
			return ExportToDataTable(Select(maxCount, searchCondition, sortSpecification));
		}

		#endregion

		#region Insert using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Insert, true)]
		public virtual CustName.AppName.DAL.Attachment1Identifier Insert(Attachment1 attachment1)
		{
			if (attachment1.ObjectStatus != CustName.AppName.DAL.ObjectStatus.New)
				throw new InvalidOperationException("Only new entity objects can be added.");
			Attachment1 repositoryAttachment1 = (Attachment1)CustName.AppName.BL.Global.ClassFactory.GetEntityObject(CustName.AppName.DAL.EntityClass.Attachment1);
			Sync(attachment1, repositoryAttachment1, DataSourceOperation.Create);
			this.Repository.SaveAttachment1(repositoryAttachment1);
			return repositoryAttachment1.ObjectId.Value;
		}

		#endregion

		#region Update using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Update, true)]
		public int Update(Attachment1 attachment1)
		{
			if (!attachment1.ObjectId.HasValue)
				throw new InvalidOperationException("Only preexisting entity objects can be updated.");
			Attachment1 repositoryAttachment1 = (Attachment1)this.Repository.GetAttachment1(attachment1.ObjectId.Value);
			if (repositoryAttachment1 == null)
				throw new InvalidOperationException("Entity object not found.");
			Sync(attachment1, repositoryAttachment1, DataSourceOperation.Update);
			this.Repository.SaveAttachment1(repositoryAttachment1);
			return 1;
		}

		#endregion

		#region Delete using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Delete, true)]
		public virtual int Delete(Attachment1 attachment1)
		{
			if (!attachment1.ObjectId.HasValue)
				throw new InvalidOperationException("Only preexisting entity objects can be deleted.");
			this.Repository.DeleteAttachment1(attachment1);
			return 1;
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
	}

	public abstract class BaseDependentEntity1DataSource : IDisposable
	{
		// Track whether Dispose has been called.
		private bool disposed;
		private CustName.AppName.DAL.Repository repository;
		private int count = -1;

		public BaseDependentEntity1DataSource()
		{
		}

		// This destructor will run only if the Dispose method does not get called.
		// Do not provide destructors in types derived from this class.
		~BaseDependentEntity1DataSource()
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

		#region Select and Select Count

		public int Count()
		{
			return this.count;
		}

		[DataObjectMethod(DataObjectMethodType.Select, true)]
		public virtual DependentEntity1List Select()
		{
			return Select(-1, null, null);
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual IList<DependentEntity1> SelectIList()
		{
			return (IList<DependentEntity1>)Select(-1, null, null);
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DataTable SelectDataTable()
		{
			return ExportToDataTable(Select());
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DependentEntity1List Select(CustName.AppName.DAL.DependentEntity1Identifier objectId)
		{
			DependentEntity1List dependentEntity1List = (DependentEntity1List)CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(CustName.AppName.DAL.EntityClass.DependentEntity1);
			DependentEntity1 dependentEntity1 = (DependentEntity1)this.Repository.GetDependentEntity1(objectId);
			if (dependentEntity1 != null)
				dependentEntity1List.Add(dependentEntity1);
			this.count = dependentEntity1List.Count;
			return dependentEntity1List;
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual IList<DependentEntity1> SelectIList(CustName.AppName.DAL.DependentEntity1Identifier objectId)
		{
			return (IList<DependentEntity1>)Select(objectId);
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DataTable SelectDataTable(CustName.AppName.DAL.DependentEntity1Identifier objectId)
		{
			return ExportToDataTable(Select(objectId));
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DependentEntity1List Select(int maxCount, CustName.AppName.DAL.SearchCondition searchCondition, CustName.AppName.DAL.SortSpecification sortSpecification)
		{
			DependentEntity1List dependentEntity1List = (DependentEntity1List)this.Repository.FindDependentEntity1(maxCount, searchCondition, sortSpecification);
			this.count = dependentEntity1List.Count;
			return dependentEntity1List;
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DataTable SelectDataTable(int maxCount, CustName.AppName.DAL.SearchCondition searchCondition, CustName.AppName.DAL.SortSpecification sortSpecification)
		{
			return ExportToDataTable(Select(maxCount, searchCondition, sortSpecification));
		}

		#endregion

		#region Insert using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Insert, true)]
		public virtual CustName.AppName.DAL.DependentEntity1Identifier Insert(DependentEntity1 dependentEntity1)
		{
			if (dependentEntity1.ObjectStatus != CustName.AppName.DAL.ObjectStatus.New)
				throw new InvalidOperationException("Only new entity objects can be added.");
			DependentEntity1 repositoryDependentEntity1 = (DependentEntity1)CustName.AppName.BL.Global.ClassFactory.GetEntityObject(CustName.AppName.DAL.EntityClass.DependentEntity1);
			Sync(dependentEntity1, repositoryDependentEntity1, DataSourceOperation.Create);
			this.Repository.SaveDependentEntity1(repositoryDependentEntity1);
			return repositoryDependentEntity1.ObjectId.Value;
		}

		#endregion

		#region Update using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Update, true)]
		public int Update(DependentEntity1 dependentEntity1)
		{
			if (!dependentEntity1.ObjectId.HasValue)
				throw new InvalidOperationException("Only preexisting entity objects can be updated.");
			DependentEntity1 repositoryDependentEntity1 = (DependentEntity1)this.Repository.GetDependentEntity1(dependentEntity1.ObjectId.Value);
			if (repositoryDependentEntity1 == null)
				throw new InvalidOperationException("Entity object not found.");
			Sync(dependentEntity1, repositoryDependentEntity1, DataSourceOperation.Update);
			this.Repository.SaveDependentEntity1(repositoryDependentEntity1);
			return 1;
		}

		#endregion

		#region Delete using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Delete, true)]
		public virtual int Delete(DependentEntity1 dependentEntity1)
		{
			if (!dependentEntity1.ObjectId.HasValue)
				throw new InvalidOperationException("Only preexisting entity objects can be deleted.");
			this.Repository.DeleteDependentEntity1(dependentEntity1);
			return 1;
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
	}

	public abstract class BaseDependentEntity2DataSource : IDisposable
	{
		// Track whether Dispose has been called.
		private bool disposed;
		private CustName.AppName.DAL.Repository repository;
		private int count = -1;

		public BaseDependentEntity2DataSource()
		{
		}

		// This destructor will run only if the Dispose method does not get called.
		// Do not provide destructors in types derived from this class.
		~BaseDependentEntity2DataSource()
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

		#region Select and Select Count

		public int Count()
		{
			return this.count;
		}

		[DataObjectMethod(DataObjectMethodType.Select, true)]
		public virtual DependentEntity2List Select()
		{
			return Select(-1, null, null);
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual IList<DependentEntity2> SelectIList()
		{
			return (IList<DependentEntity2>)Select(-1, null, null);
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DataTable SelectDataTable()
		{
			return ExportToDataTable(Select());
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DependentEntity2List Select(CustName.AppName.DAL.DependentEntity2Identifier objectId)
		{
			DependentEntity2List dependentEntity2List = (DependentEntity2List)CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(CustName.AppName.DAL.EntityClass.DependentEntity2);
			DependentEntity2 dependentEntity2 = (DependentEntity2)this.Repository.GetDependentEntity2(objectId);
			if (dependentEntity2 != null)
				dependentEntity2List.Add(dependentEntity2);
			this.count = dependentEntity2List.Count;
			return dependentEntity2List;
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual IList<DependentEntity2> SelectIList(CustName.AppName.DAL.DependentEntity2Identifier objectId)
		{
			return (IList<DependentEntity2>)Select(objectId);
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DataTable SelectDataTable(CustName.AppName.DAL.DependentEntity2Identifier objectId)
		{
			return ExportToDataTable(Select(objectId));
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DependentEntity2List Select(int maxCount, CustName.AppName.DAL.SearchCondition searchCondition, CustName.AppName.DAL.SortSpecification sortSpecification)
		{
			DependentEntity2List dependentEntity2List = (DependentEntity2List)this.Repository.FindDependentEntity2(maxCount, searchCondition, sortSpecification);
			this.count = dependentEntity2List.Count;
			return dependentEntity2List;
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DataTable SelectDataTable(int maxCount, CustName.AppName.DAL.SearchCondition searchCondition, CustName.AppName.DAL.SortSpecification sortSpecification)
		{
			return ExportToDataTable(Select(maxCount, searchCondition, sortSpecification));
		}

		#endregion

		#region Insert using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Insert, true)]
		public virtual CustName.AppName.DAL.DependentEntity2Identifier Insert(DependentEntity2 dependentEntity2)
		{
			if (dependentEntity2.ObjectStatus != CustName.AppName.DAL.ObjectStatus.New)
				throw new InvalidOperationException("Only new entity objects can be added.");
			DependentEntity2 repositoryDependentEntity2 = (DependentEntity2)CustName.AppName.BL.Global.ClassFactory.GetEntityObject(CustName.AppName.DAL.EntityClass.DependentEntity2);
			Sync(dependentEntity2, repositoryDependentEntity2, DataSourceOperation.Create);
			this.Repository.SaveDependentEntity2(repositoryDependentEntity2);
			return repositoryDependentEntity2.ObjectId.Value;
		}

		#endregion

		#region Update using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Update, true)]
		public int Update(DependentEntity2 dependentEntity2)
		{
			if (!dependentEntity2.ObjectId.HasValue)
				throw new InvalidOperationException("Only preexisting entity objects can be updated.");
			DependentEntity2 repositoryDependentEntity2 = (DependentEntity2)this.Repository.GetDependentEntity2(dependentEntity2.ObjectId.Value);
			if (repositoryDependentEntity2 == null)
				throw new InvalidOperationException("Entity object not found.");
			Sync(dependentEntity2, repositoryDependentEntity2, DataSourceOperation.Update);
			this.Repository.SaveDependentEntity2(repositoryDependentEntity2);
			return 1;
		}

		#endregion

		#region Delete using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Delete, true)]
		public virtual int Delete(DependentEntity2 dependentEntity2)
		{
			if (!dependentEntity2.ObjectId.HasValue)
				throw new InvalidOperationException("Only preexisting entity objects can be deleted.");
			this.Repository.DeleteDependentEntity2(dependentEntity2);
			return 1;
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
	}

	public abstract class BaseIndependentEntity1DataSource : IDisposable
	{
		// Track whether Dispose has been called.
		private bool disposed;
		private CustName.AppName.DAL.Repository repository;
		private int count = -1;

		public BaseIndependentEntity1DataSource()
		{
		}

		// This destructor will run only if the Dispose method does not get called.
		// Do not provide destructors in types derived from this class.
		~BaseIndependentEntity1DataSource()
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

		#region Select and Select Count

		public int Count()
		{
			return this.count;
		}

		[DataObjectMethod(DataObjectMethodType.Select, true)]
		public virtual IndependentEntity1List Select()
		{
			return Select(-1, null, null);
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual IList<IndependentEntity1> SelectIList()
		{
			return (IList<IndependentEntity1>)Select(-1, null, null);
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DataTable SelectDataTable()
		{
			return ExportToDataTable(Select());
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual IndependentEntity1List Select(CustName.AppName.DAL.IndependentEntity1Identifier objectId)
		{
			IndependentEntity1List independentEntity1List = (IndependentEntity1List)CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(CustName.AppName.DAL.EntityClass.IndependentEntity1);
			IndependentEntity1 independentEntity1 = (IndependentEntity1)this.Repository.GetIndependentEntity1(objectId);
			if (independentEntity1 != null)
				independentEntity1List.Add(independentEntity1);
			this.count = independentEntity1List.Count;
			return independentEntity1List;
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual IList<IndependentEntity1> SelectIList(CustName.AppName.DAL.IndependentEntity1Identifier objectId)
		{
			return (IList<IndependentEntity1>)Select(objectId);
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DataTable SelectDataTable(CustName.AppName.DAL.IndependentEntity1Identifier objectId)
		{
			return ExportToDataTable(Select(objectId));
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual IndependentEntity1List Select(int maxCount, CustName.AppName.DAL.SearchCondition searchCondition, CustName.AppName.DAL.SortSpecification sortSpecification)
		{
			IndependentEntity1List independentEntity1List = (IndependentEntity1List)this.Repository.FindIndependentEntity1(maxCount, searchCondition, sortSpecification);
			this.count = independentEntity1List.Count;
			return independentEntity1List;
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DataTable SelectDataTable(int maxCount, CustName.AppName.DAL.SearchCondition searchCondition, CustName.AppName.DAL.SortSpecification sortSpecification)
		{
			return ExportToDataTable(Select(maxCount, searchCondition, sortSpecification));
		}

		#endregion

		#region Insert using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Insert, true)]
		public virtual CustName.AppName.DAL.IndependentEntity1Identifier Insert(IndependentEntity1 independentEntity1)
		{
			if (independentEntity1.ObjectStatus != CustName.AppName.DAL.ObjectStatus.New)
				throw new InvalidOperationException("Only new entity objects can be added.");
			IndependentEntity1 repositoryIndependentEntity1 = (IndependentEntity1)CustName.AppName.BL.Global.ClassFactory.GetEntityObject(CustName.AppName.DAL.EntityClass.IndependentEntity1);
			Sync(independentEntity1, repositoryIndependentEntity1, DataSourceOperation.Create);
			this.Repository.SaveIndependentEntity1(repositoryIndependentEntity1);
			return repositoryIndependentEntity1.ObjectId.Value;
		}

		#endregion

		#region Update using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Update, true)]
		public int Update(IndependentEntity1 independentEntity1)
		{
			if (!independentEntity1.ObjectId.HasValue)
				throw new InvalidOperationException("Only preexisting entity objects can be updated.");
			IndependentEntity1 repositoryIndependentEntity1 = (IndependentEntity1)this.Repository.GetIndependentEntity1(independentEntity1.ObjectId.Value);
			if (repositoryIndependentEntity1 == null)
				throw new InvalidOperationException("Entity object not found.");
			Sync(independentEntity1, repositoryIndependentEntity1, DataSourceOperation.Update);
			this.Repository.SaveIndependentEntity1(repositoryIndependentEntity1);
			return 1;
		}

		#endregion

		#region Delete using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Delete, true)]
		public virtual int Delete(IndependentEntity1 independentEntity1)
		{
			if (!independentEntity1.ObjectId.HasValue)
				throw new InvalidOperationException("Only preexisting entity objects can be deleted.");
			this.Repository.DeleteIndependentEntity1(independentEntity1);
			return 1;
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
	}

	public abstract class BaseIndependentEntity2DataSource : IDisposable
	{
		// Track whether Dispose has been called.
		private bool disposed;
		private CustName.AppName.DAL.Repository repository;
		private int count = -1;

		public BaseIndependentEntity2DataSource()
		{
		}

		// This destructor will run only if the Dispose method does not get called.
		// Do not provide destructors in types derived from this class.
		~BaseIndependentEntity2DataSource()
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

		#region Select and Select Count

		public int Count()
		{
			return this.count;
		}

		[DataObjectMethod(DataObjectMethodType.Select, true)]
		public virtual IndependentEntity2List Select()
		{
			return Select(-1, null, null);
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual IList<IndependentEntity2> SelectIList()
		{
			return (IList<IndependentEntity2>)Select(-1, null, null);
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DataTable SelectDataTable()
		{
			return ExportToDataTable(Select());
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual IndependentEntity2List Select(CustName.AppName.DAL.IndependentEntity2Identifier objectId)
		{
			IndependentEntity2List independentEntity2List = (IndependentEntity2List)CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(CustName.AppName.DAL.EntityClass.IndependentEntity2);
			IndependentEntity2 independentEntity2 = (IndependentEntity2)this.Repository.GetIndependentEntity2(objectId);
			if (independentEntity2 != null)
				independentEntity2List.Add(independentEntity2);
			this.count = independentEntity2List.Count;
			return independentEntity2List;
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual IList<IndependentEntity2> SelectIList(CustName.AppName.DAL.IndependentEntity2Identifier objectId)
		{
			return (IList<IndependentEntity2>)Select(objectId);
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DataTable SelectDataTable(CustName.AppName.DAL.IndependentEntity2Identifier objectId)
		{
			return ExportToDataTable(Select(objectId));
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual IndependentEntity2List Select(int maxCount, CustName.AppName.DAL.SearchCondition searchCondition, CustName.AppName.DAL.SortSpecification sortSpecification)
		{
			IndependentEntity2List independentEntity2List = (IndependentEntity2List)this.Repository.FindIndependentEntity2(maxCount, searchCondition, sortSpecification);
			this.count = independentEntity2List.Count;
			return independentEntity2List;
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DataTable SelectDataTable(int maxCount, CustName.AppName.DAL.SearchCondition searchCondition, CustName.AppName.DAL.SortSpecification sortSpecification)
		{
			return ExportToDataTable(Select(maxCount, searchCondition, sortSpecification));
		}

		#endregion

		#region Insert using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Insert, true)]
		public virtual CustName.AppName.DAL.IndependentEntity2Identifier Insert(IndependentEntity2 independentEntity2)
		{
			if (independentEntity2.ObjectStatus != CustName.AppName.DAL.ObjectStatus.New)
				throw new InvalidOperationException("Only new entity objects can be added.");
			IndependentEntity2 repositoryIndependentEntity2 = (IndependentEntity2)CustName.AppName.BL.Global.ClassFactory.GetEntityObject(CustName.AppName.DAL.EntityClass.IndependentEntity2);
			Sync(independentEntity2, repositoryIndependentEntity2, DataSourceOperation.Create);
			this.Repository.SaveIndependentEntity2(repositoryIndependentEntity2);
			return repositoryIndependentEntity2.ObjectId.Value;
		}

		#endregion

		#region Update using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Update, true)]
		public int Update(IndependentEntity2 independentEntity2)
		{
			if (!independentEntity2.ObjectId.HasValue)
				throw new InvalidOperationException("Only preexisting entity objects can be updated.");
			IndependentEntity2 repositoryIndependentEntity2 = (IndependentEntity2)this.Repository.GetIndependentEntity2(independentEntity2.ObjectId.Value);
			if (repositoryIndependentEntity2 == null)
				throw new InvalidOperationException("Entity object not found.");
			Sync(independentEntity2, repositoryIndependentEntity2, DataSourceOperation.Update);
			this.Repository.SaveIndependentEntity2(repositoryIndependentEntity2);
			return 1;
		}

		#endregion

		#region Delete using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Delete, true)]
		public virtual int Delete(IndependentEntity2 independentEntity2)
		{
			if (!independentEntity2.ObjectId.HasValue)
				throw new InvalidOperationException("Only preexisting entity objects can be deleted.");
			this.Repository.DeleteIndependentEntity2(independentEntity2);
			return 1;
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
	}

	public abstract class BaseRelationshipEntity1DataSource : IDisposable
	{
		// Track whether Dispose has been called.
		private bool disposed;
		private CustName.AppName.DAL.Repository repository;
		private int count = -1;

		public BaseRelationshipEntity1DataSource()
		{
		}

		// This destructor will run only if the Dispose method does not get called.
		// Do not provide destructors in types derived from this class.
		~BaseRelationshipEntity1DataSource()
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

		#region Select and Select Count

		public int Count()
		{
			return this.count;
		}

		[DataObjectMethod(DataObjectMethodType.Select, true)]
		public virtual RelationshipEntity1List Select()
		{
			return Select(-1, null, null);
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual IList<RelationshipEntity1> SelectIList()
		{
			return (IList<RelationshipEntity1>)Select(-1, null, null);
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DataTable SelectDataTable()
		{
			return ExportToDataTable(Select());
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual RelationshipEntity1List Select(CustName.AppName.DAL.RelationshipEntity1Identifier objectId)
		{
			RelationshipEntity1List relationshipEntity1List = (RelationshipEntity1List)CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(CustName.AppName.DAL.EntityClass.RelationshipEntity1);
			RelationshipEntity1 relationshipEntity1 = (RelationshipEntity1)this.Repository.GetRelationshipEntity1(objectId);
			if (relationshipEntity1 != null)
				relationshipEntity1List.Add(relationshipEntity1);
			this.count = relationshipEntity1List.Count;
			return relationshipEntity1List;
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual IList<RelationshipEntity1> SelectIList(CustName.AppName.DAL.RelationshipEntity1Identifier objectId)
		{
			return (IList<RelationshipEntity1>)Select(objectId);
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DataTable SelectDataTable(CustName.AppName.DAL.RelationshipEntity1Identifier objectId)
		{
			return ExportToDataTable(Select(objectId));
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual RelationshipEntity1List Select(int maxCount, CustName.AppName.DAL.SearchCondition searchCondition, CustName.AppName.DAL.SortSpecification sortSpecification)
		{
			RelationshipEntity1List relationshipEntity1List = (RelationshipEntity1List)this.Repository.FindRelationshipEntity1(maxCount, searchCondition, sortSpecification);
			this.count = relationshipEntity1List.Count;
			return relationshipEntity1List;
		}

		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public virtual DataTable SelectDataTable(int maxCount, CustName.AppName.DAL.SearchCondition searchCondition, CustName.AppName.DAL.SortSpecification sortSpecification)
		{
			return ExportToDataTable(Select(maxCount, searchCondition, sortSpecification));
		}

		#endregion

		#region Insert using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Insert, true)]
		public virtual CustName.AppName.DAL.RelationshipEntity1Identifier Insert(RelationshipEntity1 relationshipEntity1)
		{
			if (relationshipEntity1.ObjectStatus != CustName.AppName.DAL.ObjectStatus.New)
				throw new InvalidOperationException("Only new entity objects can be added.");
			RelationshipEntity1 repositoryRelationshipEntity1 = (RelationshipEntity1)CustName.AppName.BL.Global.ClassFactory.GetEntityObject(CustName.AppName.DAL.EntityClass.RelationshipEntity1);
			Sync(relationshipEntity1, repositoryRelationshipEntity1, DataSourceOperation.Create);
			this.Repository.SaveRelationshipEntity1(repositoryRelationshipEntity1);
			return repositoryRelationshipEntity1.ObjectId.Value;
		}

		#endregion

		#region Update using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Update, true)]
		public int Update(RelationshipEntity1 relationshipEntity1)
		{
			if (!relationshipEntity1.ObjectId.HasValue)
				throw new InvalidOperationException("Only preexisting entity objects can be updated.");
			RelationshipEntity1 repositoryRelationshipEntity1 = (RelationshipEntity1)this.Repository.GetRelationshipEntity1(relationshipEntity1.ObjectId.Value);
			if (repositoryRelationshipEntity1 == null)
				throw new InvalidOperationException("Entity object not found.");
			Sync(relationshipEntity1, repositoryRelationshipEntity1, DataSourceOperation.Update);
			this.Repository.SaveRelationshipEntity1(repositoryRelationshipEntity1);
			return 1;
		}

		#endregion

		#region Delete using DataObjectTypeName

		[DataObjectMethod(DataObjectMethodType.Delete, true)]
		public virtual int Delete(RelationshipEntity1 relationshipEntity1)
		{
			if (!relationshipEntity1.ObjectId.HasValue)
				throw new InvalidOperationException("Only preexisting entity objects can be deleted.");
			this.Repository.DeleteRelationshipEntity1(relationshipEntity1);
			return 1;
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
	}
}
