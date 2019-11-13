using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using TekArtisan.Encryption;

namespace CustName.AppName.DAL
{
	public abstract class BaseRepository
	{
		protected IClassFactory classFactory;
		protected string user = "undefined";
		protected bool ignoreCollision;
		protected int commandTimeout = 30;

		public IClassFactory ClassFactory
		{
			get
			{
				return this.classFactory;
			}
			set
			{
				this.classFactory = value;
			}
		}

		public string User
		{
			get
			{
				return this.user;
			}
			set
			{
				this.user = value;
			}
		}

		public bool IgnoreCollision
		{
			get
			{
				return this.ignoreCollision;
			}
			set
			{
				this.ignoreCollision = value;
			}
		}

		#region Connection related members

		public abstract void Close();

		public virtual int CommandTimeout
		{
			get
			{
				return this.commandTimeout;
			}
			set
			{
				this.commandTimeout = value;
			}
		}

		#endregion

		#region Get functions.

		public virtual IEntityObject Get(EntityClass entityClass, IIdentifier objectId)
		{
			return this.Get(entityClass, objectId, null);
		}

		public virtual IEntityObject Get(EntityClass entityClass, IIdentifier objectId, IEntityObjectContext context)
		{
			if (entityClass == EntityClass.Attachment1)
				return (IEntityObject)this.GetAttachment1((Attachment1Identifier)objectId, context);
			else if (entityClass == EntityClass.DependentEntity1)
				return (IEntityObject)this.GetDependentEntity1((DependentEntity1Identifier)objectId, context);
			else if (entityClass == EntityClass.DependentEntity2)
				return (IEntityObject)this.GetDependentEntity2((DependentEntity2Identifier)objectId, context);
			else if (entityClass == EntityClass.IndependentEntity1)
				return (IEntityObject)this.GetIndependentEntity1((IndependentEntity1Identifier)objectId, context);
			else if (entityClass == EntityClass.IndependentEntity2)
				return (IEntityObject)this.GetIndependentEntity2((IndependentEntity2Identifier)objectId, context);
			else if (entityClass == EntityClass.RelationshipEntity1)
				return (IEntityObject)this.GetRelationshipEntity1((RelationshipEntity1Identifier)objectId, context);
			throw new DALException(RepositoryExceptionMessage.EntityClassNotSupported);
		}

		public abstract IAttachment1 GetAttachment1(Attachment1Identifier objectId);

		public abstract IAttachment1 GetAttachment1(Attachment1Identifier objectId, IEntityObjectContext context);

		public abstract IDependentEntity1 GetDependentEntity1(DependentEntity1Identifier objectId);

		public abstract IDependentEntity1 GetDependentEntity1(DependentEntity1Identifier objectId, IEntityObjectContext context);

		public abstract IDependentEntity2 GetDependentEntity2(DependentEntity2Identifier objectId);

		public abstract IDependentEntity2 GetDependentEntity2(DependentEntity2Identifier objectId, IEntityObjectContext context);

		public abstract IIndependentEntity1 GetIndependentEntity1(IndependentEntity1Identifier objectId);

		public abstract IIndependentEntity1 GetIndependentEntity1(IndependentEntity1Identifier objectId, IEntityObjectContext context);

		public abstract IIndependentEntity2 GetIndependentEntity2(IndependentEntity2Identifier objectId);

		public abstract IIndependentEntity2 GetIndependentEntity2(IndependentEntity2Identifier objectId, IEntityObjectContext context);

		public abstract IRelationshipEntity1 GetRelationshipEntity1(RelationshipEntity1Identifier objectId);

		public abstract IRelationshipEntity1 GetRelationshipEntity1(RelationshipEntity1Identifier objectId, IEntityObjectContext context);

		#endregion Get functions.

		#region Get BLOB functions.

		public abstract byte[] GetAttachment1BLOB(Attachment1Identifier objectId, int updateId, string columnName);

		public abstract byte[] GetAttachment1BLOB(Attachment1Identifier objectId, int updateId, string columnName, bool ignoreCollision);

