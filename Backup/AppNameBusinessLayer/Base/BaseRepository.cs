using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CustName.AppName.DAL;

namespace CustName.AppName.BL
{
	public abstract class BaseRepository
	{
		private CustName.AppName.DAL.Repository repository = CustName.AppName.BL.Global.ClassFactory.GetDALRepository();
		private IEntityObjectContext context = null;

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

		public virtual EntityObject Get(EntityClass entityClass, IIdentifier objectId)
		{
			return (EntityObject)this.repository.Get(entityClass, objectId, this.context);
		}

		public virtual IList Find(EntityClass entityClass, int maxCount, SearchCondition searchCondition)
		{
			return this.repository.Find(entityClass, maxCount, searchCondition, null, this.context);
		}

		public virtual IList Find(EntityClass entityClass, int maxCount, SearchCondition searchCondition, SortSpecification sortSpecification)
		{
			return this.repository.Find(entityClass, maxCount, searchCondition, sortSpecification, this.context);
		}

		#region Attachment1 related members.

		public virtual Attachment1List FindAttachment1(int maxCount, SearchCondition searchCondition)
		{
			return (Attachment1List)this.repository.FindAttachment1(maxCount, searchCondition, this.context);
		}

		public virtual Attachment1List FindAttachment1(int maxCount, SearchCondition searchCondition, SortSpecification sortSpecification)
		{
			return (Attachment1List)this.repository.FindAttachment1(maxCount, searchCondition, sortSpecification, this.context);
		}

		public virtual Attachment1 GetAttachment1(Attachment1Identifier objectId)
		{
			return (Attachment1)this.repository.GetAttachment1(objectId, this.context);
		}

		#endregion Attachment1 related members.

		#region DependentEntity1 related members.

		public virtual DependentEntity1List FindDependentEntity1(int maxCount, SearchCondition searchCondition)
		{
			return (DependentEntity1List)this.repository.FindDependentEntity1(maxCount, searchCondition, this.context);
		}

		public virtual DependentEntity1List FindDependentEntity1(int maxCount, SearchCondition searchCondition, SortSpecification sortSpecification)
		{
			return (DependentEntity1List)this.repository.FindDependentEntity1(maxCount, searchCondition, sortSpecification, this.context);
		}

		public virtual DependentEntity1 GetDependentEntity1(DependentEntity1Identifier objectId)
		{
			return (DependentEntity1)this.repository.GetDependentEntity1(objectId, this.context);
		}

		public SortSpecification DependentEntity1_ChildOwnedAttachment1SortSpecification
		{
			get
			{
				return this.repository.DependentEntity1_ChildOwnedAttachment1SortSpecification;
			}
			set
			{
				this.repository.DependentEntity1_ChildOwnedAttachment1SortSpecification = value;
			}
		}

		public SortSpecification DependentEntity1_ChildOwnedDependentEntity2SortSpecification
		{
			get
			{
				return this.repository.DependentEntity1_ChildOwnedDependentEntity2SortSpecification;
			}
			set
			{
				this.repository.DependentEntity1_ChildOwnedDependentEntity2SortSpecification = value;
			}
		}

		#endregion DependentEntity1 related members.

		#region DependentEntity2 related members.

		public virtual DependentEntity2List FindDependentEntity2(int maxCount, SearchCondition searchCondition)
		{
			return (DependentEntity2List)this.repository.FindDependentEntity2(maxCount, searchCondition, this.context);
		}

		public virtual DependentEntity2List FindDependentEntity2(int maxCount, SearchCondition searchCondition, SortSpecification sortSpecification)
		{
			return (DependentEntity2List)this.repository.FindDependentEntity2(maxCount, searchCondition, sortSpecification, this.context);
		}

		public virtual DependentEntity2 GetDependentEntity2(DependentEntity2Identifier objectId)
		{
			return (DependentEntity2)this.repository.GetDependentEntity2(objectId, this.context);
		}

		public SortSpecification DependentEntity2_ChildOwnedRelationshipEntity1SortSpecification
		{
			get
			{
				return this.repository.DependentEntity2_ChildOwnedRelationshipEntity1SortSpecification;
			}
			set
			{
				this.repository.DependentEntity2_ChildOwnedRelationshipEntity1SortSpecification = value;
			}
		}

		#endregion DependentEntity2 related members.

		#region IndependentEntity1 related members.

		public virtual IndependentEntity1List FindIndependentEntity1(int maxCount, SearchCondition searchCondition)
		{
			return (IndependentEntity1List)this.repository.FindIndependentEntity1(maxCount, searchCondition, this.context);
		}

		public virtual IndependentEntity1List FindIndependentEntity1(int maxCount, SearchCondition searchCondition, SortSpecification sortSpecification)
		{
			return (IndependentEntity1List)this.repository.FindIndependentEntity1(maxCount, searchCondition, sortSpecification, this.context);
		}

		public virtual IndependentEntity1 GetIndependentEntity1(IndependentEntity1Identifier objectId)
		{
			return (IndependentEntity1)this.repository.GetIndependentEntity1(objectId, this.context);
		}

		public SortSpecification IndependentEntity1_ChildOwnedDependentEntity1SortSpecification
		{
			get
			{
				return this.repository.IndependentEntity1_ChildOwnedDependentEntity1SortSpecification;
			}
			set
			{
				this.repository.IndependentEntity1_ChildOwnedDependentEntity1SortSpecification = value;
			}
		}

		#endregion IndependentEntity1 related members.

		#region IndependentEntity2 related members.

		public virtual IndependentEntity2List FindIndependentEntity2(int maxCount, SearchCondition searchCondition)
		{
			return (IndependentEntity2List)this.repository.FindIndependentEntity2(maxCount, searchCondition, this.context);
		}

		public virtual IndependentEntity2List FindIndependentEntity2(int maxCount, SearchCondition searchCondition, SortSpecification sortSpecification)
		{
			return (IndependentEntity2List)this.repository.FindIndependentEntity2(maxCount, searchCondition, sortSpecification, this.context);
		}

		public virtual IndependentEntity2 GetIndependentEntity2(IndependentEntity2Identifier objectId)
		{
			return (IndependentEntity2)this.repository.GetIndependentEntity2(objectId, this.context);
		}

		public SortSpecification IndependentEntity2_ChildOwnedRelationshipEntity1SortSpecification
		{
			get
			{
				return this.repository.IndependentEntity2_ChildOwnedRelationshipEntity1SortSpecification;
			}
			set
			{
				this.repository.IndependentEntity2_ChildOwnedRelationshipEntity1SortSpecification = value;
			}
		}

		#endregion IndependentEntity2 related members.

		#region RelationshipEntity1 related members.

		public virtual RelationshipEntity1List FindRelationshipEntity1(int maxCount, SearchCondition searchCondition)
		{
			return (RelationshipEntity1List)this.repository.FindRelationshipEntity1(maxCount, searchCondition, this.context);
		}

		public virtual RelationshipEntity1List FindRelationshipEntity1(int maxCount, SearchCondition searchCondition, SortSpecification sortSpecification)
		{
			return (RelationshipEntity1List)this.repository.FindRelationshipEntity1(maxCount, searchCondition, sortSpecification, this.context);
		}

		public virtual RelationshipEntity1 GetRelationshipEntity1(RelationshipEntity1Identifier objectId)
		{
			return (RelationshipEntity1)this.repository.GetRelationshipEntity1(objectId, this.context);
		}

		#endregion RelationshipEntity1 related members.
	}
}
