using System;
using System.Collections.Generic;
using System.Text;
using CustName.AppName.DAL;

namespace CustName.AppName.WinPL
{
	// Class that contains data for the EntityObjectSelection event.
	public class EntityObjectSelectionEventArgs
	{
		private IList<IIdentifier> selectedEntityObjectList;

		public EntityObjectSelectionEventArgs(IList<IIdentifier> selectedEntityObjectList)
		{
			this.selectedEntityObjectList = selectedEntityObjectList;
		}

		public IList<IIdentifier> SelectedEntityObjectList
		{
			get
			{
				return selectedEntityObjectList;
			}
		}
	}

	// Delegate declaration.
	public delegate void EntityObjectSelectionEventHandler(object sender, EntityObjectSelectionEventArgs e);
}
