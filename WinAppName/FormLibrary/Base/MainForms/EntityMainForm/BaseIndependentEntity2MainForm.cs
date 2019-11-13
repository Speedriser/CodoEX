using System.Collections.Generic;

namespace CustName.AppName.WinPL.MainForms
{
	public partial class BaseIndependentEntity2MainForm : CustName.AppName.WinPL.MainForms.EntityMainForm
	{
		// Panel/TabPage Matrix
		// childOwnedRelationshipEntity1PanelControl; relationshipEntity1_XtraTabPage

		public BaseIndependentEntity2MainForm()
		{
			// Execute Designer generated initialization code.
			InitializeComponent();
			// Execute custom initialization code.
			// NOTE: This code is executed at design and run time.
			//CustomInitializeComponent();
			// Also see OnLoad & CustomInitializeRuntimeComponent methods for runtime only initialization.
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

		//private void CustomInitializeComponent()
		//{
		//}

		public override bool GetEntityPanelControlBindings(out List<EntityPanelControlBinding> entityPanelControlBindingList)
		{
			entityPanelControlBindingList = new List<EntityPanelControlBinding>(2);
			// Add EntityPanelControlBinding for the root panel control.
			// Parent Entity = ; Child Entity = IndependentEntity2
			entityPanelControlBindingList.Add(new EntityPanelControlBinding { PanelControl = this.parentIndependentEntity2PanelControl, DataSourcePanelControl = null, DataMember = null });

			// Add EntityPanelControlBinding(s) for child panel control(s).

			// Add EntityPanelControlBinding for the childOwnedRelationshipEntity1PanelControl child panel control.
			// Parent Entity = IndependentEntity2; Child Entity = RelationshipEntity1; FK Property = IndependentEntity2Id; Relationship = 
			entityPanelControlBindingList.Add(new EntityPanelControlBinding { PanelControl = this.childOwnedRelationshipEntity1PanelControl, DataSourcePanelControl = this.parentIndependentEntity2PanelControl, DataMember = "ChildOwnedRelationshipEntity1List" });
			return true;
		}

		//public override bool GetSplitContainerControls(out List<SplitContainerControl> splitContainerControlList)
		//{
		//		splitContainerControlList = new List<SplitContainerControl>(1);
		//		splitContainerControlList.Add(this.independentEntity2_SplitContainerControl);
		//		return true;
		//}

		public override bool GetTabControls(out List<DevExpress.XtraTab.XtraTabControl> tabControlList)
		{
			tabControlList = new List<DevExpress.XtraTab.XtraTabControl>(1);
			tabControlList.Add(this.independentEntity2_XtraTabControl);
			return true;
		}

		// panelControlList must be ordered such that for a given control, all child controls appear after it in the list.
		// Required by EndEdit function.
		public override bool GetPanelControls(out List<PanelControl> panelControlList)
		{
			panelControlList = new List<PanelControl>(2);
			panelControlList.Add(this.parentIndependentEntity2PanelControl);
			panelControlList.Add(this.childOwnedRelationshipEntity1PanelControl);
			return true;
		}

		public CustName.AppName.BL.IndependentEntity2 SelectedItem
		{
			get
			{
				return (this.rootPanelControl.bindingSource.Current as CustName.AppName.BL.IndependentEntity2);
			}
		}

		// Override defined to allow form to be opened in Visual Studio Designer.
		protected override void PanelControl_ToolBarButtonClick(object sender, ToolBarButtonClickEventArgs e)
		{
			base.PanelControl_ToolBarButtonClick(sender, e);
		}

		// Override defined to allow form to be opened in Visual Studio Designer.
		protected override void EntityPanelControl_OpenEntityObject(object sender, OpenEntityObjectEventArgs e)
		{
			base.EntityPanelControl_OpenEntityObject(sender, e);
		}

		// Override defined to allow form to be opened in Visual Studio Designer.
		protected override void EntityPanelControl_QueryPanelReadOnlyStatus(object sender, QueryReadOnlyStatusEventArgs e)
		{
			base.EntityPanelControl_QueryPanelReadOnlyStatus(sender, e);
		}

		// Override defined to allow form to be opened in Visual Studio Designer.
		protected override void XtraTabControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
		{
			base.XtraTabControl_SelectedPageChanged(sender, e);
		}

		// Override defined to allow form to be opened in Visual Studio Designer.
		protected override void objectListListBox_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
		{
			base.objectListListBox_DrawItem(sender, e);
		}

	}
}
