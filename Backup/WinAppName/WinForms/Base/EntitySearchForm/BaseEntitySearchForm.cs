using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CustName.AppName.WinPL.SearchForms
{
	public partial class BaseEntitySearchForm : DevExpress.XtraEditors.XtraForm, CustName.AppName.WinPL.IForm
	{
		private CustName.AppName.WinPL.OpenEntityObjectEventHandler openEntityObject = null;
		public event CustName.AppName.WinPL.EntityObjectSelectionEventHandler EntityObjectSelection = null;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		public BaseEntitySearchForm()
		{
			// Required for Windows Form Designer support
			InitializeComponent();
		}

		// This method is called by the class factory immediately after object construction.
		public virtual void CompleteInitialization()
		{
			LoadSupportingData();
		}

		#region IForm

		event CustName.AppName.WinPL.OpenEntityObjectEventHandler IForm.OpenEntityObject
		{
			add { openEntityObject += value; }
			remove { openEntityObject -= value; }
		}

		void IForm.AddNew()
		{
			throw new NotSupportedException();
		}

		public CustName.AppName.DAL.IEntityList EntityList
		{
			get
			{
				throw new NotSupportedException();
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		bool IForm.Save()
		{
			throw new NotSupportedException();
		}

		void IForm.Clear()
		{
			EntitySearchControl.Clear();
		}

		void IForm.NotifyRepositoryChanged()
		{
			NotifyRepositoryChanged();
		}

		bool IForm.HasUncommittedChanges()
		{
			throw new NotSupportedException();
		}

		void IForm.EndEdit()
		{
			throw new NotSupportedException();
		}

		void IForm.PrintPreview()
		{
			EntitySearchControl.PrintPreview();
		}

		void IForm.Print()
		{
			EntitySearchControl.Print();
		}

		#endregion

		protected virtual void NotifyRepositoryChanged()
		{
			LoadSupportingData();
		}

		protected virtual void LoadSupportingData()
		{
			EntitySearchControl.RefreshDomainLists();
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public virtual CustName.AppName.WinPL.SearchControlMode Mode
		{
			get
			{
				return EntitySearchControl.Mode;
			}
			set
			{
				EntitySearchControl.Mode = value;
				switch (EntitySearchControl.Mode)
				{
					case CustName.AppName.WinPL.SearchControlMode.Search:
						this.findBarButtonItem.Caption = "&Open";
						this.findToolBarBarButtonItem.Caption = "Open";
						break;
					case CustName.AppName.WinPL.SearchControlMode.Lookup:
						this.findBarButtonItem.Caption = "&Select";
						this.findToolBarBarButtonItem.Caption = "Select";
						break;
				}
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public virtual CustName.AppName.WinPL.SearchControls.EntitySearchControl EntitySearchControl
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public virtual bool FooterVisible
		{
			get
			{
				return EntitySearchControl.FooterVisible;
			}
			set
			{
				EntitySearchControl.FooterVisible = value;
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public virtual bool GroupFooterVisible
		{
			get
			{
				return EntitySearchControl.GroupFooterVisible;
			}
			set
			{
				EntitySearchControl.GroupFooterVisible = value;
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public virtual bool FilterPanelVisible
		{
			get
			{
				return EntitySearchControl.FilterPanelVisible;
			}
			set
			{
				EntitySearchControl.FilterPanelVisible = value;
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public virtual bool FilterRowVisible
		{
			get
			{
				return EntitySearchControl.FilterRowVisible;
			}
			set
			{
				EntitySearchControl.FilterRowVisible = value;
			}
		}

		protected virtual void findBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			OnFindClick();
		}

		protected virtual void clearBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			OnClearClick();
		}

		protected virtual void openBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			OnOpenClick();
		}

		protected virtual void footerBarCheckItem_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			FooterVisible = ((DevExpress.XtraBars.BarCheckItem)e.Item).Checked;
		}

		protected virtual void groupFooterBarCheckItem_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			GroupFooterVisible = ((DevExpress.XtraBars.BarCheckItem)e.Item).Checked;
		}

		protected virtual void filterRowBarCheckItem_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			FilterRowVisible = ((DevExpress.XtraBars.BarCheckItem)e.Item).Checked;
		}

		protected virtual void filterPanelBarCheckItem_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			FilterPanelVisible = ((DevExpress.XtraBars.BarCheckItem)e.Item).Checked;
		}

		protected virtual void EntitySearchControl_FooterVisibleChanged(object sender, EventArgs e)
		{
			if (footerBarCheckItem.Checked != FooterVisible)
				footerBarCheckItem.Checked = FooterVisible;
			if (footerToolBarBarCheckItem.Checked != FooterVisible)
				footerToolBarBarCheckItem.Checked = FooterVisible;
		}

		protected void EntitySearchControl_GroupFooterVisibleChanged(object sender, EventArgs e)
		{
			if (groupFooterBarCheckItem.Checked != GroupFooterVisible)
				groupFooterBarCheckItem.Checked = GroupFooterVisible;
			if (groupFooterToolBarBarCheckItem.Checked != GroupFooterVisible)
				groupFooterToolBarBarCheckItem.Checked = GroupFooterVisible;
		}

		protected void EntitySearchControl_FilterPanelVisibleChanged(object sender, EventArgs e)
		{
			if (filterPanelBarCheckItem.Checked != FilterPanelVisible)
				filterPanelBarCheckItem.Checked = FilterPanelVisible;
			if (filterPanelToolBarBarCheckItem.Checked != FilterPanelVisible)
				filterPanelToolBarBarCheckItem.Checked = FilterPanelVisible;
		}

		protected void EntitySearchControl_FilterRowVisibleChanged(object sender, EventArgs e)
		{
			if (filterRowBarCheckItem.Checked != FilterRowVisible)
				filterRowBarCheckItem.Checked = FilterRowVisible;
			if (filterRowToolBarBarCheckItem.Checked != FilterRowVisible)
				filterRowToolBarBarCheckItem.Checked = FilterRowVisible;
		}

		protected virtual void EntitySearchControl_EntityObjectSelection(object sender, EntityObjectSelectionEventArgs e)
		{
			OnEntityObjectSelectionEvent(e);
		}

		protected virtual void OnFindClick()
		{
			EntitySearchControl.Find();
		}

		protected virtual void OnClearClick()
		{
			EntitySearchControl.Clear();
		}

		protected virtual void OnOpenClick()
		{
			EntitySearchControl.Open();
		}

		protected virtual void OnEntityObjectSelectionEvent(EntityObjectSelectionEventArgs e)
		{
			if (EntityObjectSelection != null)
				EntityObjectSelection(this, e);
		}
	}
}
