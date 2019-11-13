using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CustName.AppName.DAL
{
	// [ ORDER BY
	//     {
	//     order_by_expression
	//   [ COLLATE collation_name ]
	//   [ ASC | DESC ]
	//     } [ ,...n ]
	// ]
	public abstract class BaseSortSpecification
	{
		public const string ParamPlaceholderString = "@param_";

		private StringBuilder sortSpecificationBuilder = new StringBuilder();
		internal List<QueryConstant> ConstantList = new List<QueryConstant>();

		public virtual SortSpecification Append(string value)
		{
			this.sortSpecificationBuilder.Append(value);
			return (SortSpecification)this;
		}

		public virtual SortSpecification AppendDirectionSpecifier(SortSpecificationDirectionSpecifierConstant directionSpecifier)
		{
			if (directionSpecifier == SortSpecificationDirectionSpecifier.Ascending)
			{
				Append(" ");
				Append(SortSpecificationDirectionSpecifier.Ascending.Value);
			}
			else if (directionSpecifier == SortSpecificationDirectionSpecifier.Descending)
			{
				Append(" ");
				Append(SortSpecificationDirectionSpecifier.Descending.Value);
			}
			return (SortSpecification)this;
		}

		public virtual SortSpecification AppendSortSpecification(Attachment1BasePropertyName propertyName, SortSpecificationDirectionSpecifierConstant directionSpecifier)
		{
			if (this.sortSpecificationBuilder.Length > 0)
				this.sortSpecificationBuilder.Append(", ");
			AppendPropertyName(propertyName);
			if (directionSpecifier != SortSpecificationDirectionSpecifier.Ascending)
				AppendDirectionSpecifier(directionSpecifier);
			return (SortSpecification)this;
		}

		public virtual SortSpecification AppendPropertyName(Attachment1BasePropertyName propertyName)
		{
			Append("[");
			Append(Attachment1BasePropertyNameMapper.GetColumnName(propertyName));
			Append("]");
			return (SortSpecification)this;
		}

		public virtual SortSpecification AppendSortSpecification(DependentEntity1BasePropertyName propertyName, SortSpecificationDirectionSpecifierConstant directionSpecifier)
		{
			if (this.sortSpecificationBuilder.Length > 0)
				this.sortSpecificationBuilder.Append(", ");
			AppendPropertyName(propertyName);
			if (directionSpecifier != SortSpecificationDirectionSpecifier.Ascending)
				AppendDirectionSpecifier(directionSpecifier);
			return (SortSpecification)this;
		}

		public virtual SortSpecification AppendPropertyName(DependentEntity1BasePropertyName propertyName)
		{
			Append("[");
			Append(DependentEntity1BasePropertyNameMapper.GetColumnName(propertyName));
			Append("]");
			return (SortSpecification)this;
		}

		public virtual SortSpecification AppendSortSpecification(DependentEntity2BasePropertyName propertyName, SortSpecificationDirectionSpecifierConstant directionSpecifier)
		{
			if (this.sortSpecificationBuilder.Length > 0)
				this.sortSpecificationBuilder.Append(", ");
			AppendPropertyName(propertyName);
			if (directionSpecifier != SortSpecificationDirectionSpecifier.Ascending)
				AppendDirectionSpecifier(directionSpecifier);
			return (SortSpecification)this;
		}

		public virtual SortSpecification AppendPropertyName(DependentEntity2BasePropertyName propertyName)
		{
			Append("[");
			Append(DependentEntity2BasePropertyNameMapper.GetColumnName(propertyName));
			Append("]");
			return (SortSpecification)this;
		}

		public virtual SortSpecification AppendSortSpecification(IndependentEntity1BasePropertyName propertyName, SortSpecificationDirectionSpecifierConstant directionSpecifier)
		{
			if (this.sortSpecificationBuilder.Length > 0)
				this.sortSpecificationBuilder.Append(", ");
			AppendPropertyName(propertyName);
			if (directionSpecifier != SortSpecificationDirectionSpecifier.Ascending)
				AppendDirectionSpecifier(directionSpecifier);
			return (SortSpecification)this;
		}

		public virtual SortSpecification AppendPropertyName(IndependentEntity1BasePropertyName propertyName)
		{
			Append("[");
			Append(IndependentEntity1BasePropertyNameMapper.GetColumnName(propertyName));
			Append("]");
			return (SortSpecification)this;
		}

		public virtual SortSpecification AppendSortSpecification(IndependentEntity2BasePropertyName propertyName, SortSpecificationDirectionSpecifierConstant directionSpecifier)
		{
			if (this.sortSpecificationBuilder.Length > 0)
				this.sortSpecificationBuilder.Append(", ");
			AppendPropertyName(propertyName);
			if (directionSpecifier != SortSpecificationDirectionSpecifier.Ascending)
				AppendDirectionSpecifier(directionSpecifier);
			return (SortSpecification)this;
		}

		public virtual SortSpecification AppendPropertyName(IndependentEntity2BasePropertyName propertyName)
		{
			Append("[");
			Append(IndependentEntity2BasePropertyNameMapper.GetColumnName(propertyName));
			Append("]");
			return (SortSpecification)this;
		}

		public virtual SortSpecification AppendSortSpecification(RelationshipEntity1BasePropertyName propertyName, SortSpecificationDirectionSpecifierConstant directionSpecifier)
		{
			if (this.sortSpecificationBuilder.Length > 0)
				this.sortSpecificationBuilder.Append(", ");
			AppendPropertyName(propertyName);
			if (directionSpecifier != SortSpecificationDirectionSpecifier.Ascending)
				AppendDirectionSpecifier(directionSpecifier);
			return (SortSpecification)this;
		}

		public virtual SortSpecification AppendPropertyName(RelationshipEntity1BasePropertyName propertyName)
		{
			Append("[");
			Append(RelationshipEntity1BasePropertyNameMapper.GetColumnName(propertyName));
			Append("]");
			return (SortSpecification)this;
		}

		public virtual string GetText()
		{
			return this.sortSpecificationBuilder.ToString();
		}

		//
		// Summary:
		//     Converts the value of this instance to a System.String.
		//
		// Returns:
		//     A string whose value is the same as this instance.
		public override string ToString()
		{
			return this.sortSpecificationBuilder.ToString();
		}

		// Made virtual because (for example) a more powerful version could check the condition to see if it would always evaluate to true.
		public virtual bool IsNullCondition()
		{
			return (this.sortSpecificationBuilder.Length == 0);
		}

	}
}
