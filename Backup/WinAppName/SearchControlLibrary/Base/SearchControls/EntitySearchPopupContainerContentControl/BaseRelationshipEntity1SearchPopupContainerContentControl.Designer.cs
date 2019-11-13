namespace CustName.AppName.WinPL.SearchControls
{
	partial class BaseRelationshipEntity1SearchPopupContainerContentControl
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
			this.relationshipEntity1SearchControl = new CustName.AppName.WinPL.SearchControls.RelationshipEntity1SearchControl();
			this.relationshipEntity1SearchLayoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
			this.layoutControl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.rootLayoutControlGroup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.findButtonLayoutControlItem)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.selectButtonLayoutControlItem)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.noSelectionButtonLayoutControlItem)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.relationshipEntity1SearchLayoutControlItem)).BeginInit();
			this.SuspendLayout();
			//
			// layoutControl
			//
			this.layoutControl.Controls.Add(this.relationshipEntity1SearchControl);
			this.layoutControl.Controls.SetChildIndex(this.relationshipEntity1SearchControl, 0);
			this.layoutControl.Controls.SetChildIndex(this.findSimpleButton, 0);
			this.layoutControl.Controls.SetChildIndex(this.noSelectionSimpleButton, 0);
			this.layoutControl.Controls.SetChildIndex(this.selectSimpleButton, 0);
			//
			// rootLayoutControlGroup
			//
			this.rootLayoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.relationshipEntity1SearchLayoutControlItem});
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
			// relationshipEntity1SearchControl
			//
			this.relationshipEntity1SearchControl.Location = new System.Drawing.Point(2, 35);
			this.relationshipEntity1SearchControl.Name = "relationshipEntity1SearchControl";
			this.relationshipEntity1SearchControl.Size = new System.Drawing.Size(397, 264);
			this.relationshipEntity1SearchControl.TabIndex = 7;
			this.relationshipEntity1SearchControl.TabStop = false;
			this.relationshipEntity1SearchControl.EntityObjectSelection += new CustName.AppName.WinPL.EntityObjectSelectionEventHandler(this.relationshipEntity1SearchControl_EntityObjectSelection);
			//
			// relationshipEntity1SearchLayoutControlItem
			//
			this.relationshipEntity1SearchLayoutControlItem.Control = this.relationshipEntity1SearchControl;
			this.relationshipEntity1SearchLayoutControlItem.Location = new System.Drawing.Point(0, 33);
			this.relationshipEntity1SearchLayoutControlItem.Name = "relationshipEntity1SearchLayoutControlItem";
			this.relationshipEntity1SearchLayoutControlItem.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.relationshipEntity1SearchLayoutControlItem.Size = new System.Drawing.Size(398, 265);
			this.relationshipEntity1SearchLayoutControlItem.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.relationshipEntity1SearchLayoutControlItem.Text = "RelationshipEntity1 Search";
			this.relationshipEntity1SearchLayoutControlItem.TextSize = new System.Drawing.Size(0, 0);
			this.relationshipEntity1SearchLayoutControlItem.TextToControlDistance = 0;
			this.relationshipEntity1SearchLayoutControlItem.TextVisible = false;
			//
			// BaseRelationshipEntity1SearchPopupContainerContentControl
			//
			this.Name = "BaseRelationshipEntity1SearchPopupContainerContentControl";
			((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
			this.layoutControl.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.rootLayoutControlGroup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.findButtonLayoutControlItem)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.selectButtonLayoutControlItem)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.noSelectionButtonLayoutControlItem)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.relationshipEntity1SearchLayoutControlItem)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public CustName.AppName.WinPL.SearchControls.RelationshipEntity1SearchControl relationshipEntity1SearchControl;
		public DevExpress.XtraLayout.LayoutControlItem relationshipEntity1SearchLayoutControlItem;
	}
}