		protected abstract byte[] GetAttachment1BLOBCore(Attachment1Identifier objectId, int updateId, string columnName, bool ignoreCollision);

		public abstract byte[] GetDependentEntity1BLOB(DependentEntity1Identifier objectId, int updateId, string columnName);

		public abstract byte[] GetDependentEntity1BLOB(DependentEntity1Identifier objectId, int updateId, string columnName, bool ignoreCollision);

		protected abstract byte[] GetDependentEntity1BLOBCore(DependentEntity1Identifier objectId, int updateId, string columnName, bool ignoreCollision);

		public abstract byte[] GetDependentEntity2BLOB(DependentEntity2Identifier objectId, int updateId, string columnName);

		public abstract byte[] GetDependentEntity2BLOB(DependentEntity2Identifier objectId, int updateId, string columnName, bool ignoreCollision);

		protected abstract byte[] GetDependentEntity2BLOBCore(DependentEntity2Identifier objectId, int updateId, string columnName, bool ignoreCollision);

		public abstract byte[] GetIndependentEntity1BLOB(IndependentEntity1Identifier objectId, int updateId, string columnName);

		public abstract byte[] GetIndependentEntity1BLOB(IndependentEntity1Identifier objectId, int updateId, string columnName, bool ignoreCollision);

		protected abstract byte[] GetIndependentEntity1BLOBCore(IndependentEntity1Identifier objectId, int updateId, string columnName, bool ignoreCollision);

		public abstract byte[] GetIndependentEntity2BLOB(IndependentEntity2Identifier objectId, int updateId, string columnName);

		public abstract byte[] GetIndependentEntity2BLOB(IndependentEntity2Identifier objectId, int updateId, string columnName, bool ignoreCollision);

		protected abstract byte[] GetIndependentEntity2BLOBCore(IndependentEntity2Identifier objectId, int updateId, string columnName, bool ignoreCollision);

		public abstract byte[] GetRelationshipEntity1BLOB(RelationshipEntity1Identifier objectId, int updateId, string columnName);

		public abstract byte[] GetRelationshipEntity1BLOB(RelationshipEntity1Identifier objectId, int updateId, string columnName, bool ignoreCollision);

		protected abstract byte[] GetRelationshipEntity1BLOBCore(RelationshipEntity1Identifier objectId, int updateId, string columnName, bool ignoreCollision);

		#endregion Get BLOB functions.

		#region Delete functions.

		public virtual void Delete(IEntityObject obj)
		{
			this.DeleteCore(obj, this.ignoreCollision);
		}

		public virtual void Delete(IEntityObject obj, bool ignoreCollision)
		{
			this.DeleteCore(obj, ignoreCollision);
		}

		protected virtual void DeleteCore(IEntityObject obj, bool ignoreCollision)
		{
			if (!(obj is IEntityObject)) throw new DALException(RepositoryExceptionMessage.NotBaseEntityObjectCompatible);
			if (obj.EntityClass == EntityClass.Attachment1)
				this.DeleteAttachment1((IAttachment1)obj, ignoreCollision);
			else if (obj.EntityClass == EntityClass.DependentEntity1)
				this.DeleteDependentEntity1((IDependentEntity1)obj, ignoreCollision);
			else if (obj.EntityClass == EntityClass.DependentEntity2)
				this.DeleteDependentEntity2((IDependentEntity2)obj, ignoreCollision);
			else if (obj.EntityClass == EntityClass.IndependentEntity1)
				this.DeleteIndependentEntity1((IIndependentEntity1)obj, ignoreCollision);
			else if (obj.EntityClass == EntityClass.IndependentEntity2)
				this.DeleteIndependentEntity2((IIndependentEntity2)obj, ignoreCollision);
			else if (obj.EntityClass == EntityClass.RelationshipEntity1)
				this.DeleteRelationshipEntity1((IRelationshipEntity1)obj, ignoreCollision);
			else
				throw new DALException(RepositoryExceptionMessage.EntityClassNotSupported);
		}

