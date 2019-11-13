using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CustName.AppName.DAL;

namespace CustName.AppName.BL
{
	public abstract partial class BaseAttachment1List : BindingListView<Attachment1>, IAttachment1List
	{
		// Reference to the owner entity object that members of this collection have an association with.
		// Because instances of the collection could be owned by multiple entity classes, IEntityObject is the strongest type than can be used.
		private IEntityObject parent = null;
		private CollectionName collectionName = CustName.AppName.DAL.CollectionName.None;

		public BaseAttachment1List()
			: base()
		{
			Initialize();
		}

		public BaseAttachment1List(List<Attachment1> list)
			: base(list)
		{
			Initialize();
		}

		protected virtual void Initialize()
		{
		}

		public virtual Attachment1 AddNew(bool commit)
		{
			Attachment1 attachment1 = this.AddNew();
			if (commit) this.EndNew(this.Count - 1);
			return attachment1;
		}

		public virtual int IndexOf(Attachment1Identifier objectId)
		{
			int index = 0;
			foreach (Attachment1 attachment1 in this)
			{
				if (attachment1.ObjectId == objectId)
					return index;
				else
					++index;
			}
			return -1;
		}

		#region BindingListView<Attachment1>

		// Overridden so that new Attachment1 instances added to the collection are manufactured by the class factory.
		protected override object AddNewCore()
		{
			Attachment1 attachment1 = (Attachment1)CustName.AppName.BL.Global.ClassFactory.GetEntityObject(EntityClass.Attachment1);
			attachment1.AddNewList = (IList)this;
			this.Add(attachment1);
			return attachment1;
			// Note: This may disable the AddingNew event.
		}

		#endregion BindingListView<Attachment1>

		#region Collection<Attachment1>

		// Override Collection<T> InsertItem method to set the ParentList property of Attachment1 items added to the list.
		protected override void InsertItem(int index, Attachment1 item)
		{
			SetItemCollectionPointer(item, this); // Must come before call to InsertItem.
			base.InsertItem(index, item);
		}

		protected override void SetItem(int index, Attachment1 item)
		{
			SetItemCollectionPointer(item, this); // Must come before call to SetItem.
			base.SetItem(index, item);
		}

		protected override void RemoveItem(int index)
		{
			if (Items[index].AddNewList == (IList)this) Items[index].AddNewList = null;
			SetItemCollectionPointer(Items[index], null);
			base.RemoveItem(index);
		}

		protected override void ClearItems()
		{
			foreach (Attachment1 item in Items)
			{
				if (item.AddNewList == (IList)this) item.AddNewList = null;
				SetItemCollectionPointer(item, null);
			}
			base.ClearItems();
		}

		private void SetItemCollectionPointer(Attachment1 item, BaseAttachment1List collectionPointer)
		{
			if (this.collectionName == CustName.AppName.DAL.CollectionName.DependentEntity1_ChildOwnedAttachment1List)
				item.ParentOwnerDependentEntity1_Attachment1List = (Attachment1List)collectionPointer;
			//else if (this.collectionName == CustName.AppName.DAL.CollectionName.None)
			// Do nothing.
		}

		#endregion Collection<Attachment1>

		#region IAttachment1List

		public virtual IEntityObject Parent
		{
			get
			{
				return this.parent;
			}
			set
			{
				this.parent = value;
			}
		}

		public virtual CollectionName CollectionName
		{
			get
			{
				return this.collectionName;
			}
			set
			{
				this.collectionName = value;
				foreach (Attachment1 item in Items)
				{
					SetItemCollectionPointer(item, this);
				}
			}
		}

		public virtual void IncrementDeleteCount()
		{
			for (int index = 0; index < this.Count; ++index)
				this[index].IncrementDeleteCount();
		}

		public virtual void DecrementDeleteCount()
		{
			for (int index = 0; index < this.Count; ++index)
				this[index].DecrementDeleteCount();
		}

		#endregion IAttachment1List
	}

