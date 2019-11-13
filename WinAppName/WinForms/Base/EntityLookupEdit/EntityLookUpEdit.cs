using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;
using CustName.AppName.DAL;
using CustName.AppName.WinPL.SearchControls;

namespace DevExpress.CustomEditors
{
	/// <summary>
	/// EntityLookUpEdit is a descendant from PopupContainerEdit.
	/// It displays a dialog form below the text box when the edit button is clicked.
	/// </summary>
	[ToolboxItemAttribute(true)]
	public class EntityLookUpEdit : LookUpEdit
	{
		static EntityLookUpEdit()
		{
			RepositoryItemEntityLookUpEdit.Register();
		}

		public EntityLookUpEdit()
		{
			this.Properties.PropertiesChanged += new System.EventHandler(this.EntityLookUpEdit_Properties_PropertiesChanged);
		}

		public override string EditorTypeName
		{
			get { return RepositoryItemEntityLookUpEdit.EditorName; }
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public new RepositoryItemEntityLookUpEdit Properties
		{
			get { return base.Properties as RepositoryItemEntityLookUpEdit; }
		}

		protected override void OnClickButton(DevExpress.XtraEditors.Drawing.EditorButtonObjectInfoArgs buttonInfo)
		{
			if ((buttonInfo.Button.Tag as string) == "Open")
			{
				if (this.Properties.EntityClass != EntityClass.None)
				{
					IIdentifier objectId = GetObjectId();
					CustName.AppName.WinPL.OpenEntityObjectEventArgs e = new CustName.AppName.WinPL.OpenEntityObjectEventArgs(this.Properties.EntityClass, objectId);
					this.Properties.RaiseOpenEntityObject(e);
				}
			}
			base.OnClickButton(buttonInfo);
		}

		protected override void OnEditorEnter(EventArgs e)
		{
			base.OnEditorEnter(e);
			SetButtonEnablement();
		}

		protected override void OnEditValueChanged()
		{
			base.OnEditValueChanged();
			SetButtonEnablement();
		}

		private void EntityLookUpEdit_Properties_PropertiesChanged(object sender, EventArgs e)
		{
			if (this.Properties.SettingReadOnlyProperty)
				SetButtonEnablement();
		}

		private void SetButtonEnablement()
		{
			foreach (DevExpress.XtraEditors.Controls.EditorButton button in this.Properties.Buttons)
			{
				if ((button.Tag as string) == "Open")
				{
					button.Enabled = (GetObjectId() != null);
				}
			}
		}

		public virtual IIdentifier GetObjectId()
		{
			return (this.Properties.GetObjectId(this.EditValue));
		}

	}
}
