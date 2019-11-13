using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CustName.AppName.DAL
{
	public partial class QueryConstant : BaseQueryConstant
	{
		public QueryConstant(DbType dbType, object value)
			: base(dbType, value)
		{
		}

		public QueryConstant()
			: base()
		{
		}
	}
}
