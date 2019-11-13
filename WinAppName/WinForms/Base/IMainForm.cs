using System;
using System.Collections.Generic;
using System.Text;
using CustName.AppName.DAL;

namespace CustName.AppName.WinPL
{
	public interface IMainForm
	{
		void OpenSearchForm(EntityClass entityClass);
		void OpenMainForm(EntityClass entityClass, CustName.AppName.DAL.IEntityList entityList);
	}
}
