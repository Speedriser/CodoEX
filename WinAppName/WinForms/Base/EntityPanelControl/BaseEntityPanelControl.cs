using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CustName.AppName.WinPL.MainForms
{
	public enum Cardinality
	{
		None,
		One,
		Many
	}

	// PanelEnablementMode is a setting that does not change unless explicitly set.
	// See this.panelEnablementMode.
	public enum PanelEnablementMode
	{
		Disabled, // All controls disabled. User interaction with controls not possible. AllowNew and AllowRemove settings ignored.
		ReadOnly, // All controls read only. Users can interact with controls but cannot update their values. For example, grid can be scrolled, edit values can be copied but not pasted. AllowNew and AllowRemove settings ignored.
		Enabled // Enablement controlled by the SelectionState. AllowNew and AllowRemove settings in effect.
	}

	// SelectionState is not a setting.
	// SelectionState is the record selection state determined by GetSelectionState().
	// SelectionState may be influenced by overriding GetSelectionReadOnlyStatus() or subscribing to the QuerySelectionReadOnlyStatus event.
	public enum SelectionState
	{
		// There is no currently selected entity object ...OR...
		// OnQuerySelectionReadOnlyStatus returned false for entity object.
		// OnQuerySelectionReadOnlyStatus calls GetSelectionReadOnlyStatus which can be overridden.
		EditableSelection,
		// There is a currently selected entity object AND it is marked deleted.
		LogicallyDeletedSelection,
		// There is a currently selected entity object ...AND...
		// OnQuerySelectionReadOnlyStatus returned true for the entity object.
		// OnQuerySelectionReadOnlyStatus calls GetSelectionReadOnlyStatus which can be overridden.
		ReadOnlySelection
	}

	// PanelEnablementState is not a setting.
	// PanelEnablementState is state derived from this.panelEnablementMode (PanelEnablementMode) and GetSelectionState() (SelectionState).
	// PanelEnablementState determines the actual enablement state of the controls.
	public enum PanelEnablementState
	{
		// PanelEnablementMode = Disabled. SelectionState not considered.
		Disabled,
		// PanelEnablementMode = ReadOnly. SelectionState not considered.
		ReadOnly,
		// PanelEnablementMode = Enabled. SelectionState = EditableSelection. AllowNew and AllowRemove in effect.
		SelectionEditable,
		// PanelEnablementMode = Enabled. SelectionState = LogicallyDeletedSelection. AllowNew and AllowRemove in effect.
		LogicallyDeletedSelection,
		// PanelEnablementMode = Enabled. SelectionState = ReadOnlySelection. AllowNew and AllowRemove in effect.
		SelectionReadOnly
	}

	[ToolboxItemAttribute(false)]
	public partial class BaseEntityPanelControl : CustName.AppName.WinPL.MainForms.PanelControl
	{
		public const int VIEW_MODE_TOGGLE = CustName.AppName.WinPL.MainForms.PanelControl.OBJECT_LIST_PANEL_TOGGLE + 1;

		public event CustName.AppName.WinPL.OpenEntityObjectEventHandler OpenEntityObject = null;
		public event QueryReadOnlyStatusEventHandler QueryPanelReadOnlyStatus = null;
		public event QueryReadOnlyStatusEventHandler QuerySelectionReadOnlyStatus = null;
		public event QueryReadOnlyStatusEventHandler QueryControlReadOnlyStatus = null;
		public event QueryReadOnlyStatusEventHandler QueryAllowAddNewState = null;
		public event QueryReadOnlyStatusEventHandler QueryAllowRemoveState = null;

		protected ViewMode viewMode = ViewMode.None;

		private const int GRID_VIEW_IMAGE_INDEX = 8;
		private const int FORM_VIEW_IMAGE_INDEX = 9;
		private const int CARD_VIEW_IMAGE_INDEX = 10;

		private bool allowAddNew = true;
		private bool allowRemove = true;
		private PanelEnablementMode panelEnablementMode = PanelEnablementMode.Enabled;
		private DevExpress.XtraBars.BarButtonItem viewToggleBarButtonItem;

		public BaseEntityPanelControl()
		{
			// Execute Designer generated initialization code.
			InitializeComponent();
			// Execute custom initialization code.
			// NOTE: This code is executed at design and run time.
			CustomInitializeComponent();
			// Also see OnLoad & CustomInitializeRuntimeComponent methods for runtime only initialization.
		}

		[DefaultValue(true)]
		public bool AllowAddNew
		{
			get
			{
				return this.allowAddNew;
			}
			set
			{
				this.allowAddNew = value;
			}
		}

		[DefaultValue(true)]
		public bool AllowRemove
		{
			get
			{
				return this.allowRemove;
			}
			set
			{
				this.allowRemove = value;
			}
		}

		protected virtual void bindingSource_CurrentChanged(object sender, EventArgs e)
		{
			// Make sure the form is put into read-only mode if the new selection is marked for deletion.
			SetPanelEnablementState();
		}

		protected virtual void bindingSource_ListChanged(object sender, ListChangedEventArgs e)
		{
			// Abort if control is in design mode.
			// Required because BindingSource control will raise ListChanged event when its DataSource method is changed in design mode.
			// Calling this event handler in design mode without the abort logic causes an error in the Visual Studio designer.
			if (this.DesignMode1)
				return;

			// e.PropertyDescriptor == null occurs when BindingSource.ResetItem is called.
			if (e.ListChangedType == ListChangedType.ItemChanged && e.PropertyDescriptor != null)
			{
				if (e.PropertyDescriptor.Name == "MarkedForDeletion")
				{
					// This change only impacts the UI if the object that is marked for deletion is the currently selected one.
					// Make sure the panel is put into read-only mode if the current item is marked for deletion from the repository.
					if (this.bindingSource.List[e.NewIndex] == this.SelectedItem) // Is the changed object the same as the logically deleted object?
						SetPanelEnablementState();
				}
			}
			else if (e.ListChangedType == ListChangedType.Reset)
			{
				SetPanelEnablementState();
			}
		}

		public virtual Cardinality Cardinality
		{
			get
			{
				return Cardinality.None;
			}
		}

		// Returns the main CardView control defined by a subclass.
		public virtual DevExpress.XtraGrid.Views.Card.CardView CardView
		{
			get
			{
				return null;
			}
		}

		protected virtual void cardView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			// Navigating to or from the new card does not cause PositionChanged or CurrentChanged events to be raised by the BindingSource.
			// This logic is therefore needed to ensure that SetPanelEnablementState() is called under these circumstances.
			DevExpress.XtraGrid.Views.Card.CardView cardView = this.CardView;
			if (cardView.IsNewItemRow(e.FocusedRowHandle) || cardView.IsNewItemRow(e.PrevFocusedRowHandle))
				SetPanelEnablementState();
		}

		// Causes the control to configure itself in accordance with its related SplitContainer, FormView_LayoutControl and GridControl.
		public override void Configure()
		{
			base.Configure();
			DevExpress.XtraLayout.LayoutControl formView_LayoutControl = this.FormView_LayoutControl;
			DevExpress.XtraGrid.GridControl gridControl = this.GridControl;
			SetButtonVisibility(VIEW_MODE_TOGGLE, gridControl != null);
			if (formView_LayoutControl != null || gridControl != null)
			{
				if (this.DefaultViewMode == ViewMode.None)
				{
					if (this.Cardinality == Cardinality.One || !this.IsNestedPanel)
					{
						// Form view preferred.
						if (formView_LayoutControl == null)
							SetViewMode(ViewMode.Grid);
						else
							SetViewMode(ViewMode.Form);
					}
					else
					{
						// Grid view preferred.
						if (gridControl == null)
							SetViewMode(ViewMode.Form);
						else
							SetViewMode(ViewMode.Grid);
					}
				}
				else
					SetViewMode(this.DefaultViewMode);
			}
		}

		private void CustomInitializeComponent()
		{
			//
			// The following changes to the barManger/bar were written by hand because those components are inherited from the base PanelControl and are locked when this control is opened in the Visual Studio designer.
			//
			this.viewToggleBarButtonItem = new DevExpress.XtraBars.BarButtonItem();
			((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
			this.SuspendLayout();
			//
			// barManager
			//
			this.barManager.Items.Insert(0, this.viewToggleBarButtonItem);
			++this.barManager.MaxItemId;
			//
			// bar
			//
			this.bar.LinksPersistInfo.Insert(0, new DevExpress.XtraBars.LinkPersistInfo(this.viewToggleBarButtonItem));
			//
			// viewToggleBarButtonItem
			//
			this.viewToggleBarButtonItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
			this.viewToggleBarButtonItem.Caption = "View Toggle";
			this.viewToggleBarButtonItem.Description = "View Toggle";
			this.viewToggleBarButtonItem.Hint = "Switch to Form View";
			this.viewToggleBarButtonItem.Id = this.barManager.MaxItemId - 1;
			this.viewToggleBarButtonItem.ImageIndex = FORM_VIEW_IMAGE_INDEX;
			this.viewToggleBarButtonItem.Name = "viewToggleBarButtonItem";
			this.viewToggleBarButtonItem.Tag = "View";
			this.viewToggleBarButtonItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.viewModeToggleBarButtonItem_ItemClick);

			((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
			this.ResumeLayout(false);
		}

		// Workaround to address issue with DesignMode attribute (Knowledge Base KB 839202).
		// DesignMode property for a control does not return correct value when control used as part if a derived control.
		// Returns true if this control or any of its ancestors is in design mode.
		protected override bool DesignMode1
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

		protected virtual void dataNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
		{
			if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
			{
				CustName.AppName.BL.BaseEntityObject selectedEntityObject = this.SelectedItem;
				if (selectedEntityObject != null && selectedEntityObject.EntityType == CustName.AppName.DAL.EntityType.Independent && selectedEntityObject.ObjectStatus != CustName.AppName.DAL.ObjectStatus.New)
				{
					// The entity object exists in the repository i.e. has been saved before.
					// Only allow logical deletions.
					if (selectedEntityObject.MarkedForDeletion)
						selectedEntityObject.DecrementDeleteCount();
					else
						selectedEntityObject.IncrementDeleteCount();
					e.Handled = true; // Inform DataNavigator not to perform standard action.
				}
			}
		}

		public virtual CustName.AppName.DAL.EntityClass EntityClass
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		protected virtual ViewMode DefaultViewMode
		{
			get
			{
				return ViewMode.None;
			}
		}

		public virtual void EndEdit()
		{
			DevExpress.XtraGrid.GridControl gridControl = this.GridControl;
			if (gridControl != null)
				(gridControl.FocusedView as DevExpress.XtraGrid.Views.Base.ColumnView).CloseEditor();
			this.bindingSource.EndEdit();
		}

		public virtual bool GetAllowAddNewState(bool newRow)
		{
			if (this.Cardinality == Cardinality.Many)
			{
				return this.AllowAddNew;
			}
			else
			{
				// Veto result if cardinality one and object already exists.
				return (this.AllowAddNew && this.bindingSource.Count == 0); // Use BindingSource Count, not ((IList)this.bindingSource.DataSource).Count, because the former returns the count of the collection identified by both the DataSource and DataMember properties of BindingSource.
			}
		}

		public virtual bool GetAllowRemoveState(CustName.AppName.BL.BaseEntityObject entityObject, bool newRow)
		{
			return this.AllowRemove; // Allow records to be removed by default.
		}

		public virtual PanelEnablementMode GetPanelEnablementMode()
		{
			if (this.PanelEnablementMode == PanelEnablementMode.Disabled)
			{
				return PanelEnablementMode.Disabled;
			}
			else
			{
				if (PerformQueryPanelReadOnlyStatus(this.PanelEnablementMode == PanelEnablementMode.ReadOnly))
					return PanelEnablementMode.ReadOnly;
				else
					return PanelEnablementMode.Enabled;
			}
		}

		public virtual bool GetControlReadOnlyStatus(CustName.AppName.BL.BaseEntityObject entityObject, string controlName)
		{
			return GetControlReadOnlyStatus(entityObject, controlName, this.bindingSource.List != null && IsNewRowSelected(), false); // Use List instead of DataSource because List takes both DataSource and DataMember into account.
		}

		public virtual bool GetControlReadOnlyStatus(string controlName)
		{
			CustName.AppName.BL.BaseEntityObject selectedEntityObject;
			if (this.bindingSource.List != null && this.bindingSource.Count > 0) // Use BindingSource Count, not ((IList)this.bindingSource.DataSource).Count, because the former returns the count of the collection identified by both the DataSource and DataMember properties of BindingSource.
				selectedEntityObject = this.SelectedItem;
			else
				selectedEntityObject = null;

			return GetControlReadOnlyStatus(selectedEntityObject, controlName);
		}

		public virtual bool GetControlReadOnlyStatus(CustName.AppName.BL.BaseEntityObject entityObject, string controlName, bool newRow, bool defaultStatus)
		{
			return defaultStatus;
		}

		public bool GetPanelReadOnlyStatus()
		{
			return GetPanelReadOnlyStatus(false);
		}

		public virtual bool GetPanelReadOnlyStatus(bool defaultStatus)
		{
			return defaultStatus;
		}

		public virtual bool GetSelectionReadOnlyStatus(CustName.AppName.BL.BaseEntityObject entityObject)
		{
			return false; // Selection is not read only by default.
		}

		// Returns the GridControl control defined by a subclass.
		// The GridControl control constitutes the Datasheet View.
		public virtual DevExpress.XtraGrid.GridControl GridControl
		{
			get
			{
				return null;
			}
		}

		// Returns the main GridView control defined by a subclass.
		public virtual DevExpress.XtraGrid.Views.Grid.GridView GridView
		{
			get
			{
				return null;
			}
		}

		protected virtual void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			// Navigating to or from the new row does not cause PositionChanged or CurrentChanged events to be raised by the BindingSource.
			// This logic is therefore needed to ensure that SetPanelEnablementState() is called under these circumstances.
			DevExpress.XtraGrid.Views.Grid.GridView gridView = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
			if (gridView.IsNewItemRow(e.FocusedRowHandle) || gridView.IsNewItemRow(e.PrevFocusedRowHandle))
				SetPanelEnablementState();
		}

		public void HideDataNavigator()
		{
			this.dataNavigator.Visible = false;
		}

		public virtual bool IsNewRowSelected()
		{
			DevExpress.XtraGrid.Views.Base.ColumnView mainView = this.MainView;
			if (mainView == null)
				return false; // Impossible for a new row to be selected if there is no grid.
			else
				return mainView.IsNewItemRow(mainView.FocusedRowHandle);
		}

		public DevExpress.XtraGrid.Views.Base.ColumnView MainView
		{
			get
			{
				DevExpress.XtraGrid.GridControl gridControl = this.GridControl;
				if (gridControl == null)
					return null;
				else
					return gridControl.MainView as DevExpress.XtraGrid.Views.Base.ColumnView;
			}
		}

		public override void NotifyFirstActivation()
		{
			DevExpress.XtraGrid.Views.Grid.GridView gridView = this.GridView;
			if (gridView != null)
				gridView.BestFitColumns();
		}

		public virtual void OnQueryAllowAddNewState(QueryReadOnlyStatusEventArgs e)
		{
			if (QueryAllowAddNewState != null)
				QueryAllowAddNewState(this, e);
		}

		public virtual void OnQueryAllowRemoveState(QueryReadOnlyStatusEventArgs e)
		{
			if (QueryAllowRemoveState != null)
				QueryAllowRemoveState(this, e);
		}

		public virtual void OnQueryControlReadOnlyStatus(QueryReadOnlyStatusEventArgs e)
		{
			if (QueryControlReadOnlyStatus != null)
				QueryControlReadOnlyStatus(this, e);
		}

		protected virtual void OnOpenEntityObject(CustName.AppName.WinPL.OpenEntityObjectEventArgs e)
		{
			if (OpenEntityObject != null)
				OpenEntityObject(this, e);
		}

		public virtual void OnQueryPanelReadOnlyStatus(QueryReadOnlyStatusEventArgs e)
		{
			if (QueryPanelReadOnlyStatus != null)
				QueryPanelReadOnlyStatus(this, e);
		}

		public virtual void OnQuerySelectionReadOnlyStatus(QueryReadOnlyStatusEventArgs e)
		{
			if (QuerySelectionReadOnlyStatus != null)
				QuerySelectionReadOnlyStatus(this, e);
		}

		protected virtual void OnViewModeChange(ViewMode viewMode)
		{
		}

		[DefaultValue(PanelEnablementMode.Enabled)]
		public virtual PanelEnablementMode PanelEnablementMode
		{
			get
			{
				return this.panelEnablementMode;
			}
			set
			{
				this.panelEnablementMode = value;
			}
		}

		private bool PerformQueryAllowAddNewState(bool newRow)
		{
			bool allowAddNew = this.GetAllowAddNewState(newRow);
			if (QueryAllowAddNewState == null)
				return allowAddNew;
			else
			{
				QueryReadOnlyStatusEventArgs e = new QueryReadOnlyStatusEventArgs(null, null, newRow, !allowAddNew);
				OnQueryAllowAddNewState(e);
				return !e.ReadOnly;
			}
		}

		private bool PerformQueryAllowRemoveState(CustName.AppName.BL.BaseEntityObject entityObject, bool newRow)
		{
			bool allowRemove = this.GetAllowRemoveState(entityObject, newRow);
			if (QueryAllowRemoveState == null)
				return allowRemove;
			else
			{
				QueryReadOnlyStatusEventArgs e = new QueryReadOnlyStatusEventArgs(entityObject, null, newRow, !allowRemove);
				OnQueryAllowRemoveState(e);
				return !e.ReadOnly;
			}
		}

		private bool PerformQueryControlReadOnlyStatus(CustName.AppName.BL.BaseEntityObject entityObject, string controlName, bool newRow, bool defaultStatus)
		{
			bool readOnly = GetControlReadOnlyStatus(entityObject, controlName, newRow, defaultStatus);
			if (QueryControlReadOnlyStatus == null)
				return readOnly;
			else
			{
				QueryReadOnlyStatusEventArgs e = new QueryReadOnlyStatusEventArgs(entityObject, controlName, newRow, readOnly);
				OnQueryControlReadOnlyStatus(e);
				return e.ReadOnly;
			}
		}

		private bool PerformQueryPanelReadOnlyStatus(bool defaultStatus)
		{
			bool readOnly = GetPanelReadOnlyStatus(defaultStatus);
			if (QueryPanelReadOnlyStatus == null)
				return readOnly;
			else
			{
				QueryReadOnlyStatusEventArgs e = new QueryReadOnlyStatusEventArgs(null, null, false, readOnly);
				OnQueryPanelReadOnlyStatus(e);
				return e.ReadOnly;
			}
		}

		private bool PerformQuerySelectionReadOnlyStatus(CustName.AppName.BL.BaseEntityObject entityObject)
		{
			bool readOnly = GetSelectionReadOnlyStatus(entityObject);
			if (QuerySelectionReadOnlyStatus == null)
				return readOnly;
			else
			{
				QueryReadOnlyStatusEventArgs e = new QueryReadOnlyStatusEventArgs(entityObject, null, false, readOnly);
				OnQuerySelectionReadOnlyStatus(e);
				return e.ReadOnly;
			}
		}

		// Returns the preferred height of the control taking into account the vertical space required by the FormView_LayoutControl (Form view) control to display all child controls.
		public override int PreferredHeight
		{
			get
			{
				DevExpress.XtraLayout.LayoutControl formView_LayoutControl = this.FormView_LayoutControl;
				DevExpress.XtraGrid.GridControl gridControl = this.GridControl;
				if (formView_LayoutControl == null)
					return gridControl.PreferredSize.Height;
				else
					return (this.Height - formView_LayoutControl.Height) + formView_LayoutControl.PreferredSize.Height;
			}
		}

		public virtual CustName.AppName.BL.BaseEntityObject SelectedItem
		{
			get
			{
				return (this.bindingSource.Current as CustName.AppName.BL.BaseEntityObject);
			}
		}

		public override void SetButtonVisibility(int button, bool visibility)
		{
			if (button == VIEW_MODE_TOGGLE)
			{
				if (visibility)
					this.viewToggleBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
				else
					this.viewToggleBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
			}
			else
				base.SetButtonVisibility(button, visibility);
		}

		public virtual void SetPanelEnablementState()
		{
			DevExpress.XtraEditors.BaseEdit baseEditControl;
			bool newRow = IsNewRowSelected();
			PanelEnablementMode panelEnablementMode = GetPanelEnablementMode();
			PanelEnablementState panelEnablementState;
			CustName.AppName.BL.BaseEntityObject selectedEntityObject;
			DevExpress.XtraLayout.LayoutControl formView_LayoutControl = this.FormView_LayoutControl;
			DevExpress.XtraGrid.GridControl gridControl = this.GridControl;
			DevExpress.XtraGrid.Views.Card.CardView cardView = this.CardView;
			DevExpress.XtraGrid.Views.Grid.GridView gridView = this.GridView;


			// Use List instead of DataSource because List takes both DataSource and DataMember into account.
			// Use BindingSource Count, not ((IList)this.bindingSource.DataSource).Count, because the former returns the count of the collection identified by both the DataSource and DataMember properties of BindingSource.
			if (this.bindingSource.List != null && !newRow && this.bindingSource.Count > 0)
				selectedEntityObject = this.SelectedItem;
			else
				selectedEntityObject = null;

			switch (panelEnablementMode)
			{
				case PanelEnablementMode.Enabled:
					if (selectedEntityObject == null)
					{
						panelEnablementState = PanelEnablementState.SelectionEditable;
					}
					else
					{
						if (selectedEntityObject.MarkedForDeletion)
							panelEnablementState = PanelEnablementState.LogicallyDeletedSelection;
						else if (PerformQuerySelectionReadOnlyStatus(selectedEntityObject))
							panelEnablementState = PanelEnablementState.SelectionReadOnly;
						else
							panelEnablementState = PanelEnablementState.SelectionEditable;
					}
					break;
				case PanelEnablementMode.ReadOnly:
					panelEnablementState = PanelEnablementState.ReadOnly;
					break;
				default: // PanelEnablementMode.Disabled
					panelEnablementState = PanelEnablementState.Disabled;
					break;
			}

			switch (panelEnablementState)
			{
				case PanelEnablementState.Disabled:
					//
					// Configure the data navigator.
					//
					this.dataNavigator.Buttons.Append.Enabled = false;
					this.dataNavigator.Buttons.Remove.Enabled = false;
					this.dataNavigator.Buttons.CancelEdit.Enabled = false;
					this.dataNavigator.Buttons.EndEdit.Enabled = false;
					//
					// Configure grid control (if there is one).
					//
					if (gridView != null)
					{
						gridControl.Enabled = false;
						gridView.OptionsBehavior.Editable = true;
						foreach (DevExpress.XtraGrid.Columns.GridColumn gridColumn in gridView.Columns)
						{
							gridColumn.OptionsColumn.ReadOnly = false;
						}
					}
					if (cardView != null)
					{
						gridControl.Enabled = false;
						cardView.OptionsBehavior.Editable = true;
						foreach (DevExpress.XtraGrid.Columns.GridColumn gridColumn in cardView.Columns)
						{
							gridColumn.OptionsColumn.ReadOnly = false;
						}
					}
					//
					// Configure form view controls.
					//
					foreach (Control control in formView_LayoutControl.Controls)
					{
						control.Enabled = false;
						if ((baseEditControl = control as DevExpress.XtraEditors.BaseEdit) != null)
						{
							baseEditControl.Properties.ReadOnly = false;
						}
					}
					break;
				case PanelEnablementState.ReadOnly:
					//
					// Configure the data navigator.
					//
					this.dataNavigator.Buttons.Append.Enabled = false;
					this.dataNavigator.Buttons.Remove.Enabled = false;
					this.dataNavigator.Buttons.CancelEdit.Enabled = false;
					this.dataNavigator.Buttons.EndEdit.Enabled = false;
					//
					// Configure grid control (if there is one).
					//
					if (gridView != null)
					{
						gridControl.Enabled = true;
						gridView.OptionsBehavior.Editable = true;
						foreach (DevExpress.XtraGrid.Columns.GridColumn gridColumn in gridView.Columns)
						{
							gridColumn.OptionsColumn.ReadOnly = true;
						}
					}
					if (cardView != null)
					{
						gridControl.Enabled = true;
						cardView.OptionsBehavior.Editable = true;
						foreach (DevExpress.XtraGrid.Columns.GridColumn gridColumn in cardView.Columns)
						{
							gridColumn.OptionsColumn.ReadOnly = true;
						}
					}
					//
					// Configure form view controls.
					//
					foreach (Control control in formView_LayoutControl.Controls)
					{
						control.Enabled = true;
						if ((baseEditControl = control as DevExpress.XtraEditors.BaseEdit) != null)
						{
							baseEditControl.Properties.ReadOnly = true;
						}
					}
					break;
				case PanelEnablementState.SelectionEditable:
					//
					// Configure the data navigator.
					//
					this.dataNavigator.Buttons.Append.Enabled = PerformQueryAllowAddNewState(newRow);
					this.dataNavigator.Buttons.Remove.Enabled = PerformQueryAllowRemoveState(selectedEntityObject, newRow);
					this.dataNavigator.Buttons.CancelEdit.Enabled = true;
					this.dataNavigator.Buttons.EndEdit.Enabled = true;
					//
					// Configure grid control (if there is one).
					//
					if (gridView != null)
					{
						gridControl.Enabled = true;
						gridView.OptionsBehavior.Editable = true;
						foreach (DevExpress.XtraGrid.Columns.GridColumn gridColumn in gridView.Columns)
						{
							gridColumn.OptionsColumn.ReadOnly = PerformQueryControlReadOnlyStatus(selectedEntityObject, gridColumn.Name, newRow, false);
						}
					}
					if (cardView != null)
					{
						gridControl.Enabled = true;
						cardView.OptionsBehavior.Editable = true;
						foreach (DevExpress.XtraGrid.Columns.GridColumn gridColumn in cardView.Columns)
						{
							gridColumn.OptionsColumn.ReadOnly = PerformQueryControlReadOnlyStatus(selectedEntityObject, gridColumn.Name, newRow, false);
						}
					}
					//
					// Configure form view controls.
					//
					foreach (Control control in formView_LayoutControl.Controls)
					{
						control.Enabled = true;
						if ((baseEditControl = control as DevExpress.XtraEditors.BaseEdit) != null)
						{
							// (selectedEntityObject == null) is needed because form controls, unlike the grid, cannot auto create an entity object when typed into.
							baseEditControl.Properties.ReadOnly = ((selectedEntityObject == null) || PerformQueryControlReadOnlyStatus(selectedEntityObject, control.Name, newRow, false));
						}
					}
					break;
				case PanelEnablementState.LogicallyDeletedSelection:
					//
					// Configure the data navigator.
					//
					this.dataNavigator.Buttons.Append.Enabled = PerformQueryAllowAddNewState(newRow);
					this.dataNavigator.Buttons.Remove.Enabled = PerformQueryAllowRemoveState(selectedEntityObject, newRow);
					this.dataNavigator.Buttons.CancelEdit.Enabled = true;
					this.dataNavigator.Buttons.EndEdit.Enabled = true;
					//
					// Configure grid control (if there is one).
					//
					if (gridView != null)
					{
						gridControl.Enabled = true;
						gridView.OptionsBehavior.Editable = true;
						foreach (DevExpress.XtraGrid.Columns.GridColumn gridColumn in gridView.Columns)
						{
							gridColumn.OptionsColumn.ReadOnly = true;
						}
					}
					if (cardView != null)
					{
						gridControl.Enabled = true;
						cardView.OptionsBehavior.Editable = true;
						foreach (DevExpress.XtraGrid.Columns.GridColumn gridColumn in cardView.Columns)
						{
							gridColumn.OptionsColumn.ReadOnly = true;
						}
					}
					//
					// Configure form view controls.
					//
					foreach (Control control in formView_LayoutControl.Controls)
					{
						control.Enabled = true;
						if ((baseEditControl = control as DevExpress.XtraEditors.BaseEdit) != null)
						{
							baseEditControl.Properties.ReadOnly = true;
						}
					}
					break;
				case PanelEnablementState.SelectionReadOnly:
					//
					// Configure the data navigator.
					//
					this.dataNavigator.Buttons.Append.Enabled = PerformQueryAllowAddNewState(newRow);
					this.dataNavigator.Buttons.Remove.Enabled = PerformQueryAllowRemoveState(selectedEntityObject, newRow);
					this.dataNavigator.Buttons.CancelEdit.Enabled = true;
					this.dataNavigator.Buttons.EndEdit.Enabled = true;
					//
					// Configure grid control (if there is one).
					//
					if (gridView != null)
					{
						gridControl.Enabled = true;
						gridView.OptionsBehavior.Editable = true;
						foreach (DevExpress.XtraGrid.Columns.GridColumn gridColumn in gridView.Columns)
						{
							gridColumn.OptionsColumn.ReadOnly = PerformQueryControlReadOnlyStatus(selectedEntityObject, gridColumn.Name, newRow, true);
						}
					}
					if (cardView != null)
					{
						gridControl.Enabled = true;
						cardView.OptionsBehavior.Editable = true;
						foreach (DevExpress.XtraGrid.Columns.GridColumn gridColumn in cardView.Columns)
						{
							gridColumn.OptionsColumn.ReadOnly = PerformQueryControlReadOnlyStatus(selectedEntityObject, gridColumn.Name, newRow, true);
						}
					}
					//
					// Configure form view controls.
					//
					foreach (Control control in formView_LayoutControl.Controls)
					{
						control.Enabled = true;
						if ((baseEditControl = control as DevExpress.XtraEditors.BaseEdit) != null)
						{
							baseEditControl.Properties.ReadOnly = PerformQueryControlReadOnlyStatus(selectedEntityObject, control.Name, newRow, true);
						}
					}
					break;
			}
		}

		// Applies the given ViewMode setting regardless of the current ViewMode setting.
		public virtual void SetViewMode(ViewMode viewMode)
		{
			if (this.viewMode == ViewMode.Card || this.viewMode == ViewMode.Grid)
				this.EndEdit();
			this.viewMode = viewMode;
			DevExpress.XtraLayout.LayoutControl formView_LayoutControl = this.FormView_LayoutControl;
			DevExpress.XtraGrid.GridControl gridControl = this.GridControl;
			switch (this.viewMode)
			{
				case ViewMode.Form:
					this.viewToggleBarButtonItem.Hint = "Switch to Grid View";
					this.viewToggleBarButtonItem.ImageIndex = GRID_VIEW_IMAGE_INDEX;
					if (gridControl != null)
					{
						gridControl.Visible = false;
						gridControl.SendToBack();
					}
					formView_LayoutControl.BringToFront();
					formView_LayoutControl.Visible = true;
					break;
				case ViewMode.Grid:
					this.viewToggleBarButtonItem.Hint = "Switch to Card View";
					this.viewToggleBarButtonItem.ImageIndex = CARD_VIEW_IMAGE_INDEX;
					formView_LayoutControl.Visible = false;
					formView_LayoutControl.SendToBack();
					if (gridControl != null)
					{
						//DevExpress.XtraGrid.Views.Base.BaseView view = gridControl.MainView;
						//int dataSourceRowIndex = -1;
						//int focusedRowHandle = view.FocusedRowHandle;
						//if (focusedRowHandle != gridControl.InvalidRowHandle)
						//    dataSourceRowIndex = view.GetDataSourceRowIndex(focusedRowHandle);
						int dataSourceRowIndex = this.bindingSource.Position;
						DevExpress.XtraGrid.Views.Base.ColumnView view = (DevExpress.XtraGrid.Views.Base.ColumnView)this.GridView;
						gridControl.MainView = (DevExpress.XtraGrid.Views.Base.BaseView)view;
						if (dataSourceRowIndex != -1)
							view.FocusedRowHandle = view.GetRowHandle(dataSourceRowIndex);
						gridControl.BringToFront();
						gridControl.Visible = true;
					}
					break;
				case ViewMode.Card:
					this.viewToggleBarButtonItem.Hint = "Switch to Form View";
					this.viewToggleBarButtonItem.ImageIndex = FORM_VIEW_IMAGE_INDEX;
					formView_LayoutControl.Visible = false;
					formView_LayoutControl.SendToBack();
					if (gridControl != null)
					{
						int dataSourceRowIndex = this.bindingSource.Position;
						DevExpress.XtraGrid.Views.Base.ColumnView view = (DevExpress.XtraGrid.Views.Base.ColumnView)this.CardView;
						gridControl.MainView = (DevExpress.XtraGrid.Views.Base.BaseView)view;
						if (dataSourceRowIndex != -1)
							view.FocusedRowHandle = view.GetRowHandle(dataSourceRowIndex);
						gridControl.BringToFront();
						gridControl.Visible = true;
					}
					break;
			}
		}

		public void ShowDataNavigator()
		{
			this.dataNavigator.Visible = true;
		}

		public void ToggleDataNavigatorVisibility()
		{
			if (this.dataNavigator.Visible)
				HideDataNavigator();
			else
				ShowDataNavigator();
		}

		protected virtual ViewMode GetNextAvailableViewMode()
		{
			DevExpress.XtraLayout.LayoutControl formView_LayoutControl = this.FormView_LayoutControl;
			DevExpress.XtraGrid.GridControl gridControl = this.GridControl;
			DevExpress.XtraGrid.Views.Grid.GridView gridView;
			DevExpress.XtraGrid.Views.Card.CardView cardView;
			if (gridControl == null)
			{
				gridView = null;
				cardView = null;
			}
			else
			{
				gridView = this.GridView;
				cardView = this.CardView;
			}

			ViewMode availableViewMode = ViewMode.None;
			switch (this.ViewMode)
			{
				case ViewMode.Form:
					if (gridView != null)
						availableViewMode = ViewMode.Grid;
					else if (cardView != null)
						availableViewMode = ViewMode.Card;
					else if (formView_LayoutControl != null)
						availableViewMode = ViewMode.Form;
					break;
				case ViewMode.Grid:
					if (cardView != null)
						availableViewMode = ViewMode.Card;
					else if (formView_LayoutControl != null)
						availableViewMode = ViewMode.Form;
					else if (gridView != null)
						availableViewMode = ViewMode.Grid;
					break;
				case ViewMode.Card:
					if (formView_LayoutControl != null)
						availableViewMode = ViewMode.Form;
					else if (gridView != null)
						availableViewMode = ViewMode.Grid;
					else if (cardView != null)
						availableViewMode = ViewMode.Card;
					break;
			}

			return availableViewMode;
		}

		// Switches the ViewMode from the current setting to the next setting (Form -> Grid -> Card -> Form etc).
		public virtual void ToggleViewMode()
		{
			this.ViewMode = GetNextAvailableViewMode();
		}

		// Gets or sets the ViewMode of the control.
		// The control may be in either Form View or Datasheet View mode.
		[DefaultValue(ViewMode.None)]
		public virtual ViewMode ViewMode
		{
			get
			{
				return this.viewMode;
			}
			set
			{
				if (this.viewMode != value)
				{
					SetViewMode(value);
					OnViewModeChange(this.viewMode);
				}
			}
		}

		protected void viewModeToggleBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			ToggleViewMode();
		}

		// Returns the View Mode Toggle button that is part of the base control.
		// The button is a custom addition to the DataNavigator control.
		public virtual DevExpress.XtraBars.BarButtonItem ViewModeToggleButton
		{
			get
			{
				return this.viewToggleBarButtonItem;
			}
		}

		public virtual void SetDefaultAppendFocus()
		{
		}

		// Summary:
		//     Occurs before an item is added to the underlying list.
		//
		// Exceptions:
		//   System.InvalidOperationException:
		//     System.ComponentModel.AddingNewEventArgs.NewObject is not the same type as
		//     the type contained in the list.
		public event AddingNewEventHandler AddingNew
		{
			add
			{
				this.bindingSource.AddingNew += value;
			}
			remove
			{
				this.bindingSource.AddingNew -= value;
			}
		}

		//
		// Summary:
		//     Occurs when the currently bound item changes.
		public event EventHandler CurrentChanged
		{
			add
			{
				this.bindingSource.CurrentChanged += value;
			}
			remove
			{
				this.bindingSource.CurrentChanged -= value;
			}
		}

		//
		// Summary:
		//     Occurs when a property value of the System.Windows.Forms.BindingSource.Current
		//     property has changed.
		public event EventHandler CurrentItemChanged
		{
			add
			{
				this.bindingSource.CurrentItemChanged += value;
			}
			remove
			{
				this.bindingSource.CurrentItemChanged -= value;
			}
		}

		//
		// Summary:
		//     Occurs when the underlying list changes or an item in the list changes.
		public event ListChangedEventHandler ListChanged
		{
			add
			{
				this.bindingSource.ListChanged += value;
			}
			remove
			{
				this.bindingSource.ListChanged -= value;
			}
		}

		//
		// Summary:
		//     Occurs after the value of the System.Windows.Forms.BindingSource.Position
		//     property has changed.
		public event EventHandler PositionChanged
		{
			add
			{
				this.bindingSource.PositionChanged += value;
			}
			remove
			{
				this.bindingSource.PositionChanged -= value;
			}
		}

	}

	public class QueryReadOnlyStatusEventArgs : EventArgs
	{
		private CustName.AppName.BL.BaseEntityObject entityObject;
		private string controlName;
		private bool newRow;
		private bool readOnly;

		public QueryReadOnlyStatusEventArgs(CustName.AppName.BL.BaseEntityObject entityObject, string controlName, bool newRow, bool defaultReadOnlySetting)
		{
			this.entityObject = entityObject;
			this.controlName = controlName;
			this.newRow = newRow;
			this.readOnly = defaultReadOnlySetting;
		}

		public CustName.AppName.BL.BaseEntityObject EntityObject
		{
			get
			{
				return this.entityObject;
			}
		}

		public string ControlName
		{
			get
			{
				return this.controlName;
			}
		}

		public bool NewRow
		{
			get
			{
				return this.newRow;
			}
		}

		public bool ReadOnly
		{
			get
			{
				return this.readOnly;
			}
			set
			{
				this.readOnly = value;
			}
		}
	}

	public delegate void QueryReadOnlyStatusEventHandler(object sender, QueryReadOnlyStatusEventArgs e);
}
