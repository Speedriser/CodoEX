using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustName.AppName.DAL
{
	public partial class SqlServerRepository : BaseSqlServerRepository
	{
		public SqlServerRepository(IClassFactory classFactory)
			: base(classFactory)
		{
		}
	}
}
