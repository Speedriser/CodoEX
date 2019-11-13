using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CustName.AppName.BL
{
	public class BindingListView<T> : BindingList<T>, IBindingListView, IRaiseItemChangedEvents
	{
		private bool sorted = false;
		private bool filtered = false;
		private string filterString = null;
		private ListSortDirection sortDirection = ListSortDirection.Ascending;
		private PropertyDescriptor sortProperty = null;
		private ListSortDescriptionCollection sortDescriptions = new ListSortDescriptionCollection();
		private List<T> originalCollection = new List<T>();

		public BindingListView() : base()
		{
		}

		public BindingListView(List<T> list) : base(list)
		{
		}

		protected override bool SupportsSearchingCore
		{
			get { return true; }
		}

		protected override int FindCore(PropertyDescriptor property, object key)
		{
			// Simple iteration:
			for (int i = 0; i < Count; i++)
			{
				T item = this[i];
				if (property.GetValue(item).Equals(key))
				{
					return i;
				}
			}
			return -1; // Not found

			// Alternative search implementation
			// using List.FindIndex:
			//Predicate<T> pred = delegate(T item)
			//{
			// if (property.GetValue(item).Equals(key))
			// return true;
			// else
			// return false;
			//};
			//List<T> list = Items as List<T>;
			//if (list == null)
			// return -1;
			//return list.FindIndex(pred);
		}

		protected override bool SupportsSortingCore
		{
			get { return true; }
		}

		protected override bool IsSortedCore
		{
			get { return this.sorted; }
		}

		protected override ListSortDirection SortDirectionCore
		{
			get { return this.sortDirection; }
		}

		protected override PropertyDescriptor SortPropertyCore
		{
			get { return this.sortProperty; }
		}

		protected override void ApplySortCore(PropertyDescriptor property, ListSortDirection direction)
		{
			this.sortDirection = direction;
			this.sortProperty = property;
			SortComparer<T> comparer = new SortComparer<T>(property,direction);
			ApplySortInternal(comparer);
		}

		private void ApplySortInternal(SortComparer<T> comparer)
		{
			if (this.originalCollection.Count == 0)
			{
				this.originalCollection.AddRange(this);
			}
			List<T> listRef = this.Items as List<T>;
			if (listRef == null)
				return;
			listRef.Sort(comparer);
			this.sorted = true;
			OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
		}

		protected override void RemoveSortCore()
		{
			if (!this.sorted)
				return;
			Clear();
			foreach (T item in this.originalCollection)
			{
				Add(item);
			}
			this.originalCollection.Clear();
			this.sortProperty = null;
			this.sortDescriptions = null;
			this.sorted = false;
		}

		void IBindingListView.ApplySort(ListSortDescriptionCollection sorts)
		{
			this.sortProperty = null;
			this.sortDescriptions = sorts;
			SortComparer<T> comparer = new SortComparer<T>(sorts);
			ApplySortInternal(comparer);
		}

		string IBindingListView.Filter
		{
			get
			{
				return this.filterString;
			}
			set
			{
				this.filterString = value;
				this.filtered = true;
				UpdateFilter();
			}
		}

		void IBindingListView.RemoveFilter()
		{
			if (!this.filtered)
				return;
			this.filterString = null;
			this.filtered = false;
			this.sorted = false;
			this.sortDescriptions = null;
			this.sortProperty = null;
			Clear();
			foreach (T item in this.originalCollection)
			{
				Add(item);
			}
			this.originalCollection.Clear();
		}

		ListSortDescriptionCollection IBindingListView.SortDescriptions
		{
			get
			{
				return this.sortDescriptions;
			}
		}

		bool IBindingListView.SupportsAdvancedSorting
		{
			get
			{
				return true;
			}
		}

		bool IBindingListView.SupportsFiltering
		{
			get
			{
				return true;
			}
		}

		protected virtual void UpdateFilter()
		{
			int equalsPos = this.filterString.IndexOf('=');
			// Get property name
			string propName = this.filterString.Substring(0,equalsPos).Trim();
			// Get filter criteria
			string criteria = this.filterString.Substring(equalsPos+1,
			this.filterString.Length - equalsPos - 1).Trim();
			// Strip leading and trailing quotes
			criteria = criteria.Substring(1, criteria.Length - 2);
			// Get a property descriptor for the filter property
			PropertyDescriptor propDesc = TypeDescriptor.GetProperties(typeof(T))[propName];
			if (this.originalCollection.Count == 0)
			{
				this.originalCollection.AddRange(this);
			}
			List<T> currentCollection = new List<T>(this);
			Clear();
			foreach (T item in currentCollection)
			{
				object value = propDesc.GetValue(item);
				if (value.ToString() == criteria)
				{
					Add(item);
				}
			}
		}

		bool IBindingList.AllowNew
		{
			get
			{
				return CheckReadOnly();
			}
		}

		bool IBindingList.AllowRemove
		{
			get
			{
				return CheckReadOnly();
			}
		}

		private bool CheckReadOnly()
		{
			if (this.sorted || this.filtered)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		bool IRaiseItemChangedEvents.RaisesItemChangedEvents
		{
			get
			{
				return true;
			}
		}
	}
}
