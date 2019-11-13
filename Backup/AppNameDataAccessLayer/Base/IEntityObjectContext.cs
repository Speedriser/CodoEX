using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustName.AppName.DAL
{
	public interface IEntityObjectContext
	{
		void Add(IEntityObjectContextItem obj);

		void Remove(IEntityObjectContextItem obj);

		IEntityObjectContextItem Get(IIdentifier objectId);
	}
}
