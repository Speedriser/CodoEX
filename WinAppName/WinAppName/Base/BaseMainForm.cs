using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraBars;
using CustName.AppName.BL;
using CustName.AppName.DAL;

namespace CustName.AppName.WinPL
{
	public partial class BaseMainForm : DevExpress.XtraEditors.XtraForm, IMainForm
	{
		private const string DEFAULT_SKIN = "McSkin"; //"Dark Side"; // "Money Twins";
		private const string styleMask = "Style: ";
		private const string skinMask = "Skin: ";
		protected IList<IIdentifier> selectedEntityObjectList;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		public BaseMainForm()
		{
			// Required for Windows Form Designer support
			InitializeComponent();
			// Execute custom initialization code.
			// NOTE: This code is executed at design and run time.
			CustomInitializeComponent();
			// Also see OnLoad & CustomInitializeRuntimeComponent methods for runtime only initialization.
		}

		// Workaround to address issue with DesignMode attribute (Knowledge Base KB 839202).
		// DesignMode property for a control does not return correct value when control used as part if a derived control.
		// Returns true if this control or any of its ancestors is in design mode.
		protected virtual bool DesignMode1
		{
			get
			{
				if (base.DesignMode)
				{
					return true;
				}
				else
				{
					System.Windows.Forms.Control parent = this.Parent;
					while (parent != null)
					{
						System.ComponentModel.ISite site = parent.Site;
						if (site != null && site.DesignMode)
							return true;
						parent = parent.Parent;
					}
				}
				return false;
			}
		}

		private void CustomInitializeComponent()
		{
			DevExpress.UserSkins.BonusSkins.Register();
			InitializeStyle();
			InitializeMDI();
			SetupDefaultNavigationGroup();
		}

		//protected override void CustomInitializeRuntimeComponent()
		//{
		//}

		//protected override void OnLoad(EventArgs e)
		//{
		//	if (!DesignMode1)
		//		// Execute extended custom form initialization.
		//		CustomInitializeRuntimeComponent();
		//	base.OnLoad(e);
		//}

		protected virtual void InitializeStyle()
		{
			// Set default style.
			DevExpress.LookAndFeel.UserLookAndFeel.Default.SetStyle(DevExpress.LookAndFeel.LookAndFeelStyle.Skin, false, false, DEFAULT_SKIN);
			paintStyleBarSubItem.Caption = "Style: " + DEFAULT_SKIN;
			paintStyleBarSubItem.Hint = paintStyleBarSubItem.Caption;
			// Populate Options menu with available skins.
			foreach (DevExpress.Skins.SkinContainer cnt in DevExpress.Skins.SkinManager.Default.Skins)
			{
				BarButtonItem item = new BarButtonItem(barManager, skinMask + cnt.SkinName);
				item.Name = cnt.SkinName + "BarButtonItem";
				item.Id = barManager.GetNewItemId();
				item.Tag = cnt.SkinName;
				paintStyleBarSubItem.AddItem(item);
				item.ItemClick += new ItemClickEventHandler(skinBarButtonItem_ItemClick);
			}
		}

		protected virtual void InitializeMDI()
		{
			this.xtraTabbedMdiManager.MdiParent = this.tabbedMDIBarButtonItem.Down ? this : null;
			this.cascadeBarButtonItem.Enabled = this.tileHorizontalBarButtonItem.Enabled = this.tileVerticalBarButtonItem.Enabled = this.arrangeIconsBarButtonItem.Enabled = !tabbedMDIBarButtonItem.Down;
		}

		#region Main Menubar

		#region File Menu

		protected virtual void newIndependentEntity1BarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			OpenMainForm(EntityClass.IndependentEntity1, null);
		}

