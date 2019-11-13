namespace CustName.AppName.WinPL.MainForms
{
	partial class BaseEntityPanelControl
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

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseEntityPanelControl));
			this.dataNavigator = new DevExpress.XtraEditors.DataNavigator();
			this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.barManagerImageCollection16)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			//
			// barManagerImageCollection16
			//
			this.barManagerImageCollection16.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("barManagerImageCollection16.ImageStream")));
			//
			// dataNavigator
			//
			this.dataNavigator.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.dataNavigator.DataSource = this.bindingSource;
			this.dataNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dataNavigator.Location = new System.Drawing.Point(0, 276);
			this.dataNavigator.MaximumSize = new System.Drawing.Size(285, 24);
			this.dataNavigator.MinimumSize = new System.Drawing.Size(265, 24);
			this.dataNavigator.Name = "dataNavigator";
			this.dataNavigator.ShowToolTips = true;
			this.dataNavigator.Size = new System.Drawing.Size(285, 24);
			this.dataNavigator.TabIndex = 4;
			this.dataNavigator.Text = "Data Navigator";
			this.dataNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Center;
			this.dataNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dataNavigator_ButtonClick);
			//
			// bindingSource
			//
			this.bindingSource.CurrentChanged += new System.EventHandler(this.bindingSource_CurrentChanged);
			this.bindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bindingSource_ListChanged);
			//
			// BaseEntityPanelControl
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.dataNavigator);
			this.Name = "BaseEntityPanelControl";
			this.Controls.SetChildIndex(this.dataNavigator, 0);
			((System.ComponentModel.ISupportInitialize)(this.barManagerImageCollection16)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.BindingSource bindingSource;
		public DevExpress.XtraEditors.DataNavigator dataNavigator;
	}
}
