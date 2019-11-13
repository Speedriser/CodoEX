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
	public partial class BaseIndependentEntity2SearchPopupContainerContentControl : CustName.AppName.WinPL.SearchControls.EntitySearchPopupContainerContentControl
	{
		public BaseIndependentEntity2SearchPopupContainerContentControl()
		{
			InitializeComponent();
			// Execute extended form initialization.
			BaseInitializeComponent();
			// Execute extended custom form initialization.
			CustomInitializeComponent();
		}

		private void BaseInitializeComponent()
		{
			this.independentEntity2SearchControl.Mode = SearchControlMode.Lookup;
			this.independentEntity2SearchControl.RefreshDomainLists();
		}

		protected virtual void CustomInitializeComponent()
		{
		}

		public override CustName.AppName.DAL.EntityClass EntityClass
		{
			get
			{
				return CustName.AppName.DAL.EntityClass.IndependentEntity2;
			}
		}

		public override void RefreshDomainLists()
		{
			this.independentEntity2SearchControl.RefreshDomainLists();
		}

		protected override void findSimpleButton_Click(object sender, EventArgs e)
		{
			this.independentEntity2SearchControl.Find();
		}

		protected override void selectSimpleButton_Click(object sender, EventArgs e)
		{
			this.independentEntity2SearchControl.Open();
		}

		protected virtual void independentEntity2SearchControl_EntityObjectSelection(object sender, CustName.AppName.WinPL.EntityObjectSelectionEventArgs e)
		{
			OnEntityObjectSelection(e);
		}
	}
}
