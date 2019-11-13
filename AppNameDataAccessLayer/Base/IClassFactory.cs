using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustName.AppName.DAL
{
	public interface IClassFactory
	{
		IEntityObject GetEntityObject(EntityClass entityClass);

		IEntityObject GetEntityObject(EntityClass entityClass, Guid instanceId);

		IEntityList GetEntityListObject(EntityClass entityClass);
	}
}
