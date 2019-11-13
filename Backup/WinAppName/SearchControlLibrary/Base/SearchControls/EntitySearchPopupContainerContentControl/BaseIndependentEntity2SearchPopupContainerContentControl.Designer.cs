namespace CustName.AppName.WinPL.SearchControls
{
	partial class BaseIndependentEntity2SearchPopupContainerContentControl
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.independentEntity2SearchControl = new CustName.AppName.WinPL.SearchControls.IndependentEntity2SearchControl();
			this.independentEntity2SearchLayoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
			this.layoutControl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.rootLayoutControlGroup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.findButtonLayoutControlItem)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.selectButtonLayoutControlItem)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.noSelectionButtonLayoutControlItem)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.independentEntity2SearchLayoutControlItem)).BeginInit();
			this.SuspendLayout();
			//
			// layoutControl
			//
			this.layoutControl.Controls.Add(this.independentEntity2SearchControl);
			this.layoutControl.Controls.SetChildIndex(this.independentEntity2SearchControl, 0);
			this.layoutControl.Controls.SetChildIndex(this.findSimpleButton, 0);
			this.layoutControl.Controls.SetChildIndex(this.noSelectionSimpleButton, 0);
			this.layoutControl.Controls.SetChildIndex(this.selectSimpleButton, 0);
			//
			// rootLayoutControlGroup
			//
			this.rootLayoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.independentEntity2SearchLayoutControlItem});
			//
			// findButtonLayoutControlItem
			//
			this.findButtonLayoutControlItem.Size = new System.Drawing.Size(91, 33);
			//
			// selectButtonLayoutControlItem
			//
			this.selectButtonLayoutControlItem.Size = new System.Drawing.Size(91, 33);
			//
			// noSelectionButtonLayoutControlItem
			//
			this.noSelectionButtonLayoutControlItem.Size = new System.Drawing.Size(91, 33);
			//
			// emptySpaceItem1
			//
			this.emptySpaceItem1.Size = new System.Drawing.Size(125, 33);
			//
			// independentEntity2SearchControl
			//
			this.independentEntity2SearchControl.Location = new System.Drawing.Point(2, 35);
			this.independentEntity2SearchControl.Name = "independentEntity2SearchControl";
			this.independentEntity2SearchControl.Size = new System.Drawing.Size(397, 264);
			this.independentEntity2SearchControl.TabIndex = 7;
			this.independentEntity2SearchControl.TabStop = false;
			this.independentEntity2SearchControl.EntityObjectSelection += new CustName.AppName.WinPL.EntityObjectSelectionEventHandler(this.independentEntity2SearchControl_EntityObjectSelection);
			//
			// independentEntity2SearchLayoutControlItem
			//
			this.independentEntity2SearchLayoutControlItem.Control = this.independentEntity2SearchControl;
			this.independentEntity2SearchLayoutControlItem.Location = new System.Drawing.Point(0, 33);
			this.independentEntity2SearchLayoutControlItem.Name = "independentEntity2SearchLayoutControlItem";
			this.independentEntity2SearchLayoutControlItem.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.independentEntity2SearchLayoutControlItem.Size = new System.Drawing.Size(398, 265);
			this.independentEntity2SearchLayoutControlItem.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.independentEntity2SearchLayoutControlItem.Text = "IndependentEntity2 Search";
			this.independentEntity2SearchLayoutControlItem.TextSize = new System.Drawing.Size(0, 0);
			this.independentEntity2SearchLayoutControlItem.TextToControlDistance = 0;
			this.independentEntity2SearchLayoutControlItem.TextVisible = false;
			//
			// BaseIndependentEntity2SearchPopupContainerContentControl
			//
			this.Name = "BaseIndependentEntity2SearchPopupContainerContentControl";
			((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
			this.layoutControl.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.rootLayoutControlGroup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.findButtonLayoutControlItem)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.selectButtonLayoutControlItem)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.noSelectionButtonLayoutControlItem)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.independentEntity2SearchLayoutControlItem)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public CustName.AppName.WinPL.SearchControls.IndependentEntity2SearchControl independentEntity2SearchControl;
		public DevExpress.XtraLayout.LayoutControlItem independentEntity2SearchLayoutControlItem;
	}
}
