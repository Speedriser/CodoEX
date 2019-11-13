
namespace CustName.AppName.WinPL
{
	public class BaseMainFormNavigationTreeNodeTag
	{
		private char formType;
		private CustName.AppName.DAL.EntityClass entityClass;

		public char FormType
		{
			get { return formType; }
			set { formType = value; }
		}

		public CustName.AppName.DAL.EntityClass EntityClass
		{
			get { return entityClass; }
			set { entityClass = value; }
		}
	}
}
