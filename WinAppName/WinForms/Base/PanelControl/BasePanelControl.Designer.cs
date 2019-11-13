namespace CustName.AppName.WinPL.MainForms
{
	partial class BasePanelControl
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasePanelControl));
			this.barManager = new DevExpress.XtraBars.BarManager(this.components);
			this.bar = new DevExpress.XtraBars.Bar();
			this.objectListPanelToggleBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
			this.panel2ToggleBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
			this.panel1ToggleBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			this.barManagerImageCollection16 = new DevExpress.Utils.ImageCollection(this.components);
			((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.barManagerImageCollection16)).BeginInit();
			this.SuspendLayout();
			//
			// barManager
			//
			this.barManager.AllowCustomization = false;
			this.barManager.AllowMoveBarOnToolbar = false;
			this.barManager.AllowQuickCustomization = false;
			this.barManager.AllowShowToolbarsPopup = false;
			this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar});
			this.barManager.DockControls.Add(this.barDockControlTop);
			this.barManager.DockControls.Add(this.barDockControlBottom);
			this.barManager.DockControls.Add(this.barDockControlLeft);
			this.barManager.DockControls.Add(this.barDockControlRight);
			this.barManager.Form = this;
			this.barManager.Images = this.barManagerImageCollection16;
			this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.objectListPanelToggleBarButtonItem,
            this.panel2ToggleBarButtonItem,
            this.panel1ToggleBarButtonItem});
			this.barManager.MainMenu = this.bar;
			this.barManager.MaxItemId = 3;
			//
			// bar
			//
			this.bar.BarName = "Panel Tool Bar";
			this.bar.DockCol = 0;
			this.bar.DockRow = 0;
			this.bar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
			this.bar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.objectListPanelToggleBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.panel2ToggleBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.panel1ToggleBarButtonItem)});
			this.bar.OptionsBar.AllowQuickCustomization = false;
			this.bar.OptionsBar.DisableClose = true;
			this.bar.OptionsBar.DisableCustomization = true;
			this.bar.OptionsBar.DrawDragBorder = false;
			this.bar.OptionsBar.MultiLine = true;
			this.bar.OptionsBar.UseWholeRow = true;
			this.bar.Text = "Panel Tool Bar";
			//
			// objectListPanelToggleBarButtonItem
			//
			this.objectListPanelToggleBarButtonItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
			this.objectListPanelToggleBarButtonItem.Caption = "Object List Panel Toggle";
			this.objectListPanelToggleBarButtonItem.Description = "Object List Panel Toggle";
			this.objectListPanelToggleBarButtonItem.Hint = "Hide Object List";
			this.objectListPanelToggleBarButtonItem.Id = 0;
			this.objectListPanelToggleBarButtonItem.ImageIndex = 6;
			this.objectListPanelToggleBarButtonItem.Name = "objectListPanelToggleBarButtonItem";
			this.objectListPanelToggleBarButtonItem.Tag = "HideObjectListPanel";
			this.objectListPanelToggleBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.objectListPanelToggleBarButtonItem_ItemClick);
			//
			// panel2ToggleBarButtonItem
			//
			this.panel2ToggleBarButtonItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
			this.panel2ToggleBarButtonItem.Caption = "Panel 2 Toggle";
			this.panel2ToggleBarButtonItem.Description = "Panel 2 Toggle";
			this.panel2ToggleBarButtonItem.Hint = "Maximize Section";
			this.panel2ToggleBarButtonItem.Id = 1;
			this.panel2ToggleBarButtonItem.ImageIndex = 4;
			this.panel2ToggleBarButtonItem.Name = "panel2ToggleBarButtonItem";
			this.panel2ToggleBarButtonItem.Tag = "HidePanel2";
			this.panel2ToggleBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.panel2ToggleBarButtonItem_ItemClick);
			//
			// panel1ToggleBarButtonItem
			//
			this.panel1ToggleBarButtonItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
			this.panel1ToggleBarButtonItem.Caption = "Panel 1 Toggle";
			this.panel1ToggleBarButtonItem.Description = "Panel 1 Toggle";
			this.panel1ToggleBarButtonItem.Hint = "Hide Upper Section";
			this.panel1ToggleBarButtonItem.Id = 2;
			this.panel1ToggleBarButtonItem.ImageIndex = 0;
			this.panel1ToggleBarButtonItem.Name = "panel1ToggleBarButtonItem";
			this.panel1ToggleBarButtonItem.Tag = "HidePanel1";
			this.panel1ToggleBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.panel1ToggleBarButtonItem_ItemClick);
			//
			// barManagerImageCollection16
			//
			this.barManagerImageCollection16.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("barManagerImageCollection16.ImageStream")));
			//
			// BasePanelControl
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlTop);
			this.Name = "BasePanelControl";
			this.Size = new System.Drawing.Size(400, 300);
			((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.barManagerImageCollection16)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
		public DevExpress.XtraBars.Bar bar;
		public DevExpress.XtraBars.BarManager barManager;
		public DevExpress.Utils.ImageCollection barManagerImageCollection16;
		public DevExpress.XtraBars.BarButtonItem objectListPanelToggleBarButtonItem;
		public DevExpress.XtraBars.BarButtonItem panel2ToggleBarButtonItem;
		public DevExpress.XtraBars.BarButtonItem panel1ToggleBarButtonItem;
	}
}
