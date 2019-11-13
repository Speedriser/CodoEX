namespace CustName.AppName.WinPL.SearchControls
{
	partial class BaseDependentEntity1SearchPopupContainerContentControl
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
			this.dependentEntity1SearchControl = new CustName.AppName.WinPL.SearchControls.DependentEntity1SearchControl();
			this.dependentEntity1SearchLayoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
			this.layoutControl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.rootLayoutControlGroup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.findButtonLayoutControlItem)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.selectButtonLayoutControlItem)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.noSelectionButtonLayoutControlItem)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dependentEntity1SearchLayoutControlItem)).BeginInit();
			this.SuspendLayout();
			//
			// layoutControl
			//
			this.layoutControl.Controls.Add(this.dependentEntity1SearchControl);
			this.layoutControl.Controls.SetChildIndex(this.dependentEntity1SearchControl, 0);
			this.layoutControl.Controls.SetChildIndex(this.findSimpleButton, 0);
			this.layoutControl.Controls.SetChildIndex(this.noSelectionSimpleButton, 0);
			this.layoutControl.Controls.SetChildIndex(this.selectSimpleButton, 0);
			//
			// rootLayoutControlGroup
			//
			this.rootLayoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.dependentEntity1SearchLayoutControlItem});
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
			// dependentEntity1SearchControl
			//
			this.dependentEntity1SearchControl.Location = new System.Drawing.Point(2, 35);
			this.dependentEntity1SearchControl.Name = "dependentEntity1SearchControl";
			this.dependentEntity1SearchControl.Size = new System.Drawing.Size(397, 264);
			this.dependentEntity1SearchControl.TabIndex = 7;
			this.dependentEntity1SearchControl.TabStop = false;
			this.dependentEntity1SearchControl.EntityObjectSelection += new CustName.AppName.WinPL.EntityObjectSelectionEventHandler(this.dependentEntity1SearchControl_EntityObjectSelection);
			//
			// dependentEntity1SearchLayoutControlItem
			//
			this.dependentEntity1SearchLayoutControlItem.Control = this.dependentEntity1SearchControl;
			this.dependentEntity1SearchLayoutControlItem.Location = new System.Drawing.Point(0, 33);
			this.dependentEntity1SearchLayoutControlItem.Name = "dependentEntity1SearchLayoutControlItem";
			this.dependentEntity1SearchLayoutControlItem.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.dependentEntity1SearchLayoutControlItem.Size = new System.Drawing.Size(398, 265);
			this.dependentEntity1SearchLayoutControlItem.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.dependentEntity1SearchLayoutControlItem.Text = "DependentEntity1 Search";
			this.dependentEntity1SearchLayoutControlItem.TextSize = new System.Drawing.Size(0, 0);
			this.dependentEntity1SearchLayoutControlItem.TextToControlDistance = 0;
			this.dependentEntity1SearchLayoutControlItem.TextVisible = false;
			//
			// BaseDependentEntity1SearchPopupContainerContentControl
			//
			this.Name = "BaseDependentEntity1SearchPopupContainerContentControl";
			((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
			this.layoutControl.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.rootLayoutControlGroup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.findButtonLayoutControlItem)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.selectButtonLayoutControlItem)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.noSelectionButtonLayoutControlItem)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dependentEntity1SearchLayoutControlItem)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public CustName.AppName.WinPL.SearchControls.DependentEntity1SearchControl dependentEntity1SearchControl;
		public DevExpress.XtraLayout.LayoutControlItem dependentEntity1SearchLayoutControlItem;
	}
}
