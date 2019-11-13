using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CustName.AppName.WinPL.SearchControls
{
	[ToolboxItemAttribute(false)]
	public partial class BaseEntitySearchPopupContainerContentControl : DevExpress.XtraEditors.XtraUserControl
	{
		public event CustName.AppName.WinPL.EntityObjectSelectionEventHandler EntityObjectSelection = null;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		public BaseEntitySearchPopupContainerContentControl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call
		}

		public virtual CustName.AppName.DAL.EntityClass EntityClass
		{
			get
			{
				return CustName.AppName.DAL.EntityClass.None;
			}
		}

		public virtual string DefaultDisplayProperty
		{
			get
			{
				return "ObjectPrimaryDescriptor";
			}
		}

		protected virtual void findSimpleButton_Click(object sender, EventArgs e)
		{
		}

		protected virtual void selectSimpleButton_Click(object sender, EventArgs e)
		{
		}

		protected virtual void noSelectionSimpleButton_Click(object sender, EventArgs e)
		{
			OnEntityObjectSelection(new CustName.AppName.WinPL.EntityObjectSelectionEventArgs(null));
		}

		// Raises the EntityObjectSelection event by invoking the delegates.
		protected virtual void OnEntityObjectSelection(CustName.AppName.WinPL.EntityObjectSelectionEventArgs e)
		{
			if (EntityObjectSelection != null)
				EntityObjectSelection(this, e);
		}

		public virtual void RefreshDomainLists()
		{
		}
	}
}
