namespace CustName.AppName.WinPL.SearchForms
{
	partial class BaseIndependentEntity1SearchForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseIndependentEntity1SearchForm));
			this.entitySearchControl = new CustName.AppName.WinPL.SearchControls.IndependentEntity1SearchControl();
			((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
			this.SuspendLayout();
			//
			// imageCollection
			//
			this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
			//
			// entitySearchControl
			//
			this.entitySearchControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.entitySearchControl.Location = new System.Drawing.Point(0, 51);
			this.entitySearchControl.Name = "entitySearchControl";
			this.entitySearchControl.Size = new System.Drawing.Size(792, 515);
			this.entitySearchControl.TabIndex = 4;
			//
			// BaseIndependentEntity1SearchForm
			//
			this.ClientSize = new System.Drawing.Size(792, 566);
			this.Controls.Add(this.entitySearchControl);
			this.Name = "BaseIndependentEntity1SearchForm";
			this.Text = "Independent Entity 1 Search";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Controls.SetChildIndex(this.entitySearchControl, 0);
			((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public CustName.AppName.WinPL.SearchControls.IndependentEntity1SearchControl entitySearchControl;
	}
}
