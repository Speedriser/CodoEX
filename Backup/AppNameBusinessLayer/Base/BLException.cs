using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustName.AppName.BL
{
	public class BLException : ApplicationException
	{
		// Implement the standard constructors.
		public BLException() : base() { }
		public BLException(string message) : base(message) { }
		public BLException(string message, Exception innerException) : base(message, innerException) { }
	}
}
