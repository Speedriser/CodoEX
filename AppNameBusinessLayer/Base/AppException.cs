using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustName.AppName.BL
{
	public partial class AppException : BaseAppException
	{
		public AppException(int index, Exception exception) : base(index, exception) { }
	}
}
