using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CustName.AppName.DAL;
using CustName.AppName.BL;

namespace CustName.AppName.WinPL.SearchControls
{
	[ToolboxItemAttribute(false)]
	public partial class BaseIndependentEntity2SearchControl : CustName.AppName.WinPL.SearchControls.EntitySearchControl
	{
		public int BestFitMaxRowCount = 200;
		public int ColumnMaxWidth = 450;
		public int MaxResultCount = 2000;
		private SortSpecification sortSpecification;

		public BaseIndependentEntity2SearchControl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			// Execute extended form initialization.
			BaseInitializeComponent();
			// Execute extended custom form initialization.
			CustomInitializeComponent();
		}

		private void BaseInitializeComponent()
		{
			Mode = SearchControlMode.Search;

			this.resultsGridControl.DoubleClick += new System.EventHandler(this.resultsGridControl_DoubleClick);

			this.SortSpecification = this.DefaultSortSpecification;
		}

		protected virtual void CustomInitializeComponent()
		{
		}

		protected override DevExpress.XtraGrid.Views.Grid.GridView MainGridView
		{
			get
			{
				return this.mainGridView;
			}
		}

		protected override DevExpress.XtraGrid.GridControl GridControl
		{
			get
			{
				return this.resultsGridControl;
			}
		}

		public SortSpecification SortSpecification
		{
			get
			{
				return this.sortSpecification;
			}
			set
			{
				this.sortSpecification = value;
			}
		}

