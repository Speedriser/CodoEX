using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CustName.AppName.BL;

namespace CustName.AppName.WinPL
{
	public partial class AppExceptionForm : System.Windows.Forms.Form
	{
		public AppExceptionForm(string message, Exception exception)
		{
			InitializeComponent();
			BaseInitializeComponent(message, exception);
		}

		protected void BaseInitializeComponent(string message, Exception exception)
		{
			if (message != null && message != "") messageLabel.Text = message;
			// Generate AppExceptionList object based on the given Exception object and bind it to the grid.
			appExceptionBindingSource.SuspendBinding();
			appExceptionBindingSource.DataSource = CustName.AppName.BL.Global.CreateAppExceptionList(exception);
			appExceptionBindingSource.ResumeBinding();
		}

		private void appExceptionDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			appExceptionDataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
			appExceptionDataGridView.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
		}
	}
}
