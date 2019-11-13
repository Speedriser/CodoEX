using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustName.AppName.BL
{
	public class BaseAppException
	{
		private int index;
		private Exception exception;

		public BaseAppException(int index, Exception exception)
		{
			this.index = index;
			this.exception = exception;
		}

		public int Index
		{
			get
			{
				return this.index;
			}
		}

		public string HelpLink
		{
			get
			{
				return exception.HelpLink;
			}
		}

		public string Message
		{
			get
			{
				return exception.Message;
			}
		}


		public string Source
		{
			get
			{
				return exception.Source;
			}
		}

		public string StackTrace
		{
			get
			{
				return exception.StackTrace;
			}
		}
	}
}
