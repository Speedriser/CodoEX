using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CustName.AppName.DAL
{
	public interface IEntityObject : IEntityObjectContextItem, IEditableObject, INotifyPropertyChanged
	{
		string ObjectPrimaryDescriptor
		{
			get;
		}

		event EventHandler HasUncommittedChangesChanged;

		#region Entity Information Properties

		EntityType EntityType
		{
			get;
		}

		EntityClass EntityClass
		{
			get;
		}

		#endregion Entity Information Properties

		#region Object Status Properties

		ObjectStatus ObjectStatus
		{
			get;
			set;
		}

		bool HasUncommittedChanges
		{
			get;
			set;
		}

		bool NewlyAddedToList
		{
			get;
		}

		#endregion Object Status Properties

		#region Base Properties

		Guid ObjectInstanceId
		{
			get;
			set;
		}

		DateTime? CreateTimestamp
		{
			get;
			set;
		}

		object CreateTimestamp_DBObjectValue
		{
			get;
		}

		DateTime CreateTimestamp_NoNull
		{
			get;
			set;
		}

		string CreateUser
		{
			get;
			set;
		}

		object CreateUser_DBObjectValue
		{
			get;
		}

		DateTime? LastUpdateTimestamp
		{
			get;
			set;
		}

		object LastUpdateTimestamp_DBObjectValue
		{
			get;
		}

		DateTime LastUpdateTimestamp_NoNull
		{
			get;
			set;
		}

		string LastUpdateUser
		{
			get;
			set;
		}

		object LastUpdateUser_DBObjectValue
		{
			get;
		}

		int UpdateId
		{
			get;
			set;
		}

		object UpdateId_DBObjectValue
		{
			get;
		}

		#endregion Base Properties

		#region Logical Delete Functions

		bool MarkedForDeletion
		{
			get;
		}

		void IncrementDeleteCount();

		void DecrementDeleteCount();

		#endregion Logical Delete Functions

		#region Object Comparison

		bool SameAs(IEntityObject obj);

		#endregion Object Comparison

		#region Object Copy

		void PopulateFrom(IEntityObject source);

		#endregion Object Copy

		#region IEditableObject Related

		IList AddNewList
		{
			get;
			set;
		}

		#endregion

		#region Miscellaneous

		void Load(bool recurse);

		IList<IEntityObject> GetOwnedObjects(bool loaded, IList<IEntityObject> list);

		#endregion Miscellaneous
	}
}
