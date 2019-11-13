using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CustName.AppName.WinPL.MainForms
{
	[ToolboxItemAttribute(false)]
	public partial class BasePanelControl : DevExpress.XtraEditors.XtraUserControl
	{
		public const int PANEL1_TOGGLE = 0;
		public const int PANEL2_TOGGLE = 1;
		public const int OBJECT_LIST_PANEL_TOGGLE = 2;

		private bool nestedPanel = false;

		protected CustName.AppName.WinPL.MainForms.SplitContainerControl panel1ToggleSplitContainerControl = null;
		protected CustName.AppName.WinPL.MainForms.SplitContainerControl panel2ToggleSplitContainerControl = null;
		protected DevExpress.XtraEditors.SplitContainerControl objectListPanelToggleSplitContainerControl = null;

		public event CustName.AppName.WinPL.MainForms.ToolBarButtonClickEventHandler ToolBarButtonClick = null;

		public BasePanelControl()
		{
			// Execute Designer generated initialization code.
			InitializeComponent();
			// Execute custom initialization code.
			// NOTE: This code is executed at design and run time.
			//CustomInitializeComponent();
			// Also see OnLoad & CustomInitializeRuntimeComponent methods for runtime only initialization.
		}

		// Causes the control to configure itself in accordance with its related SplitContainer, FormView_LayoutControl and GridControl.
		public virtual void Configure()
		{
			this.nestedPanel = false;
			this.panel1ToggleSplitContainerControl = null;
			this.panel2ToggleSplitContainerControl = null;
			this.objectListPanelToggleSplitContainerControl = null;

			// Get the parent, grand parent and parent base SplitContainerControls of this BasePanelControl.
			int parentPanelNumber = 0;
			DevExpress.XtraEditors.SplitContainerControl parentSplitContainerControl = null;
			DevExpress.XtraEditors.SplitContainerControl grandParentSplitContainerControl = null;
			GetParentSplitContainerControls(this, ref parentSplitContainerControl, ref parentPanelNumber, ref grandParentSplitContainerControl, ref this.objectListPanelToggleSplitContainerControl);

			// Configure PANEL1_TOGGLE and PANEL2_TOGGLE buttons and nestedPanel indicator.
			if (parentSplitContainerControl == null || parentSplitContainerControl == this.objectListPanelToggleSplitContainerControl)
			{
				// There is no parent SplitContainerControl or the parent SplitContainerControl is the base SplitContainerControl.
				// There is no need for a panel 1/panel 2 toggle button(s) because this panel is not sitting on a SplitContainerControl or is sitting on the base SplitContainerControl that separates the Object List and Object Detail sections.
				SetButtonVisibility(PANEL1_TOGGLE, false);
				SetButtonVisibility(PANEL2_TOGGLE, false);
			}
			else
			{
				// BasePanelControl is inside a SplitContainerControl that is not the base SplitContainerControl.
				switch (parentPanelNumber)
				{
					case 1:
						// PANEL2_TOGGLE button has to be enabled because there must exist a panel 2 to show/hide.
						this.panel2ToggleSplitContainerControl = (CustName.AppName.WinPL.MainForms.SplitContainerControl)parentSplitContainerControl;
						SetButtonVisibility(PANEL2_TOGGLE, true);
						this.nestedPanel = (grandParentSplitContainerControl != null && grandParentSplitContainerControl != this.objectListPanelToggleSplitContainerControl);
						break;
					case 2:
						// PANEL2_TOGGLE button has to disabled because this panel is sitting in panel 2 of its parent SplitContainerControl.
						// Therefore, there is no panel 2 located under this panel to hide/show.
						SetButtonVisibility(PANEL2_TOGGLE, false);
						this.nestedPanel = true;
						break;
				}
				if (this.nestedPanel)
				{
					switch (parentPanelNumber)
					{
						case 1:
							this.panel1ToggleSplitContainerControl = (CustName.AppName.WinPL.MainForms.SplitContainerControl)grandParentSplitContainerControl;
							break;
						case 2:
							this.panel1ToggleSplitContainerControl = (CustName.AppName.WinPL.MainForms.SplitContainerControl)parentSplitContainerControl;
							break;
					}
					SetButtonVisibility(PANEL1_TOGGLE, true);
				}
				else
					SetButtonVisibility(PANEL1_TOGGLE, false);
			}
			ConfigureButton(PANEL1_TOGGLE);
			ConfigureButton(PANEL2_TOGGLE);

			// Configure the OBJECT_LIST_PANEL_TOGGLE button.
			SetButtonVisibility(OBJECT_LIST_PANEL_TOGGLE, this.objectListPanelToggleSplitContainerControl != null);
			ConfigureButton(OBJECT_LIST_PANEL_TOGGLE);
		}

		public virtual void ConfigureButton(int button)
		{
			switch (button)
			{
				case PANEL1_TOGGLE:
					if (this.panel1ToggleSplitContainerControl != null)
					{
						switch (this.panel1ToggleSplitContainerControl.PanelVisibility)
						{
							case SplitPanelVisibility.Both:
							case SplitPanelVisibility.Panel1:
								SetButtonState(PANEL1_TOGGLE, "HidePanel1");
								break;
							case SplitPanelVisibility.Panel2:
								SetButtonState(PANEL1_TOGGLE, "ShowPanel1");
								break;
						}
					}
					break;
				case PANEL2_TOGGLE:
					if (this.panel2ToggleSplitContainerControl != null)
					{
						switch (this.panel2ToggleSplitContainerControl.PanelVisibility)
						{
							case SplitPanelVisibility.Both:
							case SplitPanelVisibility.Panel2:
								SetButtonState(PANEL2_TOGGLE, "HidePanel2");
								break;
							case SplitPanelVisibility.Panel1:
								SetButtonState(PANEL2_TOGGLE, "ShowPanel2");
								break;
						}
					}
					break;
				case OBJECT_LIST_PANEL_TOGGLE:
					if (this.objectListPanelToggleSplitContainerControl != null)
					{
						switch (this.objectListPanelToggleSplitContainerControl.PanelVisibility)
						{
							case SplitPanelVisibility.Both:
							case SplitPanelVisibility.Panel1: // Should not occur.
								SetButtonState(OBJECT_LIST_PANEL_TOGGLE, "HideObjectListPanel");
								break;
							case SplitPanelVisibility.Panel2:
								SetButtonState(OBJECT_LIST_PANEL_TOGGLE, "ShowObjectListPanel");
								break;
						}
					}
					break;
			}
		}

		//private void CustomInitializeComponent()
		//{
		//}

		protected virtual void CustomInitializeRuntimeComponent()
		{
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

		// Returns the LayoutControl control defined by a subclass.
		// The LayoutControl control contains the controls making up the Form View.
		public virtual DevExpress.XtraLayout.LayoutControl FormView_LayoutControl
		{
			get
			{
				return null;
			}
		}

		public bool IsNestedPanel
		{
			get
			{
				return this.nestedPanel;
			}
		}

		public virtual void NotifyFirstActivation()
		{
		}

		public virtual void NotifyRepositoryChanged()
		{
			LoadSupportingData();
		}

		public virtual void LoadSupportingData()
		{
		}

		protected void objectListPanelToggleBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			CustName.AppName.WinPL.MainForms.ToolBarButtonClickEventArgs toolBarButtonClickEventArgs = new CustName.AppName.WinPL.MainForms.ToolBarButtonClickEventArgs(OBJECT_LIST_PANEL_TOGGLE);
			toolBarButtonClickEventArgs.OldState = (string)this.objectListPanelToggleBarButtonItem.Tag;
			SetObjectListPanelVisibility(toolBarButtonClickEventArgs.OldState == "ShowObjectListPanel");
			toolBarButtonClickEventArgs.NewState = (string)this.objectListPanelToggleBarButtonItem.Tag;
			OnToolBarButtonClick(toolBarButtonClickEventArgs);
		}

		// Returns the Object List Panel Toggle button.
		public virtual DevExpress.XtraBars.BarButtonItem ObjectListPanelToggleButton
		{
			get
			{
				return this.objectListPanelToggleBarButtonItem;
			}
		}

		// Raises the ToolBarButtonClick event by invoking the delegates.
		protected virtual void OnToolBarButtonClick(CustName.AppName.WinPL.MainForms.ToolBarButtonClickEventArgs e)
		{
			if (ToolBarButtonClick != null)
			{
				// Invokes the delegates.
				ToolBarButtonClick(this, e);
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			if (!DesignMode1)
				// Execute extended custom form initialization.
				CustomInitializeRuntimeComponent();
			base.OnLoad(e);
		}

		protected void panel1ToggleBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			CustName.AppName.WinPL.MainForms.ToolBarButtonClickEventArgs toolBarButtonClickEventArgs = new CustName.AppName.WinPL.MainForms.ToolBarButtonClickEventArgs(PANEL1_TOGGLE);
			toolBarButtonClickEventArgs.OldState = (string)this.panel1ToggleBarButtonItem.Tag;
			SetPanel1Visibility(toolBarButtonClickEventArgs.OldState == "ShowPanel1");
			toolBarButtonClickEventArgs.NewState = (string)this.panel1ToggleBarButtonItem.Tag;
			OnToolBarButtonClick(toolBarButtonClickEventArgs);
		}

		// Returns the Panel 1 Toggle button.
		public virtual DevExpress.XtraBars.BarButtonItem Panel1ToggleButton
		{
			get
			{
				return this.panel1ToggleBarButtonItem;
			}
		}

		protected void panel2ToggleBarButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
		{
			CustName.AppName.WinPL.MainForms.ToolBarButtonClickEventArgs toolBarButtonClickEventArgs = new CustName.AppName.WinPL.MainForms.ToolBarButtonClickEventArgs(PANEL2_TOGGLE);
			toolBarButtonClickEventArgs.OldState = (string)this.panel2ToggleBarButtonItem.Tag;
			SetPanel2Visibility(toolBarButtonClickEventArgs.OldState == "ShowPanel2");
			toolBarButtonClickEventArgs.NewState = (string)this.panel2ToggleBarButtonItem.Tag;
			OnToolBarButtonClick(toolBarButtonClickEventArgs);
		}

		// Returns the Panel 2 Toggle button.
		public virtual DevExpress.XtraBars.BarButtonItem Panel2ToggleButton
		{
			get
			{
				return this.panel2ToggleBarButtonItem;
			}
		}

		// Returns the preferred height of the control taking into account the vertical space required by the FormView_LayoutControl (Form view) control to display all child controls.
		public virtual int PreferredHeight
		{
			get
			{
				if (this.FormView_LayoutControl == null)
					return base.PreferredSize.Height;
				else
					return (this.Height - this.FormView_LayoutControl.Height) + this.FormView_LayoutControl.PreferredSize.Height;
			}
		}

		public virtual void SetButtonState(int button, string state)
		{
			switch (button)
			{
				case PANEL1_TOGGLE:
					switch (state)
					{
						case "HidePanel1":
							if (this.panel1ToggleSplitContainerControl == null || (this.panel1ToggleSplitContainerControl != null && !this.panel1ToggleSplitContainerControl.Horizontal))
							{
								this.panel1ToggleBarButtonItem.ImageIndex = 0;
								this.panel1ToggleBarButtonItem.Tag = "HidePanel1";
								this.panel1ToggleBarButtonItem.Hint = "Hide Upper Section";
							}
							else
							{
								this.panel1ToggleBarButtonItem.ImageIndex = 2;
								this.panel1ToggleBarButtonItem.Tag = "HidePanel1";
								this.panel1ToggleBarButtonItem.Hint = "Hide Left Section";
							}
							break;
						case "ShowPanel1":
							if (this.panel1ToggleSplitContainerControl == null || (this.panel1ToggleSplitContainerControl != null && !this.panel1ToggleSplitContainerControl.Horizontal))
							{
								this.panel1ToggleBarButtonItem.ImageIndex = 1;
								this.panel1ToggleBarButtonItem.Tag = "ShowPanel1";
								this.panel1ToggleBarButtonItem.Hint = "Show Upper Section";
							}
							else
							{
								this.panel1ToggleBarButtonItem.ImageIndex = 3;
								this.panel1ToggleBarButtonItem.Tag = "ShowPanel1";
								this.panel1ToggleBarButtonItem.Hint = "Show Right Section";
							}
							break;
					}
					break;
				case PANEL2_TOGGLE:
					switch (state)
					{
						case "HidePanel2":
							this.panel2ToggleBarButtonItem.ImageIndex = 4;
							this.panel2ToggleBarButtonItem.Tag = "HidePanel2";
							this.panel2ToggleBarButtonItem.Hint = "Maximize Section";
							break;
						case "ShowPanel2":
							this.panel2ToggleBarButtonItem.ImageIndex = 5;
							this.panel2ToggleBarButtonItem.Tag = "ShowPanel2";
							this.panel2ToggleBarButtonItem.Hint = "Show Lower Section";
							break;
					}
					break;
				case OBJECT_LIST_PANEL_TOGGLE:
					switch (state)
					{
						case "HideObjectListPanel":
							this.objectListPanelToggleBarButtonItem.ImageIndex = 6;
							this.objectListPanelToggleBarButtonItem.Tag = "HideObjectListPanel";
							this.objectListPanelToggleBarButtonItem.Hint = "Hide Item List";
							break;
						case "ShowObjectListPanel":
							this.objectListPanelToggleBarButtonItem.ImageIndex = 7;
							this.objectListPanelToggleBarButtonItem.Tag = "ShowObjectListPanel";
							this.objectListPanelToggleBarButtonItem.Hint = "Show Item List";
							break;
					}
					break;
			}
		}

		public virtual void SetButtonVisibility(int button, bool visible)
		{
			switch (button)
			{
				case PANEL1_TOGGLE:
					this.panel1ToggleBarButtonItem.Visibility = (visible ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never);
					break;
				case PANEL2_TOGGLE:
					this.panel2ToggleBarButtonItem.Visibility = (visible ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never);
					break;
				case OBJECT_LIST_PANEL_TOGGLE:
					this.objectListPanelToggleBarButtonItem.Visibility = (visible ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never);
					break;
			}
		}

		// Toggles the visible status of the parent SplitContainerControl's Object List panel.
		public virtual void SetObjectListPanelVisibility(bool visible)
		{
			if (this.objectListPanelToggleSplitContainerControl != null)
			{
				if (visible)
				{
					this.objectListPanelToggleSplitContainerControl.PanelVisibility = SplitPanelVisibility.Both;
					SetButtonState(OBJECT_LIST_PANEL_TOGGLE, "HideObjectListPanel");
				}
				else
				{
					this.objectListPanelToggleSplitContainerControl.PanelVisibility = SplitPanelVisibility.Panel2;
					SetButtonState(OBJECT_LIST_PANEL_TOGGLE, "ShowObjectListPanel");
				}
			}
		}

		// Toggles the visible status of the parent SplitContainerControl's panel 1.
		public virtual void SetPanel1Visibility(bool visible)
		{
			if (this.panel1ToggleSplitContainerControl != null)
			{
				if (visible)
				{
					this.panel1ToggleSplitContainerControl.PanelVisibility = SplitPanelVisibility.Both;
					SetButtonState(PANEL1_TOGGLE, "HidePanel1");
				}
				else
				{
					this.panel1ToggleSplitContainerControl.PanelVisibility = SplitPanelVisibility.Panel2;
					SetButtonState(PANEL1_TOGGLE, "ShowPanel1");
				}
			}
		}

		// Toggles the visible status of the parent SplitContainerControl's panel 2.
		public virtual void SetPanel2Visibility(bool visible)
		{
			if (this.panel2ToggleSplitContainerControl != null)
			{
				if (visible)
				{
					this.panel2ToggleSplitContainerControl.PanelVisibility = SplitPanelVisibility.Both;
					SetButtonState(PANEL2_TOGGLE, "HidePanel2");
				}
				else
				{
					this.panel2ToggleSplitContainerControl.PanelVisibility = SplitPanelVisibility.Panel1;
					SetButtonState(PANEL2_TOGGLE, "ShowPanel2");
				}
			}
		}

		protected virtual DevExpress.XtraEditors.SplitContainerControl GetParentBaseSplitContainerControl(Control control)
		{
			if (control.Parent is DevExpress.XtraEditors.SplitContainerControl)
			{
				DevExpress.XtraEditors.SplitContainerControl splitContainerControl = (DevExpress.XtraEditors.SplitContainerControl)control.Parent;
				if (splitContainerControl.Name == "baseSplitContainerControl")
					return splitContainerControl;
			}
			else if (control.Parent == null)
			{
				return null;
			}
			return GetParentBaseSplitContainerControl(control.Parent);
		}

		protected virtual DevExpress.XtraEditors.SplitContainerControl GetParentSplitContainerControl(Control control, ref int parentPanelNumber)
		{
			if (control.Parent is DevExpress.XtraEditors.SplitContainerControl)
			{
				DevExpress.XtraEditors.SplitContainerControl parentSplitContainerControl = (DevExpress.XtraEditors.SplitContainerControl)control.Parent;
				if (ReferenceEquals(control, parentSplitContainerControl.Panel1))
					parentPanelNumber = 1;
				else
					parentPanelNumber = 2;
				return parentSplitContainerControl;
			}
			else if (control.Parent == null)
			{
				return null;
			}
			return GetParentSplitContainerControl(control.Parent, ref parentPanelNumber);
		}

		// Obtains the immediate parent, grand parent and parent base SplitContainerControls of the given control.
		protected virtual void GetParentSplitContainerControls(Control control, ref DevExpress.XtraEditors.SplitContainerControl parentSplitContainerControl, ref int parentSplitContainerControlPanelNumber, ref DevExpress.XtraEditors.SplitContainerControl grandParentSplitContainerControl, ref DevExpress.XtraEditors.SplitContainerControl baseSplitContainerControl)
		{
			if ((parentSplitContainerControl = GetParentSplitContainerControl(control, ref parentSplitContainerControlPanelNumber)) == null)
			{
				// Control has no parent SplitContainerControl.
				grandParentSplitContainerControl = null;
				baseSplitContainerControl = null;
			}
			else
			{
				// Control has a parent SplitContainerControl.
				// Is this SplitContainerControl also the base SplitContainerControl?
				if (parentSplitContainerControl.Name == "baseSplitContainerControl")
				{
					// Yes it is.
					baseSplitContainerControl = (grandParentSplitContainerControl = parentSplitContainerControl);
				}
				else
				{
					// No, the parent SplitContainerControl is not the base SplitContainerControl.
					// Get the grandparent SplitContainerControl.
					int temp = 0;
					if ((grandParentSplitContainerControl = GetParentSplitContainerControl(parentSplitContainerControl, ref temp)) == null)
					{
						// There is no grandparent SplitContainerControl.
						// By implication, there is also no parent base SplitContainerControl.
						baseSplitContainerControl = null;
					}
					else if (grandParentSplitContainerControl.Name == "baseSplitContainerControl")
						// There is a grandparent SplitContainerControl and it is also the base SplitContainerControl.
						baseSplitContainerControl = grandParentSplitContainerControl;
					else
						// There is a grandparent SplitContainerControl but it is not the base SplitContainerControl.
						// Get the base SplitContainerControl.
						// It will be one of the great grandparents if it exists.
						baseSplitContainerControl = GetParentBaseSplitContainerControl(grandParentSplitContainerControl);
				}
			}
		}

	}

}
