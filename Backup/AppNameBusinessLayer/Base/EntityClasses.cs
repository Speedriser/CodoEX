using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustName.AppName.BL
{
	public partial class Attachment1 : BaseAttachment1
	{
		public Attachment1()
			: base()
		{
		}

		public Attachment1(Guid instanceId)
			: base(instanceId)
		{
		}
	}

	public partial class DependentEntity1 : BaseDependentEntity1
	{
		public DependentEntity1()
			: base()
		{
		}

		public DependentEntity1(Guid instanceId)
			: base(instanceId)
		{
		}
	}

	public partial class DependentEntity2 : BaseDependentEntity2
	{
		public DependentEntity2()
			: base()
		{
		}

		public DependentEntity2(Guid instanceId)
			: base(instanceId)
		{
		}
	}

	public partial class IndependentEntity1 : BaseIndependentEntity1
	{
		public IndependentEntity1()
			: base()
		{
		}

		public IndependentEntity1(Guid instanceId)
			: base(instanceId)
		{
		}
	}

	public partial class IndependentEntity2 : BaseIndependentEntity2
	{
		public IndependentEntity2()
			: base()
		{
		}

		public IndependentEntity2(Guid instanceId)
			: base(instanceId)
		{
		}
	}

	public partial class RelationshipEntity1 : BaseRelationshipEntity1
	{
		public RelationshipEntity1()
			: base()
		{
		}

		public RelationshipEntity1(Guid instanceId)
			: base(instanceId)
		{
		}
	}
}
