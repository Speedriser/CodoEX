using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CustName.AppName.WinPL.SearchControls
{
	[ToolboxItemAttribute(false)]
	public partial class BaseEntitySearchControl : DevExpress.XtraEditors.XtraUserControl
	{
		protected CustName.AppName.WinPL.SearchControlMode mode;

		public event EntityObjectSelectionEventHandler EntityObjectSelection = null;
		public event EventHandler FooterVisibleChanged = null;
		public event EventHandler GroupFooterVisibleChanged = null;
		public event EventHandler FilterRowVisibleChanged = null;
		public event EventHandler FilterPanelVisibleChanged = null;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		public BaseEntitySearchControl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call
		}

		protected virtual DevExpress.XtraGrid.Views.Grid.GridView MainGridView
		{
			get
			{
				return null;
			}
		}

		protected virtual DevExpress.XtraGrid.GridControl GridControl
		{
			get
			{
				return null;
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public CustName.AppName.WinPL.SearchControlMode Mode
		{
			get
			{
				return mode;
			}
			set
			{
				mode = value;
				switch (mode)
				{
					case CustName.AppName.WinPL.SearchControlMode.Search:
						this.MainGridView.OptionsSelection.MultiSelect = true;
						break;
					case CustName.AppName.WinPL.SearchControlMode.Lookup:
						this.MainGridView.OptionsSelection.MultiSelect = false;
						break;
				}
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public virtual bool FooterVisible
		{
			get
			{
				return this.MainGridView.OptionsView.ShowFooter;
			}
			set
			{
				bool oldValue = FooterVisible;
				this.MainGridView.OptionsView.ShowFooter = value;
				bool newValue = FooterVisible;
				if (oldValue != newValue) OnFooterVisibleChanged(EventArgs.Empty);
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public virtual bool GroupFooterVisible
		{
			get
			{
				return (this.MainGridView.GroupFooterShowMode == DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways);
			}
			set
			{
				bool oldValue = GroupFooterVisible;
				if (value)
					this.MainGridView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
				else
					this.MainGridView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.Hidden;
				bool newValue = GroupFooterVisible;
				if (oldValue != newValue) OnGroupFooterVisibleChanged(EventArgs.Empty);
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public virtual bool FilterRowVisible
		{
			get
			{
				return this.MainGridView.OptionsView.ShowAutoFilterRow;
			}
			set
			{
				bool oldValue = FilterRowVisible;
				this.MainGridView.OptionsView.ShowAutoFilterRow = value;
				bool newValue = FilterRowVisible;
				if (oldValue != newValue) OnFilterRowVisibleChanged(EventArgs.Empty);
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public virtual bool FilterPanelVisible
		{
			get
			{
				return (this.MainGridView.OptionsView.ShowFilterPanelMode == DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways);
			}
			set
			{
				bool oldValue = FilterPanelVisible;
				if (value)
					this.MainGridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
				else
					this.MainGridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
				bool newValue = FilterPanelVisible;
				if (oldValue != newValue) OnFilterPanelVisibleChanged(EventArgs.Empty);
			}
		}

		protected virtual void OnFooterVisibleChanged(EventArgs e)
		{
			if (FooterVisibleChanged != null)
				FooterVisibleChanged(this, e);
		}

		protected virtual void OnGroupFooterVisibleChanged(EventArgs e)
		{
			if (GroupFooterVisibleChanged != null)
				GroupFooterVisibleChanged(this, e);
		}

		protected virtual void OnFilterRowVisibleChanged(EventArgs e)
		{
			if (FilterRowVisibleChanged != null)
				FilterRowVisibleChanged(this, e);
		}

		protected virtual void OnFilterPanelVisibleChanged(EventArgs e)
		{
			if (FilterPanelVisibleChanged != null)
				FilterPanelVisibleChanged(this, e);
		}

		protected virtual void OnEntityObjectSelectionEvent(EntityObjectSelectionEventArgs e)
		{
			if (EntityObjectSelection != null)
				EntityObjectSelection(this, e);
		}

		protected virtual void resultsGridControl_DoubleClick(object sender, EventArgs e)
		{
			Open();
		}

		public virtual void Find()
		{
		}

		public virtual void Clear()
		{
		}

		public virtual void Open()
		{
		}

		public virtual void RefreshDomainLists()
		{
		}

		public virtual void PrintPreview()
		{
			// Check whether the GridControl can be printed.
			if (!GridControl.IsPrintingAvailable) {
				DevExpress.XtraEditors.XtraMessageBox.Show("The XtraPrinting dll was not found.");
				return;
			}
			// Open the Preview window.
			GridControl.ShowPrintPreview();
		}

		public virtual void Print()
		{
			// Check whether the GridControl can be printed.
			if (!GridControl.IsPrintingAvailable) {
				DevExpress.XtraEditors.XtraMessageBox.Show("The XtraPrinting dll was not found.");
				return;
			}
			// Print.
			GridControl.Print();
		}
	}
}
