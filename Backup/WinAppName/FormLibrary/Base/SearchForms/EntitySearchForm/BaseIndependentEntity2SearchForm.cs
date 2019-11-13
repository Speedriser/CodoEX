using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CustName.AppName.DAL;
using CustName.AppName.BL;

namespace CustName.AppName.WinPL.SearchForms
{
	public partial class BaseIndependentEntity2SearchForm : CustName.AppName.WinPL.SearchForms.EntitySearchForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		public BaseIndependentEntity2SearchForm()
		{
			// Required for Windows Form Designer support
			InitializeComponent();
			// Execute extended form initialization.
			BaseInitializeComponent();
		}

		protected virtual void BaseInitializeComponent()
		{
			EntitySearchControl.FooterVisibleChanged += new EventHandler(EntitySearchControl_FooterVisibleChanged);
			EntitySearchControl.GroupFooterVisibleChanged += new EventHandler(EntitySearchControl_GroupFooterVisibleChanged);
			EntitySearchControl.FilterRowVisibleChanged += new EventHandler(EntitySearchControl_FilterRowVisibleChanged);
			EntitySearchControl.FilterPanelVisibleChanged += new EventHandler(EntitySearchControl_FilterPanelVisibleChanged);
			EntitySearchControl.EntityObjectSelection += new EntityObjectSelectionEventHandler(EntitySearchControl_EntityObjectSelection);
			EntitySearchControl_FooterVisibleChanged(null, null);
			EntitySearchControl_GroupFooterVisibleChanged(null, null);
			EntitySearchControl_FilterRowVisibleChanged(null, null);
			EntitySearchControl_FilterPanelVisibleChanged(null, null);
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public override CustName.AppName.WinPL.SearchControls.EntitySearchControl EntitySearchControl
		{
			get
			{
				return (CustName.AppName.WinPL.SearchControls.EntitySearchControl)this.entitySearchControl;
			}
		}

		protected override void OnEntityObjectSelectionEvent(EntityObjectSelectionEventArgs e)
		{
			base.OnEntityObjectSelectionEvent(e);
			IMainForm mainForm = this.ParentForm as IMainForm;
			if (mainForm == null)
			{
				this.Close();
			}
			else
			{
				CustName.AppName.DAL.Repository repository = CustName.AppName.BL.Global.ClassFactory.GetDALRepository();
				IndependentEntity2List selectedIndependentEntity2List = (IndependentEntity2List)CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(EntityClass.IndependentEntity2);
				CustName.AppName.BL.IndependentEntity2 independentEntity2ForEdit;
				try
				{
					this.Cursor = Cursors.WaitCursor;
					IndependentEntity2Identifier objectId;
					for (int index = 0; index < e.SelectedEntityObjectList.Count; ++index)
					{
						objectId = (IndependentEntity2Identifier)e.SelectedEntityObjectList[index];
						if ((independentEntity2ForEdit = (CustName.AppName.BL.IndependentEntity2)repository.GetIndependentEntity2(objectId)) != null)
							selectedIndependentEntity2List.Add(independentEntity2ForEdit);
					}
				}
				finally
				{
					this.Cursor = Cursors.Default;
				}
				if (selectedIndependentEntity2List.Count > 0)
					mainForm.OpenMainForm(EntityClass.IndependentEntity2, selectedIndependentEntity2List);
			}
		}
	}
}
