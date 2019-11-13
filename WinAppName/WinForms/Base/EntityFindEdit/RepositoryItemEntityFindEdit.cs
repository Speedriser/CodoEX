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
	[UserRepositoryItem("Register")]
	[ToolboxItemAttribute(true)]
	public class RepositoryItemEntityFindEdit : RepositoryItemPopupContainerEdit
	{
		private bool settingReadOnlyProperty = false;
		// Event handler for the content container control EntityObjectSelection event.
		// The function RaiseEntityObjectSelection simply reraises the event.
		private CustName.AppName.WinPL.EntityObjectSelectionEventHandler entityObjectSelectionEventHandler;
		// The name of the entity property to display.
		// Must be a valid property of the object returned by GetEntityObject method and identified by the EditValue property.
		// Value is exposed by the Text property.
		private string displayMember;

		private static readonly object openEntityObject = new object();

		static RepositoryItemEntityFindEdit()
		{
			Register();
		}

		public RepositoryItemEntityFindEdit()
		{
			// Default inherited properties.
			this.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
			this.CloseOnOuterMouseClick = false;
			this.PopupControl = new DevExpress.XtraEditors.PopupContainerControl();
			this.PopupControl.Size = new System.Drawing.Size(500, 400);
			this.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.entityObjectSelectionEventHandler = new CustName.AppName.WinPL.EntityObjectSelectionEventHandler(this.EntitySearchPopupContainerContentControl_EntityObjectSelection);
			// Default custom properties.
			this.displayMember = null;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				EntitySearchPopupContainerContentControl existingContentControl = this.ContentControl;
				if (existingContentControl != null)
					existingContentControl.EntityObjectSelection -= entityObjectSelectionEventHandler;
			}
			base.Dispose(disposing);
		}

		internal const string EditorName = "EntityFindEdit";

		public static void Register()
		{
			EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(EditorName, typeof(EntityFindEdit),
				typeof(RepositoryItemEntityFindEdit), typeof(DevExpress.XtraEditors.ViewInfo.PopupContainerEditViewInfo),
				new DevExpress.XtraEditors.Drawing.ButtonEditPainter(), true, null));
		}
		public override string EditorTypeName
		{
			get { return EditorName; }
		}

		protected new EntityFindEdit OwnerEdit { get { return base.OwnerEdit as EntityFindEdit; } }

		[DefaultValue(DevExpress.Utils.DefaultBoolean.True)]
		public override DevExpress.Utils.DefaultBoolean AllowNullInput
		{
			get
			{
				return base.AllowNullInput;
			}
			set
			{
				base.AllowNullInput = value;
			}
		}

		[DefaultValue(false)]
		public override bool CloseOnOuterMouseClick
		{
			get
			{
				return base.CloseOnOuterMouseClick;
			}
			set
			{
				base.CloseOnOuterMouseClick = value;
			}
		}

		[DefaultValue(false)]
		public override bool ReadOnly
		{
			get
			{
				return base.ReadOnly;
			}
			set
			{
				this.settingReadOnlyProperty = true;
				base.ReadOnly = value;
				this.settingReadOnlyProperty = false;
			}
		}

		[DefaultValue(null)]
		public string DisplayMember
		{
			get { return this.displayMember; }
			set
			{
				if (this.displayMember != value)
				{
					this.displayMember = value;
					OnPropertiesChanged();
				}
			}
		}

		[Browsable(false)]
		public virtual bool SettingReadOnlyProperty
		{
			get
			{
				return this.settingReadOnlyProperty;
			}
		}

		[Description("Gets or sets the entity control to display in the popup window."), DefaultValue(null)]
		public EntitySearchPopupContainerContentControl ContentControl
		{
			get
			{
				if (this.PopupControl.Controls.Count > 0)
					return (this.PopupControl.Controls[0] as EntitySearchPopupContainerContentControl);
				else
					return null;
			}
			set
			{
				EntitySearchPopupContainerContentControl existingContentControl;
				if ((existingContentControl = this.ContentControl) != value)
				{
					OnContentControlChanging();
					// Remove existing content control if there is one.
					if (existingContentControl != null)
					{
						existingContentControl.EntityObjectSelection -= entityObjectSelectionEventHandler;
					}
					if (this.PopupControl.Controls.Count > 0)
						this.PopupControl.Controls.Clear();
					// Add new content control.
					if (value != null)
					{
						this.PopupControl.Controls.Add(value);
						value.Dock = DockStyle.Fill;
						value.EntityObjectSelection += entityObjectSelectionEventHandler;
					}
					OnContentControlChanged();
					OnPropertiesChanged();
				}
			}
		}

		protected override void RaiseQueryPopUp(CancelEventArgs e)
		{
			OnQueryPopUp(e);
			base.RaiseQueryPopUp(e);
		}

		protected override void RaiseQueryResultValue(QueryResultValueEventArgs e)
		{
			OnQueryResultValue(e);
			base.RaiseQueryResultValue(e);
		}

		protected override void RaiseQueryDisplayText(QueryDisplayTextEventArgs e)
		{
			e.DisplayText = this.GetDefaultDisplayText(e.EditValue);
			base.RaiseQueryDisplayText(e);
		}

		protected internal virtual void RaiseOpenEntityObject(CustName.AppName.WinPL.OpenEntityObjectEventArgs e)
		{
			CustName.AppName.WinPL.OpenEntityObjectEventHandler handler = (CustName.AppName.WinPL.OpenEntityObjectEventHandler)this.Events[openEntityObject];
			if (handler != null) handler(GetEventSender(), e);
		}

		// [Description("Enables you to handle open entity requests.")], Category(CategoryName.Events)]
		public event CustName.AppName.WinPL.OpenEntityObjectEventHandler OpenEntityObject
		{
			add { this.Events.AddHandler(openEntityObject, value); }
			remove { this.Events.RemoveHandler(openEntityObject, value); }
		}

		private void EntitySearchPopupContainerContentControl_EntityObjectSelection(object sender, CustName.AppName.WinPL.EntityObjectSelectionEventArgs e)
		{
			OnEntityObjectSelection(e);
		}

		protected internal virtual void OnContentControlChanging()
		{
			if (OwnerEdit != null)
			{
				OwnerEdit.OnContentControlChanging();
			}
		}
		protected internal virtual void OnContentControlChanged()
		{
			if (OwnerEdit != null)
			{
				OwnerEdit.OnContentControlChanged();
			}
		}

		protected virtual void OnEntityObjectSelection(CustName.AppName.WinPL.EntityObjectSelectionEventArgs e)
		{
			if (OwnerEdit != null)
			{
				OwnerEdit.OnEntityObjectSelection(e);
			}
		}

		// This method has been implemented to allow the OwnerEdit to receive QueryPopUp notifications without having to subscribe to the event.
		protected virtual void OnQueryPopUp(CancelEventArgs e)
		{
			if (OwnerEdit != null)
			{
				OwnerEdit.OnQueryPopUp(e);
			}
		}

		// This method has been implemented to allow the OwnerEdit to receive QueryResultValue notifications without having to subscribe to the event.
		protected virtual void OnQueryResultValue(QueryResultValueEventArgs e)
		{
			if (OwnerEdit != null)
			{
				OwnerEdit.OnQueryResultValue(e);
			}
		}

		//Override the Assign method
		public override void Assign(RepositoryItem item)
		{
			RepositoryItemEntityFindEdit source = item as RepositoryItemEntityFindEdit;
			BeginUpdate();
			try
			{
				base.Assign(item);
				if (source == null) return;
				// At this point the PopupContainerControl (accessed via PopupControl property) owned by the base class (RepositoryItemPopupContainerEdit)
				// will have been copied from the source to this instance by the base Assign method.
				// However, it will not have connected this object's EntityObjectSelectionEventHandler to any content control that may be hosted by the PopupContainerControl.
				EntitySearchPopupContainerContentControl existingContentControl = this.ContentControl; // The content control returned will be the same as the one belonging to source since both objects have the same PopupContainerControl.
				if (existingContentControl != null)
					existingContentControl.EntityObjectSelection += entityObjectSelectionEventHandler;
				this.displayMember = source.displayMember;
			}
			finally
			{
				EndUpdate();
			}
			Events.AddHandler(openEntityObject, source.Events[openEntityObject]);
		}

		public override void CreateDefaultButton()
		{
			base.CreateDefaultButton();
			EditorButton btn = new EditorButton(ButtonPredefines.Ellipsis);
			btn.Caption = "Open";
			btn.IsDefaultButton = true;
			btn.Tag = "Open";
			btn.ToolTip = "Open";
			this.Buttons.Add(btn);
		}

		public virtual void RefreshDomainLists()
		{
			EntitySearchPopupContainerContentControl contentControl = this.ContentControl;
			if (contentControl != null)
				contentControl.RefreshDomainLists();
		}

		public virtual String GetDefaultDisplayText(object editValue)
		{
			string propertyValue;
			if (this.DesignMode)
				propertyValue = editValue as string;
			else
			{
				propertyValue = null;
				IIdentifier objectId = GetObjectId(editValue);
				if (objectId != null)
				{
					Object entityObject = GetEntityObject(objectId);
					if (entityObject == null)
					{
						propertyValue = "?";
					}
					else
					{

						// Locate the display property in the object.
						string displayMember = this.DisplayMember;
						if (displayMember == null)
						{
							EntitySearchPopupContainerContentControl existingContentControl = this.ContentControl;
							if (existingContentControl != null)
								displayMember = existingContentControl.DefaultDisplayProperty;
						}
						if (displayMember == null)
							propertyValue = entityObject.ToString();
						else
						{
							PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(entityObject).Find(displayMember, true);
							if (propertyDescriptor == null)
								propertyValue = entityObject.ToString();
							else
								propertyValue = Convert.ToString(propertyDescriptor.GetValue(entityObject));
						}
					}
				}
			}
			return propertyValue;
		}

		public virtual IIdentifier GetObjectId(object editValue)
		{
			return (editValue == null || editValue == DBNull.Value || !(editValue is IIdentifier) ? null : (IIdentifier)editValue);
		}

		//
		// Summary:
		//     Returns an entity object identified by the objectId parameter.
		public virtual object GetEntityObject(IIdentifier objectId)
		{
			// Cache logic could go here or Repository Context could be used.
			CustName.AppName.WinPL.SearchControls.EntitySearchPopupContainerContentControl contentControl = this.ContentControl;
			if (contentControl == null)
				return null;
			else
				return CustName.AppName.BL.Global.ClassFactory.GetDALRepository().Get(this.ContentControl.EntityClass, objectId);
		}

	}
}
