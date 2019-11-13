
namespace CustName.AppName.WinPL.MainForms
{
	public class BaseEntityMainFormTabPageTag
	{
		protected bool previouslyActivated;

		public virtual bool PreviouslyActivated
		{
			get
			{
				return this.previouslyActivated;
			}
			set
			{
				this.previouslyActivated = value;
			}
		}
	}
}