	public abstract partial class BaseDependentEntity1List : BindingListView<DependentEntity1>, IDependentEntity1List
	{
		// Reference to the owner entity object that members of this collection have an association with.
		// Because instances of the collection could be owned by multiple entity classes, IEntityObject is the strongest type than can be used.
		private IEntityObject parent = null;
		private CollectionName collectionName = CustName.AppName.DAL.CollectionName.None;

		public BaseDependentEntity1List()
			: base()
		{
			Initialize();
		}

		public BaseDependentEntity1List(List<DependentEntity1> list)
			: base(list)
		{
			Initialize();
		}

		protected virtual void Initialize()
		{
		}

		public virtual DependentEntity1 AddNew(bool commit)
		{
			DependentEntity1 dependentEntity1 = this.AddNew();
			if (commit) this.EndNew(this.Count - 1);
			return dependentEntity1;
		}

		public virtual int IndexOf(DependentEntity1Identifier objectId)
		{
			int index = 0;
			foreach (DependentEntity1 dependentEntity1 in this)
			{
				if (dependentEntity1.ObjectId == objectId)
					return index;
				else
					++index;
			}
			return -1;
		}

		#region BindingListView<DependentEntity1>

		// Overridden so that new DependentEntity1 instances added to the collection are manufactured by the class factory.
		protected override object AddNewCore()
		{
			DependentEntity1 dependentEntity1 = (DependentEntity1)CustName.AppName.BL.Global.ClassFactory.GetEntityObject(EntityClass.DependentEntity1);
			dependentEntity1.AddNewList = (IList)this;
			this.Add(dependentEntity1);
			return dependentEntity1;
			// Note: This may disable the AddingNew event.
		}

		#endregion BindingListView<DependentEntity1>

		#region Collection<DependentEntity1>

		// Override Collection<T> InsertItem method to set the ParentList property of DependentEntity1 items added to the list.
		protected override void InsertItem(int index, DependentEntity1 item)
		{
			SetItemCollectionPointer(item, this); // Must come before call to InsertItem.
			base.InsertItem(index, item);
		}

		protected override void SetItem(int index, DependentEntity1 item)
		{
			SetItemCollectionPointer(item, this); // Must come before call to SetItem.
			base.SetItem(index, item);
		}

		protected override void RemoveItem(int index)
		{
			if (Items[index].AddNewList == (IList)this) Items[index].AddNewList = null;
			SetItemCollectionPointer(Items[index], null);
			base.RemoveItem(index);
		}

		protected override void ClearItems()
		{
			foreach (DependentEntity1 item in Items)
			{
				if (item.AddNewList == (IList)this) item.AddNewList = null;
				SetItemCollectionPointer(item, null);
			}
			base.ClearItems();
		}

		private void SetItemCollectionPointer(DependentEntity1 item, BaseDependentEntity1List collectionPointer)
		{
			if (this.collectionName == CustName.AppName.DAL.CollectionName.IndependentEntity1_ChildOwnedDependentEntity1List)
				item.ParentOwnerIndependentEntity1_DependentEntity1List = (DependentEntity1List)collectionPointer;
			//else if (this.collectionName == CustName.AppName.DAL.CollectionName.None)
			// Do nothing.
		}

		#endregion Collection<DependentEntity1>

		#region IDependentEntity1List

		public virtual IEntityObject Parent
		{
			get
			{
				return this.parent;
			}
			set
			{
				this.parent = value;
			}
		}

		public virtual CollectionName CollectionName
		{
			get
			{
				return this.collectionName;
			}
			set
			{
				this.collectionName = value;
				foreach (DependentEntity1 item in Items)
				{
					SetItemCollectionPointer(item, this);
				}
			}
		}

		public virtual void IncrementDeleteCount()
		{
			for (int index = 0; index < this.Count; ++index)
				this[index].IncrementDeleteCount();
		}

		public virtual void DecrementDeleteCount()
		{
			for (int index = 0; index < this.Count; ++index)
				this[index].DecrementDeleteCount();
		}

		#endregion IDependentEntity1List
	}

