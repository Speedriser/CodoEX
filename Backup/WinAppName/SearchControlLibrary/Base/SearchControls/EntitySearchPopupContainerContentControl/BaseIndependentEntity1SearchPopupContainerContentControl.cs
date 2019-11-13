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
	public partial class BaseIndependentEntity1SearchPopupContainerContentControl : CustName.AppName.WinPL.SearchControls.EntitySearchPopupContainerContentControl
	{
		public BaseIndependentEntity1SearchPopupContainerContentControl()
		{
			InitializeComponent();
			// Execute extended form initialization.
			BaseInitializeComponent();
			// Execute extended custom form initialization.
			CustomInitializeComponent();
		}

		private void BaseInitializeComponent()
		{
			this.independentEntity1SearchControl.Mode = SearchControlMode.Lookup;
			this.independentEntity1SearchControl.RefreshDomainLists();
		}

		protected virtual void CustomInitializeComponent()
		{
		}

		public override CustName.AppName.DAL.EntityClass EntityClass
		{
			get
			{
				return CustName.AppName.DAL.EntityClass.IndependentEntity1;
			}
		}

		public override void RefreshDomainLists()
		{
			this.independentEntity1SearchControl.RefreshDomainLists();
		}

		protected override void findSimpleButton_Click(object sender, EventArgs e)
		{
			this.independentEntity1SearchControl.Find();
		}

		protected override void selectSimpleButton_Click(object sender, EventArgs e)
		{
			this.independentEntity1SearchControl.Open();
		}

		protected virtual void independentEntity1SearchControl_EntityObjectSelection(object sender, CustName.AppName.WinPL.EntityObjectSelectionEventArgs e)
		{
			OnEntityObjectSelection(e);
		}
	}
}
