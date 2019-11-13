using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CustName.AppName.WinPL
{
	public class XtraTabbedMdiManager : DevExpress.XtraTabbedMdi.XtraTabbedMdiManager
	{
		private Image _backgroundImage = null;
		private Point _point = new Point();

		public XtraTabbedMdiManager() : base() { }

		public XtraTabbedMdiManager(IContainer container) :
			base(container) { }

		public Image BackgroundImage
		{
			get { return _backgroundImage; }
			set { _backgroundImage = value; }
		}

		protected override void DrawNC(DevExpress.Utils.Drawing.DXPaintEventArgs e)
		{
			base.DrawNC(e);
			if (this.Pages.Count == 0 && this._backgroundImage != null)
			{
				this._point.X = (this.Bounds.Width - this._backgroundImage.Width) / 2;
				this._point.Y = (this.Bounds.Height - this._backgroundImage.Height) / 2;
				e.Graphics.DrawImageUnscaled(this._backgroundImage, this._point);
			}
		}
	}
}