		public virtual void Delete(EntityClass entityClass, IIdentifier objectId, int updateId)
		{
			this.Delete(entityClass, objectId, updateId, this.ignoreCollision);
		}

		public virtual void Delete(EntityClass entityClass, IIdentifier objectId, int updateId, bool ignoreCollision)
		{
			if (entityClass == EntityClass.Attachment1)
				this.DeleteAttachment1((Attachment1Identifier)objectId, updateId, ignoreCollision);
			else if (entityClass == EntityClass.DependentEntity1)
				this.DeleteDependentEntity1((DependentEntity1Identifier)objectId, updateId, ignoreCollision);
			else if (entityClass == EntityClass.DependentEntity2)
				this.DeleteDependentEntity2((DependentEntity2Identifier)objectId, updateId, ignoreCollision);
			else if (entityClass == EntityClass.IndependentEntity1)
				this.DeleteIndependentEntity1((IndependentEntity1Identifier)objectId, updateId, ignoreCollision);
			else if (entityClass == EntityClass.IndependentEntity2)
				this.DeleteIndependentEntity2((IndependentEntity2Identifier)objectId, updateId, ignoreCollision);
			else if (entityClass == EntityClass.RelationshipEntity1)
				this.DeleteRelationshipEntity1((RelationshipEntity1Identifier)objectId, updateId, ignoreCollision);
			else
				throw new DALException(RepositoryExceptionMessage.EntityClassNotSupported);
		}

		public virtual void Delete(IList list)
		{
			this.DeleteCore(list, this.ignoreCollision);
		}

		public virtual void Delete(IList list, bool ignoreCollision)
		{
			this.DeleteCore(list, ignoreCollision);
		}

		protected virtual void DeleteCore(IList list, bool ignoreCollision)
		{
			CollisionList collisions = null;

			foreach (object obj in list)
			{
				if (obj is IEntityObject)
				{
					if (ignoreCollision)
					{
						// Collision exceptions are not expected.
						// Any other exception should bubble up to the caller.
						this.Delete((IEntityObject)obj, true);
					}
					else
					{
						// Collision exception(s) possible.
						// If such an exception is caught while deleting an object in the list, its Collision object will be added to the collisions
						// collection.
						// After all objects have been processed, a single CollisionException containing the collisions list will be raised.
						// That way, an attempt is made to delete all objects in the list while still notifying the caller of any exceptions via the
						// normal method of raising a CollisionException.
						try
						{
							this.Delete((IEntityObject)obj, false);
						}
						catch (SingleCollisionException e)
						{
							// Delete failed due to collision.
							// Add the Collision object contained in the CollisionException to the collisions list.
							if (collisions == null) collisions = new CollisionList();
							collisions.Add(e.Collision);
						}
					}
				}
			}

			if (collisions != null) throw new MultipleCollisionException(RepositoryExceptionMessage.MultipleCollisionsDetected, collisions);
		}

		public abstract void DeleteAttachment1(IAttachment1 attachment1);

		public abstract void DeleteAttachment1(IAttachment1 attachment1, bool ignoreCollision);

		protected abstract void DeleteAttachment1Core(IAttachment1 attachment1, bool ignoreCollision);

		protected abstract void DeleteAttachment1Core(IAttachment1 attachment1, bool ignoreCollision, SaveLog saveLog);

		protected abstract void DeleteAttachment1EntityObjectCore(IAttachment1 attachment1, bool ignoreCollision, SaveLog saveLog);

		public abstract void DeleteAttachment1(Attachment1Identifier objectId, int updateId);

		public abstract void DeleteAttachment1(Attachment1Identifier objectId, int updateId, bool ignoreCollision);

		protected abstract void DeleteAttachment1Core(Attachment1Identifier objectId, int updateId, bool ignoreCollision);

		protected abstract void DeleteAttachment1(SearchCondition searchCondition);

		public abstract void DeleteDependentEntity1(IDependentEntity1 dependentEntity1);

		public abstract void DeleteDependentEntity1(IDependentEntity1 dependentEntity1, bool ignoreCollision);

		protected abstract void DeleteDependentEntity1Core(IDependentEntity1 dependentEntity1, bool ignoreCollision);

