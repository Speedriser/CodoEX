using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustName.AppName.BL
{
	public static partial class EntityObjectContextExceptionMessage
	{
		public const string None = "";
		public const string AttemptToAddInvalidEntityObject = "Attempt to add a null or New status entity object to an EntityObjectContext instance.";
		public const string AttemptToRemoveInvalidEntityObject = "Attempt to remove a null or New status entity object from an EntityObjectContext instance.";
	}

	public static partial class EntityObjectDataSourceExceptionMessage
	{
		public const string None = "";
		public const string ObjectNotFound = "No object corresponding data source object found.";
	}
}
