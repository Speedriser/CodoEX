using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustName.AppName.DAL
{
	public struct SearchConditionOperatorConstant : IComparable, IComparable<SearchConditionOperatorConstant>, IEquatable<SearchConditionOperatorConstant>
	{
		public readonly string Value;

		public SearchConditionOperatorConstant(string value)
		{
			this.Value = value;
		}

		// Summary:
		//     Returns an indication whether the values of two specified SearchConditionOperatorConstant objects
		//     are not equal.
		//
		// Parameters:
		//   a:
		//     A SearchConditionOperatorConstant object.
		//
		//   b:
		//     A SearchConditionOperatorConstant object.
		//
		// Returns:
		//     true if a and b are not equal; otherwise, false.
		public static bool operator !=(SearchConditionOperatorConstant a, SearchConditionOperatorConstant b)
		{
			return !SearchConditionOperatorConstant.Equal(a, b);
		}

		//
		// Summary:
		//     Returns an indication whether the values of two specified SearchConditionOperatorConstant objects
		//     are equal.
		//
		// Parameters:
		//   a:
		//     A SearchConditionOperatorConstant object.
		//
		//   b:
		//     A SearchConditionOperatorConstant object.
		//
		// Returns:
		//     true if a and b are equal; otherwise, false.
		public static bool operator ==(SearchConditionOperatorConstant a, SearchConditionOperatorConstant b)
		{
			return SearchConditionOperatorConstant.Equal(a, b);
		}

		// Summary:
		//     Compares this instance to a specified SearchConditionOperatorConstant object and returns an indication
		//     of their relative values.
		//
		// Parameters:
		//   value:
		//     A SearchConditionOperatorConstant object to compare to this instance.
		//
		// Returns:
		//     A signed number indicating the relative values of this instance and value.
		//      Value Description A negative integer This instance is less than value. Zero
		//     This instance is equal to value. A positive integer This instance is greater
		//     than value.
		public int CompareTo(SearchConditionOperatorConstant value)
		{
			int result;
			if ((result = this.Value.CompareTo(value.Value)) != 0)
				return result;
			return 0;
		}

		//
		// Summary:
		//     Compares this instance to a specified object and returns an indication of
		//     their relative values.
		//
		// Parameters:
		//   value:
		//     An object to compare, or null.
		//
		// Returns:
		//     A signed number indicating the relative values of this instance and value.
		//      Value Description A negative integer This instance is less than value. Zero
		//     This instance is equal to value. A positive integer This instance is greater
		//     than value.  -or- value is null.
		//
		// Exceptions:
		//   System.ArgumentException:
		//     value is not a SearchConditionOperatorConstant.
		public int CompareTo(object value)
		{
			if (value is SearchConditionOperatorConstant)
				return this.CompareTo((SearchConditionOperatorConstant)value);
			throw new ArgumentException("value is not a SearchConditionOperatorConstant", "value");
		}

		//
		// Summary:
		//     Returns a value indicating whether this instance and a specified SearchConditionOperatorConstant
		//     object represent the same value.
		//
		// Parameters:
		//   g:
		//     A SearchConditionOperatorConstant object to compare to this instance.
		//
		// Returns:
		//     true if g is equal to this instance; otherwise, false.
		public bool Equals(SearchConditionOperatorConstant oi)
		{
			return SearchConditionOperatorConstant.Equal(this, oi);
		}

		//
		// Summary:
		//     Returns a value indicating whether this instance is equal to a specified
		//     object.
		//
		// Parameters:
		//   o:
		//     The object to compare with this instance.
		//
		// Returns:
		//     true if o is a SearchConditionOperatorConstant that has the same value as this instance; otherwise,
		//     false.
		public override bool Equals(object o)
		{
			if (o is SearchConditionOperatorConstant)
				return SearchConditionOperatorConstant.Equal(this, (SearchConditionOperatorConstant)o);
			return false;
		}

		//
		// Summary:
		//     Returns the hash code for this instance.
		//
		// Returns:
		//     The hash code for this instance.
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		public override string ToString()
		{
			return this.Value.ToString();
		}

		private static bool Equal(SearchConditionOperatorConstant a, SearchConditionOperatorConstant b)
		{
			return a.Value == b.Value;
		}
	}

	public partial class SearchConditionOperator
	{
		public static readonly SearchConditionOperatorConstant And = new SearchConditionOperatorConstant("AND");
		public static readonly SearchConditionOperatorConstant Not = new SearchConditionOperatorConstant("NOT");
		public static readonly SearchConditionOperatorConstant Or = new SearchConditionOperatorConstant("OR");
	}
	public struct SearchConditionExpressionOperatorConstant : IComparable, IComparable<SearchConditionExpressionOperatorConstant>, IEquatable<SearchConditionExpressionOperatorConstant>
	{
		public readonly string Value;

		public SearchConditionExpressionOperatorConstant(string value)
		{
			this.Value = value;
		}

		// Summary:
		//     Returns an indication whether the values of two specified SearchConditionExpressionOperatorConstant objects
		//     are not equal.
		//
		// Parameters:
		//   a:
		//     A SearchConditionExpressionOperatorConstant object.
		//
		//   b:
		//     A SearchConditionExpressionOperatorConstant object.
		//
		// Returns:
		//     true if a and b are not equal; otherwise, false.
		public static bool operator !=(SearchConditionExpressionOperatorConstant a, SearchConditionExpressionOperatorConstant b)
		{
			return !SearchConditionExpressionOperatorConstant.Equal(a, b);
		}

		//
		// Summary:
		//     Returns an indication whether the values of two specified SearchConditionExpressionOperatorConstant objects
		//     are equal.
		//
		// Parameters:
		//   a:
		//     A SearchConditionExpressionOperatorConstant object.
		//
		//   b:
		//     A SearchConditionExpressionOperatorConstant object.
		//
		// Returns:
		//     true if a and b are equal; otherwise, false.
		public static bool operator ==(SearchConditionExpressionOperatorConstant a, SearchConditionExpressionOperatorConstant b)
		{
			return SearchConditionExpressionOperatorConstant.Equal(a, b);
		}

		// Summary:
		//     Compares this instance to a specified SearchConditionExpressionOperatorConstant object and returns an indication
		//     of their relative values.
		//
		// Parameters:
		//   value:
		//     A SearchConditionExpressionOperatorConstant object to compare to this instance.
		//
		// Returns:
		//     A signed number indicating the relative values of this instance and value.
		//      Value Description A negative integer This instance is less than value. Zero
		//     This instance is equal to value. A positive integer This instance is greater
		//     than value.
		public int CompareTo(SearchConditionExpressionOperatorConstant value)
		{
			int result;
			if ((result = this.Value.CompareTo(value.Value)) != 0)
				return result;
			return 0;
		}

		//
		// Summary:
		//     Compares this instance to a specified object and returns an indication of
		//     their relative values.
		//
		// Parameters:
		//   value:
		//     An object to compare, or null.
		//
		// Returns:
		//     A signed number indicating the relative values of this instance and value.
		//      Value Description A negative integer This instance is less than value. Zero
		//     This instance is equal to value. A positive integer This instance is greater
		//     than value.  -or- value is null.
		//
		// Exceptions:
		//   System.ArgumentException:
		//     value is not a SearchConditionExpressionOperatorConstant.
		public int CompareTo(object value)
		{
			if (value is SearchConditionExpressionOperatorConstant)
				return this.CompareTo((SearchConditionExpressionOperatorConstant)value);
			throw new ArgumentException("value is not a SearchConditionExpressionOperatorConstant", "value");
		}

		//
		// Summary:
		//     Returns a value indicating whether this instance and a specified SearchConditionExpressionOperatorConstant
		//     object represent the same value.
		//
		// Parameters:
		//   g:
		//     A SearchConditionExpressionOperatorConstant object to compare to this instance.
		//
		// Returns:
		//     true if g is equal to this instance; otherwise, false.
		public bool Equals(SearchConditionExpressionOperatorConstant oi)
		{
			return SearchConditionExpressionOperatorConstant.Equal(this, oi);
		}

		//
		// Summary:
		//     Returns a value indicating whether this instance is equal to a specified
		//     object.
		//
		// Parameters:
		//   o:
		//     The object to compare with this instance.
		//
		// Returns:
		//     true if o is a SearchConditionExpressionOperatorConstant that has the same value as this instance; otherwise,
		//     false.
		public override bool Equals(object o)
		{
			if (o is SearchConditionExpressionOperatorConstant)
				return SearchConditionExpressionOperatorConstant.Equal(this, (SearchConditionExpressionOperatorConstant)o);
			return false;
		}

		//
		// Summary:
		//     Returns the hash code for this instance.
		//
		// Returns:
		//     The hash code for this instance.
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		public override string ToString()
		{
			return this.Value.ToString();
		}

		private static bool Equal(SearchConditionExpressionOperatorConstant a, SearchConditionExpressionOperatorConstant b)
		{
			return a.Value == b.Value;
		}
	}

	public partial class SearchConditionExpressionOperator
	{
		//Is the operator used to test the equality between two expressions.
		public static readonly SearchConditionExpressionOperatorConstant Equal = new SearchConditionExpressionOperatorConstant("=");
		// Is the operator used to test the condition of two expressions not being equal to each other.
		public static readonly SearchConditionExpressionOperatorConstant NotEqual = new SearchConditionExpressionOperatorConstant("<>");
		// Is the operator used to test the condition of one expression being greater than the other.
		public static readonly SearchConditionExpressionOperatorConstant GreaterThan = new SearchConditionExpressionOperatorConstant(">");
		// Is the operator used to test the condition of one expression being greater than or equal to the other expression.
		public static readonly SearchConditionExpressionOperatorConstant GreaterThanOrEqual = new SearchConditionExpressionOperatorConstant(">=");
		// Is the operator used to test the condition of one expression not being greater than the other expression.
		public static readonly SearchConditionExpressionOperatorConstant NotGreaterThan = new SearchConditionExpressionOperatorConstant("!>");
		// Is the operator used to test the condition of one expression being less than the other.
		public static readonly SearchConditionExpressionOperatorConstant LessThan = new SearchConditionExpressionOperatorConstant("<");
		// Is the operator used to test the condition of one expression being less than or equal to the other expression.
		public static readonly SearchConditionExpressionOperatorConstant LessThanOrEqual = new SearchConditionExpressionOperatorConstant("<");
		// Is the operator used to test the condition of one expression not being less than the other expression.
		public static readonly SearchConditionExpressionOperatorConstant NotLessThan = new SearchConditionExpressionOperatorConstant("!<");
		// Indicates that the subsequent character string is to be used with pattern matching.
		public static readonly SearchConditionExpressionOperatorConstant Like = new SearchConditionExpressionOperatorConstant("LIKE");
		public static readonly SearchConditionExpressionOperatorConstant NotLike = new SearchConditionExpressionOperatorConstant("NOT LIKE");
	}
	public struct SortSpecificationDirectionSpecifierConstant : IComparable, IComparable<SortSpecificationDirectionSpecifierConstant>, IEquatable<SortSpecificationDirectionSpecifierConstant>
	{
		public readonly string Value;

		public SortSpecificationDirectionSpecifierConstant(string value)
		{
			this.Value = value;
		}

		// Summary:
		//     Returns an indication whether the values of two specified SortSpecificationDirectionSpecifierConstant objects
		//     are not equal.
		//
		// Parameters:
		//   a:
		//     A SortSpecificationDirectionSpecifierConstant object.
		//
		//   b:
		//     A SortSpecificationDirectionSpecifierConstant object.
		//
		// Returns:
		//     true if a and b are not equal; otherwise, false.
		public static bool operator !=(SortSpecificationDirectionSpecifierConstant a, SortSpecificationDirectionSpecifierConstant b)
		{
			return !SortSpecificationDirectionSpecifierConstant.Equal(a, b);
		}

		//
		// Summary:
		//     Returns an indication whether the values of two specified SortSpecificationDirectionSpecifierConstant objects
		//     are equal.
		//
		// Parameters:
		//   a:
		//     A SortSpecificationDirectionSpecifierConstant object.
		//
		//   b:
		//     A SortSpecificationDirectionSpecifierConstant object.
		//
		// Returns:
		//     true if a and b are equal; otherwise, false.
		public static bool operator ==(SortSpecificationDirectionSpecifierConstant a, SortSpecificationDirectionSpecifierConstant b)
		{
			return SortSpecificationDirectionSpecifierConstant.Equal(a, b);
		}

		// Summary:
		//     Compares this instance to a specified SortSpecificationDirectionSpecifierConstant object and returns an indication
		//     of their relative values.
		//
		// Parameters:
		//   value:
		//     A SortSpecificationDirectionSpecifierConstant object to compare to this instance.
		//
		// Returns:
		//     A signed number indicating the relative values of this instance and value.
		//      Value Description A negative integer This instance is less than value. Zero
		//     This instance is equal to value. A positive integer This instance is greater
		//     than value.
		public int CompareTo(SortSpecificationDirectionSpecifierConstant value)
		{
			int result;
			if ((result = this.Value.CompareTo(value.Value)) != 0)
				return result;
			return 0;
		}

		//
		// Summary:
		//     Compares this instance to a specified object and returns an indication of
		//     their relative values.
		//
		// Parameters:
		//   value:
		//     An object to compare, or null.
		//
		// Returns:
		//     A signed number indicating the relative values of this instance and value.
		//      Value Description A negative integer This instance is less than value. Zero
		//     This instance is equal to value. A positive integer This instance is greater
		//     than value.  -or- value is null.
		//
		// Exceptions:
		//   System.ArgumentException:
		//     value is not a SortSpecificationDirectionSpecifierConstant.
		public int CompareTo(object value)
		{
			if (value is SortSpecificationDirectionSpecifierConstant)
				return this.CompareTo((SortSpecificationDirectionSpecifierConstant)value);
			throw new ArgumentException("value is not a SortSpecificationDirectionSpecifierConstant", "value");
		}

		//
		// Summary:
		//     Returns a value indicating whether this instance and a specified SortSpecificationDirectionSpecifierConstant
		//     object represent the same value.
		//
		// Parameters:
		//   g:
		//     A SortSpecificationDirectionSpecifierConstant object to compare to this instance.
		//
		// Returns:
		//     true if g is equal to this instance; otherwise, false.
		public bool Equals(SortSpecificationDirectionSpecifierConstant oi)
		{
			return SortSpecificationDirectionSpecifierConstant.Equal(this, oi);
		}

		//
		// Summary:
		//     Returns a value indicating whether this instance is equal to a specified
		//     object.
		//
		// Parameters:
		//   o:
		//     The object to compare with this instance.
		//
		// Returns:
		//     true if o is a SortSpecificationDirectionSpecifierConstant that has the same value as this instance; otherwise,
		//     false.
		public override bool Equals(object o)
		{
			if (o is SortSpecificationDirectionSpecifierConstant)
				return SortSpecificationDirectionSpecifierConstant.Equal(this, (SortSpecificationDirectionSpecifierConstant)o);
			return false;
		}

		//
		// Summary:
		//     Returns the hash code for this instance.
		//
		// Returns:
		//     The hash code for this instance.
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		public override string ToString()
		{
			return this.Value.ToString();
		}

		private static bool Equal(SortSpecificationDirectionSpecifierConstant a, SortSpecificationDirectionSpecifierConstant b)
		{
			return a.Value == b.Value;
		}
	}

	public partial class SortSpecificationDirectionSpecifier
	{
		public static readonly SortSpecificationDirectionSpecifierConstant Ascending = new SortSpecificationDirectionSpecifierConstant("ASC");
		public static readonly SortSpecificationDirectionSpecifierConstant Descending = new SortSpecificationDirectionSpecifierConstant("DESC");
	}
	public struct RepositoryExceptionMessageConstant : IComparable, IComparable<RepositoryExceptionMessageConstant>, IEquatable<RepositoryExceptionMessageConstant>
	{
		public readonly string Value;

		public RepositoryExceptionMessageConstant(string value)
		{
			this.Value = value;
		}

		// Summary:
		//     Returns an indication whether the values of two specified RepositoryExceptionMessageConstant objects
		//     are not equal.
		//
		// Parameters:
		//   a:
		//     A RepositoryExceptionMessageConstant object.
		//
		//   b:
		//     A RepositoryExceptionMessageConstant object.
		//
		// Returns:
		//     true if a and b are not equal; otherwise, false.
		public static bool operator !=(RepositoryExceptionMessageConstant a, RepositoryExceptionMessageConstant b)
		{
			return !RepositoryExceptionMessageConstant.Equal(a, b);
		}

		//
		// Summary:
		//     Returns an indication whether the values of two specified RepositoryExceptionMessageConstant objects
		//     are equal.
		//
		// Parameters:
		//   a:
		//     A RepositoryExceptionMessageConstant object.
		//
		//   b:
		//     A RepositoryExceptionMessageConstant object.
		//
		// Returns:
		//     true if a and b are equal; otherwise, false.
		public static bool operator ==(RepositoryExceptionMessageConstant a, RepositoryExceptionMessageConstant b)
		{
			return RepositoryExceptionMessageConstant.Equal(a, b);
		}

		// Summary:
		//     Compares this instance to a specified RepositoryExceptionMessageConstant object and returns an indication
		//     of their relative values.
		//
		// Parameters:
		//   value:
		//     A RepositoryExceptionMessageConstant object to compare to this instance.
		//
		// Returns:
		//     A signed number indicating the relative values of this instance and value.
		//      Value Description A negative integer This instance is less than value. Zero
		//     This instance is equal to value. A positive integer This instance is greater
		//     than value.
		public int CompareTo(RepositoryExceptionMessageConstant value)
		{
			int result;
			if ((result = this.Value.CompareTo(value.Value)) != 0)
				return result;
			return 0;
		}

		//
		// Summary:
		//     Compares this instance to a specified object and returns an indication of
		//     their relative values.
		//
		// Parameters:
		//   value:
		//     An object to compare, or null.
		//
		// Returns:
		//     A signed number indicating the relative values of this instance and value.
		//      Value Description A negative integer This instance is less than value. Zero
		//     This instance is equal to value. A positive integer This instance is greater
		//     than value.  -or- value is null.
		//
		// Exceptions:
		//   System.ArgumentException:
		//     value is not a RepositoryExceptionMessageConstant.
		public int CompareTo(object value)
		{
			if (value is RepositoryExceptionMessageConstant)
				return this.CompareTo((RepositoryExceptionMessageConstant)value);
			throw new ArgumentException("value is not a RepositoryExceptionMessageConstant", "value");
		}

		//
		// Summary:
		//     Returns a value indicating whether this instance and a specified RepositoryExceptionMessageConstant
		//     object represent the same value.
		//
		// Parameters:
		//   g:
		//     A RepositoryExceptionMessageConstant object to compare to this instance.
		//
		// Returns:
		//     true if g is equal to this instance; otherwise, false.
		public bool Equals(RepositoryExceptionMessageConstant oi)
		{
			return RepositoryExceptionMessageConstant.Equal(this, oi);
		}

		//
		// Summary:
		//     Returns a value indicating whether this instance is equal to a specified
		//     object.
		//
		// Parameters:
		//   o:
		//     The object to compare with this instance.
		//
		// Returns:
		//     true if o is a RepositoryExceptionMessageConstant that has the same value as this instance; otherwise,
		//     false.
		public override bool Equals(object o)
		{
			if (o is RepositoryExceptionMessageConstant)
				return RepositoryExceptionMessageConstant.Equal(this, (RepositoryExceptionMessageConstant)o);
			return false;
		}

		//
		// Summary:
		//     Returns the hash code for this instance.
		//
		// Returns:
		//     The hash code for this instance.
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		public override string ToString()
		{
			return this.Value.ToString();
		}

		private static bool Equal(RepositoryExceptionMessageConstant a, RepositoryExceptionMessageConstant b)
		{
			return a.Value == b.Value;
		}
	}

	public partial class RepositoryExceptionMessage
	{
		public static readonly RepositoryExceptionMessageConstant None = new RepositoryExceptionMessageConstant("");
		public static readonly RepositoryExceptionMessageConstant UpdateCollisionDetected = new RepositoryExceptionMessageConstant("Update collision detected.");
		public static readonly RepositoryExceptionMessageConstant DeleteCollisionDetected = new RepositoryExceptionMessageConstant("Delete collision detected.");
		public static readonly RepositoryExceptionMessageConstant MultipleCollisionsDetected = new RepositoryExceptionMessageConstant("Multiple collisions detected.");
		public static readonly RepositoryExceptionMessageConstant NotBaseEntityObjectCompatible = new RepositoryExceptionMessageConstant("Object not BaseEntityObject compatible.");
		public static readonly RepositoryExceptionMessageConstant UnexpectedExceptionDetected = new RepositoryExceptionMessageConstant("Unexpected exception detected.");
		public static readonly RepositoryExceptionMessageConstant NonEmptySearchConditionRequired = new RepositoryExceptionMessageConstant("Non-empty search condition required.");
		public static readonly RepositoryExceptionMessageConstant CannotUpdateForeignKey = new RepositoryExceptionMessageConstant("Cannot update foreign key property when object is linked to related object in memory.");
		public static readonly RepositoryExceptionMessageConstant EntityClassNotSupported = new RepositoryExceptionMessageConstant("Entity class not supported.");
		public static readonly RepositoryExceptionMessageConstant CustomDeleteFunctionNotImplemented = new RepositoryExceptionMessageConstant("Custom delete function not implemented.");
		public static readonly RepositoryExceptionMessageConstant CustomSaveFunctionNotImplemented = new RepositoryExceptionMessageConstant("Custom delete function not implemented.");
	}
}
