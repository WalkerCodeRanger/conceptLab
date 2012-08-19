using ConceptLab.PureObjects.Logic;
using ConceptLab.PureObjects.Math.Binary;

namespace ConceptLab.PureObjects.Math
{
	public class Integer
	{
		private readonly Sign sign;
		private readonly BinaryNumber value;

		#region Constructors
		public Integer()
		{
			value = BinaryNumber.Zero;
			sign = Sign.Zero;
		}

		public Integer(BinaryNumber value)
		{
			this.value = value;
			sign = Sign.Positive;
		}

		public Integer(BinaryNumber value, Bool positive)
		{
			this.value = value;
			sign = Sign.Create(positive).CheckZero(value);
		}

		public Integer(BinaryNumber value, Sign sign)
		{
			this.sign = sign.CheckZero(value);
			this.value = value;
		}

		public Integer(Integer value)
		{
			sign = value.sign;
			this.value = value.value;
		}
		#endregion

		#region Casts
		public static implicit operator Integer(int value)
		{
			return new Integer(System.Math.Abs(value), value >=0);
		}

		public static explicit operator int(Integer value)
		{
			// Becuase of the interaction with procedural functions, we go ahead and use control constructs here
			return (int)value.AbsBinaryNumber * (value.IsNegative ? -1 : 1);
		}
		#endregion

		public BinaryNumber AbsBinaryNumber
		{
			get { return value; }
		}

		public Sign Sign
		{
			get { return sign; }
		}

		public Bool IsPositive
		{
			get { return sign.IsPositive; }
		}
		public Bool IsZero
		{
			get { return value.IsZero; }
		}
		public Bool IsNegative
		{
			get { return sign.IsNegative; }
		}

		#region Unary Operations
		public Integer Abs()
		{
			return new Integer(value);
		}

		public Integer Negate()
		{
			return new Integer(value, sign.Negate());
		}

		public Integer Increment()
		{
			var newValue = IsNegative.Accept(() => value.Decrement(), () => value.Increment());
			return new Integer(newValue, IsNegative.Not);
		}

		public Integer Decrement()
		{
			var newValue = IsPositive.Accept(() => value.Decrement(), () => value.Increment());
			return new Integer(newValue, IsPositive);
		}
		#endregion

		#region Arithmetic Operations
		public Integer Add(Integer rhs)
		{
			return sign.IsOppositeOf(rhs.Sign).Accept(() => value.LessThan(rhs.value).Accept(() => new Integer(rhs.value.Subtract(value), rhs.IsPositive),
																							 () => new Integer(value.Subtract(rhs.value), IsPositive)),
													  () => new Integer(value.Add(rhs.value), IsPositive.Or(rhs.IsPositive)));
		}

		public Integer Subtract(Integer rhs)
		{
			return Add(rhs.Negate());
		}

		public Integer Multiply(Integer rhs)
		{
			var product = value.Multiply(rhs.value);
			return new Integer(product, sign.EqualTo(rhs.sign));
		}

		public DivisionResult<Integer> DivideBy(Integer rhs)
		{
			var result = value.DivideBy(rhs.value);
			var quotient = new Integer(result.Quotient, sign.EqualTo(rhs.sign));
			var remainder = new Integer(result.Remainder, sign);
			return DivisionResult.Create(quotient, remainder);
		}
		#endregion

		#region Comparision Operations
		public Bool EqualTo(Integer rhs)
		{
			return sign.EqualTo(rhs.sign).And(() => value.EqualTo(rhs.value));
		}

		public Bool LessThan(Integer rhs)
		{
			return rhs.IsPositive.And(IsPositive.Not)
				.Or(() => rhs.IsPositive.Accept(() => value.LessThan(rhs.value),
												() => IsNegative.And(() => rhs.value.LessThan(value))));
		}

		public Bool LessThanOrEqualTo(Integer rhs)
		{
			return rhs.IsPositive.And(IsPositive.Not)
				.Or(() => rhs.IsPositive.Accept(() => value.LessThanOrEqualTo(rhs.value),
				                                () => IsPositive.Not.And(() => rhs.value.LessThanOrEqualTo(value))));
		}

		public Bool GreaterThan(Integer rhs)
		{
			return rhs.LessThan(this);
		}

		public Bool GreaterThanOrEqualTo(Integer rhs)
		{
			return rhs.LessThanOrEqualTo(this);
		}
		#endregion

		#region Shift Operations
		public Integer ShiftLeft()
		{
			return new Integer(value.ShiftLeft(), sign);
		}

		public Integer ShiftLeft(Integer places)
		{
			return places.Sign.IsNegative.Accept(() => ShiftRight(places.value), () => ShiftLeft(places.value));
		}

		public Integer ShiftLeft(BinaryNumber places)
		{
			return new Integer(value.ShiftLeft(places), sign);
		}

		public Integer ShiftRight()
		{
			return new Integer(value.ShiftRight(), sign);
		}

		public Integer ShiftRight(Integer places)
		{
			return places.Sign.IsNegative.Accept(() => ShiftLeft(places.value), () => ShiftRight(places.value));
		}

		public Integer ShiftRight(BinaryNumber places)
		{
			return new Integer(value.ShiftRight(places), sign);
		}
		#endregion

		public override string ToString()
		{
			return sign.ToString() + value;
		}
	}
}