		protected abstract void DeleteDependentEntity1Core(IDependentEntity1 dependentEntity1, bool ignoreCollision, SaveLog saveLog);

		protected abstract void DeleteDependentEntity1EntityObjectCore(IDependentEntity1 dependentEntity1, bool ignoreCollision, SaveLog saveLog);

		public abstract void DeleteDependentEntity1(DependentEntity1Identifier objectId, int updateId);

		public abstract void DeleteDependentEntity1(DependentEntity1Identifier objectId, int updateId, bool ignoreCollision);

		protected abstract void DeleteDependentEntity1Core(DependentEntity1Identifier objectId, int updateId, bool ignoreCollision);

		protected abstract void DeleteDependentEntity1(SearchCondition searchCondition);

		public abstract void DeleteDependentEntity2(IDependentEntity2 dependentEntity2);

		public abstract void DeleteDependentEntity2(IDependentEntity2 dependentEntity2, bool ignoreCollision);

		protected abstract void DeleteDependentEntity2Core(IDependentEntity2 dependentEntity2, bool ignoreCollision);

		protected abstract void DeleteDependentEntity2Core(IDependentEntity2 dependentEntity2, bool ignoreCollision, SaveLog saveLog);

		protected abstract void DeleteDependentEntity2EntityObjectCore(IDependentEntity2 dependentEntity2, bool ignoreCollision, SaveLog saveLog);

		public abstract void DeleteDependentEntity2(DependentEntity2Identifier objectId, int updateId);

		public abstract void DeleteDependentEntity2(DependentEntity2Identifier objectId, int updateId, bool ignoreCollision);

		protected abstract void DeleteDependentEntity2Core(DependentEntity2Identifier objectId, int updateId, bool ignoreCollision);

		protected abstract void DeleteDependentEntity2(SearchCondition searchCondition);

		public abstract void DeleteIndependentEntity1(IIndependentEntity1 independentEntity1);

		public abstract void DeleteIndependentEntity1(IIndependentEntity1 independentEntity1, bool ignoreCollision);

		protected abstract void DeleteIndependentEntity1Core(IIndependentEntity1 independentEntity1, bool ignoreCollision);

		protected abstract void DeleteIndependentEntity1Core(IIndependentEntity1 independentEntity1, bool ignoreCollision, SaveLog saveLog);

		protected abstract void DeleteIndependentEntity1EntityObjectCore(IIndependentEntity1 independentEntity1, bool ignoreCollision, SaveLog saveLog);

		public abstract void DeleteIndependentEntity1(IndependentEntity1Identifier objectId, int updateId);

		public abstract void DeleteIndependentEntity1(IndependentEntity1Identifier objectId, int updateId, bool ignoreCollision);

		protected abstract void DeleteIndependentEntity1Core(IndependentEntity1Identifier objectId, int updateId, bool ignoreCollision);

		protected abstract void DeleteIndependentEntity1(SearchCondition searchCondition);

		public abstract void DeleteIndependentEntity2(IIndependentEntity2 independentEntity2);

		public abstract void DeleteIndependentEntity2(IIndependentEntity2 independentEntity2, bool ignoreCollision);

		protected abstract void DeleteIndependentEntity2Core(IIndependentEntity2 independentEntity2, bool ignoreCollision);

		protected abstract void DeleteIndependentEntity2Core(IIndependentEntity2 independentEntity2, bool ignoreCollision, SaveLog saveLog);

		protected abstract void DeleteIndependentEntity2EntityObjectCore(IIndependentEntity2 independentEntity2, bool ignoreCollision, SaveLog saveLog);

		public abstract void DeleteIndependentEntity2(IndependentEntity2Identifier objectId, int updateId);

		public abstract void DeleteIndependentEntity2(IndependentEntity2Identifier objectId, int updateId, bool ignoreCollision);

		protected abstract void DeleteIndependentEntity2Core(IndependentEntity2Identifier objectId, int updateId, bool ignoreCollision);

		protected abstract void DeleteIndependentEntity2(SearchCondition searchCondition);