		protected virtual void openIndependentEntity1BarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			Open(EntityClass.IndependentEntity1);
		}

		protected virtual void newIndependentEntity2BarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			OpenMainForm(EntityClass.IndependentEntity2, null);
		}

		protected virtual void openIndependentEntity2BarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			Open(EntityClass.IndependentEntity2);
		}

		protected virtual void closeBarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (this.ActiveMdiChild != null)
				this.ActiveMdiChild.Close();
		}

		protected virtual void saveBarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			SaveActiveForm();
		}

		protected virtual void saveAllBarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			SaveAllForms();
		}

		protected virtual void pageSetupBarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			DevExpress.XtraEditors.XtraMessageBox.Show("Function not available.");
		}

		protected virtual void printPreviewBarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			PrintPreviewActiveForm();
		}

		protected virtual void printBarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			PrintActiveForm();
		}

		protected virtual void exitBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			this.Close();
			System.Windows.Forms.Application.Exit();
		}

		#endregion

		#region View Menu

		protected virtual void applicationExplorerBarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			this.appExplorerDockPanel.Visibility = this.applicationExplorerBarButtonItem.Down ? DevExpress.XtraBars.Docking.DockVisibility.Visible : DevExpress.XtraBars.Docking.DockVisibility.Hidden;
		}

		protected virtual void appExplorerDockPanel_VisibilityChanged(object sender, DevExpress.XtraBars.Docking.VisibilityChangedEventArgs e)
		{
			this.applicationExplorerBarButtonItem.Down = (this.appExplorerDockPanel.Visibility != DevExpress.XtraBars.Docking.DockVisibility.Hidden);
		}

		#endregion

		#region Options Menu

		protected virtual void optionsBarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			DevExpress.XtraEditors.XtraMessageBox.Show("Function not available.");
		}

		protected virtual void loadLayoutBarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			DevExpress.XtraEditors.XtraMessageBox.Show("Function not available.");
		}

		protected virtual void saveLayoutBarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			DevExpress.XtraEditors.XtraMessageBox.Show("Function not available.");
		}

		// Applies a selected skin to the UI.
		protected virtual void skinBarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle((string)e.Item.Tag);
			this.paintStyleBarSubItem.Caption = e.Item.Caption;
			this.paintStyleBarSubItem.Hint = this.paintStyleBarSubItem.Caption;
		}

		protected virtual void styleButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			switch ((String)e.Item.Tag)
			{
				case "WindowsXP":
					DevExpress.LookAndFeel.UserLookAndFeel.Default.SetWindowsXPStyle();
					break;
				case "Flat":
					DevExpress.LookAndFeel.UserLookAndFeel.Default.SetFlatStyle();
					break;
				case "Office2003":
					DevExpress.LookAndFeel.UserLookAndFeel.Default.SetOffice2003Style();
					break;
				case "Style3D":
					DevExpress.LookAndFeel.UserLookAndFeel.Default.SetStyle3D();
					break;
				case "UltraFlat":
					DevExpress.LookAndFeel.UserLookAndFeel.Default.SetUltraFlatStyle();
					break;
				default:
					DevExpress.LookAndFeel.UserLookAndFeel.Default.SetDefaultStyle();
					break;
			}
			paintStyleBarSubItem.Caption = e.Item.Caption;
			paintStyleBarSubItem.Hint = e.Item.Description;
		}

		#endregion

		#region Window Menu

		protected virtual void tabbedMDIBarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			InitializeMDI();
		}

		protected virtual void cascadeBarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			LayoutMdi(MdiLayout.Cascade);
		}

		protected virtual void tileHorizontalBarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			LayoutMdi(MdiLayout.TileHorizontal);
		}

		protected virtual void tileVerticalBarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			LayoutMdi(MdiLayout.TileVertical);
		}

		protected virtual void arrangeIconsBarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			LayoutMdi(MdiLayout.ArrangeIcons);
		}

		protected virtual void closeAllBarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			CloseAllDocuments(null);
		}

		protected virtual void closeAllButThisBarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			CloseAllDocuments(ActiveMdiChild);
		}

		#endregion

		#region Help Menu

		protected virtual void contentsBarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			DevExpress.XtraEditors.XtraMessageBox.Show("Function not available.");
		}

		protected virtual void indexBarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			DevExpress.XtraEditors.XtraMessageBox.Show("Function not available.");
		}

		protected virtual void searchBarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			DevExpress.XtraEditors.XtraMessageBox.Show("Function not available.");
		}

		protected virtual void aboutBarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			AboutBoxForm form = (AboutBoxForm)CustName.AppName.WinPL.Global.ClassFactory.GetAboutBoxForm();
			form.ShowDialog(this);
		}

		#endregion

		#endregion

		#region Main Toolbar

		protected virtual void newIndependentEntity1ToolBarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			OpenMainForm(EntityClass.IndependentEntity1, null);
		}

		protected virtual void openIndependentEntity1ToolBarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			Open(EntityClass.IndependentEntity1);
		}

		protected virtual void newIndependentEntity2ToolBarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			OpenMainForm(EntityClass.IndependentEntity2, null);
		}

		protected virtual void openIndependentEntity2ToolBarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			Open(EntityClass.IndependentEntity2);
		}

		protected virtual void newToolBarLargeButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			((BarButtonItemLink)e.Link).ShowPopup();
		}

		protected virtual void openToolBarLargeButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			((BarButtonItemLink)e.Link).ShowPopup();
		}

		protected virtual void saveToolBarLargeButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			SaveActiveForm();
		}

		protected virtual void saveAllToolBarLargeButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			SaveAllForms();
		}

		protected virtual void printToolBarLargeButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			PrintPreviewActiveForm(); // Unlike the corresponding menu option, this one opens the preview window instead of printing directly.
		}

		protected virtual void helpToolBarLargeButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			DevExpress.XtraEditors.XtraMessageBox.Show("Function not implemented.");
		}

		#endregion

		#region Form

		public virtual void OpenSearchForm(EntityClass entityClass)
		{
			System.Windows.Forms.Form form = CustName.AppName.WinPL.Global.ClassFactory.GetSearchForm(entityClass);
			ClearForm(form);
			form.MdiParent = this;
			form.Show();
		}

		public virtual void OpenMainForm(EntityClass entityClass, IEntityList entityList)
		{
			System.Windows.Forms.Form form = CustName.AppName.WinPL.Global.ClassFactory.GetMainForm(entityClass);
			form.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MdiChildForm_FormClosing);
			((IForm)form).OpenEntityObject += new CustName.AppName.WinPL.OpenEntityObjectEventHandler(this.EntityPanelControl_OpenEntityObject);
			SetFormContent(form, entityClass, entityList);
			form.MdiParent = this;
			form.Show();
		}

		public virtual void SetFormContent(System.Windows.Forms.Form form, EntityClass entityClass, IEntityList entityList)
		{
			if (entityList == null)
				((IForm)form).AddNew();
			else
				((IForm)form).EntityList = entityList;
		}

		public virtual void Open(EntityClass entityClass)
		{
			// Get entity object selection(s) from user.

			System.Windows.Forms.Form form = CustName.AppName.WinPL.Global.ClassFactory.GetSearchForm(entityClass);
			ClearForm(form);
			EntityObjectSelectionEventHandler entityObjectSelectionEventHandler = new EntityObjectSelectionEventHandler(EntityObjectSelection);
			((CustName.AppName.WinPL.SearchForms.EntitySearchForm)form).EntityObjectSelection += entityObjectSelectionEventHandler;
			form.ShowDialog(this);
			((CustName.AppName.WinPL.SearchForms.EntitySearchForm)form).EntityObjectSelection -= entityObjectSelectionEventHandler;

			// Open entity object selection(s) in new tab(s).

			if (this.selectedEntityObjectList != null && this.selectedEntityObjectList.Count > 0)
			{
				CustName.AppName.DAL.Repository repository = CustName.AppName.BL.Global.ClassFactory.GetDALRepository();
				IEntityList selectedEntityList = CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(entityClass);
				IEntityObject entityObjectForEdit;
				foreach (IIdentifier objectId in this.selectedEntityObjectList)
				{
					if ((entityObjectForEdit = repository.Get(entityClass, objectId)) != null)
					{
						selectedEntityList.Add(entityObjectForEdit);
					}
				}
				this.selectedEntityObjectList = null;
				if (selectedEntityList.Count > 0)
					OpenMainForm(entityClass, selectedEntityList);
			}
		}

		protected virtual void EntityPanelControl_OpenEntityObject(object sender, OpenEntityObjectEventArgs e)
		{
			if (e.ObjectId != null)
			{
				BaseEntityObject entityObject;
				CustName.AppName.DAL.Repository repository = CustName.AppName.BL.Global.ClassFactory.GetDALRepository();

				switch (e.EntityClass)
				{
					case EntityClass.IndependentEntity1:
						if ((entityObject = (BaseEntityObject)repository.GetIndependentEntity1((IndependentEntity1Identifier)e.ObjectId)) != null)
						{
							IndependentEntity1List independentEntity1List = (IndependentEntity1List)CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(EntityClass.IndependentEntity1);
							independentEntity1List.Add((CustName.AppName.BL.IndependentEntity1)entityObject);
							OpenMainForm(EntityClass.IndependentEntity1, (IEntityList)independentEntity1List);
						}
						break;
					case EntityClass.IndependentEntity2:
						if ((entityObject = (BaseEntityObject)repository.GetIndependentEntity2((IndependentEntity2Identifier)e.ObjectId)) != null)
						{
							IndependentEntity2List independentEntity2List = (IndependentEntity2List)CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(EntityClass.IndependentEntity2);
							independentEntity2List.Add((CustName.AppName.BL.IndependentEntity2)entityObject);
							OpenMainForm(EntityClass.IndependentEntity2, (IEntityList)independentEntity2List);
						}
						break;
				}
			}
		}

		protected virtual void EntityObjectSelection(object sender, EntityObjectSelectionEventArgs e)
		{
			this.selectedEntityObjectList = e.SelectedEntityObjectList;
		}

		public virtual void SaveForm(System.Windows.Forms.Form form)
		{
			if ((form as IForm) != null)
			{
				// Search forms will throw NotSupportedException.
				try
				{
					((IForm)form).Save();
				}
				catch (NotSupportedException) { }
			}
		}

		public virtual void SaveActiveForm()
		{
			if (this.ActiveMdiChild != null)
			{
				SaveForm(this.ActiveMdiChild);
				NotifyAllFormsRepositoryChanged();
			}
		}

		public virtual void SaveAllForms()
		{
			foreach (System.Windows.Forms.Form form in MdiChildren)
				SaveForm(form);
			NotifyAllFormsRepositoryChanged();
		}

		public virtual void NotifyAllFormsRepositoryChanged()
		{
			foreach (System.Windows.Forms.Form form in MdiChildren)
				((IForm)form).NotifyRepositoryChanged();
		}

		public virtual void ClearForm(System.Windows.Forms.Form form)
		{
			if ((form as IForm) != null) ((IForm)form).Clear();
		}

		public virtual void PrintPreviewActiveForm()
		{
			if (this.ActiveMdiChild != null) PrintPreviewForm(this.ActiveMdiChild);
		}

		public virtual void PrintPreviewForm(System.Windows.Forms.Form form)
		{
			if ((form as IForm) != null) ((IForm)form).PrintPreview();
		}

		public virtual void PrintActiveForm()
		{
			if (this.ActiveMdiChild != null) PrintForm(this.ActiveMdiChild);
		}

		public virtual void PrintForm(System.Windows.Forms.Form form)
		{
			if ((form as IForm) != null) ((IForm)form).Print();
		}

		protected void MdiChildForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			IForm form = sender as IForm;
			if (form != null)
			{
				((System.Windows.Forms.Form)sender).Activate();
				if (form.HasUncommittedChanges())
				{
					switch (DevExpress.XtraEditors.XtraMessageBox.Show("Do you want to save the changes to form " + ((System.Windows.Forms.Form)form).Text + "?", this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1))
					{
						case DialogResult.Yes:
							if (!form.Save())
								e.Cancel = true;
							break;
						case DialogResult.No:
							break;
						case DialogResult.Cancel:
							e.Cancel = true;
							break;
					}
				}
			}
		}

		public virtual void CloseAllDocuments(System.Windows.Forms.Form activeMdiChild)
		{
			if (activeMdiChild == null)
			{
				foreach (System.Windows.Forms.Form form in MdiChildren)
					form.Close();
			}
			else
			{
				foreach (System.Windows.Forms.Form form in MdiChildren)
				{
					if (form != activeMdiChild)
						form.Close();
				}
			}
		}

		#endregion

		#region Navigation Bar

		public virtual void SetupDefaultNavigationGroup()
		{
			System.Windows.Forms.TreeNode treeNode1;
			System.Windows.Forms.TreeNode treeNode2;

			this.defaultTreeView.BeginUpdate();

			this.defaultTreeView.Nodes.Add(treeNode1 = new System.Windows.Forms.TreeNode("Independent Entity 1"));
			treeNode1.Name = "IndependentEntity1Node";
			treeNode1.Tag = new MainFormNavigationTreeNodeTag { FormType = 'E', EntityClass = EntityClass.IndependentEntity1 };
			treeNode1.Nodes.Add(treeNode2 = new System.Windows.Forms.TreeNode("Search"));
			treeNode2.Name = "IndependentEntity1SearchNode";
			treeNode2.Tag = new MainFormNavigationTreeNodeTag { FormType = 'S', EntityClass = EntityClass.IndependentEntity1 };
			treeNode1.Nodes.Add(treeNode2 = new System.Windows.Forms.TreeNode("New"));
			treeNode2.Name = "NewIndependentEntity1Node";
			treeNode2.Tag = new MainFormNavigationTreeNodeTag { FormType = 'N', EntityClass = EntityClass.IndependentEntity1 };
			this.defaultTreeView.Nodes.Add(treeNode1 = new System.Windows.Forms.TreeNode("Independent Entity 2"));
			treeNode1.Name = "IndependentEntity2Node";
			treeNode1.Tag = new MainFormNavigationTreeNodeTag { FormType = 'E', EntityClass = EntityClass.IndependentEntity2 };
			treeNode1.Nodes.Add(treeNode2 = new System.Windows.Forms.TreeNode("Search"));
			treeNode2.Name = "IndependentEntity2SearchNode";
			treeNode2.Tag = new MainFormNavigationTreeNodeTag { FormType = 'S', EntityClass = EntityClass.IndependentEntity2 };
			treeNode1.Nodes.Add(treeNode2 = new System.Windows.Forms.TreeNode("New"));
			treeNode2.Name = "NewIndependentEntity2Node";
			treeNode2.Tag = new MainFormNavigationTreeNodeTag { FormType = 'N', EntityClass = EntityClass.IndependentEntity2 };
			//this.defaultTreeView.ExpandAll();

			this.defaultTreeView.EndUpdate();
		}

		protected virtual void defaultTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			this.defaultTreeView.SelectedNode = e.Node;
			MainFormNavigationTreeNodeTag mainFormNavigationTreeNodeTag = e.Node.Tag as MainFormNavigationTreeNodeTag;
			if (mainFormNavigationTreeNodeTag != null)
			{
				switch (mainFormNavigationTreeNodeTag.FormType)
				{
					case 'S':
						OpenSearchForm(mainFormNavigationTreeNodeTag.EntityClass);
						break;
					case 'N':
						OpenMainForm(mainFormNavigationTreeNodeTag.EntityClass, null);
						break;
				}
			}
		}


		#endregion
	}
}
