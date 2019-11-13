using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CustName.AppName.DAL;
using CustName.AppName.BL;
using CustName.AppName.WinPL;

namespace CustName.AppName.WinPL.MainForms.IndependentEntity1Panels
{
	[ToolboxItemAttribute(false)]
	public partial class BaseChildOwnedDependentEntity2PanelControl : CustName.AppName.WinPL.MainForms.EntityPanelControl
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		public BaseChildOwnedDependentEntity2PanelControl()
		{
			// Execute Designer generated initialization code.
			InitializeComponent();
			// Execute custom initialization code.
			// NOTE: This code is executed at design and run time.
			CustomInitializeComponent();
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

		private void CustomInitializeComponent()
		{
			//
			// this.dependentEntity2_CardView
			//
			this.dependentEntity2_CardView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.cardView_FocusedRowChanged);
			//
			// this.dependentEntity2_GridView
			//
			this.dependentEntity2_GridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView_FocusedRowChanged);
		}

		protected override void CustomInitializeRuntimeComponent()
		{

			#region ParseEditValue event handlers for the GridControl.

			// Grid columns bound to value type business object properties do not support ^0 (null setting) because value types cannot represent null values (although some do support an empty value, which isn't the same thing).
			// If such properties are bound to database columns that are nullable, there needs to be a way for the user to set a null value via the UI.
			// To facilitate this, nullable value type properties can be bound instead to their corresponding DBObjectValue property procedures.
			// DBObjectValue properties are always of type Object and can accept null and DBNull.values as well as values in boxed form converted to the correct value type.
			// The problem with binding DBObjectValue properties to grid columns is that the grid no longer converts text entered into the column by the user into the value type.
			// To correct this, ParseEditValue event handlers are used to perform the conversion so that updates written to the DBObjectValue properties are of the correct (boxed) type.
			// Without the ParseEditValue event handlers, the default action of the grid is to update the DBObjectValue properties with strings, which they cannot handle.
			this.attrInteger1_RepositoryItemTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.attrInteger1_RepositoryItemTextEdit_ParseEditValue);

			#endregion

			#region ParseEditValue event handlers for the TextEdit controls.

			this.attrInteger1_LtbTextEdit.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.attrInteger1_LtbTextEdit_ParseEditValue);

			#endregion
		}

		public override CustName.AppName.DAL.EntityClass EntityClass
		{
			get
			{
				return CustName.AppName.DAL.EntityClass.DependentEntity2;
			}
		}

		public override Cardinality Cardinality
		{
			get
			{
				return Cardinality.Many;
			}
		}

		public override DevExpress.XtraLayout.LayoutControl FormView_LayoutControl
		{
			get
			{
				return this.formView_LayoutControl;
			}
		}

		public override DevExpress.XtraGrid.GridControl GridControl
		{
			get
			{
				return this.gridControl;
			}
		}

		public override DevExpress.XtraGrid.Views.Card.CardView CardView
		{
			get
			{
				return this.dependentEntity2_CardView;
			}
		}

		public override DevExpress.XtraGrid.Views.Grid.GridView GridView
		{
			get
			{
				return this.dependentEntity2_GridView;
			}
		}

		public override void LoadSupportingData()
		{
			base.LoadSupportingData();
			// The logic verifies each control exists before attempting to refresh it.
			// The control instance may have been destroyed by a customization.
		}

		protected virtual void EntityPanelControl_OpenEntityObject(object sender, OpenEntityObjectEventArgs e)
		{
			this.OnOpenEntityObject(e);
		}


		#region ParseEditValue event handlers for the GridControl.

		protected void attrInteger1_RepositoryItemTextEdit_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
		{
			String value;
			if ((value = (e.Value as String)) != null)
			{
				int result;
				if (int.TryParse(value, out result))
				{
					e.Value = (Object)result;
					e.Handled = true;
				}

			}
		}

		#endregion

		#region ParseEditValue event handlers for TextEdit controls.

		protected void attrInteger1_LtbTextEdit_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
		{
			String value;
			if ((value = (e.Value as String)) != null)
			{
				int result;
				if (int.TryParse(value, out result))
				{
					e.Value = (Object)result;
					e.Handled = true;
				}

			}
		}

		#endregion

		protected virtual String GetText(object entityObject, string displayMember)
		{
			String propertyValue = null;
			if (entityObject != null)
			{
				// Locate the display property in the object.
				PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(entityObject).Find(displayMember, true);
				if (propertyDescriptor != null)
				{
					propertyValue = Convert.ToString(propertyDescriptor.GetValue(entityObject));
				}
			}
			return propertyValue;
		}


		protected override void dataNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
		{
			base.dataNavigator_ButtonClick(sender, e);
			if (e.Button.ButtonType == NavigatorButtonType.Append)
			{
				SetDefaultAppendFocus();
			}
		}

		public override void SetDefaultAppendFocus()
		{
			switch (ViewMode)
			{
				case ViewMode.Form:
					this.name_LtbTextEdit.Focus();
					break;
				case ViewMode.Card:
				case ViewMode.Grid:
					this.gridControl.Focus();
					break;
			}
		}

	}
}
