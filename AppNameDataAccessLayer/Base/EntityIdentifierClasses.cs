using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustName.AppName.DAL
{
	[Serializable]
	public struct Attachment1Identifier : IComparable<Attachment1Identifier>, IEquatable<Attachment1Identifier>, IIdentifier
	{
		private const int fieldCount = 2;
		private int attachment1Id;

		public int Attachment1Id
		{
			get
			{
				return this.attachment1Id;
			}
			set
			{
				this.attachment1Id = value;
			}
		}

		// Summary:
		//     Returns an indication whether the values of two specified Attachment1Identifier objects
		//     are not equal.
		//
		// Parameters:
		//   a:
		//     A Attachment1Identifier object.
		//
		//   b:
		//     A Attachment1Identifier object.
		//
		// Returns:
		//     true if a and b are not equal; otherwise, false.
		public static bool operator !=(Attachment1Identifier a, Attachment1Identifier b)
		{
			return !Attachment1Identifier.Equal(a, b);
		}

		//
		// Summary:
		//     Returns an indication whether the values of two specified Attachment1Identifier objects
		//     are equal.
		//
		// Parameters:
		//   a:
		//     A Attachment1Identifier object.
		//
		//   b:
		//     A Attachment1Identifier object.
		//
		// Returns:
		//     true if a and b are equal; otherwise, false.
		public static bool operator ==(Attachment1Identifier a, Attachment1Identifier b)
		{
			return Attachment1Identifier.Equal(a, b);
		}

		// Summary:
		//     Compares this instance to a specified Attachment1Identifier object and returns an indication
		//     of their relative values.
		//
		// Parameters:
		//   value:
		//     A Attachment1Identifier object to compare to this instance.
		//
		// Returns:
		//     A signed number indicating the relative values of this instance and value.
		//      Value Description A negative integer This instance is less than value. Zero
		//     This instance is equal to value. A positive integer This instance is greater
		//     than value.
		public int CompareTo(Attachment1Identifier value)
		{
			int result;
			if ((result = this.attachment1Id.CompareTo(value.attachment1Id)) != 0)
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
		//     value is not a Attachment1Identifier.
		public int CompareTo(object value)
		{
			if (value is Attachment1Identifier)
				return this.CompareTo((Attachment1Identifier)value);
			throw new ArgumentException("value is not a Attachment1Identifier", "value");
		}

		//
		// Summary:
		//     Returns a value indicating whether this instance and a specified Attachment1Identifier
		//     object represent the same value.
		//
		// Parameters:
		//   g:
		//     A Attachment1Identifier object to compare to this instance.
		//
		// Returns:
		//     true if g is equal to this instance; otherwise, false.
		public bool Equals(Attachment1Identifier oi)
		{
			return Attachment1Identifier.Equal(this, oi);
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
		//     true if o is a Attachment1Identifier that has the same value as this instance; otherwise,
		//     false.
		public override bool Equals(object o)
		{
			if (o is Attachment1Identifier)
				return Attachment1Identifier.Equal(this, (Attachment1Identifier)o);
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
			int hash = 23;
			hash = ((hash << 5) * 37) + this.Attachment1Id.GetHashCode();
			return hash;
		}

		public override string ToString()
		{
			string s = "Attachment1Id=" + this.attachment1Id.ToString();
			return s;
		}

		public int FieldCount
		{
			get
			{
				return Attachment1Identifier.fieldCount;
			}
		}

		[System.Runtime.CompilerServices.IndexerName("Item")]
		public object this[int index]
		{
			get
			{
				switch (index)
				{
					case 0:
						return (object)this.attachment1Id;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
			set
			{
				switch (index)
				{
					case 0:
						this.attachment1Id = (int)value;
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
		}

		[System.Runtime.CompilerServices.IndexerName("Item")]
		public object this[string index]
		{
			get
			{
				switch (index)
				{
					case "Attachment1Id":
						return (object)this.attachment1Id;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
			set
			{
				switch (index)
				{
					case "Attachment1Id":
						this.attachment1Id = (int)value;
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
		}

		public bool Equivalent(IIdentifier identifier)
		{
			bool equivalent = true;
			if (identifier.FieldCount == Attachment1Identifier.fieldCount)
			{
				object fieldA, fieldB;
				for (int index = 0; index < Attachment1Identifier.fieldCount; ++index)
				{
					fieldA = identifier[index];
					fieldB = this[index];
					if (!(fieldA.GetType() == fieldB.GetType() && fieldA.Equals(fieldB)))
					{
						equivalent = false;
						break;
					}
				}
			}
			else
				equivalent = false;
			return equivalent;
		}

		private static bool Equal(Attachment1Identifier a, Attachment1Identifier b)
		{
			return a.attachment1Id == b.attachment1Id;
		}
	}

	[Serializable]
	public struct DependentEntity1Identifier : IComparable<DependentEntity1Identifier>, IEquatable<DependentEntity1Identifier>, IIdentifier
	{
		private const int fieldCount = 2;
		private int dependentEntity1Id;

		public int DependentEntity1Id
		{
			get
			{
				return this.dependentEntity1Id;
			}
			set
			{
				this.dependentEntity1Id = value;
			}
		}

		// Summary:
		//     Returns an indication whether the values of two specified DependentEntity1Identifier objects
		//     are not equal.
		//
		// Parameters:
		//   a:
		//     A DependentEntity1Identifier object.
		//
		//   b:
		//     A DependentEntity1Identifier object.
		//
		// Returns:
		//     true if a and b are not equal; otherwise, false.
		public static bool operator !=(DependentEntity1Identifier a, DependentEntity1Identifier b)
		{
			return !DependentEntity1Identifier.Equal(a, b);
		}

		//
		// Summary:
		//     Returns an indication whether the values of two specified DependentEntity1Identifier objects
		//     are equal.
		//
		// Parameters:
		//   a:
		//     A DependentEntity1Identifier object.
		//
		//   b:
		//     A DependentEntity1Identifier object.
		//
		// Returns:
		//     true if a and b are equal; otherwise, false.
		public static bool operator ==(DependentEntity1Identifier a, DependentEntity1Identifier b)
		{
			return DependentEntity1Identifier.Equal(a, b);
		}

		// Summary:
		//     Compares this instance to a specified DependentEntity1Identifier object and returns an indication
		//     of their relative values.
		//
		// Parameters:
		//   value:
		//     A DependentEntity1Identifier object to compare to this instance.
		//
		// Returns:
		//     A signed number indicating the relative values of this instance and value.
		//      Value Description A negative integer This instance is less than value. Zero
		//     This instance is equal to value. A positive integer This instance is greater
		//     than value.
		public int CompareTo(DependentEntity1Identifier value)
		{
			int result;
			if ((result = this.dependentEntity1Id.CompareTo(value.dependentEntity1Id)) != 0)
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
		//     value is not a DependentEntity1Identifier.
		public int CompareTo(object value)
		{
			if (value is DependentEntity1Identifier)
				return this.CompareTo((DependentEntity1Identifier)value);
			throw new ArgumentException("value is not a DependentEntity1Identifier", "value");
		}

		//
		// Summary:
		//     Returns a value indicating whether this instance and a specified DependentEntity1Identifier
		//     object represent the same value.
		//
		// Parameters:
		//   g:
		//     A DependentEntity1Identifier object to compare to this instance.
		//
		// Returns:
		//     true if g is equal to this instance; otherwise, false.
		public bool Equals(DependentEntity1Identifier oi)
		{
			return DependentEntity1Identifier.Equal(this, oi);
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
		//     true if o is a DependentEntity1Identifier that has the same value as this instance; otherwise,
		//     false.
		public override bool Equals(object o)
		{
			if (o is DependentEntity1Identifier)
				return DependentEntity1Identifier.Equal(this, (DependentEntity1Identifier)o);
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
			int hash = 23;
			hash = ((hash << 5) * 37) + this.DependentEntity1Id.GetHashCode();
			return hash;
		}

		public override string ToString()
		{
			string s = "DependentEntity1Id=" + this.dependentEntity1Id.ToString();
			return s;
		}

		public int FieldCount
		{
			get
			{
				return DependentEntity1Identifier.fieldCount;
			}
		}

		[System.Runtime.CompilerServices.IndexerName("Item")]
		public object this[int index]
		{
			get
			{
				switch (index)
				{
					case 0:
						return (object)this.dependentEntity1Id;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
			set
			{
				switch (index)
				{
					case 0:
						this.dependentEntity1Id = (int)value;
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
		}

		[System.Runtime.CompilerServices.IndexerName("Item")]
		public object this[string index]
		{
			get
			{
				switch (index)
				{
					case "DependentEntity1Id":
						return (object)this.dependentEntity1Id;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
			set
			{
				switch (index)
				{
					case "DependentEntity1Id":
						this.dependentEntity1Id = (int)value;
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
		}

		public bool Equivalent(IIdentifier identifier)
		{
			bool equivalent = true;
			if (identifier.FieldCount == DependentEntity1Identifier.fieldCount)
			{
				object fieldA, fieldB;
				for (int index = 0; index < DependentEntity1Identifier.fieldCount; ++index)
				{
					fieldA = identifier[index];
					fieldB = this[index];
					if (!(fieldA.GetType() == fieldB.GetType() && fieldA.Equals(fieldB)))
					{
						equivalent = false;
						break;
					}
				}
			}
			else
				equivalent = false;
			return equivalent;
		}

		private static bool Equal(DependentEntity1Identifier a, DependentEntity1Identifier b)
		{
			return a.dependentEntity1Id == b.dependentEntity1Id;
		}
	}

	[Serializable]
	public struct DependentEntity2Identifier : IComparable<DependentEntity2Identifier>, IEquatable<DependentEntity2Identifier>, IIdentifier
	{
		private const int fieldCount = 2;
		private int dependentEntity2Id;

		public int DependentEntity2Id
		{
			get
			{
				return this.dependentEntity2Id;
			}
			set
			{
				this.dependentEntity2Id = value;
			}
		}

		// Summary:
		//     Returns an indication whether the values of two specified DependentEntity2Identifier objects
		//     are not equal.
		//
		// Parameters:
		//   a:
		//     A DependentEntity2Identifier object.
		//
		//   b:
		//     A DependentEntity2Identifier object.
		//
		// Returns:
		//     true if a and b are not equal; otherwise, false.
		public static bool operator !=(DependentEntity2Identifier a, DependentEntity2Identifier b)
		{
			return !DependentEntity2Identifier.Equal(a, b);
		}

		//
		// Summary:
		//     Returns an indication whether the values of two specified DependentEntity2Identifier objects
		//     are equal.
		//
		// Parameters:
		//   a:
		//     A DependentEntity2Identifier object.
		//
		//   b:
		//     A DependentEntity2Identifier object.
		//
		// Returns:
		//     true if a and b are equal; otherwise, false.
		public static bool operator ==(DependentEntity2Identifier a, DependentEntity2Identifier b)
		{
			return DependentEntity2Identifier.Equal(a, b);
		}

		// Summary:
		//     Compares this instance to a specified DependentEntity2Identifier object and returns an indication
		//     of their relative values.
		//
		// Parameters:
		//   value:
		//     A DependentEntity2Identifier object to compare to this instance.
		//
		// Returns:
		//     A signed number indicating the relative values of this instance and value.
		//      Value Description A negative integer This instance is less than value. Zero
		//     This instance is equal to value. A positive integer This instance is greater
		//     than value.
		public int CompareTo(DependentEntity2Identifier value)
		{
			int result;
			if ((result = this.dependentEntity2Id.CompareTo(value.dependentEntity2Id)) != 0)
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
		//     value is not a DependentEntity2Identifier.
		public int CompareTo(object value)
		{
			if (value is DependentEntity2Identifier)
				return this.CompareTo((DependentEntity2Identifier)value);
			throw new ArgumentException("value is not a DependentEntity2Identifier", "value");
		}

		//
		// Summary:
		//     Returns a value indicating whether this instance and a specified DependentEntity2Identifier
		//     object represent the same value.
		//
		// Parameters:
		//   g:
		//     A DependentEntity2Identifier object to compare to this instance.
		//
		// Returns:
		//     true if g is equal to this instance; otherwise, false.
		public bool Equals(DependentEntity2Identifier oi)
		{
			return DependentEntity2Identifier.Equal(this, oi);
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
		//     true if o is a DependentEntity2Identifier that has the same value as this instance; otherwise,
		//     false.
		public override bool Equals(object o)
		{
			if (o is DependentEntity2Identifier)
				return DependentEntity2Identifier.Equal(this, (DependentEntity2Identifier)o);
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
			int hash = 23;
			hash = ((hash << 5) * 37) + this.DependentEntity2Id.GetHashCode();
			return hash;
		}

		public override string ToString()
		{
			string s = "DependentEntity2Id=" + this.dependentEntity2Id.ToString();
			return s;
		}

		public int FieldCount
		{
			get
			{
				return DependentEntity2Identifier.fieldCount;
			}
		}

		[System.Runtime.CompilerServices.IndexerName("Item")]
		public object this[int index]
		{
			get
			{
				switch (index)
				{
					case 0:
						return (object)this.dependentEntity2Id;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
			set
			{
				switch (index)
				{
					case 0:
						this.dependentEntity2Id = (int)value;
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
		}

		[System.Runtime.CompilerServices.IndexerName("Item")]
		public object this[string index]
		{
			get
			{
				switch (index)
				{
					case "DependentEntity2Id":
						return (object)this.dependentEntity2Id;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
			set
			{
				switch (index)
				{
					case "DependentEntity2Id":
						this.dependentEntity2Id = (int)value;
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
		}

		public bool Equivalent(IIdentifier identifier)
		{
			bool equivalent = true;
			if (identifier.FieldCount == DependentEntity2Identifier.fieldCount)
			{
				object fieldA, fieldB;
				for (int index = 0; index < DependentEntity2Identifier.fieldCount; ++index)
				{
					fieldA = identifier[index];
					fieldB = this[index];
					if (!(fieldA.GetType() == fieldB.GetType() && fieldA.Equals(fieldB)))
					{
						equivalent = false;
						break;
					}
				}
			}
			else
				equivalent = false;
			return equivalent;
		}

		private static bool Equal(DependentEntity2Identifier a, DependentEntity2Identifier b)
		{
			return a.dependentEntity2Id == b.dependentEntity2Id;
		}
	}

	[Serializable]
	public struct IndependentEntity1Identifier : IComparable<IndependentEntity1Identifier>, IEquatable<IndependentEntity1Identifier>, IIdentifier
	{
		private const int fieldCount = 2;
		private int independentEntity1Id;

		public int IndependentEntity1Id
		{
			get
			{
				return this.independentEntity1Id;
			}
			set
			{
				this.independentEntity1Id = value;
			}
		}

		// Summary:
		//     Returns an indication whether the values of two specified IndependentEntity1Identifier objects
		//     are not equal.
		//
		// Parameters:
		//   a:
		//     A IndependentEntity1Identifier object.
		//
		//   b:
		//     A IndependentEntity1Identifier object.
		//
		// Returns:
		//     true if a and b are not equal; otherwise, false.
		public static bool operator !=(IndependentEntity1Identifier a, IndependentEntity1Identifier b)
		{
			return !IndependentEntity1Identifier.Equal(a, b);
		}

		//
		// Summary:
		//     Returns an indication whether the values of two specified IndependentEntity1Identifier objects
		//     are equal.
		//
		// Parameters:
		//   a:
		//     A IndependentEntity1Identifier object.
		//
		//   b:
		//     A IndependentEntity1Identifier object.
		//
		// Returns:
		//     true if a and b are equal; otherwise, false.
		public static bool operator ==(IndependentEntity1Identifier a, IndependentEntity1Identifier b)
		{
			return IndependentEntity1Identifier.Equal(a, b);
		}

		// Summary:
		//     Compares this instance to a specified IndependentEntity1Identifier object and returns an indication
		//     of their relative values.
		//
		// Parameters:
		//   value:
		//     A IndependentEntity1Identifier object to compare to this instance.
		//
		// Returns:
		//     A signed number indicating the relative values of this instance and value.
		//      Value Description A negative integer This instance is less than value. Zero
		//     This instance is equal to value. A positive integer This instance is greater
		//     than value.
		public int CompareTo(IndependentEntity1Identifier value)
		{
			int result;
			if ((result = this.independentEntity1Id.CompareTo(value.independentEntity1Id)) != 0)
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
		//     value is not a IndependentEntity1Identifier.
		public int CompareTo(object value)
		{
			if (value is IndependentEntity1Identifier)
				return this.CompareTo((IndependentEntity1Identifier)value);
			throw new ArgumentException("value is not a IndependentEntity1Identifier", "value");
		}

		//
		// Summary:
		//     Returns a value indicating whether this instance and a specified IndependentEntity1Identifier
		//     object represent the same value.
		//
		// Parameters:
		//   g:
		//     A IndependentEntity1Identifier object to compare to this instance.
		//
		// Returns:
		//     true if g is equal to this instance; otherwise, false.
		public bool Equals(IndependentEntity1Identifier oi)
		{
			return IndependentEntity1Identifier.Equal(this, oi);
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
		//     true if o is a IndependentEntity1Identifier that has the same value as this instance; otherwise,
		//     false.
		public override bool Equals(object o)
		{
			if (o is IndependentEntity1Identifier)
				return IndependentEntity1Identifier.Equal(this, (IndependentEntity1Identifier)o);
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
			int hash = 23;
			hash = ((hash << 5) * 37) + this.IndependentEntity1Id.GetHashCode();
			return hash;
		}

		public override string ToString()
		{
			string s = "IndependentEntity1Id=" + this.independentEntity1Id.ToString();
			return s;
		}

		public int FieldCount
		{
			get
			{
				return IndependentEntity1Identifier.fieldCount;
			}
		}

		[System.Runtime.CompilerServices.IndexerName("Item")]
		public object this[int index]
		{
			get
			{
				switch (index)
				{
					case 0:
						return (object)this.independentEntity1Id;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
			set
			{
				switch (index)
				{
					case 0:
						this.independentEntity1Id = (int)value;
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
		}

		[System.Runtime.CompilerServices.IndexerName("Item")]
		public object this[string index]
		{
			get
			{
				switch (index)
				{
					case "IndependentEntity1Id":
						return (object)this.independentEntity1Id;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
			set
			{
				switch (index)
				{
					case "IndependentEntity1Id":
						this.independentEntity1Id = (int)value;
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
		}

		public bool Equivalent(IIdentifier identifier)
		{
			bool equivalent = true;
			if (identifier.FieldCount == IndependentEntity1Identifier.fieldCount)
			{
				object fieldA, fieldB;
				for (int index = 0; index < IndependentEntity1Identifier.fieldCount; ++index)
				{
					fieldA = identifier[index];
					fieldB = this[index];
					if (!(fieldA.GetType() == fieldB.GetType() && fieldA.Equals(fieldB)))
					{
						equivalent = false;
						break;
					}
				}
			}
			else
				equivalent = false;
			return equivalent;
		}

		private static bool Equal(IndependentEntity1Identifier a, IndependentEntity1Identifier b)
		{
			return a.independentEntity1Id == b.independentEntity1Id;
		}
	}

	[Serializable]
	public struct IndependentEntity2Identifier : IComparable<IndependentEntity2Identifier>, IEquatable<IndependentEntity2Identifier>, IIdentifier
	{
		private const int fieldCount = 2;
		private int independentEntity2Id;

		public int IndependentEntity2Id
		{
			get
			{
				return this.independentEntity2Id;
			}
			set
			{
				this.independentEntity2Id = value;
			}
		}

		// Summary:
		//     Returns an indication whether the values of two specified IndependentEntity2Identifier objects
		//     are not equal.
		//
		// Parameters:
		//   a:
		//     A IndependentEntity2Identifier object.
		//
		//   b:
		//     A IndependentEntity2Identifier object.
		//
		// Returns:
		//     true if a and b are not equal; otherwise, false.
		public static bool operator !=(IndependentEntity2Identifier a, IndependentEntity2Identifier b)
		{
			return !IndependentEntity2Identifier.Equal(a, b);
		}

		//
		// Summary:
		//     Returns an indication whether the values of two specified IndependentEntity2Identifier objects
		//     are equal.
		//
		// Parameters:
		//   a:
		//     A IndependentEntity2Identifier object.
		//
		//   b:
		//     A IndependentEntity2Identifier object.
		//
		// Returns:
		//     true if a and b are equal; otherwise, false.
		public static bool operator ==(IndependentEntity2Identifier a, IndependentEntity2Identifier b)
		{
			return IndependentEntity2Identifier.Equal(a, b);
		}

		// Summary:
		//     Compares this instance to a specified IndependentEntity2Identifier object and returns an indication
		//     of their relative values.
		//
		// Parameters:
		//   value:
		//     A IndependentEntity2Identifier object to compare to this instance.
		//
		// Returns:
		//     A signed number indicating the relative values of this instance and value.
		//      Value Description A negative integer This instance is less than value. Zero
		//     This instance is equal to value. A positive integer This instance is greater
		//     than value.
		public int CompareTo(IndependentEntity2Identifier value)
		{
			int result;
			if ((result = this.independentEntity2Id.CompareTo(value.independentEntity2Id)) != 0)
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
		//     value is not a IndependentEntity2Identifier.
		public int CompareTo(object value)
		{
			if (value is IndependentEntity2Identifier)
				return this.CompareTo((IndependentEntity2Identifier)value);
			throw new ArgumentException("value is not a IndependentEntity2Identifier", "value");
		}

		//
		// Summary:
		//     Returns a value indicating whether this instance and a specified IndependentEntity2Identifier
		//     object represent the same value.
		//
		// Parameters:
		//   g:
		//     A IndependentEntity2Identifier object to compare to this instance.
		//
		// Returns:
		//     true if g is equal to this instance; otherwise, false.
		public bool Equals(IndependentEntity2Identifier oi)
		{
			return IndependentEntity2Identifier.Equal(this, oi);
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
		//     true if o is a IndependentEntity2Identifier that has the same value as this instance; otherwise,
		//     false.
		public override bool Equals(object o)
		{
			if (o is IndependentEntity2Identifier)
				return IndependentEntity2Identifier.Equal(this, (IndependentEntity2Identifier)o);
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
			int hash = 23;
			hash = ((hash << 5) * 37) + this.IndependentEntity2Id.GetHashCode();
			return hash;
		}

		public override string ToString()
		{
			string s = "IndependentEntity2Id=" + this.independentEntity2Id.ToString();
			return s;
		}

		public int FieldCount
		{
			get
			{
				return IndependentEntity2Identifier.fieldCount;
			}
		}

		[System.Runtime.CompilerServices.IndexerName("Item")]
		public object this[int index]
		{
			get
			{
				switch (index)
				{
					case 0:
						return (object)this.independentEntity2Id;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
			set
			{
				switch (index)
				{
					case 0:
						this.independentEntity2Id = (int)value;
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
		}

		[System.Runtime.CompilerServices.IndexerName("Item")]
		public object this[string index]
		{
			get
			{
				switch (index)
				{
					case "IndependentEntity2Id":
						return (object)this.independentEntity2Id;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
			set
			{
				switch (index)
				{
					case "IndependentEntity2Id":
						this.independentEntity2Id = (int)value;
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
		}

		public bool Equivalent(IIdentifier identifier)
		{
			bool equivalent = true;
			if (identifier.FieldCount == IndependentEntity2Identifier.fieldCount)
			{
				object fieldA, fieldB;
				for (int index = 0; index < IndependentEntity2Identifier.fieldCount; ++index)
				{
					fieldA = identifier[index];
					fieldB = this[index];
					if (!(fieldA.GetType() == fieldB.GetType() && fieldA.Equals(fieldB)))
					{
						equivalent = false;
						break;
					}
				}
			}
			else
				equivalent = false;
			return equivalent;
		}

		private static bool Equal(IndependentEntity2Identifier a, IndependentEntity2Identifier b)
		{
			return a.independentEntity2Id == b.independentEntity2Id;
		}
	}

	[Serializable]
	public struct RelationshipEntity1Identifier : IComparable<RelationshipEntity1Identifier>, IEquatable<RelationshipEntity1Identifier>, IIdentifier
	{
		private const int fieldCount = 2;
		private int relationshipEntity1Id;

		public int RelationshipEntity1Id
		{
			get
			{
				return this.relationshipEntity1Id;
			}
			set
			{
				this.relationshipEntity1Id = value;
			}
		}

		// Summary:
		//     Returns an indication whether the values of two specified RelationshipEntity1Identifier objects
		//     are not equal.
		//
		// Parameters:
		//   a:
		//     A RelationshipEntity1Identifier object.
		//
		//   b:
		//     A RelationshipEntity1Identifier object.
		//
		// Returns:
		//     true if a and b are not equal; otherwise, false.
		public static bool operator !=(RelationshipEntity1Identifier a, RelationshipEntity1Identifier b)
		{
			return !RelationshipEntity1Identifier.Equal(a, b);
		}

		//
		// Summary:
		//     Returns an indication whether the values of two specified RelationshipEntity1Identifier objects
		//     are equal.
		//
		// Parameters:
		//   a:
		//     A RelationshipEntity1Identifier object.
		//
		//   b:
		//     A RelationshipEntity1Identifier object.
		//
		// Returns:
		//     true if a and b are equal; otherwise, false.
		public static bool operator ==(RelationshipEntity1Identifier a, RelationshipEntity1Identifier b)
		{
			return RelationshipEntity1Identifier.Equal(a, b);
		}

		// Summary:
		//     Compares this instance to a specified RelationshipEntity1Identifier object and returns an indication
		//     of their relative values.
		//
		// Parameters:
		//   value:
		//     A RelationshipEntity1Identifier object to compare to this instance.
		//
		// Returns:
		//     A signed number indicating the relative values of this instance and value.
		//      Value Description A negative integer This instance is less than value. Zero
		//     This instance is equal to value. A positive integer This instance is greater
		//     than value.
		public int CompareTo(RelationshipEntity1Identifier value)
		{
			int result;
			if ((result = this.relationshipEntity1Id.CompareTo(value.relationshipEntity1Id)) != 0)
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
		//     value is not a RelationshipEntity1Identifier.
		public int CompareTo(object value)
		{
			if (value is RelationshipEntity1Identifier)
				return this.CompareTo((RelationshipEntity1Identifier)value);
			throw new ArgumentException("value is not a RelationshipEntity1Identifier", "value");
		}

		//
		// Summary:
		//     Returns a value indicating whether this instance and a specified RelationshipEntity1Identifier
		//     object represent the same value.
		//
		// Parameters:
		//   g:
		//     A RelationshipEntity1Identifier object to compare to this instance.
		//
		// Returns:
		//     true if g is equal to this instance; otherwise, false.
		public bool Equals(RelationshipEntity1Identifier oi)
		{
			return RelationshipEntity1Identifier.Equal(this, oi);
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
		//     true if o is a RelationshipEntity1Identifier that has the same value as this instance; otherwise,
		//     false.
		public override bool Equals(object o)
		{
			if (o is RelationshipEntity1Identifier)
				return RelationshipEntity1Identifier.Equal(this, (RelationshipEntity1Identifier)o);
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
			int hash = 23;
			hash = ((hash << 5) * 37) + this.RelationshipEntity1Id.GetHashCode();
			return hash;
		}

		public override string ToString()
		{
			string s = "RelationshipEntity1Id=" + this.relationshipEntity1Id.ToString();
			return s;
		}

		public int FieldCount
		{
			get
			{
				return RelationshipEntity1Identifier.fieldCount;
			}
		}

		[System.Runtime.CompilerServices.IndexerName("Item")]
		public object this[int index]
		{
			get
			{
				switch (index)
				{
					case 0:
						return (object)this.relationshipEntity1Id;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
			set
			{
				switch (index)
				{
					case 0:
						this.relationshipEntity1Id = (int)value;
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
		}

		[System.Runtime.CompilerServices.IndexerName("Item")]
		public object this[string index]
		{
			get
			{
				switch (index)
				{
					case "RelationshipEntity1Id":
						return (object)this.relationshipEntity1Id;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
			set
			{
				switch (index)
				{
					case "RelationshipEntity1Id":
						this.relationshipEntity1Id = (int)value;
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
		}

		public bool Equivalent(IIdentifier identifier)
		{
			bool equivalent = true;
			if (identifier.FieldCount == RelationshipEntity1Identifier.fieldCount)
			{
				object fieldA, fieldB;
				for (int index = 0; index < RelationshipEntity1Identifier.fieldCount; ++index)
				{
					fieldA = identifier[index];
					fieldB = this[index];
					if (!(fieldA.GetType() == fieldB.GetType() && fieldA.Equals(fieldB)))
					{
						equivalent = false;
						break;
					}
				}
			}
			else
				equivalent = false;
			return equivalent;
		}

		private static bool Equal(RelationshipEntity1Identifier a, RelationshipEntity1Identifier b)
		{
			return a.relationshipEntity1Id == b.relationshipEntity1Id;
		}
	}
}
