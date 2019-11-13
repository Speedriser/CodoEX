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
	public class RepositoryItemEntityLookUpEdit : RepositoryItemLookUpEdit
	{
		private bool settingReadOnlyProperty = false;
		private CustName.AppName.DAL.EntityClass entityClass;
		private static readonly object openEntityObject = new object();

		static RepositoryItemEntityLookUpEdit()
		{
			Register();
		}

		public RepositoryItemEntityLookUpEdit()
		{
			// Default inherited properties.
			this.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
			// Default custom properties.
			entityClass = CustName.AppName.DAL.EntityClass.None;
		}

		internal const string EditorName = "EntityLookUpEdit";

		public static void Register()
		{
			EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(EditorName, typeof(EntityLookUpEdit),
				typeof(RepositoryItemEntityLookUpEdit), typeof(DevExpress.XtraEditors.ViewInfo.LookUpEditViewInfo),
				new DevExpress.XtraEditors.Drawing.ButtonEditPainter(), true, null));
		}
		public override string EditorTypeName
		{
			get { return EditorName; }
		}

		protected new EntityLookUpEdit OwnerEdit { get { return base.OwnerEdit as EntityLookUpEdit; } }

		[DefaultValue(CustName.AppName.DAL.EntityClass.None)]
		public virtual CustName.AppName.DAL.EntityClass EntityClass
		{
			get
			{
				return this.entityClass;
			}
			set
			{
				this.entityClass = value;
			}
		}

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

		[Browsable(false)]
		public virtual bool SettingReadOnlyProperty
		{
			get
			{
				return this.settingReadOnlyProperty;
			}
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

		//Override the Assign method
		public override void Assign(RepositoryItem item)
		{
			RepositoryItemEntityLookUpEdit source = item as RepositoryItemEntityLookUpEdit;
			BeginUpdate();
			try
			{
				base.Assign(item);
				if (source == null) return;
				this.entityClass = source.entityClass;
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

		public virtual IIdentifier GetObjectId(object editValue)
		{
			return (editValue == null || editValue == DBNull.Value || !(editValue is IIdentifier) ? null : (IIdentifier)editValue);
		}

	}
}
