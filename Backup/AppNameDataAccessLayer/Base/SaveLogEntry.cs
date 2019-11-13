using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustName.AppName.DAL
{
	public class SaveLogEntry
	{
		public IEntityObject EntityObject = null;
		public RepositoryUpdateOperation RepositoryUpdateOperation = CustName.AppName.DAL.RepositoryUpdateOperation.None;
		public ObjectStatus PreSaveObjectStatus = ObjectStatus.None;
		public ObjectStatus PostSaveObjectStatus = ObjectStatus.None;
	}
}
