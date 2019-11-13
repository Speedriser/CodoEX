using System;
using System.Collections.Generic;
using System.Text;

namespace CustName.AppName.WinPL.MainForms
{
	// Class contains data for the ToolBarButtonClickEvent event.
	public class BaseToolBarButtonClickEventArgs
	{
		private int button;
		private string oldState = null;
		private string newState = null;

		public BaseToolBarButtonClickEventArgs(int button)
		{
			this.button = button;
		}

		public virtual int Button
		{
			get
			{
				return this.button;
			}
		}

		public virtual string OldState
		{
			get
			{
				return this.oldState;
			}
			set
			{
				this.oldState = value;
			}
		}

		public virtual string NewState
		{
			get
			{
				return this.newState;
			}
			set
			{
				this.newState = value;
			}
		}
	}
}
