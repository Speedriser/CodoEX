namespace CustName.AppName.WinPL.SearchControls
{
	partial class BaseEntitySearchPopupContainerContentControl
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

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
			this.selectSimpleButton = new DevExpress.XtraEditors.SimpleButton();
			this.noSelectionSimpleButton = new DevExpress.XtraEditors.SimpleButton();
			this.findSimpleButton = new DevExpress.XtraEditors.SimpleButton();
			this.rootLayoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
			this.findButtonLayoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
			this.selectButtonLayoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
			this.noSelectionButtonLayoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
			this.layoutControl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.rootLayoutControlGroup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.findButtonLayoutControlItem)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.selectButtonLayoutControlItem)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.noSelectionButtonLayoutControlItem)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			this.SuspendLayout();
			//
			// layoutControl
			//
			this.layoutControl.Appearance.DisabledLayoutGroupCaption.ForeColor = System.Drawing.SystemColors.GrayText;
			this.layoutControl.Appearance.DisabledLayoutGroupCaption.Options.UseForeColor = true;
			this.layoutControl.Appearance.DisabledLayoutItem.ForeColor = System.Drawing.SystemColors.GrayText;
			this.layoutControl.Appearance.DisabledLayoutItem.Options.UseForeColor = true;
			this.layoutControl.Controls.Add(this.selectSimpleButton);
			this.layoutControl.Controls.Add(this.noSelectionSimpleButton);
			this.layoutControl.Controls.Add(this.findSimpleButton);
			this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutControl.Location = new System.Drawing.Point(0, 0);
			this.layoutControl.Name = "layoutControl";
			this.layoutControl.Root = this.rootLayoutControlGroup;
			this.layoutControl.Size = new System.Drawing.Size(400, 300);
			this.layoutControl.TabIndex = 0;
			this.layoutControl.Text = "layoutControl1";
			//
			// selectSimpleButton
			//
			this.selectSimpleButton.Location = new System.Drawing.Point(98, 7);
			this.selectSimpleButton.Name = "selectSimpleButton";
			this.selectSimpleButton.Size = new System.Drawing.Size(80, 22);
			this.selectSimpleButton.StyleController = this.layoutControl;
			this.selectSimpleButton.TabIndex = 5;
			this.selectSimpleButton.Text = "Select";
			this.selectSimpleButton.Click += new System.EventHandler(this.selectSimpleButton_Click);
			//
			// noSelectionSimpleButton
			//
			this.noSelectionSimpleButton.Location = new System.Drawing.Point(189, 7);
			this.noSelectionSimpleButton.Name = "noSelectionSimpleButton";
			this.noSelectionSimpleButton.Size = new System.Drawing.Size(80, 22);
			this.noSelectionSimpleButton.StyleController = this.layoutControl;
			this.noSelectionSimpleButton.TabIndex = 6;
			this.noSelectionSimpleButton.Text = "Clear";
			this.noSelectionSimpleButton.Click += new System.EventHandler(this.noSelectionSimpleButton_Click);
			//
			// findSimpleButton
			//
			this.findSimpleButton.Location = new System.Drawing.Point(7, 7);
			this.findSimpleButton.Name = "findSimpleButton";
			this.findSimpleButton.Size = new System.Drawing.Size(80, 22);
			this.findSimpleButton.StyleController = this.layoutControl;
			this.findSimpleButton.TabIndex = 4;
			this.findSimpleButton.Text = "Find";
			this.findSimpleButton.Click += new System.EventHandler(this.findSimpleButton_Click);
			//
			// rootLayoutControlGroup
			//
			this.rootLayoutControlGroup.CustomizationFormText = "rootLayoutControlGroup";
			this.rootLayoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.findButtonLayoutControlItem,
            this.selectButtonLayoutControlItem,
            this.noSelectionButtonLayoutControlItem,
            this.emptySpaceItem1});
			this.rootLayoutControlGroup.Location = new System.Drawing.Point(0, 0);
			this.rootLayoutControlGroup.Name = "rootLayoutControlGroup";
			this.rootLayoutControlGroup.Size = new System.Drawing.Size(400, 300);
			this.rootLayoutControlGroup.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.rootLayoutControlGroup.Text = "rootLayoutControlGroup";
			this.rootLayoutControlGroup.TextVisible = false;
			//
			// findButtonLayoutControlItem
			//
			this.findButtonLayoutControlItem.Control = this.findSimpleButton;
			this.findButtonLayoutControlItem.CustomizationFormText = "Find Button";
			this.findButtonLayoutControlItem.Location = new System.Drawing.Point(0, 0);
			this.findButtonLayoutControlItem.MaxSize = new System.Drawing.Size(91, 33);
			this.findButtonLayoutControlItem.MinSize = new System.Drawing.Size(91, 33);
			this.findButtonLayoutControlItem.Name = "findButtonLayoutControlItem";
			this.findButtonLayoutControlItem.Size = new System.Drawing.Size(91, 298);
			this.findButtonLayoutControlItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.findButtonLayoutControlItem.Text = "Find Button";
			this.findButtonLayoutControlItem.TextLocation = DevExpress.Utils.Locations.Left;
			this.findButtonLayoutControlItem.TextSize = new System.Drawing.Size(0, 0);
			this.findButtonLayoutControlItem.TextToControlDistance = 0;
			this.findButtonLayoutControlItem.TextVisible = false;
			//
			// selectButtonLayoutControlItem
			//
			this.selectButtonLayoutControlItem.Control = this.selectSimpleButton;
			this.selectButtonLayoutControlItem.CustomizationFormText = "Select Button";
			this.selectButtonLayoutControlItem.Location = new System.Drawing.Point(91, 0);
			this.selectButtonLayoutControlItem.MaxSize = new System.Drawing.Size(91, 33);
			this.selectButtonLayoutControlItem.MinSize = new System.Drawing.Size(91, 33);
			this.selectButtonLayoutControlItem.Name = "selectButtonLayoutControlItem";
			this.selectButtonLayoutControlItem.Size = new System.Drawing.Size(91, 298);
			this.selectButtonLayoutControlItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.selectButtonLayoutControlItem.Text = "Select Button";
			this.selectButtonLayoutControlItem.TextLocation = DevExpress.Utils.Locations.Left;
			this.selectButtonLayoutControlItem.TextSize = new System.Drawing.Size(0, 0);
			this.selectButtonLayoutControlItem.TextToControlDistance = 0;
			this.selectButtonLayoutControlItem.TextVisible = false;
			//
			// noSelectionButtonLayoutControlItem
			//
			this.noSelectionButtonLayoutControlItem.Control = this.noSelectionSimpleButton;
			this.noSelectionButtonLayoutControlItem.CustomizationFormText = "No Selection Button";
			this.noSelectionButtonLayoutControlItem.Location = new System.Drawing.Point(182, 0);
			this.noSelectionButtonLayoutControlItem.MaxSize = new System.Drawing.Size(91, 33);
			this.noSelectionButtonLayoutControlItem.MinSize = new System.Drawing.Size(91, 33);
			this.noSelectionButtonLayoutControlItem.Name = "noSelectionButtonLayoutControlItem";
			this.noSelectionButtonLayoutControlItem.Size = new System.Drawing.Size(91, 298);
			this.noSelectionButtonLayoutControlItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.noSelectionButtonLayoutControlItem.Text = "No Selection Button";
			this.noSelectionButtonLayoutControlItem.TextLocation = DevExpress.Utils.Locations.Left;
			this.noSelectionButtonLayoutControlItem.TextSize = new System.Drawing.Size(0, 0);
			this.noSelectionButtonLayoutControlItem.TextToControlDistance = 0;
			this.noSelectionButtonLayoutControlItem.TextVisible = false;
			//
			// emptySpaceItem1
			//
			this.emptySpaceItem1.CustomizationFormText = "Empty Space 1";
			this.emptySpaceItem1.Location = new System.Drawing.Point(273, 0);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(125, 298);
			this.emptySpaceItem1.Text = "Empty Space 1";
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			//
			// BaseEntitySearchPopupContainerContentControl
			//
			this.Controls.Add(this.layoutControl);
			this.Name = "BaseEntitySearchPopupContainerContentControl";
			this.Size = new System.Drawing.Size(400, 300);
			((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
			this.layoutControl.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.rootLayoutControlGroup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.findButtonLayoutControlItem)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.selectButtonLayoutControlItem)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.noSelectionButtonLayoutControlItem)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public DevExpress.XtraLayout.LayoutControl layoutControl;
		public DevExpress.XtraEditors.SimpleButton noSelectionSimpleButton;
		public DevExpress.XtraEditors.SimpleButton findSimpleButton;
		public DevExpress.XtraEditors.SimpleButton selectSimpleButton;
		public DevExpress.XtraLayout.LayoutControlGroup rootLayoutControlGroup;
		public DevExpress.XtraLayout.LayoutControlItem findButtonLayoutControlItem;
		public DevExpress.XtraLayout.LayoutControlItem selectButtonLayoutControlItem;
		public DevExpress.XtraLayout.LayoutControlItem noSelectionButtonLayoutControlItem;
		public DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
	}
}