	public abstract partial class BaseDependentEntity2List : BindingListView<DependentEntity2>, IDependentEntity2List
	{
		// Reference to the owner entity object that members of this collection have an association with.
		// Because instances of the collection could be owned by multiple entity classes, IEntityObject is the strongest type than can be used.
		private IEntityObject parent = null;
		private CollectionName collectionName = CustName.AppName.DAL.CollectionName.None;

		public BaseDependentEntity2List()
			: base()
		{
			Initialize();
		}

		public BaseDependentEntity2List(List<DependentEntity2> list)
			: base(list)
		{
			Initialize();
		}

		protected virtual void Initialize()
		{
		}

		public virtual DependentEntity2 AddNew(bool commit)
		{
			DependentEntity2 dependentEntity2 = this.AddNew();
			if (commit) this.EndNew(this.Count - 1);
			return dependentEntity2;
		}

		public virtual int IndexOf(DependentEntity2Identifier objectId)
		{
			int index = 0;
			foreach (DependentEntity2 dependentEntity2 in this)
			{
				if (dependentEntity2.ObjectId == objectId)
					return index;
				else
					++index;
			}
			return -1;
		}

		#region BindingListView<DependentEntity2>

		// Overridden so that new DependentEntity2 instances added to the collection are manufactured by the class factory.
		protected override object AddNewCore()
		{
			DependentEntity2 dependentEntity2 = (DependentEntity2)CustName.AppName.BL.Global.ClassFactory.GetEntityObject(EntityClass.DependentEntity2);
			dependentEntity2.AddNewList = (IList)this;
			this.Add(dependentEntity2);
			return dependentEntity2;
			// Note: This may disable the AddingNew event.
		}

		#endregion BindingListView<DependentEntity2>

		#region Collection<DependentEntity2>

		// Override Collection<T> InsertItem method to set the ParentList property of DependentEntity2 items added to the list.
		protected override void InsertItem(int index, DependentEntity2 item)
		{
			SetItemCollectionPointer(item, this); // Must come before call to InsertItem.
			base.InsertItem(index, item);
		}

		protected override void SetItem(int index, DependentEntity2 item)
		{
			SetItemCollectionPointer(item, this); // Must come before call to SetItem.
			base.SetItem(index, item);
		}

		protected override void RemoveItem(int index)
		{
			if (Items[index].AddNewList == (IList)this) Items[index].AddNewList = null;
			SetItemCollectionPointer(Items[index], null);
			base.RemoveItem(index);
		}

		protected override void ClearItems()
		{
			foreach (DependentEntity2 item in Items)
			{
				if (item.AddNewList == (IList)this) item.AddNewList = null;
				SetItemCollectionPointer(item, null);
			}
			base.ClearItems();
		}

		private void SetItemCollectionPointer(DependentEntity2 item, BaseDependentEntity2List collectionPointer)
		{
			if (this.collectionName == CustName.AppName.DAL.CollectionName.DependentEntity1_ChildOwnedDependentEntity2List)
				item.ParentOwnerDependentEntity1_DependentEntity2List = (DependentEntity2List)collectionPointer;
			//else if (this.collectionName == CustName.AppName.DAL.CollectionName.None)
			// Do nothing.
		}

		#endregion Collection<DependentEntity2>

		#region IDependentEntity2List

		public virtual IEntityObject Parent
		{
			get
			{
				return this.parent;
			}
			set
			{
				this.parent = value;
			}
		}

		public virtual CollectionName CollectionName
		{
			get
			{
				return this.collectionName;
			}
			set
			{
				this.collectionName = value;
				foreach (DependentEntity2 item in Items)
				{
					SetItemCollectionPointer(item, this);
				}
			}
		}

		public virtual void IncrementDeleteCount()
		{
			for (int index = 0; index < this.Count; ++index)
				this[index].IncrementDeleteCount();
		}

		public virtual void DecrementDeleteCount()
		{
			for (int index = 0; index < this.Count; ++index)
				this[index].DecrementDeleteCount();
		}

		#endregion IDependentEntity2List
	}

