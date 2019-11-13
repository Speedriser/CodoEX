using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

using CustName.AppName.DAL;
namespace CustName.AppName.BL
{
	public class EntityObjectContext : IEntityObjectContext
	{
		private HybridDictionary repositoryCache = new HybridDictionary();

		// Must only be called after an object is loaded from the repository but before child objects are navigated to.
		public void Add(IEntityObjectContextItem obj)
		{
			if (obj != null && obj.ContextKey != null) // "New" object status entities and entities w/o primary object id will return a null key value.
			{
				// If the specified key already exists in the HybridDictionary, the Add method does not modify existing elements.
				this.repositoryCache.Add(obj.ContextKey, obj);
				obj.Context = (IEntityObjectContext)this;
			}
			else
				throw new BLException(EntityObjectContextExceptionMessage.AttemptToAddInvalidEntityObject);
		}

		public void Remove(IEntityObjectContextItem obj)
		{
			if (obj != null && obj.ContextKey != null) // "New" object status entities and entities w/o primary object id will return a null key value.
			{
				// Use the key of the provided object to lookup the cache.
				// If the specified key is not found, HybridDictionary returns a null reference.
				IEntityObjectContextItem matchingObjectInContext = (IEntityObjectContextItem)this.repositoryCache[(object)obj.ContextKey];
				// If the matching object in the cache is the same instance as the provided object, removal can take place, otherwise the call is ignored.
				// By checking membership first, "obj.Context = null" will not be executed if obj is a member of a different EntityObjectContext.
				if (matchingObjectInContext == obj)
				{
					// The provided object is in the context.
					// Remove it.
					this.repositoryCache.Remove((object)obj.ContextKey);
					obj.Context = null;
				}
			}
			else
				throw new BLException(EntityObjectContextExceptionMessage.AttemptToRemoveInvalidEntityObject);
		}

		public IEntityObjectContextItem Get(IIdentifier key)
		{
			return (IEntityObjectContextItem)this.repositoryCache[(object)key];
		}
	}
}
