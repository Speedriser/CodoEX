using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustName.AppName.DAL
{
	public interface IIdentifier : IComparable
	{
		[System.Runtime.CompilerServices.IndexerName("Item")]
		object this[int index]
		{
			get;
			set;
		}

		[System.Runtime.CompilerServices.IndexerName("Item")]
		object this[string index]
		{
			get;
			set;
		}

		int FieldCount
		{
			get;
		}
	}
}
