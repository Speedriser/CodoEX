using System;
using System.ComponentModel;

namespace CustName.AppName.WinPL.MainForms
{
	[ToolboxItemAttribute(false)]
	public partial class BaseSplitContainerControl : DevExpress.XtraEditors.SplitContainerControl
	{
		private bool isInitializing;
		private bool ignoreSplitterMovedEvent;
		private float splitterPositionRatio;

		public BaseSplitContainerControl()
		{
			InitializeComponent();
		}

		// Summary:
		//     Signals the object that initialization is starting.
		public override void BeginInit()
		{
			this.isInitializing = true;
			base.BeginInit();
		}
		//
		// Summary:
		//     Signals the object that initialization is complete.
		public override void EndInit()
		{
			base.EndInit();
			this.isInitializing = false;
			this.splitterPositionRatio = CalcSplitterRatio(this.SplitterPosition);
		}

		[
		Browsable(false),
		DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)
		]
		public float SplitterPositionRatio
		{
			get
			{
				return this.splitterPositionRatio;
			}
			set
			{
				this.splitterPositionRatio = value;
				SetSplitterPosition(this.splitterPositionRatio);
			}
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			if (!this.isInitializing)
			{
				// Set the splitter position according to the ratio prior to resize.
				SetSplitterPosition(this.splitterPositionRatio);
			}
		}

		protected override void OnSplitterPositionChanged()
		{
			base.OnSplitterPositionChanged();
			if (!this.ignoreSplitterMovedEvent)
				this.splitterPositionRatio = CalcSplitterRatio(this.SplitterPosition);
		}

		private float CalcSplitterRatio(int position)
		{
			if (this.Horizontal)
				return (float)position / (float)this.Size.Width;
			else
				return (float)position / (float)this.Size.Height;
		}

		private int CalcSplitterPosition(float ratio)
		{
			if (this.Horizontal)
				return (int)(((float)this.Size.Width) * ratio);
			else
				return (int)(((float)this.Size.Height) * ratio);
		}

		private void SetSplitterPosition(float ratio)
		{
			if (!this.DesignMode)
			{
				this.ignoreSplitterMovedEvent = true;
				this.SplitterPosition = CalcSplitterPosition(ratio);
				this.ignoreSplitterMovedEvent = false;
			}
		}

	}
}
