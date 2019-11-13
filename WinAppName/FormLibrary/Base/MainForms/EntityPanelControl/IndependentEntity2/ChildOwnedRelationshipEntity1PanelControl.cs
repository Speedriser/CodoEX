using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CustName.AppName.WinPL.MainForms.IndependentEntity2Panels
{
	[ToolboxItemAttribute(true)]
	public partial class ChildOwnedRelationshipEntity1PanelControl : CustName.AppName.WinPL.MainForms.IndependentEntity2Panels.BaseChildOwnedRelationshipEntity1PanelControl
	{
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

	}

}