		public abstract void DeleteRelationshipEntity1(IRelationshipEntity1 relationshipEntity1);

		public abstract void DeleteRelationshipEntity1(IRelationshipEntity1 relationshipEntity1, bool ignoreCollision);

		protected abstract void DeleteRelationshipEntity1Core(IRelationshipEntity1 relationshipEntity1, bool ignoreCollision);

		protected abstract void DeleteRelationshipEntity1Core(IRelationshipEntity1 relationshipEntity1, bool ignoreCollision, SaveLog saveLog);

		protected abstract void DeleteRelationshipEntity1EntityObjectCore(IRelationshipEntity1 relationshipEntity1, bool ignoreCollision, SaveLog saveLog);

		public abstract void DeleteRelationshipEntity1(RelationshipEntity1Identifier objectId, int updateId);

		public abstract void DeleteRelationshipEntity1(RelationshipEntity1Identifier objectId, int updateId, bool ignoreCollision);

		protected abstract void DeleteRelationshipEntity1Core(RelationshipEntity1Identifier objectId, int updateId, bool ignoreCollision);

		protected abstract void DeleteRelationshipEntity1(SearchCondition searchCondition);

		//public abstract void BulkDeleteAll();

		#endregion Delete functions.

		#region Save functions.

		public virtual void Save(IEntityObject obj)
		{
			this.Save(obj, this.ignoreCollision);
		}

		public virtual void Save(IEntityObject obj, bool ignoreCollision)
		{
			this.SaveCore(obj, ignoreCollision);
		}

		protected virtual void SaveCore(IEntityObject obj, bool ignoreCollision)
		{
			if (!(obj is IEntityObject)) throw new DALException(RepositoryExceptionMessage.NotBaseEntityObjectCompatible);
			if (obj.EntityClass == EntityClass.Attachment1)
				this.SaveAttachment1((IAttachment1)obj, ignoreCollision);
			else if (obj.EntityClass == EntityClass.DependentEntity1)
				this.SaveDependentEntity1((IDependentEntity1)obj, ignoreCollision);
			else if (obj.EntityClass == EntityClass.DependentEntity2)
				this.SaveDependentEntity2((IDependentEntity2)obj, ignoreCollision);
			else if (obj.EntityClass == EntityClass.IndependentEntity1)
				this.SaveIndependentEntity1((IIndependentEntity1)obj, ignoreCollision);
			else if (obj.EntityClass == EntityClass.IndependentEntity2)
				this.SaveIndependentEntity2((IIndependentEntity2)obj, ignoreCollision);
			else if (obj.EntityClass == EntityClass.RelationshipEntity1)
				this.SaveRelationshipEntity1((IRelationshipEntity1)obj, ignoreCollision);
			else
				throw new DALException(RepositoryExceptionMessage.EntityClassNotSupported);
		}

		public virtual void Save(IList list)
		{
			this.Save(list, this.ignoreCollision);
		}

		public virtual void Save(IList list, bool ignoreCollision)
		{
			this.SaveCore(list, ignoreCollision);
		}

		protected virtual void SaveCore(IList list, bool ignoreCollision)
		{
			CollisionList collisions = null;

			IEntityObject entityObject;
			foreach (object obj in list)
			{
				entityObject = obj as IEntityObject;
				if (entityObject != null && entityObject.HasUncommittedChanges)
				{
					if (ignoreCollision)
					{
						// Collision exceptions are not expected.
						// Any other exception should bubble up to the caller.
						this.Save((IEntityObject)obj, true);
					}
					else
					{
						// Collision exception(s) possible.
						// If such an exception is caught while saving an object in the list, its Collision object will be added to the collisions
						// collection.
						// After all objects have been processed, a single CollisionException containing the collisions list will be raised.
						// That way, an attempt is made to save all objects in the list while still notifying the caller of any exceptions via the
						// normal method of raising a CollisionException.
						try
						{
							this.Save((IEntityObject)obj, false);
						}
						catch (SingleCollisionException e)
						{
							// Save failed due to collision.
							// Add the Collision object contained in the CollisionException to the collisions list.
							if (collisions == null) collisions = new CollisionList();
							collisions.Add(e.Collision);
						}
					}
				}
			}

			if (collisions != null) throw new MultipleCollisionException(RepositoryExceptionMessage.MultipleCollisionsDetected, collisions);
		}

