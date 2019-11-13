using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CustName.AppName.DAL;

namespace CustName.AppName.WinPL.MainForms
{
	public partial class BaseEntityMainForm : DevExpress.XtraEditors.XtraForm, CustName.AppName.WinPL.IForm
	{
		protected bool ignoreCollision = true;
		protected string layoutFilePrefix;
		protected bool previouslyActivated;
		protected List<DevExpress.XtraTab.XtraTabControl> tabControlList;
		protected List<PanelControl> panelControlList;
		//protected List<SplitContainerControl> splitContainerControlList;
		protected CustName.AppName.WinPL.OpenEntityObjectEventHandler openEntityObject = null;
		protected EntityPanelControl rootPanelControl;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		public BaseEntityMainForm()
		{
			// Required for Windows Form Designer support
			InitializeComponent();
			// Execute custom initialization code.
			// NOTE: This code is executed at design and run time.
			//CustomInitializeComponent();
			// Also see OnLoad & CustomInitializeRuntimeComponent methods for runtime only initialization.
		}

		//private void CustomInitializeComponent()
		//{
		//}

		// This method is called by the class factory immediately after object construction.
		public virtual void CompleteInitialization()
		{
			this.layoutFilePrefix = this.Name;

			//PopulateSplitContainerControlList();

			// Configure XtraTabControl controls.

			PopulateTabControlList();
			if (this.tabControlList != null)
			{
				foreach (DevExpress.XtraTab.XtraTabControl tabControl in this.tabControlList)
				{
					tabControl.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.XtraTabControl_SelectedPageChanged);
					foreach (DevExpress.XtraTab.XtraTabPage tabPage in tabControl.TabPages)
					{
						tabPage.Tag = new EntityMainFormTabPageTag();
					}
				}
			}

			// Configure PanelControl controls.

			PopulatePanelControlList();
			EntityPanelControl entityPanelControl;
			foreach (PanelControl panelControl in this.panelControlList)
			{
				panelControl.ToolBarButtonClick += new CustName.AppName.WinPL.MainForms.ToolBarButtonClickEventHandler(this.PanelControl_ToolBarButtonClick);
				if ((entityPanelControl = panelControl as EntityPanelControl) != null)
				{
					entityPanelControl.OpenEntityObject += new CustName.AppName.WinPL.OpenEntityObjectEventHandler(this.EntityPanelControl_OpenEntityObject);
					entityPanelControl.QueryPanelReadOnlyStatus += new CustName.AppName.WinPL.MainForms.QueryReadOnlyStatusEventHandler(this.EntityPanelControl_QueryPanelReadOnlyStatus);
				}
			}
			// Remaining PanelControl configuration will be performed by DataBind() below.
			// DataBind() will also identify the root panel control and set this.rootPanelControl accordingly.

			// Load domain and other supporting data.
			LoadSupportingData();

			// Establish data bindings.

			List<EntityPanelControlBinding> entityPanelControlBindingList = null;
			GetEntityPanelControlBindings(out entityPanelControlBindingList);
			DataBind(entityPanelControlBindingList);

