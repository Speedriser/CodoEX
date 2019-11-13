
namespace CustName.AppName.WinPL.MainForms
{
	public class BaseEntityPanelControlBinding
	{
		protected EntityPanelControl panelControl;
		protected EntityPanelControl dataSourcePanelControl;
		protected string dataMember;

		public EntityPanelControl PanelControl
		{
			get { return panelControl; }
			set { panelControl = value; }
		}

		public EntityPanelControl DataSourcePanelControl
		{
			get { return dataSourcePanelControl; }
			set { dataSourcePanelControl = value; }
		}

		public string DataMember
		{
			get { return dataMember; }
			set { dataMember = value; }
		}

	}
}
