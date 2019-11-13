using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CustName.AppName.DAL
{
	// The primary purpose of the SaveLog is to store information needed to update the EntityObjectContext.
	// It stores entries for each in-memory object impacted by a Save operation.
	public class SaveLog : List<SaveLogEntry>
	{
		// When an entity object is deleted from the repository, it is left to the DBMS to cascade delete owned entity objects.
		// The purpose of this function is to populate the SaveLog with entries for in-memory cascade deleted entity objects.
		public void UpdateSaveLogForCascadeDelete(IEntityObject obj)
		{
			// Record the number of elements currently in the log.
			// The value is needed to identify the first element added by the following GetOwnedObjects call.
			int originalSaveLogCount = this.Count;
			// Recursively fetch all objects owned by the provided enity object.
			IList<IEntityObject> ownedObjectList = obj.GetOwnedObjects(true, null);
			// Add entries to the save log for the owned objects.
			IEntityObject ownedEntityObject;
			SaveLogEntry saveLogEntry;
			for (int index = originalSaveLogCount; index < this.Count; ++index)
			{
				ownedEntityObject = this[index].EntityObject;
				if (ownedEntityObject.ObjectStatus != ObjectStatus.New)
				{
					saveLogEntry = new SaveLogEntry();
					saveLogEntry.EntityObject = ownedEntityObject;
					saveLogEntry.RepositoryUpdateOperation = RepositoryUpdateOperation.Delete;
					// When an object is deleted, it is left to the database to cascade delete owned objects.
					// Owned in-memory objects are not processed and retain their original status.
					saveLogEntry.PreSaveObjectStatus = ownedEntityObject.ObjectStatus;
					saveLogEntry.PostSaveObjectStatus = ObjectStatus.Deleted;
					this.Add(saveLogEntry);
				}
			}
		}

		public void ApplySaveLog()
		{
			IEntityObject obj;
			foreach (SaveLogEntry saveLogEntry in this)
			{
				obj = saveLogEntry.EntityObject;
				obj.ObjectStatus = saveLogEntry.PostSaveObjectStatus;
				if (saveLogEntry.RepositoryUpdateOperation == RepositoryUpdateOperation.Insert || saveLogEntry.RepositoryUpdateOperation == RepositoryUpdateOperation.Update)
					((IEditableObject)obj).EndEdit();
				obj.HasUncommittedChanges = false;
				if (obj.Context != null && saveLogEntry.PostSaveObjectStatus == ObjectStatus.Deleted)
					// It is assumed that the log contains delete entries for all owned in-memory objects.
					obj.Context.Remove(obj);
			}
		}
	}
}
