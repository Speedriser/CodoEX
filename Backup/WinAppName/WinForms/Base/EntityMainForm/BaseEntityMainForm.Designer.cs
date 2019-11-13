namespace CustName.AppName.WinPL.MainForms
{
	partial class BaseEntityMainForm
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
			this.baseSplitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
			this.objectListLayoutControl = new DevExpress.XtraLayout.LayoutControl();
			this.objectListListBox = new System.Windows.Forms.ListBox();
			this.objectListRootLayoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
			this.objectListLayoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.baseSplitContainerControl)).BeginInit();
			this.baseSplitContainerControl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.objectListLayoutControl)).BeginInit();
			this.objectListLayoutControl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.objectListRootLayoutControlGroup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.objectListLayoutControlItem)).BeginInit();
			this.SuspendLayout();
			//
			// baseSplitContainerControl
			//
			this.baseSplitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.baseSplitContainerControl.Location = new System.Drawing.Point(0, 0);
			this.baseSplitContainerControl.Name = "baseSplitContainerControl";
			this.baseSplitContainerControl.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.baseSplitContainerControl.Panel1.Controls.Add(this.objectListLayoutControl);
			this.baseSplitContainerControl.Panel1.Text = "Panel1";
			this.baseSplitContainerControl.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.baseSplitContainerControl.Panel2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.baseSplitContainerControl.Panel2.Text = "Panel2";
			this.baseSplitContainerControl.Size = new System.Drawing.Size(792, 566);
			this.baseSplitContainerControl.SplitterPosition = 175;
			this.baseSplitContainerControl.TabIndex = 0;
			this.baseSplitContainerControl.Text = "baseSplitContainerControl";
			//
			// objectListLayoutControl
			//
			this.objectListLayoutControl.Appearance.DisabledLayoutGroupCaption.ForeColor = System.Drawing.SystemColors.GrayText;
			this.objectListLayoutControl.Appearance.DisabledLayoutGroupCaption.Options.UseForeColor = true;
			this.objectListLayoutControl.Appearance.DisabledLayoutItem.ForeColor = System.Drawing.SystemColors.GrayText;
			this.objectListLayoutControl.Appearance.DisabledLayoutItem.Options.UseForeColor = true;
			this.objectListLayoutControl.Controls.Add(this.objectListListBox);
			this.objectListLayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.objectListLayoutControl.Location = new System.Drawing.Point(0, 0);
			this.objectListLayoutControl.Name = "objectListLayoutControl";
			this.objectListLayoutControl.Root = this.objectListRootLayoutControlGroup;
			this.objectListLayoutControl.Size = new System.Drawing.Size(175, 566);
			this.objectListLayoutControl.TabIndex = 0;
			this.objectListLayoutControl.Text = "objectListLayoutControl";
			//
			// objectListListBox
			//

			//
			// objectListListBox
			//
			this.objectListListBox.DisplayMember = "ObjectPrimaryDescriptor";
			this.objectListListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.objectListListBox_DrawItem);
			this.objectListListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.objectListListBox.FormattingEnabled = true;
			this.objectListListBox.IntegralHeight = false;
			this.objectListListBox.Location = new System.Drawing.Point(6, 24);
			this.objectListListBox.Name = "objectListListBox";
			this.objectListListBox.Size = new System.Drawing.Size(164, 537);
			this.objectListListBox.TabIndex = 4;
			//
			// objectListRootLayoutControlGroup
			//
			this.objectListRootLayoutControlGroup.CustomizationFormText = "objectListRootLayoutControlGroup";
			this.objectListRootLayoutControlGroup.GroupBordersVisible = false;
			this.objectListRootLayoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.objectListLayoutControlItem});
			this.objectListRootLayoutControlGroup.Location = new System.Drawing.Point(0, 0);
			this.objectListRootLayoutControlGroup.Name = "objectListRootLayoutControlGroup";
			this.objectListRootLayoutControlGroup.Size = new System.Drawing.Size(175, 566);
			this.objectListRootLayoutControlGroup.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.objectListRootLayoutControlGroup.Text = "objectListRootLayoutControlGroup";
			this.objectListRootLayoutControlGroup.TextVisible = false;
			//
			// objectListLayoutControlItem
			//
			this.objectListLayoutControlItem.Control = this.objectListListBox;
			this.objectListLayoutControlItem.CustomizationFormText = "Item List";
			this.objectListLayoutControlItem.Location = new System.Drawing.Point(0, 0);
			this.objectListLayoutControlItem.Name = "objectListLayoutControlItem";
			this.objectListLayoutControlItem.Size = new System.Drawing.Size(175, 566);
			this.objectListLayoutControlItem.Text = "Item List";
			this.objectListLayoutControlItem.TextLocation = DevExpress.Utils.Locations.Top;
			this.objectListLayoutControlItem.TextSize = new System.Drawing.Size(41, 13);
			//
			// BaseEntityMainForm
			//
			this.ClientSize = new System.Drawing.Size(792, 566);
			this.Controls.Add(this.baseSplitContainerControl);
			this.Name = "BaseEntityMainForm";
			this.Text = "BaseEntityMainForm";
			this.Activated += new System.EventHandler(this.EntityMainForm_Activated);
			((System.ComponentModel.ISupportInitialize)(this.baseSplitContainerControl)).EndInit();
			this.baseSplitContainerControl.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.objectListLayoutControl)).EndInit();
			this.objectListLayoutControl.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.objectListRootLayoutControlGroup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.objectListLayoutControlItem)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public DevExpress.XtraEditors.SplitContainerControl baseSplitContainerControl;
		public DevExpress.XtraLayout.LayoutControl objectListLayoutControl;
		public System.Windows.Forms.ListBox objectListListBox;
		public DevExpress.XtraLayout.LayoutControlGroup objectListRootLayoutControlGroup;
		public DevExpress.XtraLayout.LayoutControlItem objectListLayoutControlItem;
	}
}