	public abstract partial class BaseIndependentEntity1List : BindingListView<IndependentEntity1>, IIndependentEntity1List
	{
		// Reference to the owner entity object that members of this collection have an association with.
		// Because instances of the collection could be owned by multiple entity classes, IEntityObject is the strongest type than can be used.
		private IEntityObject parent = null;
		private CollectionName collectionName = CustName.AppName.DAL.CollectionName.None;

		public BaseIndependentEntity1List()
			: base()
		{
			Initialize();
		}

		public BaseIndependentEntity1List(List<IndependentEntity1> list)
			: base(list)
		{
			Initialize();
		}

		protected virtual void Initialize()
		{
		}

		public virtual IndependentEntity1 AddNew(bool commit)
		{
			IndependentEntity1 independentEntity1 = this.AddNew();
			if (commit) this.EndNew(this.Count - 1);
			return independentEntity1;
		}

		public virtual int IndexOf(IndependentEntity1Identifier objectId)
		{
			int index = 0;
			foreach (IndependentEntity1 independentEntity1 in this)
			{
				if (independentEntity1.ObjectId == objectId)
					return index;
				else
					++index;
			}
			return -1;
		}

		#region BindingListView<IndependentEntity1>

		// Overridden so that new IndependentEntity1 instances added to the collection are manufactured by the class factory.
		protected override object AddNewCore()
		{
			IndependentEntity1 independentEntity1 = (IndependentEntity1)CustName.AppName.BL.Global.ClassFactory.GetEntityObject(EntityClass.IndependentEntity1);
			independentEntity1.AddNewList = (IList)this;
			this.Add(independentEntity1);
			return independentEntity1;
			// Note: This may disable the AddingNew event.
		}

		#endregion BindingListView<IndependentEntity1>

		#region Collection<IndependentEntity1>

		// Override Collection<T> InsertItem method to set the ParentList property of IndependentEntity1 items added to the list.
		protected override void InsertItem(int index, IndependentEntity1 item)
		{
			SetItemCollectionPointer(item, this); // Must come before call to InsertItem.
			base.InsertItem(index, item);
		}

		protected override void SetItem(int index, IndependentEntity1 item)
		{
			SetItemCollectionPointer(item, this); // Must come before call to SetItem.
			base.SetItem(index, item);
		}

		protected override void RemoveItem(int index)
		{
			if (Items[index].AddNewList == (IList)this) Items[index].AddNewList = null;
			SetItemCollectionPointer(Items[index], null);
			base.RemoveItem(index);
		}

		protected override void ClearItems()
		{
			foreach (IndependentEntity1 item in Items)
			{
				if (item.AddNewList == (IList)this) item.AddNewList = null;
				SetItemCollectionPointer(item, null);
			}
			base.ClearItems();
		}

		private void SetItemCollectionPointer(IndependentEntity1 item, BaseIndependentEntity1List collectionPointer)
		{
			//if (this.collectionName == CustName.AppName.DAL.CollectionName.None)
			// Do nothing.
		}

		#endregion Collection<IndependentEntity1>

		#region IIndependentEntity1List

		public virtual IEntityObject Parent
		{
			get
			{
				return this.parent;
			}
			set
			{
				this.parent = value;
			}
		}

		public virtual CollectionName CollectionName
		{
			get
			{
				return this.collectionName;
			}
			set
			{
				this.collectionName = value;
				foreach (IndependentEntity1 item in Items)
				{
					SetItemCollectionPointer(item, this);
				}
			}
		}

		public virtual void IncrementDeleteCount()
		{
			for (int index = 0; index < this.Count; ++index)
				this[index].IncrementDeleteCount();
		}

		public virtual void DecrementDeleteCount()
		{
			for (int index = 0; index < this.Count; ++index)
				this[index].DecrementDeleteCount();
		}

		#endregion IIndependentEntity1List
	}

	public abstract partial class BaseIndependentEntity2List : BindingListView<IndependentEntity2>, IIndependentEntity2List
	{
		// Reference to the owner entity object that members of this collection have an association with.
		// Because instances of the collection could be owned by multiple entity classes, IEntityObject is the strongest type than can be used.
		private IEntityObject parent = null;
		private CollectionName collectionName = CustName.AppName.DAL.CollectionName.None;

