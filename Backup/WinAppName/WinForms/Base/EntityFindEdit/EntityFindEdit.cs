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
	/// EntityFindEdit is a descendant from PopupContainerEdit.
	/// It displays a dialog form below the text box when the edit button is clicked.
	/// </summary>
	[ToolboxItemAttribute(true)]
	public class EntityFindEdit : PopupContainerEdit
	{
		// Temporarily holds the id of the selected object between the time the object is selected and the popup is closed.
		// null represents no selection.
		protected IIdentifier selectedObjectId = null;

		static EntityFindEdit()
		{
			RepositoryItemEntityFindEdit.Register();
		}

		public EntityFindEdit()
		{
			this.Properties.PropertiesChanged += new System.EventHandler(this.EntityFindEdit_Properties_PropertiesChanged);
		}

		public override string EditorTypeName
		{
			get { return RepositoryItemEntityFindEdit.EditorName; }
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public new RepositoryItemEntityFindEdit Properties
		{
			get { return base.Properties as RepositoryItemEntityFindEdit; }
		}

		protected override void OnClickButton(DevExpress.XtraEditors.Drawing.EditorButtonObjectInfoArgs buttonInfo)
		{
			if ((buttonInfo.Button.Tag as string) == "Open")
			{
				CustName.AppName.WinPL.SearchControls.EntitySearchPopupContainerContentControl contentControl = this.Properties.ContentControl;
				if (contentControl != null && contentControl.EntityClass != EntityClass.None)
				{
					IIdentifier objectId = GetObjectId();
					CustName.AppName.WinPL.OpenEntityObjectEventArgs e1 = new CustName.AppName.WinPL.OpenEntityObjectEventArgs(contentControl.EntityClass, objectId);
					this.Properties.RaiseOpenEntityObject(e1);
				}
			}
			base.OnClickButton(buttonInfo);
		}

		protected internal virtual void OnContentControlChanged()
		{
		}

		protected internal virtual void OnContentControlChanging()
		{
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

		protected internal virtual void OnEntityObjectSelection(CustName.AppName.WinPL.EntityObjectSelectionEventArgs e)
		{
			this.selectedObjectId = (e.SelectedEntityObjectList == null || e.SelectedEntityObjectList.Count == 0 ? null : (IIdentifier)e.SelectedEntityObjectList[0]);
			this.ClosePopup();
		}

		protected override void OnPopupShown()
		{
			base.OnPopupShown();
			if (this.EditValue == null || this.EditValue == DBNull.Value)
				this.selectedObjectId = null;
			else
				this.selectedObjectId = (IIdentifier)this.EditValue;
		}

		protected internal virtual void OnQueryPopUp(CancelEventArgs e)
		{
			e.Cancel = this.Properties.ReadOnly;
		}

		protected internal virtual void OnQueryResultValue(QueryResultValueEventArgs e)
		{
			e.Value = (object)(this.selectedObjectId);
		}

		private void EntityFindEdit_Properties_PropertiesChanged(object sender, EventArgs e)
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

		public void RequeryDisplayText()
		{
			this.Properties.GetDisplayText(this.EditValue);
		}

		//
		// Summary:
		//     Returns an entity object identified by the objectId parameter.
		protected virtual object GetEntityObject(IIdentifier objectId)
		{
			// Cache logic could go here or Repository Context could be used.
			CustName.AppName.WinPL.SearchControls.EntitySearchPopupContainerContentControl contentControl = this.Properties.ContentControl;
			if (contentControl == null)
				return null;
			else
				return CustName.AppName.BL.Global.ClassFactory.GetDALRepository().Get(this.Properties.ContentControl.EntityClass, objectId);
		}

		public virtual IIdentifier GetObjectId()
		{
			return (this.Properties.GetObjectId(this.EditValue));
		}

		public virtual void RefreshDomainLists()
		{
			this.Properties.RefreshDomainLists();
		}

	}
}
