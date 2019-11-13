using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CustName.AppName.DAL
{
	public abstract class BaseQueryConstant
	{
		private DbType dbType;
		private object value;

		public BaseQueryConstant(DbType dbType, object value)
		{
			this.dbType = dbType;
			this.value = value;
		}

		public BaseQueryConstant()
			: this(DbType.Object, null)
		{
		}

		public object Value
		{
			get
			{
				return this.value;
			}
			set
			{
				this.value = value;
			}
		}

		public DbType DbType
		{
			get
			{
				return this.dbType;
			}
			set
			{
				this.dbType = value;
			}
		}
	}
}
