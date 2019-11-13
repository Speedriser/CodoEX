using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustName.AppName.DAL
{
	public class CollisionException : DALException
	{
		public CollisionException(string message)
			: base(message) { }
	}
}