			this.rootPanelControl.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.rootPanelControl_bindingSource_ListChanged);
		}

		protected virtual void CustomInitializeRuntimeComponent()
		{
			// Configure panels.
			PanelControl panelControl;
			string path;
			for (int index = 0; index < this.panelControlList.Count; ++index)
			{
				panelControl = panelControlList[index];
				panelControl.Configure();
				panelControl.SetPanel2Visibility(index == 0);
				// Restore saved layouts.
				path = this.layoutFilePrefix + "_" + panelControl.Name + ".xml";
				if (System.IO.File.Exists(path))
					panelControl.FormView_LayoutControl.RestoreLayoutFromXml(path);
			}
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

		protected override void OnLoad(EventArgs e)
		{
			if (!DesignMode1)
				// Execute extended custom form initialization.
				CustomInitializeRuntimeComponent();
			base.OnLoad(e);
		}

		#region Tab control list

		public void PopulateTabControlList()
		{
			List<DevExpress.XtraTab.XtraTabControl> tabControlList = null;
			if (!GetTabControls(out tabControlList))
				tabControlList = FindTabControls();
			this.tabControlList = tabControlList;
		}

		public virtual bool GetTabControls(out List<DevExpress.XtraTab.XtraTabControl> tabControlList)
		{
			tabControlList = null;
			return false;
		}

		public virtual List<DevExpress.XtraTab.XtraTabControl> FindTabControls()
		{
			List<Control> matchingControls = new List<Control>();
			FindControls(typeof(DevExpress.XtraTab.XtraTabControl), false, this.Controls, matchingControls);

			List<DevExpress.XtraTab.XtraTabControl> tabControlList = null;
			if (matchingControls.Count > 0)
			{
				tabControlList = new List<DevExpress.XtraTab.XtraTabControl>(matchingControls.Count);
				foreach (DevExpress.XtraTab.XtraTabControl control in matchingControls)
					tabControlList.Add(control);
			}

			return tabControlList;
		}

		#endregion

		#region Panel control list

		public void PopulatePanelControlList()
		{
			List<PanelControl> panelControlList = null;
			if (!GetPanelControls(out panelControlList))
				panelControlList = FindPanelControls();
			this.panelControlList = panelControlList;
		}

		public virtual bool GetPanelControls(out List<PanelControl> panelControlList)
		{
			panelControlList = null;
			return false;
		}

		public virtual List<PanelControl> FindPanelControls()
		{
			List<Control> matchingControls = new List<Control>();
			FindControls(typeof(PanelControl), true, this.Controls, matchingControls);

			List<PanelControl> panelControlList = null;
			if (matchingControls.Count > 0)
			{
				panelControlList = new List<PanelControl>(matchingControls.Count);
				// panelControlList must be ordered such that for a given control, all child controls appear after it in the list.
				// Required by EndEdit function.
				foreach (PanelControl panelControl in matchingControls)
					panelControlList.Add(panelControl);
			}

			return panelControlList;
		}

		#endregion

		#region Entity panel binding list

		public virtual bool GetEntityPanelControlBindings(out List<EntityPanelControlBinding> entityPanelControlBindingList)
		{
			entityPanelControlBindingList = null;
			return false;
		}

		#endregion

		#region SplitContainer control list

		//public void PopulateSplitContainerControlList()
		//{
		//    List<SplitContainerControl> splitContainerControlList = null;
		//    if (!GetSplitContainerControls(out splitContainerControlList))
		//        splitContainerControlList = FindSplitContainerControls();
		//    this.splitContainerControlList = splitContainerControlList;
		//}

		//public virtual bool GetSplitContainerControls(out List<SplitContainerControl> splitContainerControlList)
		//{
		//    splitContainerControlList = null;
		//    return false;
		//}

		//public virtual List<SplitContainerControl> FindSplitContainerControls()
		//{
		//    List<Control> matchingControls = new List<Control>();
		//    FindControls(typeof(SplitContainerControl), false, this.Controls, matchingControls);

		//    List<SplitContainerControl> splitContainerControlList = null;
		//    // > 1 needed because baseSplitContainerControl (part of BaseEntityMainForm) is ignored.
		//    if (matchingControls.Count > 1)
		//    {
		//        splitContainerControlList = new List<SplitContainerControl>(matchingControls.Count);
		//        // splitContainerControlList must be ordered such that for a given control, all child controls appear after it in the list.
		//        // Required by EndEdit function.
		//        foreach (SplitContainerControl splitContainerControl in matchingControls)
		//        {
		//            if (splitContainerControl != this.baseSplitContainerControl)
		//                splitContainerControlList.Add(splitContainerControl);
		//        }
		//    }

		//    return splitContainerControlList;
		//}

		#endregion

		public string LayoutFilePrefix
		{
			get
			{
				return this.layoutFilePrefix;
			}
			set
			{
				this.layoutFilePrefix = value;
			}
		}

		#region Form activation

		protected virtual void EntityMainForm_Activated(object sender, EventArgs e)
		{
			if (!this.previouslyActivated)
			{
				OnFirstActivation();
				this.previouslyActivated = true;
			}
		}

		protected virtual void OnFirstActivation()
		{
			// Configure the root panel.
			if (this.rootPanelControl != null)
			{
				// Inform the root panel that this is its first activation.
				OnFirstActivation(this.rootPanelControl);
				// Set default control focus.
				this.rootPanelControl.SetDefaultAppendFocus();
			}
			// Inform all child panels belonging to active (selected) tab pages that this is their first activation.
			if (this.tabControlList != null)
			{
				foreach (DevExpress.XtraTab.XtraTabControl tabControl in this.tabControlList)
				{
					XtraTabControl_SelectedPageChanged(tabControl.SelectedTabPage);
				}
			}
		}

		#endregion

		#region Panel activation

		protected virtual void OnFirstActivation(PanelControl panelControl)
		{
			panelControl.NotifyFirstActivation();
		}

		#endregion

		#region Tab page activation

		protected virtual void XtraTabControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
		{
			XtraTabControl_SelectedPageChanged(e.Page);
		}

		public virtual void XtraTabControl_SelectedPageChanged(DevExpress.XtraTab.XtraTabPage page)
		{
			EntityMainFormTabPageTag entityMainFormTabPageTag = page.Tag as EntityMainFormTabPageTag;
			if (entityMainFormTabPageTag != null && !entityMainFormTabPageTag.PreviouslyActivated)
			{
				OnFirstActivation(page);
				entityMainFormTabPageTag.PreviouslyActivated = true;
			}
		}

		protected virtual void OnFirstActivation(DevExpress.XtraTab.XtraTabPage tabPage)
		{
			PanelControl panelControl = GetPrimaryPanel(tabPage);
			if (panelControl != null)
				OnFirstActivation(panelControl);
		}

		#endregion

		#region Root panel control

		public EntityPanelControl RootPanelControl
		{
			get
			{
				return this.rootPanelControl;
			}
		}

		protected virtual void rootPanelControl_bindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
		{
			switch (e.ListChangedType)
			{
				case ListChangedType.ItemChanged:
					switch (e.PropertyDescriptor.Name)
					{
						case "ObjectPrimaryDescriptor":
						case "HasUncommittedChanges":
						case "MarkedForDeletion":
							this.objectListListBox.Refresh();
							break;
					}
					break;
				default:
					this.objectListListBox.Refresh();
					break;
			}
		}

		#endregion

		#region Panel controls

		protected virtual void EntityPanelControl_OpenEntityObject(object sender, OpenEntityObjectEventArgs e)
		{
			OnOpenEntityObject(e);
		}

		protected virtual void OnOpenEntityObject(CustName.AppName.WinPL.OpenEntityObjectEventArgs e)
		{
			if (this.openEntityObject != null)
				this.openEntityObject(this, e);
		}

		protected virtual void EntityPanelControl_QueryPanelReadOnlyStatus(object sender, QueryReadOnlyStatusEventArgs e)
		{
			if (!e.ReadOnly && sender != this.rootPanelControl)
			{
				EntityPanelControl entityPanelControl = sender as EntityPanelControl;
				if (entityPanelControl != null && entityPanelControl.Tag != null)
				{
					EntityPanelControl dataSourcePanelControl = ((EntityMainFormEntityPanelControlTag)entityPanelControl.Tag).EntityPanelControlBinding.DataSourcePanelControl;
					CustName.AppName.BL.BaseEntityObject entityObject;
					e.ReadOnly = (((entityObject = dataSourcePanelControl.SelectedItem) == null) || entityObject.MarkedForDeletion || ((entityObject = this.rootPanelControl.SelectedItem) == null) || entityObject.MarkedForDeletion);
				}
			}
		}

		protected virtual void PanelControl_ToolBarButtonClick(object sender, ToolBarButtonClickEventArgs e)
		{
			int button = e.Button;
			if (button == PanelControl.OBJECT_LIST_PANEL_TOGGLE || button == PanelControl.PANEL1_TOGGLE)
			{
				foreach (PanelControl panelControl in this.panelControlList)
					panelControl.ConfigureButton(button);
			}
		}

		#endregion

		protected virtual void DataBind(List<EntityPanelControlBinding> entityPanelControlBindingList)
		{
			{
				foreach (EntityPanelControlBinding entityPanelControlBinding in entityPanelControlBindingList)
					((System.ComponentModel.ISupportInitialize)(entityPanelControlBinding.PanelControl.bindingSource)).BeginInit();
			}
			{
				// Configure the root panel.
				EntityPanelControlBinding entityPanelControlBinding;
				EntityPanelControl entityPanelControl;
				entityPanelControlBinding = entityPanelControlBindingList[0];
				entityPanelControl = entityPanelControlBinding.PanelControl;
				entityPanelControl.Tag = new EntityMainFormEntityPanelControlTag { EntityPanelControlBinding = entityPanelControlBinding };
				this.rootPanelControl = entityPanelControl;

				// Configure child panels.
				for (int index = 1; index < entityPanelControlBindingList.Count; ++index)
				{
					entityPanelControlBinding = entityPanelControlBindingList[index];
					entityPanelControl = entityPanelControlBinding.PanelControl;
					entityPanelControl.bindingSource.DataSource = entityPanelControlBinding.DataSourcePanelControl.bindingSource;
					entityPanelControl.bindingSource.DataMember = entityPanelControlBinding.DataMember;
					entityPanelControl.Tag = new EntityMainFormEntityPanelControlTag { EntityPanelControlBinding = entityPanelControlBinding };
				}
			}
			{
				foreach (EntityPanelControlBinding entityPanelControlBinding in entityPanelControlBindingList)
					((System.ComponentModel.ISupportInitialize)(entityPanelControlBinding.PanelControl.bindingSource)).EndInit();
			}
			DataBind_ObjectList();
		}

		protected virtual void DataBind_ObjectList()
		{
			// Bind the object list control to the root level BindingSource.
			this.objectListListBox.DataSource = this.rootPanelControl.bindingSource;
		}

		#region IForm interface

		event CustName.AppName.WinPL.OpenEntityObjectEventHandler IForm.OpenEntityObject
		{
			add
			{
				this.openEntityObject += value;
			}
			remove
			{
				this.openEntityObject -= value;
			}
		}

		void IForm.AddNew()
		{
			AddNew();
		}

		IEntityList IForm.EntityList
		{
			get
			{
				return this.EntityList;
			}
			set
			{
				this.EntityList = value;
			}
		}

		bool IForm.Save()
		{
			return Save();
		}

		void IForm.NotifyRepositoryChanged()
		{
			NotifyRepositoryChanged();
		}

		void IForm.Clear()
		{
			Clear();
		}

		bool IForm.HasUncommittedChanges()
		{
			return HasUncommittedChanges();
		}

		void IForm.EndEdit()
		{
			EndEdit();
		}

		void IForm.PrintPreview()
		{
			PrintPreview();
		}

		void IForm.Print()
		{
			Print();
		}

		#endregion

		#region IForm interface implementation

		protected virtual void AddNew()
		{
			if (this.EntityList == null)
				this.EntityList = CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(this.rootPanelControl.EntityClass);
			this.rootPanelControl.bindingSource.AddNew();
			this.rootPanelControl.bindingSource.EndEdit();
		}

		protected virtual IEntityList EntityList
		{
			get
			{
				return (this.rootPanelControl.bindingSource.DataSource as IEntityList);
			}
			set
			{
				if (value == null)
					this.rootPanelControl.bindingSource.DataSource = CustName.AppName.BL.Global.ClassFactory.GetEntityListType(this.rootPanelControl.EntityClass);
				else
					this.rootPanelControl.bindingSource.DataSource = (object)value;
			}
		}

		protected virtual void EndEdit()
		{
			// panelControlList is ordered such that for a given control, all child controls appear after it in the list.
			// Prior to calling EndEdit() for any given panel, EndEdit() must already have been called for all of its child panels.
			// Therefore, panelControlList is processed in reverse order.
			EntityPanelControl entityPanelControl;
			for (int index = this.panelControlList.Count - 1; index >= 0; --index)
			{
				if ((entityPanelControl = this.panelControlList[index] as EntityPanelControl) != null)
					entityPanelControl.EndEdit();
			}
		}

		protected virtual bool Save()
		{
			EndEdit();
			return Save(this.EntityList);
		}

		protected virtual bool Save(IEntityList entityList)
		{
			if (entityList == null) return true;

			List<IEntityObject> objectsToSave = new List<IEntityObject>();
			bool objectsToDeleteExist = false;
			foreach (IEntityObject entityObject in entityList)
			{
				if (entityObject.HasUncommittedChanges)
				{
					objectsToSave.Add(entityObject);
					if (!objectsToDeleteExist && entityObject.MarkedForDeletion) objectsToDeleteExist = true;
				}
			}
			List<IEntityObject> objectsToDelete = null;
			if (objectsToDeleteExist)
			{
				objectsToDelete = new List<IEntityObject>();
				foreach (IEntityObject entityObject in objectsToSave)
				{
					if (entityObject.MarkedForDeletion) objectsToDelete.Add(entityObject);
				}
			}

			OnBeforeSave(objectsToSave, objectsToDelete);

			bool exceptionDetected = false;
			if (objectsToSave.Count > 0)
			{
				try
				{
					this.Cursor = Cursors.WaitCursor;
					CustName.AppName.BL.Global.ClassFactory.GetDALRepository().Save(objectsToSave, this.ignoreCollision);
					ExtendedSave(objectsToSave, objectsToDelete);
					if (objectsToDelete != null)
					{
						foreach (IEntityObject entityObject in objectsToDelete)
						{
							entityList.Remove(entityObject);
						}
					}
				}
				catch (Exception e)
				{
					exceptionDetected = true;
					this.Cursor = Cursors.Default;
					AppExceptionForm appExceptionForm = (AppExceptionForm)CustName.AppName.WinPL.Global.ClassFactory.GetAppExceptionForm("Error saving object.", e);
					appExceptionForm.ShowDialog();
				}
				this.Cursor = Cursors.Default;
			}

			OnAfterSave(objectsToSave, objectsToDelete);

			return !exceptionDetected;
		}

		protected virtual void ExtendedSave(List<IEntityObject> objectsToSave, List<IEntityObject> objectsToDelete)
		{
		}

		protected virtual void OnBeforeSave(List<IEntityObject> objectsToSave, List<IEntityObject> objectsToDelete)
		{
		}

		protected virtual void OnAfterSave(List<IEntityObject> savedObjects, List<IEntityObject> deletedObjects)
		{
		}

		protected virtual void NotifyRepositoryChanged()
		{
			LoadSupportingData();
		}

		protected virtual void Clear()
		{
			// Not applicable to main forms.
			throw new NotSupportedException();
		}

		protected virtual bool HasUncommittedChanges()
		{
			EndEdit();
			IEntityList entityList = this.EntityList;
			if (entityList != null)
			{
				foreach (IEntityObject entityObject in entityList)
				{
					if (entityObject.HasUncommittedChanges)
						return true;
				}
			}
			return false;
		}

		protected virtual void PrintPreview()
		{
			if (this.rootPanelControl.FormView_LayoutControl != null)
			{
				if (!this.rootPanelControl.FormView_LayoutControl.IsPrintingAvailable)
					DevExpress.XtraEditors.XtraMessageBox.Show("The XtraPrinting dll was not found.");
				else
					this.rootPanelControl.FormView_LayoutControl.ShowPrintPreview();
			}
		}

		protected virtual void Print()
		{
			if (this.rootPanelControl.FormView_LayoutControl != null)
			{
				if (!this.rootPanelControl.FormView_LayoutControl.IsPrintingAvailable)
					DevExpress.XtraEditors.XtraMessageBox.Show("The XtraPrinting dll was not found.");
				else
					this.rootPanelControl.FormView_LayoutControl.Print();
			}
		}

		#endregion

		protected virtual void LoadSupportingData()
		{
			foreach (PanelControl panelControl in this.panelControlList)
			{
				panelControl.LoadSupportingData();
			}
		}

		protected virtual void objectListListBox_DrawItem(object sender, DrawItemEventArgs e)
		{
			if (this.DesignMode1)
				return;
			if (e.Index != -1)
			{
				IEntityObject entityObject = (IEntityObject)this.objectListListBox.Items[e.Index];

				Color backColor;
				Color foreColor;
				Font font = this.objectListListBox.Font;
				bool listItemIsSelected;
				if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
				{
					listItemIsSelected = true;
					backColor = SystemColors.Highlight;
					foreColor = SystemColors.HighlightText;
				}
				else
				{
					listItemIsSelected = false;
					backColor = this.objectListListBox.BackColor;
					foreColor = this.objectListListBox.ForeColor;
				}
				if (entityObject.MarkedForDeletion)
				{
					font = new Font(font, FontStyle.Strikeout);
				}
				else if (entityObject.HasUncommittedChanges)
				{
					font = new Font(font, FontStyle.Bold);
				}

				e.DrawBackground();
				e.Graphics.FillRectangle(new SolidBrush(backColor), e.Bounds);
				e.Graphics.DrawString(((IEntityObject)this.objectListListBox.Items[e.Index]).ObjectPrimaryDescriptor, font, new SolidBrush(foreColor), new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
				if (listItemIsSelected) e.DrawFocusRectangle();
			}
		}

		protected virtual PanelControl GetPrimaryPanel(DevExpress.XtraTab.XtraTabPage tabPage)
		{
			PanelControl panelControl = null;
			foreach (Control tabPageChildControl in tabPage.Controls)
			{
				if (tabPageChildControl is PanelControl)
				{
					panelControl = (PanelControl)tabPageChildControl;
				}
				else if (tabPageChildControl is DevExpress.XtraEditors.SplitContainerControl)
				{
					foreach (Control splitContainerChildControl in ((DevExpress.XtraEditors.SplitContainerControl)tabPageChildControl).Panel1.Controls)
					{
						if (splitContainerChildControl is PanelControl)
						{
							panelControl = (PanelControl)splitContainerChildControl;
							break;
						}
					}
				}
				if (panelControl != null)
					break;
			}
			return panelControl;
		}

		// The list must be ordered such that for a given control, all child controls appear after it in the list.
		// Both depth-first and breath-first searches meet this criteria.
		// This is a depth-first implementation.
		public static void FindControls(Type type, bool includeSubclasses, System.Windows.Forms.Control.ControlCollection controls, List<Control> matchingControls)
		{
			if (includeSubclasses)
			{
				foreach (Control control in controls)
				{
					if (control.GetType() == type || control.GetType().IsSubclassOf(type))
						matchingControls.Add(control);
					FindControls(type, true, control.Controls, matchingControls);
				}
			}
			else
			{
				foreach (Control control in controls)
				{
					if (control.GetType() == type)
						matchingControls.Add(control);
					FindControls(type, false, control.Controls, matchingControls);
				}
			}
		}

	}
}