		public BaseIndependentEntity2List()
			: base()
		{
			Initialize();
		}

		public BaseIndependentEntity2List(List<IndependentEntity2> list)
			: base(list)
		{
			Initialize();
		}

		protected virtual void Initialize()
		{
		}

		public virtual IndependentEntity2 AddNew(bool commit)
		{
			IndependentEntity2 independentEntity2 = this.AddNew();
			if (commit) this.EndNew(this.Count - 1);
			return independentEntity2;
		}

		public virtual int IndexOf(IndependentEntity2Identifier objectId)
		{
			int index = 0;
			foreach (IndependentEntity2 independentEntity2 in this)
			{
				if (independentEntity2.ObjectId == objectId)
					return index;
				else
					++index;
			}
			return -1;
		}

		#region BindingListView<IndependentEntity2>

		// Overridden so that new IndependentEntity2 instances added to the collection are manufactured by the class factory.
		protected override object AddNewCore()
		{
			IndependentEntity2 independentEntity2 = (IndependentEntity2)CustName.AppName.BL.Global.ClassFactory.GetEntityObject(EntityClass.IndependentEntity2);
			independentEntity2.AddNewList = (IList)this;
			this.Add(independentEntity2);
			return independentEntity2;
			// Note: This may disable the AddingNew event.
		}

		#endregion BindingListView<IndependentEntity2>

		#region Collection<IndependentEntity2>

		// Override Collection<T> InsertItem method to set the ParentList property of IndependentEntity2 items added to the list.
		protected override void InsertItem(int index, IndependentEntity2 item)
		{
			SetItemCollectionPointer(item, this); // Must come before call to InsertItem.
			base.InsertItem(index, item);
		}

		protected override void SetItem(int index, IndependentEntity2 item)
		{
			SetItemCollectionPointer(item, this); // Must come before call to SetItem.
			base.SetItem(index, item);
		}

		protected override void RemoveItem(int index)
		{
			if (Items[index].AddNewList == (IList)this) Items[index].AddNewList = null;
			SetItemCollectionPointer(Items[index], null);
			base.RemoveItem(index);
		}

		protected override void ClearItems()
		{
			foreach (IndependentEntity2 item in Items)
			{
				if (item.AddNewList == (IList)this) item.AddNewList = null;
				SetItemCollectionPointer(item, null);
			}
			base.ClearItems();
		}

		private void SetItemCollectionPointer(IndependentEntity2 item, BaseIndependentEntity2List collectionPointer)
		{
			//if (this.collectionName == CustName.AppName.DAL.CollectionName.None)
			// Do nothing.
		}

		#endregion Collection<IndependentEntity2>

		#region IIndependentEntity2List

		public virtual IEntityObject Parent
		{
			get
			{
				return this.parent;
			}
			set
			{
				this.parent = value;
			}
		}

		public virtual CollectionName CollectionName
		{
			get
			{
				return this.collectionName;
			}
			set
			{
				this.collectionName = value;
				foreach (IndependentEntity2 item in Items)
				{
					SetItemCollectionPointer(item, this);
				}
			}
		}

		public virtual void IncrementDeleteCount()
		{
			for (int index = 0; index < this.Count; ++index)
				this[index].IncrementDeleteCount();
		}

		public virtual void DecrementDeleteCount()
		{
			for (int index = 0; index < this.Count; ++index)
				this[index].DecrementDeleteCount();
		}

		#endregion IIndependentEntity2List
	}

	public abstract partial class BaseRelationshipEntity1List : BindingListView<RelationshipEntity1>, IRelationshipEntity1List
	{
		// Reference to the owner entity object that members of this collection have an association with.
		// Because instances of the collection could be owned by multiple entity classes, IEntityObject is the strongest type than can be used.
		private IEntityObject parent = null;
		private CollectionName collectionName = CustName.AppName.DAL.CollectionName.None;

