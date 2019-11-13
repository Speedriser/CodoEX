using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CustName.AppName.BL
{
	public class SortComparer<T> : IComparer<T>
	{
		private ListSortDescriptionCollection sortCollection = null;
		private PropertyDescriptor propDesc = null;
		private ListSortDirection direction = ListSortDirection.Ascending;

		public SortComparer(PropertyDescriptor propDesc, ListSortDirection direction)
		{
			this.propDesc = propDesc;
			this.direction = direction;
		}

		public SortComparer(ListSortDescriptionCollection sortCollection)
		{
			this.sortCollection = sortCollection;
		}

		int IComparer<T>.Compare(T x, T y)
		{
			if (this.propDesc != null) // Simple sort
			{
				object xValue = this.propDesc.GetValue(x);
				object yValue = this.propDesc.GetValue(y);
				return CompareValues(xValue, yValue, this.direction);
			}
			else if (this.sortCollection != null && this.sortCollection.Count > 0)
			{
				return RecursiveCompareInternal(x, y, 0);
			}
			else return 0;
		}

		private int CompareValues(object xValue, object yValue, ListSortDirection direction)
		{
			int retValue = 0;
			if (xValue == null) xValue = "";
			if (yValue == null) yValue = "";
			if (xValue is IComparable) // Can ask the x value
			{
				retValue = ((IComparable)xValue).CompareTo(yValue);
			}
			else if (yValue is IComparable) //Can ask the y value
			{
				retValue = ((IComparable)yValue).CompareTo(xValue);
			}
			// not comparable, compare String representations
			else if (!xValue.Equals(yValue))
			{
				retValue = xValue.ToString().CompareTo(yValue.ToString());
			}
			if (direction == ListSortDirection.Ascending)
			{
				return retValue;
			}
			else
			{
				return retValue * -1;
			}
		}

		private int RecursiveCompareInternal(T x, T y, int index)
		{
			if (index >= this.sortCollection.Count)
				return 0; // termination condition

			ListSortDescription listSortDesc = this.sortCollection[index];
			object xValue = listSortDesc.PropertyDescriptor.GetValue(x);
			object yValue = listSortDesc.PropertyDescriptor.GetValue(y);

			int retValue = CompareValues(xValue, yValue, listSortDesc.SortDirection);
			if (retValue == 0)
			{
				return RecursiveCompareInternal(x, y, ++index);
			}
			else
			{
				return retValue;
			}
		}
	}
}
