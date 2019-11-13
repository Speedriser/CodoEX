using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustName.AppName.BL
{
	public class Global
	{
		private static ClassFactory classFactory;

		static Global()
		{
			if (CustName.AppName.BL.Settings.CreateClassFactory)
				classFactory = new CustName.AppName.BL.ClassFactory();
		}

		public static ClassFactory ClassFactory
		{
			get
			{
				return classFactory;
			}
			set
			{
				classFactory = value;
			}
		}

		public static AppExceptionList CreateAppExceptionList(Exception exception)
		{
			AppExceptionList appExceptionList = new AppExceptionList();
			int index = 0;
			Exception currentException = exception;
			while (currentException != null)
			{
				AppException appException = new AppException(++index, currentException);
				appExceptionList.Add(appException);
				currentException = currentException.InnerException;
			}
			return appExceptionList;
		}

	}
}
