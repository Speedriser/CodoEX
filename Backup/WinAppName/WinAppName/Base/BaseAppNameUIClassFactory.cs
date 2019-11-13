using System;
using System.Windows.Forms;
using CustName.AppName.DAL;
using CustName.AppName.WinPL.SearchForms;
using CustName.AppName.WinPL.MainForms;

namespace CustName.AppName.WinPL
{
	public class BaseAppNameUIClassFactory : CustName.AppName.WinPL.ClassFactory
	{
		public override Form GetAboutBoxForm()
		{
			return (Form)(new CustName.AppName.WinPL.AboutBoxForm());
		}

		public override Form GetAppExceptionForm(string message, Exception exception)
		{
			return (Form)(new CustName.AppName.WinPL.AppExceptionForm(message, exception));
		}

		public override Form GetSearchForm(EntityClass entityClass)
		{
			EntitySearchForm entitySearchForm = CreateSearchForm(entityClass);
			if (entitySearchForm != null)
				entitySearchForm.CompleteInitialization();
			return entitySearchForm;
		}

		protected virtual EntitySearchForm CreateSearchForm(EntityClass entityClass)
		{
			switch (entityClass)
			{
				case EntityClass.IndependentEntity1:
					return (EntitySearchForm)(new IndependentEntity1SearchForm());
				case EntityClass.IndependentEntity2:
					return (EntitySearchForm)(new IndependentEntity2SearchForm());
			}
			return null;
		}

		public override Form GetMainForm(EntityClass entityClass)
		{
			EntityMainForm entityMainForm = CreateMainForm(entityClass);
			if (entityMainForm != null)
				entityMainForm.CompleteInitialization();
			return entityMainForm;
		}

		protected virtual EntityMainForm CreateMainForm(EntityClass entityClass)
		{
			switch (entityClass)
			{
				case EntityClass.IndependentEntity1:
					return (EntityMainForm)(new IndependentEntity1MainForm());
				case EntityClass.IndependentEntity2:
					return (EntityMainForm)(new IndependentEntity2MainForm());
			}
			return null;
		}
	}
}