		public BaseRelationshipEntity1List()
			: base()
		{
			Initialize();
		}

		public BaseRelationshipEntity1List(List<RelationshipEntity1> list)
			: base(list)
		{
			Initialize();
		}

		protected virtual void Initialize()
		{
		}

		public virtual RelationshipEntity1 AddNew(bool commit)
		{
			RelationshipEntity1 relationshipEntity1 = this.AddNew();
			if (commit) this.EndNew(this.Count - 1);
			return relationshipEntity1;
		}

		public virtual int IndexOf(RelationshipEntity1Identifier objectId)
		{
			int index = 0;
			foreach (RelationshipEntity1 relationshipEntity1 in this)
			{
				if (relationshipEntity1.ObjectId == objectId)
					return index;
				else
					++index;
			}
			return -1;
		}

		#region BindingListView<RelationshipEntity1>

		// Overridden so that new RelationshipEntity1 instances added to the collection are manufactured by the class factory.
		protected override object AddNewCore()
		{
			RelationshipEntity1 relationshipEntity1 = (RelationshipEntity1)CustName.AppName.BL.Global.ClassFactory.GetEntityObject(EntityClass.RelationshipEntity1);
			relationshipEntity1.AddNewList = (IList)this;
			this.Add(relationshipEntity1);
			return relationshipEntity1;
			// Note: This may disable the AddingNew event.
		}

		#endregion BindingListView<RelationshipEntity1>

		#region Collection<RelationshipEntity1>

		// Override Collection<T> InsertItem method to set the ParentList property of RelationshipEntity1 items added to the list.
		protected override void InsertItem(int index, RelationshipEntity1 item)
		{
			SetItemCollectionPointer(item, this); // Must come before call to InsertItem.
			base.InsertItem(index, item);
		}

		protected override void SetItem(int index, RelationshipEntity1 item)
		{
			SetItemCollectionPointer(item, this); // Must come before call to SetItem.
			base.SetItem(index, item);
		}

		protected override void RemoveItem(int index)
		{
			if (Items[index].AddNewList == (IList)this) Items[index].AddNewList = null;
			SetItemCollectionPointer(Items[index], null);
			base.RemoveItem(index);
		}

		protected override void ClearItems()
		{
			foreach (RelationshipEntity1 item in Items)
			{
				if (item.AddNewList == (IList)this) item.AddNewList = null;
				SetItemCollectionPointer(item, null);
			}
			base.ClearItems();
		}

		private void SetItemCollectionPointer(RelationshipEntity1 item, BaseRelationshipEntity1List collectionPointer)
		{
			if (this.collectionName == CustName.AppName.DAL.CollectionName.DependentEntity2_ChildOwnedRelationshipEntity1List)
				item.ParentOwnerDependentEntity2_RelationshipEntity1List = (RelationshipEntity1List)collectionPointer;
			else if (this.collectionName == CustName.AppName.DAL.CollectionName.IndependentEntity2_ChildOwnedRelationshipEntity1List)
				item.ParentOwnerIndependentEntity2_RelationshipEntity1List = (RelationshipEntity1List)collectionPointer;
			//else if (this.collectionName == CustName.AppName.DAL.CollectionName.None)
			// Do nothing.
		}

		#endregion Collection<RelationshipEntity1>

		#region IRelationshipEntity1List

		public virtual IEntityObject Parent
		{
			get
			{
				return this.parent;
			}
			set
			{
				this.parent = value;
			}
		}

		public virtual CollectionName CollectionName
		{
			get
			{
				return this.collectionName;
			}
			set
			{
				this.collectionName = value;
				foreach (RelationshipEntity1 item in Items)
				{
					SetItemCollectionPointer(item, this);
				}
			}
		}

		public virtual void IncrementDeleteCount()
		{
			for (int index = 0; index < this.Count; ++index)
				this[index].IncrementDeleteCount();
		}

		public virtual void DecrementDeleteCount()
		{
			for (int index = 0; index < this.Count; ++index)
				this[index].DecrementDeleteCount();
		}

		#endregion IRelationshipEntity1List
	}
}
