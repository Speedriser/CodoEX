using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CustName.AppName.WinPL
{
	internal class BaseMain
	{
		public static void Start()
		{
			StartImpl();
		}

		protected static void StartImpl()
		{
			Global.ClassFactory = new AppNameUIClassFactory();
			DevExpress.Skins.SkinManager.EnableFormSkins();
			Application.Run(new MainForm());
		}
	}
}
