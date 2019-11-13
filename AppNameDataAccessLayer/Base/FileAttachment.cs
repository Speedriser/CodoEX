using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustName.AppName.DAL
{
	public partial class FileAttachment : BaseFileAttachment
	{
		public FileAttachment(string fileName, byte[] data) : base(fileName, data) { }

		public FileAttachment(string fileName, PropertyLoad fnPropertyLoad) : base(fileName, fnPropertyLoad) { }
	}
}
