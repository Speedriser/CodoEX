using System;
using System.Collections.Generic;
using System.Text;

using CustName.AppName.DAL;

namespace CustName.AppName.WinPL
{
	public class OpenEntityObjectEventArgs
	{
		private EntityClass entityClass;
		private IIdentifier objectId;

		public OpenEntityObjectEventArgs(EntityClass entityClass, IIdentifier objectId)
		{
			this.entityClass = entityClass;
			this.objectId = objectId;
		}

		public EntityClass EntityClass
		{
			get
			{
				return this.entityClass;
			}
		}

		public IIdentifier ObjectId
		{
			get
			{
				return this.objectId;
			}
		}
	}

	// Delegate declaration.
	public delegate void OpenEntityObjectEventHandler(object sender, OpenEntityObjectEventArgs e);
}
