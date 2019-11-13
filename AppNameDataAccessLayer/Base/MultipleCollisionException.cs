using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustName.AppName.DAL
{
	public class MultipleCollisionException : CollisionException
	{
		private CollisionList collisions;

		public MultipleCollisionException(string message, CollisionList collisions)
			: base(message)
		{
			this.collisions = collisions;
		}

		public MultipleCollisionException(RepositoryExceptionMessageConstant message, CollisionList collisions)
			: this(message.Value, collisions) { }

		public CollisionList Collisions
		{
			get
			{
				return this.collisions;
			}
		}
	}
}
