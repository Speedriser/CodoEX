using System;
using System.Drawing;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.ViewInfo;
using CustName.AppName.BL;

namespace DevExpress.CustomEditors
{
	//The attribute that points to the registration method
	[UserRepositoryItem("RegisterFileAttachmentEdit")]
	[ToolboxItemAttribute(true)]
	public class RepositoryItemFileAttachmentEdit : RepositoryItemButtonEdit
	{
		private bool settingReadOnlyProperty = false;
		//The static constructor which calls the registration method
		static RepositoryItemFileAttachmentEdit() { RegisterFileAttachmentEdit(); }

		//Initialize new properties
		public RepositoryItemFileAttachmentEdit()
		{
			this.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			//useDefaultMode = true;
		}

		//The unique name for the custom editor
		public const string CustomEditName = "FileAttachmentEdit";

		//Return the unique name
		public override string EditorTypeName { get { return CustomEditName; } }

		//Register the editor
		public static void RegisterFileAttachmentEdit()
		{
			//Icon representing the editor within a container editor's Designer
			Image img = null;
			try
			{
				img = (Bitmap)Bitmap.FromStream(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CustName.AppName.WinPL.Base.FileAttachmentEdit.FileAttachmentEdit.png"));
			}
			catch
			{
			}
			EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName, typeof(FileAttachmentEdit), typeof(RepositoryItemFileAttachmentEdit),
				typeof(DevExpress.XtraEditors.ViewInfo.ButtonEditViewInfo), new DevExpress.XtraEditors.Drawing.ButtonEditPainter(), true, img));
		}

		////A custom property
		//private bool useDefaultMode;

		//public bool UseDefaultMode
		//{
		//    get { return useDefaultMode; }
		//    set
		//    {
		//        if (useDefaultMode != value)
		//        {
		//            useDefaultMode = value;
		//            OnPropertiesChanged();
		//        }
		//    }
		//}

		////Override the Assign method
		//public override void Assign(RepositoryItem item)
		//{
		//    BeginUpdate();
		//    try
		//    {
		//        base.Assign(item);
		//        RepositoryItemFileAttachmentEdit source = item as RepositoryItemFileAttachmentEdit;
		//        if (source == null) return;
		//        useDefaultMode = source.UseDefaultMode;
		//    }
		//    finally
		//    {
		//        EndUpdate();
		//    }
		//}

		public override void CreateDefaultButton()
		{
			Image img = (Bitmap)Bitmap.FromStream(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CustName.AppName.WinPL.Base.FileAttachmentEdit.RepositoryItemFileAttachmentEdit_SaveAs.png"));
			this.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "Attach File", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "Attach File", "Attach"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "Delete Attachment", -1, false, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "Delete Attachment", "Delete"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Save Attachment", -1, false, true, false, DevExpress.Utils.HorzAlignment.Center, img, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "Save Attachment", "Save")});
			this.Buttons[0].IsDefaultButton = true;
			this.Buttons[1].IsDefaultButton = true;
			this.Buttons[2].IsDefaultButton = true;
		}

		public virtual bool SettingReadOnlyProperty
		{
			get
			{
				return this.settingReadOnlyProperty;
			}
		}

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

	}

}
