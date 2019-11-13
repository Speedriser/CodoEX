using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CustName.AppName.WinPL
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			CustName.AppName.WinPL.Main.Start();
		}
	}
}
