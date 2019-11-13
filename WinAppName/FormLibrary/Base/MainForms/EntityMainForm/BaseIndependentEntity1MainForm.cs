using System.Collections.Generic;

namespace CustName.AppName.WinPL.MainForms
{
	public partial class BaseIndependentEntity1MainForm : CustName.AppName.WinPL.MainForms.EntityMainForm
	{
		// Panel/TabPage Matrix
		// childOwnedAttachment1PanelControl; attachment1_XtraTabPage
		// childOwnedDependentEntity2PanelControl; dependentEntity2_XtraTabPage
		// childOwnedRelationshipEntity1PanelControl; relationshipEntity1_XtraTabPage
		// childOwnedDependentEntity1PanelControl; dependentEntity1_XtraTabPage

		public BaseIndependentEntity1MainForm()
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
			entityPanelControlBindingList = new List<EntityPanelControlBinding>(5);
			// Add EntityPanelControlBinding for the root panel control.
			// Parent Entity = ; Child Entity = IndependentEntity1
			entityPanelControlBindingList.Add(new EntityPanelControlBinding { PanelControl = this.parentIndependentEntity1PanelControl, DataSourcePanelControl = null, DataMember = null });

			// Add EntityPanelControlBinding(s) for child panel control(s).

			// Add EntityPanelControlBinding for the childOwnedDependentEntity1PanelControl child panel control.
			// Parent Entity = IndependentEntity1; Child Entity = DependentEntity1; FK Property = IndependentEntity1Id; Relationship = 
			entityPanelControlBindingList.Add(new EntityPanelControlBinding { PanelControl = this.childOwnedDependentEntity1PanelControl, DataSourcePanelControl = this.parentIndependentEntity1PanelControl, DataMember = "ChildOwnedDependentEntity1List" });
			// Add EntityPanelControlBinding for the childOwnedAttachment1PanelControl child panel control.
			// Parent Entity = DependentEntity1; Child Entity = Attachment1; FK Property = DependentEntity1Id; Relationship = 
			entityPanelControlBindingList.Add(new EntityPanelControlBinding { PanelControl = this.childOwnedAttachment1PanelControl, DataSourcePanelControl = this.childOwnedDependentEntity1PanelControl, DataMember = "ChildOwnedAttachment1List" });
			// Add EntityPanelControlBinding for the childOwnedDependentEntity2PanelControl child panel control.
			// Parent Entity = DependentEntity1; Child Entity = DependentEntity2; FK Property = DependentEntity1Id; Relationship = 
			entityPanelControlBindingList.Add(new EntityPanelControlBinding { PanelControl = this.childOwnedDependentEntity2PanelControl, DataSourcePanelControl = this.childOwnedDependentEntity1PanelControl, DataMember = "ChildOwnedDependentEntity2List" });
			// Add EntityPanelControlBinding for the childOwnedRelationshipEntity1PanelControl child panel control.
			// Parent Entity = DependentEntity2; Child Entity = RelationshipEntity1; FK Property = DependentEntity2Id; Relationship = 
			entityPanelControlBindingList.Add(new EntityPanelControlBinding { PanelControl = this.childOwnedRelationshipEntity1PanelControl, DataSourcePanelControl = this.childOwnedDependentEntity2PanelControl, DataMember = "ChildOwnedRelationshipEntity1List" });
			return true;
		}

		//public override bool GetSplitContainerControls(out List<SplitContainerControl> splitContainerControlList)
		//{
		//		splitContainerControlList = new List<SplitContainerControl>(3);
		//		splitContainerControlList.Add(this.dependentEntity1_SplitContainerControl);
		//		splitContainerControlList.Add(this.independentEntity1_SplitContainerControl);
		//		splitContainerControlList.Add(this.dependentEntity2_SplitContainerControl);
		//		return true;
		//}

		public override bool GetTabControls(out List<DevExpress.XtraTab.XtraTabControl> tabControlList)
		{
			tabControlList = new List<DevExpress.XtraTab.XtraTabControl>(3);
			tabControlList.Add(this.dependentEntity1_XtraTabControl);
			tabControlList.Add(this.dependentEntity2_XtraTabControl);
			tabControlList.Add(this.independentEntity1_XtraTabControl);
			return true;
		}

		// panelControlList must be ordered such that for a given control, all child controls appear after it in the list.
		// Required by EndEdit function.
		public override bool GetPanelControls(out List<PanelControl> panelControlList)
		{
			panelControlList = new List<PanelControl>(5);
			panelControlList.Add(this.parentIndependentEntity1PanelControl);
			panelControlList.Add(this.childOwnedDependentEntity1PanelControl);
			panelControlList.Add(this.childOwnedAttachment1PanelControl);
			panelControlList.Add(this.childOwnedDependentEntity2PanelControl);
			panelControlList.Add(this.childOwnedRelationshipEntity1PanelControl);
			return true;
		}

		public CustName.AppName.BL.IndependentEntity1 SelectedItem
		{
			get
			{
				return (this.rootPanelControl.bindingSource.Current as CustName.AppName.BL.IndependentEntity1);
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
