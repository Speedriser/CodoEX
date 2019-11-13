using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustName.AppName.DAL
{
	public interface IEntityObjectContextItem
	{
		IIdentifier ContextKey
		{
			get;
		}

		IEntityObjectContext Context
		{
			get;
			set;
		}
	}
}
