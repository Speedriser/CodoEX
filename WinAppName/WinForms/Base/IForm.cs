using System;
using System.Collections.Generic;
using System.Text;

namespace CustName.AppName.WinPL
{
	public interface IForm
	{
		event CustName.AppName.WinPL.OpenEntityObjectEventHandler OpenEntityObject;
		void AddNew();
		CustName.AppName.DAL.IEntityList EntityList
		{
			get;
			set;
		}
		bool Save();
		void NotifyRepositoryChanged();
		void Clear();
		bool HasUncommittedChanges();
		void EndEdit();
		void PrintPreview();
		void Print();
	}
}
