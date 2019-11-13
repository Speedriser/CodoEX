using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CustName.AppName.WinPL.SearchControls
{
	[ToolboxItemAttribute(false)]
	public partial class BaseAttachment1SearchPopupContainerContentControl : CustName.AppName.WinPL.SearchControls.EntitySearchPopupContainerContentControl
	{
		public BaseAttachment1SearchPopupContainerContentControl()
		{
			InitializeComponent();
			// Execute extended form initialization.
			BaseInitializeComponent();
			// Execute extended custom form initialization.
			CustomInitializeComponent();
		}

		private void BaseInitializeComponent()
		{
			this.attachment1SearchControl.Mode = SearchControlMode.Lookup;
			this.attachment1SearchControl.RefreshDomainLists();
		}

		protected virtual void CustomInitializeComponent()
		{
		}

		public override CustName.AppName.DAL.EntityClass EntityClass
		{
			get
			{
				return CustName.AppName.DAL.EntityClass.Attachment1;
			}
		}

		public override void RefreshDomainLists()
		{
			this.attachment1SearchControl.RefreshDomainLists();
		}

		protected override void findSimpleButton_Click(object sender, EventArgs e)
		{
			this.attachment1SearchControl.Find();
		}

		protected override void selectSimpleButton_Click(object sender, EventArgs e)
		{
			this.attachment1SearchControl.Open();
		}

		protected virtual void attachment1SearchControl_EntityObjectSelection(object sender, CustName.AppName.WinPL.EntityObjectSelectionEventArgs e)
		{
			OnEntityObjectSelection(e);
		}
	}
}
