using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustName.AppName.BL
{
	public abstract partial class EntityObject : BaseEntityObject
	{
		public EntityObject()
			: base()
		{
		}

		public EntityObject(Guid instanceId)
			: base(instanceId)
		{
		}
	}
}