		public abstract void SaveAttachment1(IAttachment1 attachment1);

		public abstract void SaveAttachment1(IAttachment1 attachment1, bool ignoreCollision);

		protected abstract void SaveAttachment1Core(IAttachment1 attachment1, bool ignoreCollision);

		protected abstract void SaveAttachment1Core(IAttachment1 attachment1, bool ignoreCollision, SaveLog saveLog);

		protected abstract bool SaveAttachment1EntityObjectCore(IAttachment1 attachment1, bool ignoreCollision, SaveLog saveLog);

		public abstract void SaveDependentEntity1(IDependentEntity1 dependentEntity1);

		public abstract void SaveDependentEntity1(IDependentEntity1 dependentEntity1, bool ignoreCollision);

		protected abstract void SaveDependentEntity1Core(IDependentEntity1 dependentEntity1, bool ignoreCollision);

		protected abstract void SaveDependentEntity1Core(IDependentEntity1 dependentEntity1, bool ignoreCollision, SaveLog saveLog);

		protected abstract bool SaveDependentEntity1EntityObjectCore(IDependentEntity1 dependentEntity1, bool ignoreCollision, SaveLog saveLog);

		public abstract void SaveDependentEntity2(IDependentEntity2 dependentEntity2);

		public abstract void SaveDependentEntity2(IDependentEntity2 dependentEntity2, bool ignoreCollision);

		protected abstract void SaveDependentEntity2Core(IDependentEntity2 dependentEntity2, bool ignoreCollision);

		protected abstract void SaveDependentEntity2Core(IDependentEntity2 dependentEntity2, bool ignoreCollision, SaveLog saveLog);

		protected abstract bool SaveDependentEntity2EntityObjectCore(IDependentEntity2 dependentEntity2, bool ignoreCollision, SaveLog saveLog);

		public abstract void SaveIndependentEntity1(IIndependentEntity1 independentEntity1);

		public abstract void SaveIndependentEntity1(IIndependentEntity1 independentEntity1, bool ignoreCollision);

		protected abstract void SaveIndependentEntity1Core(IIndependentEntity1 independentEntity1, bool ignoreCollision);

		protected abstract void SaveIndependentEntity1Core(IIndependentEntity1 independentEntity1, bool ignoreCollision, SaveLog saveLog);

		protected abstract bool SaveIndependentEntity1EntityObjectCore(IIndependentEntity1 independentEntity1, bool ignoreCollision, SaveLog saveLog);

		public abstract void SaveIndependentEntity2(IIndependentEntity2 independentEntity2);

		public abstract void SaveIndependentEntity2(IIndependentEntity2 independentEntity2, bool ignoreCollision);

		protected abstract void SaveIndependentEntity2Core(IIndependentEntity2 independentEntity2, bool ignoreCollision);

		protected abstract void SaveIndependentEntity2Core(IIndependentEntity2 independentEntity2, bool ignoreCollision, SaveLog saveLog);

		protected abstract bool SaveIndependentEntity2EntityObjectCore(IIndependentEntity2 independentEntity2, bool ignoreCollision, SaveLog saveLog);

		public abstract void SaveRelationshipEntity1(IRelationshipEntity1 relationshipEntity1);

		public abstract void SaveRelationshipEntity1(IRelationshipEntity1 relationshipEntity1, bool ignoreCollision);

		protected abstract void SaveRelationshipEntity1Core(IRelationshipEntity1 relationshipEntity1, bool ignoreCollision);

		protected abstract void SaveRelationshipEntity1Core(IRelationshipEntity1 relationshipEntity1, bool ignoreCollision, SaveLog saveLog);

		protected abstract bool SaveRelationshipEntity1EntityObjectCore(IRelationshipEntity1 relationshipEntity1, bool ignoreCollision, SaveLog saveLog);

