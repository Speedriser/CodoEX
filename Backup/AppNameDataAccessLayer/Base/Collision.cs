using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustName.AppName.DAL
{
	public class Collision
	{
		private EntityClass entityClass;
		private IIdentifier objectId;
		private CollisionType collisionType;
		private string user;
		private DateTime date;

		public Collision(EntityClass entityClass, IIdentifier objectId, CollisionType collisionType, string user, DateTime date)
		{
			this.entityClass = entityClass;
			this.objectId = objectId;
			this.collisionType = collisionType;
			this.user = user;
			this.date = date;
		}

		public EntityClass EntityClass
		{
			get
			{
				return entityClass;
			}
		}

		public IIdentifier ObjectId
		{
			get
			{
				return objectId;
			}
		}

		public CollisionType CollisionType
		{
			get
			{
				return collisionType;
			}
		}

		public string User
		{
			get
			{
				return user;
			}
		}

		public DateTime Date
		{
			get
			{
				return date;
			}
		}
	}
}
