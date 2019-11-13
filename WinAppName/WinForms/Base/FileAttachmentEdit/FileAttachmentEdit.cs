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
using CustName.AppName.DAL;

namespace DevExpress.CustomEditors
{
	[ToolboxItemAttribute(true)]
	public class FileAttachmentEdit : ButtonEdit
	{
		protected bool attachFileDialogOpened = false;
		protected bool saveFileDialogOpened = false;

		//The static constructor which calls the registration method
		static FileAttachmentEdit() { RepositoryItemFileAttachmentEdit.RegisterFileAttachmentEdit(); }

		//Initialize the new instance
		public FileAttachmentEdit()
		{
			this.Properties.PropertiesChanged += new System.EventHandler(this.FileAttachmentEdit_Properties_PropertiesChanged);
		}

		//Return the unique name
		public override string EditorTypeName { get { return RepositoryItemFileAttachmentEdit.CustomEditName; } }

		//Override the Properties property
		//Simply type-cast the object to the custom repository item type
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public new RepositoryItemFileAttachmentEdit Properties
		{
			get { return base.Properties as RepositoryItemFileAttachmentEdit; }
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

		private void SetButtonEnablement()
		{
			FileAttachment fileAttachment = this.EditValue as FileAttachment;
			if (fileAttachment == null)
			{
				foreach (DevExpress.XtraEditors.Controls.EditorButton button in this.Properties.Buttons)
				{
					switch ((string)button.Tag)
					{
						case "Attach":
							button.Enabled = !this.Properties.ReadOnly;
							break;
						case "Delete":
							button.Enabled = false;
							break;
						case "Save":
							button.Enabled = false;
							break;
					}
				}
			}
			else
			{
				foreach (DevExpress.XtraEditors.Controls.EditorButton button in this.Properties.Buttons)
				{
					switch ((string)button.Tag)
					{
						case "Attach":
							button.Enabled = !this.Properties.ReadOnly;
							break;
						case "Delete":
							button.Enabled = !this.Properties.ReadOnly;
							break;
						case "Save":
							button.Enabled = true;
							break;
					}
				}
			}
		}

		protected override void OnClickButton(EditorButtonObjectInfoArgs buttonInfo)
		{
			base.OnClickButton(buttonInfo);
			FileAttachment fileAttachment = null;
			switch ((string)buttonInfo.Button.Tag)
			{
				case "Attach":
					// Present Open File Dialog to user so that they can choose a file to attach.
					OpenFileDialog openFileDialog = new OpenFileDialog();
					if (!attachFileDialogOpened)
						openFileDialog.InitialDirectory = Path.GetPathRoot(System.Windows.Forms.Application.StartupPath);
					openFileDialog.RestoreDirectory = false;
					openFileDialog.Multiselect = false;
					if (openFileDialog.ShowDialog() == DialogResult.OK)
					{
						attachFileDialogOpened = true;
						Stream stream;
						if ((stream = openFileDialog.OpenFile()) != null)
						{
							BinaryReader br = null;
							fileAttachment = null;
							try
							{
								br = new BinaryReader(stream);
								fileAttachment = new FileAttachment(openFileDialog.FileName, br.ReadBytes((int)stream.Length));
							}
							catch (Exception)
							{
								fileAttachment = null;
							}
							finally
							{
								if (br != null) br.Close();
							}
							stream.Close();
							this.EditValue = fileAttachment;
						}
					}
					break;
				case "Delete":
					this.EditValue = null;
					break;
				case "Save":
					fileAttachment = this.EditValue as FileAttachment;
					if (fileAttachment != null)
					{
						// Present Save File Dialog to user so that they can choose a location and file name for save.
						SaveFileDialog saveFileDialog = new SaveFileDialog();
						if (!saveFileDialogOpened)
							saveFileDialog.InitialDirectory = Path.GetPathRoot(System.Windows.Forms.Application.StartupPath);
						saveFileDialog.RestoreDirectory = false;
						// Start with saved file name
						saveFileDialog.FileName = fileAttachment.FileName;
						if (saveFileDialog.ShowDialog() == DialogResult.OK)
						{
							saveFileDialogOpened = true;
							Stream stream;
							if ((stream = saveFileDialog.OpenFile()) != null)
							{
								BinaryWriter bw = null;
								try
								{
									this.Cursor = Cursors.WaitCursor;
									bw = new BinaryWriter(stream);
									bw.Write(fileAttachment.Data);
								}
								finally
								{
									this.Cursor = Cursors.Default;
									if (bw != null) bw.Close();
								}
								stream.Close();
							}
						}
					}
					break;
			}
		}

		private void FileAttachmentEdit_Properties_PropertiesChanged(object sender, EventArgs e)
		{
			if (this.Properties.SettingReadOnlyProperty)
				SetButtonEnablement();
		}

	}

}
