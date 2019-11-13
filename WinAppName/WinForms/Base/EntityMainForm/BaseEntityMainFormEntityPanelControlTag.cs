
namespace CustName.AppName.WinPL.MainForms
{
	public class BaseEntityMainFormEntityPanelControlTag
	{
		protected EntityPanelControlBinding entityPanelControlBinding;

		public virtual EntityPanelControlBinding EntityPanelControlBinding
		{
			get
			{
				return this.entityPanelControlBinding;
			}
			set
			{
				this.entityPanelControlBinding = value;
			}
		}
	}
}
