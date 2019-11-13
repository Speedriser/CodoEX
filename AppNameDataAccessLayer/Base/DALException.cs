using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustName.AppName.DAL
{
	public class DALException : ApplicationException
	{
		// Implement the standard constructors.
		public DALException() : base() { }
		public DALException(string message) : base(message) { }
		public DALException(RepositoryExceptionMessageConstant message) : base(message.Value) { }
		public DALException(string message, Exception innerException) : base(message, innerException) { }
		public DALException(RepositoryExceptionMessageConstant message, Exception innerException) : base(message.Value, innerException) { }
	}
}
