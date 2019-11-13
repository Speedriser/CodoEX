namespace CustName.AppName.WinPL.SearchControls
{
	partial class BaseDependentEntity2SearchPopupContainerContentControl
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
			this.dependentEntity2SearchControl = new CustName.AppName.WinPL.SearchControls.DependentEntity2SearchControl();
			this.dependentEntity2SearchLayoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
			this.layoutControl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.rootLayoutControlGroup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.findButtonLayoutControlItem)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.selectButtonLayoutControlItem)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.noSelectionButtonLayoutControlItem)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dependentEntity2SearchLayoutControlItem)).BeginInit();
			this.SuspendLayout();
			//
			// layoutControl
			//
			this.layoutControl.Controls.Add(this.dependentEntity2SearchControl);
			this.layoutControl.Controls.SetChildIndex(this.dependentEntity2SearchControl, 0);
			this.layoutControl.Controls.SetChildIndex(this.findSimpleButton, 0);
			this.layoutControl.Controls.SetChildIndex(this.noSelectionSimpleButton, 0);
			this.layoutControl.Controls.SetChildIndex(this.selectSimpleButton, 0);
			//
			// rootLayoutControlGroup
			//
			this.rootLayoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.dependentEntity2SearchLayoutControlItem});
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
			// dependentEntity2SearchControl
			//
			this.dependentEntity2SearchControl.Location = new System.Drawing.Point(2, 35);
			this.dependentEntity2SearchControl.Name = "dependentEntity2SearchControl";
			this.dependentEntity2SearchControl.Size = new System.Drawing.Size(397, 264);
			this.dependentEntity2SearchControl.TabIndex = 7;
			this.dependentEntity2SearchControl.TabStop = false;
			this.dependentEntity2SearchControl.EntityObjectSelection += new CustName.AppName.WinPL.EntityObjectSelectionEventHandler(this.dependentEntity2SearchControl_EntityObjectSelection);
			//
			// dependentEntity2SearchLayoutControlItem
			//
			this.dependentEntity2SearchLayoutControlItem.Control = this.dependentEntity2SearchControl;
			this.dependentEntity2SearchLayoutControlItem.Location = new System.Drawing.Point(0, 33);
			this.dependentEntity2SearchLayoutControlItem.Name = "dependentEntity2SearchLayoutControlItem";
			this.dependentEntity2SearchLayoutControlItem.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.dependentEntity2SearchLayoutControlItem.Size = new System.Drawing.Size(398, 265);
			this.dependentEntity2SearchLayoutControlItem.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.dependentEntity2SearchLayoutControlItem.Text = "DependentEntity2 Search";
			this.dependentEntity2SearchLayoutControlItem.TextSize = new System.Drawing.Size(0, 0);
			this.dependentEntity2SearchLayoutControlItem.TextToControlDistance = 0;
			this.dependentEntity2SearchLayoutControlItem.TextVisible = false;
			//
			// BaseDependentEntity2SearchPopupContainerContentControl
			//
			this.Name = "BaseDependentEntity2SearchPopupContainerContentControl";
			((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
			this.layoutControl.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.rootLayoutControlGroup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.findButtonLayoutControlItem)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.selectButtonLayoutControlItem)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.noSelectionButtonLayoutControlItem)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dependentEntity2SearchLayoutControlItem)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public CustName.AppName.WinPL.SearchControls.DependentEntity2SearchControl dependentEntity2SearchControl;
		public DevExpress.XtraLayout.LayoutControlItem dependentEntity2SearchLayoutControlItem;
	}
}
