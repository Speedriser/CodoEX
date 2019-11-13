using System;
using System.Windows.Forms;

namespace CustName.AppName.WinPL
{
	public partial class ClassFactory
	{
		public virtual Form GetAboutBoxForm()
		{
			throw new NotImplementedException();
		}

		public virtual Form GetAppExceptionForm(string message, Exception exception)
		{
			throw new NotImplementedException();
		}

		public virtual Form GetSearchForm(CustName.AppName.DAL.EntityClass entityClass)
		{
			throw new NotImplementedException();
		}

		public virtual Form GetMainForm(CustName.AppName.DAL.EntityClass entityClass)
		{
			throw new NotImplementedException();
		}
	}
}
