using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CustName.AppName.DAL
{
	public delegate void PropertyLoad();

	public abstract class BaseFileAttachment
	{
		private bool blobAssigned;
		private string fileName;
		private byte[] data;
		private PropertyLoad fnPropertyLoad;

		public BaseFileAttachment(string fileName, PropertyLoad fnPropertyLoad)
		{
			this.blobAssigned = false;
			this.fileName = fileName;
			this.data = null;
			this.fnPropertyLoad = fnPropertyLoad;
		}

		public BaseFileAttachment(string fileName, byte[] data)
		{
			this.blobAssigned = true;
			this.fileName = fileName;
			this.data = data;
			this.fnPropertyLoad = null;
		}

		public bool BlobAssigned
		{
			get
			{
				return this.blobAssigned;
			}
			set
			{
				this.blobAssigned = value;
			}
		}

		public string FileName
		{
			get
			{
				return this.fileName;
			}
			set
			{
				this.fileName = value;
			}
		}

		public byte[] Data
		{
			get
			{
				if (!this.blobAssigned)
				{
					fnPropertyLoad();
					this.fnPropertyLoad = null;
				}
				return this.data;
			}
			set
			{
				this.data = value;
				if (!this.blobAssigned)
				{
					this.blobAssigned = true;
					this.fnPropertyLoad = null;
				}
			}
		}

		public override string ToString()
		{
			if (FileName == null)
				return "";
			else
				return Path.GetFileName(FileName);
		}
	}
}