		#endregion Save functions.

		#region Find functions.

		public virtual IList Find(EntityClass entityClass, int maxCount, SearchCondition searchCondition)
		{
			return Find(entityClass, maxCount, searchCondition, null, null);
		}

		public virtual IList Find(EntityClass entityClass, int maxCount, SearchCondition searchCondition, SortSpecification sortSpecification)
		{
			return Find(entityClass, maxCount, searchCondition, sortSpecification, null);
		}

		public virtual IList Find(EntityClass entityClass, int maxCount, SearchCondition searchCondition, SortSpecification sortSpecification, IEntityObjectContext context)
		{
			IList list = null;
			if (entityClass == EntityClass.Attachment1)
				list = (IList)this.FindAttachment1(maxCount, searchCondition, context);
			else if (entityClass == EntityClass.DependentEntity1)
				list = (IList)this.FindDependentEntity1(maxCount, searchCondition, context);
			else if (entityClass == EntityClass.DependentEntity2)
				list = (IList)this.FindDependentEntity2(maxCount, searchCondition, context);
			else if (entityClass == EntityClass.IndependentEntity1)
				list = (IList)this.FindIndependentEntity1(maxCount, searchCondition, context);
			else if (entityClass == EntityClass.IndependentEntity2)
				list = (IList)this.FindIndependentEntity2(maxCount, searchCondition, context);
			else if (entityClass == EntityClass.RelationshipEntity1)
				list = (IList)this.FindRelationshipEntity1(maxCount, searchCondition, context);
			return list;
		}

		public abstract IAttachment1List FindAttachment1(int maxCount, SearchCondition searchCondition);

		public abstract IAttachment1List FindAttachment1(int maxCount, SearchCondition searchCondition, SortSpecification sortSpecification);

		public abstract IAttachment1List FindAttachment1(int maxCount, SearchCondition searchCondition, IEntityObjectContext context);

		public abstract IAttachment1List FindAttachment1(int maxCount, SearchCondition searchCondition, SortSpecification sortSpecification, IEntityObjectContext context);

		// Parameter propertyName must be a Attachment1PropertyName class constant (Attachment1BasePropertyName is a subset of Attachment1PropertyName).
		public abstract ArrayList GetAssociatedAttachment1Ids(int maxCount, Attachment1PropertyName attachment1PropertyName, object value);

		public abstract IDependentEntity1List FindDependentEntity1(int maxCount, SearchCondition searchCondition);

		public abstract IDependentEntity1List FindDependentEntity1(int maxCount, SearchCondition searchCondition, SortSpecification sortSpecification);

		public abstract IDependentEntity1List FindDependentEntity1(int maxCount, SearchCondition searchCondition, IEntityObjectContext context);

		public abstract IDependentEntity1List FindDependentEntity1(int maxCount, SearchCondition searchCondition, SortSpecification sortSpecification, IEntityObjectContext context);

		// Parameter propertyName must be a DependentEntity1PropertyName class constant (DependentEntity1BasePropertyName is a subset of DependentEntity1PropertyName).
		public abstract ArrayList GetAssociatedDependentEntity1Ids(int maxCount, DependentEntity1PropertyName dependentEntity1PropertyName, object value);

		public abstract SortSpecification DependentEntity1_ChildOwnedAttachment1SortSpecification
		{
			get;
			set;
		}

		public abstract SortSpecification DependentEntity1_ChildOwnedDependentEntity2SortSpecification
		{
			get;
			set;
		}

		public abstract IDependentEntity2List FindDependentEntity2(int maxCount, SearchCondition searchCondition);

		public abstract IDependentEntity2List FindDependentEntity2(int maxCount, SearchCondition searchCondition, SortSpecification sortSpecification);

		public abstract IDependentEntity2List FindDependentEntity2(int maxCount, SearchCondition searchCondition, IEntityObjectContext context);

		public abstract IDependentEntity2List FindDependentEntity2(int maxCount, SearchCondition searchCondition, SortSpecification sortSpecification, IEntityObjectContext context);