		public override void Find()
		{
			SearchCondition searchCondition = new SearchCondition();

			// --------------------------------------------------------------------------------
			// Obtain the search criteria from the filter controls.
			//
			// name_LftbTextEdit
			Object value;
			if ((value = GetTextFilterValue(name_LftbTextEdit.EditValue)) != null)
			{
				if (!searchCondition.IsNullCondition())
					searchCondition.AppendOperator(SearchConditionOperator.And);
				searchCondition.AppendSearchCondition(IndependentEntity2PropertyName.Name, SearchConditionExpressionOperator.Like, value);
			}

			// status_LftbTextEdit
			if ((value = GetTextFilterValue(status_LftbTextEdit.EditValue)) != null)
			{
				if (!searchCondition.IsNullCondition())
					searchCondition.AppendOperator(SearchConditionOperator.And);
				searchCondition.AppendSearchCondition(IndependentEntity2PropertyName.Status, SearchConditionExpressionOperator.Like, value);
			}

			// attrString1_LftbTextEdit
			if ((value = GetTextFilterValue(attrString1_LftbTextEdit.EditValue)) != null)
			{
				if (!searchCondition.IsNullCondition())
					searchCondition.AppendOperator(SearchConditionOperator.And);
				searchCondition.AppendSearchCondition(IndependentEntity2PropertyName.AttrString1, SearchConditionExpressionOperator.Like, value);
			}

			// attrString2_LftbTextEdit
			if ((value = GetTextFilterValue(attrString2_LftbTextEdit.EditValue)) != null)
			{
				if (!searchCondition.IsNullCondition())
					searchCondition.AppendOperator(SearchConditionOperator.And);
				searchCondition.AppendSearchCondition(IndependentEntity2PropertyName.AttrString2, SearchConditionExpressionOperator.Like, value);
			}

			// attrBool1_LfckbCheckEdit
			if (attrBool1_LfckbCheckEdit.CheckState != CheckState.Indeterminate)
			{
				value = attrBool1_LfckbCheckEdit.Checked;
				if (!searchCondition.IsNullCondition())
					searchCondition.AppendOperator(SearchConditionOperator.And);
				searchCondition.AppendSearchCondition(IndependentEntity2PropertyName.AttrBool1, SearchConditionExpressionOperator.Equal, value);
			}

			// --------------------------------------------------------------------------------
			// Execute search against the database.
			//
			SortSpecification sortSpecification = this.SortSpecification;
			this.resultsBindingSource.CancelEdit();
			this.resultsBindingSource.SuspendBinding();
			try
			{
				this.Cursor = Cursors.WaitCursor;
				if (searchCondition.IsNullCondition())
					this.resultsBindingSource.DataSource = CustName.AppName.BL.Global.ClassFactory.GetDALRepository().FindIndependentEntity2(MaxResultCount, null, sortSpecification);
				else
					this.resultsBindingSource.DataSource = CustName.AppName.BL.Global.ClassFactory.GetDALRepository().FindIndependentEntity2(MaxResultCount, searchCondition, sortSpecification);
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
			this.resultsBindingSource.ResumeBinding();
			// Automatically size columns to fit content.
			SizeColumns();
			// Now that the search is complete, automatically switch to the Results tab in case the Filter tab is selected.
			this.tabbedControlGroup.SelectedTabPageIndex = 1;
		}

		public override void Clear()
		{
			this.name_LftbTextEdit.EditValue = null;
			this.status_LftbTextEdit.EditValue = null;
			this.attrString1_LftbTextEdit.EditValue = null;
			this.attrString2_LftbTextEdit.EditValue = null;
			this.attrBool1_LfckbCheckEdit.CheckState = CheckState.Indeterminate;
			this.resultsBindingSource.DataSource = CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(EntityClass.IndependentEntity2);
		}

		public override void Open()
		{
			List<CustName.AppName.BL.IndependentEntity2> independentEntity2List = GetSelectedIndependentEntity2List();
			if (independentEntity2List.Count > 0)
			{
				List<IIdentifier> selectedEntityObjectList = new List<IIdentifier>();
				foreach (CustName.AppName.BL.IndependentEntity2 independentEntity2 in independentEntity2List)
				{
					if (independentEntity2.ObjectId.HasValue) // Should not be the case unless an ability to add new records via search is implemented.
						selectedEntityObjectList.Add((IIdentifier)independentEntity2.ObjectId.Value);
				}
				if (selectedEntityObjectList.Count > 0)
				{
					OnEntityObjectSelectionEvent(new EntityObjectSelectionEventArgs(selectedEntityObjectList));
				}
			}
		}

		public override void RefreshDomainLists()
		{
			if (this.Mode == SearchControlMode.Lookup)
				this.resultsBindingSource.DataSource = CustName.AppName.BL.Global.ClassFactory.GetEntityListObject(EntityClass.IndependentEntity2);
		}


		public virtual List<CustName.AppName.BL.IndependentEntity2> GetSelectedIndependentEntity2List()
		{
			List<CustName.AppName.BL.IndependentEntity2> independentEntity2List = new List<CustName.AppName.BL.IndependentEntity2>();
			int[] selectedRows = this.mainGridView.GetSelectedRows();
			if (selectedRows != null)
			{
				// Add the selected IndependentEntity2 objects to the list.
				CustName.AppName.BL.IndependentEntity2 independentEntity2;
				for (int rowIndex = 0; rowIndex < this.mainGridView.SelectedRowsCount; ++rowIndex)
				{
					if ((independentEntity2 = this.mainGridView.GetRow(selectedRows[rowIndex]) as CustName.AppName.BL.IndependentEntity2) != null)
						independentEntity2List.Add(independentEntity2);
				}
			}
			return independentEntity2List;
		}

		public virtual void SizeColumns()
		{
			this.resultsGridControl.SuspendLayout();
			// By default, automatically size columns to fit visible content.
			this.mainGridView.BestFitMaxRowCount = BestFitMaxRowCount;
			this.mainGridView.BestFitColumns();
			// Revert BestFitMaxRowCount back to -1 so that when the user applies best fit via the grid menu, all rows are taken into account.
			this.mainGridView.BestFitMaxRowCount = -1;
			// Max sure no column width exceeds the maximum.
			if (!this.mainGridView.OptionsView.ColumnAutoWidth)
			{
				// Make sure no column exceeds the maximum width limit.
				foreach (DevExpress.XtraGrid.Columns.GridColumn gridColumn in this.mainGridView.Columns)
				{
					if (!gridColumn.OptionsColumn.FixedWidth)
					{
						if ((gridColumn.ColumnEdit as DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit) == null)
						{
							if (gridColumn.Width > ColumnMaxWidth) gridColumn.Width = ColumnMaxWidth;
						}
						else
						{
							gridColumn.Width = gridColumn.MinWidth;
						}
					}
				}
			}
			resultsGridControl.ResumeLayout();
		}

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

		protected string GetTextFilterValue(object editValue)
		{
			if (!(editValue == DBNull.Value || String.IsNullOrEmpty(editValue as String)))
			{
				string text = (string)editValue;
				// Determine if the text likely represents a SQL LIKE pattern.
				// If not, it will be okay to automatically add '%' wildcards the text so that all similar strings are matched.
				Regex r = new Regex("%|_|(\\[(\\^?)(\\w+)((-(\\w+))?)\\])");
				Match m = r.Match(text);
				if (!m.Success)
					text = "%" + text + "%";
				return text;
			}
			else
				return null;
		}


		public virtual CustName.AppName.DAL.SortSpecification DefaultSortSpecification
		{
			get
			{
				return null;
			}
		}

	}
}
