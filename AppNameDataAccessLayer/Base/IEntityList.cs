using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CustName.AppName.DAL
{
	public interface IEntityList : IBindingListView
	{
		IEntityObject Parent
		{
			get;
			set;
		}

		CollectionName CollectionName
		{
			get;
			set;
		}

		void IncrementDeleteCount();

		void DecrementDeleteCount();
	}
}