		// Parameter propertyName must be a DependentEntity2PropertyName class constant (DependentEntity2BasePropertyName is a subset of DependentEntity2PropertyName).
		public abstract ArrayList GetAssociatedDependentEntity2Ids(int maxCount, DependentEntity2PropertyName dependentEntity2PropertyName, object value);

		public abstract SortSpecification DependentEntity2_ChildOwnedRelationshipEntity1SortSpecification
		{
			get;
			set;
		}

		public abstract IIndependentEntity1List FindIndependentEntity1(int maxCount, SearchCondition searchCondition);

		public abstract IIndependentEntity1List FindIndependentEntity1(int maxCount, SearchCondition searchCondition, SortSpecification sortSpecification);

		public abstract IIndependentEntity1List FindIndependentEntity1(int maxCount, SearchCondition searchCondition, IEntityObjectContext context);

		public abstract IIndependentEntity1List FindIndependentEntity1(int maxCount, SearchCondition searchCondition, SortSpecification sortSpecification, IEntityObjectContext context);

		// Parameter propertyName must be a IndependentEntity1PropertyName class constant (IndependentEntity1BasePropertyName is a subset of IndependentEntity1PropertyName).
		public abstract ArrayList GetAssociatedIndependentEntity1Ids(int maxCount, IndependentEntity1PropertyName independentEntity1PropertyName, object value);

		public abstract SortSpecification IndependentEntity1_ChildOwnedDependentEntity1SortSpecification
		{
			get;
			set;
		}

		public abstract IIndependentEntity2List FindIndependentEntity2(int maxCount, SearchCondition searchCondition);

		public abstract IIndependentEntity2List FindIndependentEntity2(int maxCount, SearchCondition searchCondition, SortSpecification sortSpecification);

		public abstract IIndependentEntity2List FindIndependentEntity2(int maxCount, SearchCondition searchCondition, IEntityObjectContext context);

		public abstract IIndependentEntity2List FindIndependentEntity2(int maxCount, SearchCondition searchCondition, SortSpecification sortSpecification, IEntityObjectContext context);

		// Parameter propertyName must be a IndependentEntity2PropertyName class constant (IndependentEntity2BasePropertyName is a subset of IndependentEntity2PropertyName).
		public abstract ArrayList GetAssociatedIndependentEntity2Ids(int maxCount, IndependentEntity2PropertyName independentEntity2PropertyName, object value);

		public abstract SortSpecification IndependentEntity2_ChildOwnedRelationshipEntity1SortSpecification
		{
			get;
			set;
		}

		public abstract IRelationshipEntity1List FindRelationshipEntity1(int maxCount, SearchCondition searchCondition);

		public abstract IRelationshipEntity1List FindRelationshipEntity1(int maxCount, SearchCondition searchCondition, SortSpecification sortSpecification);

		public abstract IRelationshipEntity1List FindRelationshipEntity1(int maxCount, SearchCondition searchCondition, IEntityObjectContext context);

		public abstract IRelationshipEntity1List FindRelationshipEntity1(int maxCount, SearchCondition searchCondition, SortSpecification sortSpecification, IEntityObjectContext context);

		// Parameter propertyName must be a RelationshipEntity1PropertyName class constant (RelationshipEntity1BasePropertyName is a subset of RelationshipEntity1PropertyName).
		public abstract ArrayList GetAssociatedRelationshipEntity1Ids(int maxCount, RelationshipEntity1PropertyName relationshipEntity1PropertyName, object value);

		#endregion Find functions.


		#region Attachment1 related members.


		#endregion Attachment1 related members.

		#region DependentEntity1 related members.


		#endregion DependentEntity1 related members.

		#region DependentEntity2 related members.


		#endregion DependentEntity2 related members.

		#region IndependentEntity1 related members.


		#endregion IndependentEntity1 related members.

		#region IndependentEntity2 related members.


		#endregion IndependentEntity2 related members.

		#region RelationshipEntity1 related members.


		#endregion RelationshipEntity1 related members.

	}
}
