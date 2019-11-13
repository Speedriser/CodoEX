using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustName.AppName.DAL
{
	public class SingleCollisionException : CollisionException
	{
		private Collision collision;

		public SingleCollisionException(string message, EntityClass entityClass, IIdentifier objectId, CollisionType collisionType, string user, DateTime date)
			: base(message)
		{
			this.collision = new Collision(entityClass, objectId, collisionType, user, date);
		}

		public SingleCollisionException(RepositoryExceptionMessageConstant message, EntityClass entityClass, IIdentifier objectId, CollisionType collisionType, string user, DateTime date)
			: this(message.Value, entityClass, objectId, collisionType, user, date) { }

		public SingleCollisionException(string message, Collision collision)
			: base(message)
		{
			this.collision = collision;
		}

		public SingleCollisionException(RepositoryExceptionMessageConstant message, Collision collision)
			: this(message.Value, collision) { }

		public Collision Collision
		{
			get
			{
				return this.collision;
			}
		}
	}
}
