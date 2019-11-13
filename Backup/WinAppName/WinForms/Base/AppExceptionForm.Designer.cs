namespace CustName.AppName.WinPL
{
	partial class AppExceptionForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.appExceptionDataGridView = new System.Windows.Forms.DataGridView();
			this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.sourceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.messageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.stackTraceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.helpLinkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.appExceptionBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.messageLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.appExceptionDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.appExceptionBindingSource)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			//
			// appExceptionDataGridView
			//
			this.appExceptionDataGridView.AllowUserToAddRows = false;
			this.appExceptionDataGridView.AllowUserToDeleteRows = false;
			this.appExceptionDataGridView.AllowUserToOrderColumns = true;
			this.appExceptionDataGridView.AutoGenerateColumns = false;
			this.appExceptionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.appExceptionDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Index,
            this.sourceDataGridViewTextBoxColumn,
            this.messageDataGridViewTextBoxColumn,
            this.stackTraceDataGridViewTextBoxColumn,
            this.helpLinkDataGridViewTextBoxColumn});
			this.appExceptionDataGridView.DataSource = this.appExceptionBindingSource;
			this.appExceptionDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.appExceptionDataGridView.Location = new System.Drawing.Point(3, 23);
			this.appExceptionDataGridView.Name = "appExceptionDataGridView";
			this.appExceptionDataGridView.ReadOnly = true;
			this.appExceptionDataGridView.Size = new System.Drawing.Size(586, 340);
			this.appExceptionDataGridView.TabIndex = 0;
			this.appExceptionDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.appExceptionDataGridView_DataBindingComplete);
			//
			// Index
			//
			this.Index.DataPropertyName = "Index";
			this.Index.HeaderText = "Index";
			this.Index.Name = "Index";
			this.Index.ReadOnly = true;
			//
			// sourceDataGridViewTextBoxColumn
			//
			this.sourceDataGridViewTextBoxColumn.DataPropertyName = "Source";
			this.sourceDataGridViewTextBoxColumn.HeaderText = "Source";
			this.sourceDataGridViewTextBoxColumn.Name = "sourceDataGridViewTextBoxColumn";
			this.sourceDataGridViewTextBoxColumn.ReadOnly = true;
			//
			// messageDataGridViewTextBoxColumn
			//
			this.messageDataGridViewTextBoxColumn.DataPropertyName = "Message";
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.messageDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
			this.messageDataGridViewTextBoxColumn.HeaderText = "Message";
			this.messageDataGridViewTextBoxColumn.Name = "messageDataGridViewTextBoxColumn";
			this.messageDataGridViewTextBoxColumn.ReadOnly = true;
			//
			// stackTraceDataGridViewTextBoxColumn
			//
			this.stackTraceDataGridViewTextBoxColumn.DataPropertyName = "StackTrace";
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.stackTraceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
			this.stackTraceDataGridViewTextBoxColumn.HeaderText = "StackTrace";
			this.stackTraceDataGridViewTextBoxColumn.Name = "stackTraceDataGridViewTextBoxColumn";
			this.stackTraceDataGridViewTextBoxColumn.ReadOnly = true;
			//
			// helpLinkDataGridViewTextBoxColumn
			//
			this.helpLinkDataGridViewTextBoxColumn.DataPropertyName = "HelpLink";
			this.helpLinkDataGridViewTextBoxColumn.HeaderText = "HelpLink";
			this.helpLinkDataGridViewTextBoxColumn.Name = "helpLinkDataGridViewTextBoxColumn";
			this.helpLinkDataGridViewTextBoxColumn.ReadOnly = true;
			//
			// appExceptionBindingSource
			//
			this.appExceptionBindingSource.AllowNew = false;
			this.appExceptionBindingSource.DataSource = typeof(CustName.AppName.BL.AppExceptionList);
			//
			// tableLayoutPanel1
			//
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.messageLabel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.appExceptionDataGridView, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(592, 366);
			this.tableLayoutPanel1.TabIndex = 1;
			//
			// messageLabel
			//
			this.messageLabel.AutoSize = true;
			this.messageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.messageLabel.Location = new System.Drawing.Point(3, 0);
			this.messageLabel.Name = "messageLabel";
			this.messageLabel.Size = new System.Drawing.Size(586, 20);
			this.messageLabel.TabIndex = 0;
			this.messageLabel.Text = "Unexpected exception encountered.";
			this.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			//
			// AppExceptionForm
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(592, 366);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "AppExceptionForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Exception Detected";
			((System.ComponentModel.ISupportInitialize)(this.appExceptionDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.appExceptionBindingSource)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.DataGridView appExceptionDataGridView;
		public System.Windows.Forms.BindingSource appExceptionBindingSource;
		public System.Windows.Forms.DataGridViewTextBoxColumn Index;
		public System.Windows.Forms.DataGridViewTextBoxColumn sourceDataGridViewTextBoxColumn;
		public System.Windows.Forms.DataGridViewTextBoxColumn messageDataGridViewTextBoxColumn;
		public System.Windows.Forms.DataGridViewTextBoxColumn stackTraceDataGridViewTextBoxColumn;
		public System.Windows.Forms.DataGridViewTextBoxColumn helpLinkDataGridViewTextBoxColumn;
		public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		public System.Windows.Forms.Label messageLabel;
	}
}
