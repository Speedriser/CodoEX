namespace CustName.AppName.WinPL.SearchForms
{
	partial class BaseEntitySearchForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseEntitySearchForm));
			this.barManager = new DevExpress.XtraBars.BarManager(this.components);
			this.toolBarBar = new DevExpress.XtraBars.Bar();
			this.findToolBarBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
			this.clearToolBarBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
			this.openToolBarBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
			this.optionsToolBarBarSubItem = new DevExpress.XtraBars.BarSubItem();
			this.footerToolBarBarCheckItem = new DevExpress.XtraBars.BarCheckItem();
			this.groupFooterToolBarBarCheckItem = new DevExpress.XtraBars.BarCheckItem();
			this.filterRowToolBarBarCheckItem = new DevExpress.XtraBars.BarCheckItem();
			this.filterPanelToolBarBarCheckItem = new DevExpress.XtraBars.BarCheckItem();
			this.mainMenuBar = new DevExpress.XtraBars.Bar();
			this.searchBarSubItem = new DevExpress.XtraBars.BarSubItem();
			this.findBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
			this.clearBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
			this.openBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
			this.optionsBarSubItem = new DevExpress.XtraBars.BarSubItem();
			this.footerBarCheckItem = new DevExpress.XtraBars.BarCheckItem();
			this.groupFooterBarCheckItem = new DevExpress.XtraBars.BarCheckItem();
			this.filterRowBarCheckItem = new DevExpress.XtraBars.BarCheckItem();
			this.filterPanelBarCheckItem = new DevExpress.XtraBars.BarCheckItem();
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			this.imageCollection = new DevExpress.Utils.ImageCollection(this.components);
			this.barCheckItem2 = new DevExpress.XtraBars.BarCheckItem();
			((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
			this.SuspendLayout();
			//
			// barManager
			//
			this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.toolBarBar,
            this.mainMenuBar});
			this.barManager.DockControls.Add(this.barDockControlTop);
			this.barManager.DockControls.Add(this.barDockControlBottom);
			this.barManager.DockControls.Add(this.barDockControlLeft);
			this.barManager.DockControls.Add(this.barDockControlRight);
			this.barManager.Form = this;
			this.barManager.Images = this.imageCollection;
			this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.searchBarSubItem,
            this.findBarButtonItem,
            this.clearBarButtonItem,
            this.openBarButtonItem,
            this.findToolBarBarButtonItem,
            this.clearToolBarBarButtonItem,
            this.openToolBarBarButtonItem,
            this.filterPanelToolBarBarCheckItem,
            this.barCheckItem2,
            this.filterRowToolBarBarCheckItem,
            this.footerToolBarBarCheckItem,
            this.groupFooterToolBarBarCheckItem,
            this.groupFooterBarCheckItem,
            this.footerBarCheckItem,
            this.filterRowBarCheckItem,
            this.filterPanelBarCheckItem,
            this.optionsBarSubItem,
            this.optionsToolBarBarSubItem});
			this.barManager.MainMenu = this.mainMenuBar;
			this.barManager.MaxItemId = 19;
			this.barManager.MdiMenuMergeStyle = DevExpress.XtraBars.BarMdiMenuMergeStyle.OnlyWhenChildMaximized;
			//
			// toolBarBar
			//
			this.toolBarBar.BarName = "Toolbar";
			this.toolBarBar.DockCol = 0;
			this.toolBarBar.DockRow = 1;
			this.toolBarBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
			this.toolBarBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.findToolBarBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.clearToolBarBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.openToolBarBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.optionsToolBarBarSubItem, true)});
			this.toolBarBar.Text = "Toolbar";
			//
			// findToolBarBarButtonItem
			//
			this.findToolBarBarButtonItem.Caption = "Find";
			this.findToolBarBarButtonItem.Id = 5;
			this.findToolBarBarButtonItem.ImageIndex = 0;
			this.findToolBarBarButtonItem.ImageIndexDisabled = 1;
			this.findToolBarBarButtonItem.Name = "findToolBarBarButtonItem";
			this.findToolBarBarButtonItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
			this.findToolBarBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.findBarButtonItem_ItemClick);
			//
			// clearToolBarBarButtonItem
			//
			this.clearToolBarBarButtonItem.Caption = "Clear";
			this.clearToolBarBarButtonItem.Id = 6;
			this.clearToolBarBarButtonItem.ImageIndex = 2;
			this.clearToolBarBarButtonItem.ImageIndexDisabled = 3;
			this.clearToolBarBarButtonItem.Name = "clearToolBarBarButtonItem";
			this.clearToolBarBarButtonItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
			this.clearToolBarBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.clearBarButtonItem_ItemClick);
			//
			// openToolBarBarButtonItem
			//
			this.openToolBarBarButtonItem.Caption = "Open";
			this.openToolBarBarButtonItem.Id = 7;
			this.openToolBarBarButtonItem.ImageIndex = 4;
			this.openToolBarBarButtonItem.ImageIndexDisabled = 5;
			this.openToolBarBarButtonItem.Name = "openToolBarBarButtonItem";
			this.openToolBarBarButtonItem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
			this.openToolBarBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.openBarButtonItem_ItemClick);
			//
			// optionsToolBarBarSubItem
			//
			this.optionsToolBarBarSubItem.Caption = "Options";
			this.optionsToolBarBarSubItem.Id = 18;
			this.optionsToolBarBarSubItem.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.footerToolBarBarCheckItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.groupFooterToolBarBarCheckItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.filterRowToolBarBarCheckItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.filterPanelToolBarBarCheckItem)});
			this.optionsToolBarBarSubItem.Name = "optionsToolBarBarSubItem";
			//
			// footerToolBarBarCheckItem
			//
			this.footerToolBarBarCheckItem.Caption = "Main Footer";
			this.footerToolBarBarCheckItem.Id = 11;
			this.footerToolBarBarCheckItem.Name = "footerToolBarBarCheckItem";
			this.footerToolBarBarCheckItem.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.footerBarCheckItem_CheckedChanged);
			//
			// groupFooterToolBarBarCheckItem
			//
			this.groupFooterToolBarBarCheckItem.Caption = "Group Footer";
			this.groupFooterToolBarBarCheckItem.Id = 12;
			this.groupFooterToolBarBarCheckItem.Name = "groupFooterToolBarBarCheckItem";
			this.groupFooterToolBarBarCheckItem.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.groupFooterBarCheckItem_CheckedChanged);
			//
			// filterRowToolBarBarCheckItem
			//
			this.filterRowToolBarBarCheckItem.Caption = "Filter Row";
			this.filterRowToolBarBarCheckItem.Id = 10;
			this.filterRowToolBarBarCheckItem.Name = "filterRowToolBarBarCheckItem";
			this.filterRowToolBarBarCheckItem.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.filterRowBarCheckItem_CheckedChanged);
			//
			// filterPanelToolBarBarCheckItem
			//
			this.filterPanelToolBarBarCheckItem.Caption = "Filter Panel";
			this.filterPanelToolBarBarCheckItem.Id = 8;
			this.filterPanelToolBarBarCheckItem.Name = "filterPanelToolBarBarCheckItem";
			this.filterPanelToolBarBarCheckItem.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.filterPanelBarCheckItem_CheckedChanged);
			//
			// mainMenuBar
			//
			this.mainMenuBar.BarName = "Main Menu";
			this.mainMenuBar.DockCol = 0;
			this.mainMenuBar.DockRow = 0;
			this.mainMenuBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
			this.mainMenuBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.searchBarSubItem)});
			this.mainMenuBar.OptionsBar.MultiLine = true;
			this.mainMenuBar.OptionsBar.UseWholeRow = true;
			this.mainMenuBar.Text = "Main Menu";
			//
			// searchBarSubItem
			//
			this.searchBarSubItem.Caption = "&Search";
			this.searchBarSubItem.Id = 1;
			this.searchBarSubItem.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.findBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.clearBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.openBarButtonItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.optionsBarSubItem, true)});
			this.searchBarSubItem.Name = "searchBarSubItem";
			//
			// findBarButtonItem
			//
			this.findBarButtonItem.Caption = "&Find";
			this.findBarButtonItem.Id = 2;
			this.findBarButtonItem.ImageIndex = 0;
			this.findBarButtonItem.ImageIndexDisabled = 1;
			this.findBarButtonItem.Name = "findBarButtonItem";
			this.findBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.findBarButtonItem_ItemClick);
			//
			// clearBarButtonItem
			//
			this.clearBarButtonItem.Caption = "&Clear";
			this.clearBarButtonItem.Id = 3;
			this.clearBarButtonItem.ImageIndex = 2;
			this.clearBarButtonItem.ImageIndexDisabled = 1;
			this.clearBarButtonItem.Name = "clearBarButtonItem";
			this.clearBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.clearBarButtonItem_ItemClick);
			//
			// openBarButtonItem
			//
			this.openBarButtonItem.Caption = "&Open";
			this.openBarButtonItem.Id = 4;
			this.openBarButtonItem.ImageIndex = 4;
			this.openBarButtonItem.ImageIndexDisabled = 5;
			this.openBarButtonItem.Name = "openBarButtonItem";
			this.openBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.openBarButtonItem_ItemClick);
			//
			// optionsBarSubItem
			//
			this.optionsBarSubItem.Caption = "Options";
			this.optionsBarSubItem.Id = 17;
			this.optionsBarSubItem.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.footerBarCheckItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.groupFooterBarCheckItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.filterRowBarCheckItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.filterPanelBarCheckItem)});
			this.optionsBarSubItem.Name = "optionsBarSubItem";
			//
			// footerBarCheckItem
			//
			this.footerBarCheckItem.Caption = "Main Footer";
			this.footerBarCheckItem.Id = 14;
			this.footerBarCheckItem.Name = "footerBarCheckItem";
			this.footerBarCheckItem.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.footerBarCheckItem_CheckedChanged);
			//
			// groupFooterBarCheckItem
			//
			this.groupFooterBarCheckItem.Caption = "Group Footer";
			this.groupFooterBarCheckItem.Id = 13;
			this.groupFooterBarCheckItem.Name = "groupFooterBarCheckItem";
			this.groupFooterBarCheckItem.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.groupFooterBarCheckItem_CheckedChanged);
			//
			// filterRowBarCheckItem
			//
			this.filterRowBarCheckItem.Caption = "Filter Row";
			this.filterRowBarCheckItem.Id = 15;
			this.filterRowBarCheckItem.Name = "filterRowBarCheckItem";
			this.filterRowBarCheckItem.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.filterRowBarCheckItem_CheckedChanged);
			//
			// filterPanelBarCheckItem
			//
			this.filterPanelBarCheckItem.Caption = "Filter Panel";
			this.filterPanelBarCheckItem.Id = 16;
			this.filterPanelBarCheckItem.Name = "filterPanelBarCheckItem";
			this.filterPanelBarCheckItem.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.filterPanelBarCheckItem_CheckedChanged);
			//
			// imageCollection
			//
			this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
			//
			// barCheckItem2
			//
			this.barCheckItem2.Caption = "barCheckItem2";
			this.barCheckItem2.Id = 9;
			this.barCheckItem2.Name = "barCheckItem2";
			//
			// BaseEntitySearchForm
			//
			this.ClientSize = new System.Drawing.Size(792, 566);
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlTop);
			this.Name = "BaseEntitySearchForm";
			this.Text = "BaseEntitySearchForm";
			((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public DevExpress.XtraBars.BarManager barManager;
		public DevExpress.XtraBars.Bar toolBarBar;
		public DevExpress.XtraBars.Bar mainMenuBar;
		public DevExpress.XtraBars.BarDockControl barDockControlTop;
		public DevExpress.XtraBars.BarDockControl barDockControlBottom;
		public DevExpress.XtraBars.BarDockControl barDockControlLeft;
		public DevExpress.XtraBars.BarDockControl barDockControlRight;
		public DevExpress.XtraBars.BarSubItem searchBarSubItem;
		public DevExpress.XtraBars.BarButtonItem findBarButtonItem;
		public DevExpress.XtraBars.BarButtonItem clearBarButtonItem;
		public DevExpress.XtraBars.BarButtonItem openBarButtonItem;
		public DevExpress.XtraBars.BarButtonItem findToolBarBarButtonItem;
		public DevExpress.XtraBars.BarButtonItem clearToolBarBarButtonItem;
		public DevExpress.XtraBars.BarButtonItem openToolBarBarButtonItem;
		public DevExpress.Utils.ImageCollection imageCollection;
		public DevExpress.XtraBars.BarCheckItem filterPanelToolBarBarCheckItem;
		public DevExpress.XtraBars.BarCheckItem filterRowToolBarBarCheckItem;
		public DevExpress.XtraBars.BarCheckItem footerToolBarBarCheckItem;
		public DevExpress.XtraBars.BarCheckItem barCheckItem2;
		public DevExpress.XtraBars.BarCheckItem groupFooterToolBarBarCheckItem;
		public DevExpress.XtraBars.BarCheckItem groupFooterBarCheckItem;
		public DevExpress.XtraBars.BarCheckItem footerBarCheckItem;
		public DevExpress.XtraBars.BarCheckItem filterRowBarCheckItem;
		public DevExpress.XtraBars.BarCheckItem filterPanelBarCheckItem;
		public DevExpress.XtraBars.BarSubItem optionsBarSubItem;
		public DevExpress.XtraBars.BarSubItem optionsToolBarBarSubItem;
	}
}
