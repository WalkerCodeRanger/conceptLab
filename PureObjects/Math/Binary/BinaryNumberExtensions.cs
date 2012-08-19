using System;
using ConceptLab.PureObjects.Logic;
using ConceptLab.PureObjects.Math.Binary.Visitors;

namespace ConceptLab.PureObjects.Math.Binary
{
	public static class BinaryNumberExtensions
	{
		public static BinaryNumber Increment(this BinaryNumber x)
		{
			return x.Accept(IncrementFunc.Instance);
		}
		public static BinaryNumber Decrement(this BinaryNumber x)
		{
			return x.Accept(DecrementFunc.Instance);
		}

		#region Arithmetic Operations
		public static BinaryNumber Add(this BinaryNumber x, BinaryNumber y)
		{
			return x.Accept(y, AddFunc.Instance);
		}
		public static BinaryNumber Subtract(this BinaryNumber x, BinaryNumber y)
		{
			return x.Accept(y, SubtractFunc.Instance);
		}
		public static BinaryNumber Multiply(this BinaryNumber x, BinaryNumber y)
		{
			// For efficency always recur down the smaller number
			return x.LessThan(y).Accept(() => y.Accept(MultiplyFunc.Instance, x), () => x.Accept(MultiplyFunc.Instance, y));
		}
		public static DivisionResult<BinaryNumber> DivideBy(this BinaryNumber dividend, BinaryNumber divisor)
		{
			return divisor.IsZero.Accept(() => { throw new DivideByZeroException(); },
										() => dividend.UncheckedDivideBy(divisor));
		}

		private static DivisionResult<BinaryNumber> UncheckedDivideBy(this BinaryNumber dividend, BinaryNumber divisor)
		{
			return dividend.IsZero.Accept(() => DivisionResult.Create(BinaryNumber.Zero, BinaryNumber.Zero),
										  () =>
										  {
											  var partial = dividend.Rest.DivideBy(divisor);
											  var remainder = dividend.IsOdd.Accept(() => partial.Remainder.DoubleAddOne(),
																					() => partial.Remainder.Double());
											  var quotient = remainder.GreaterThanOrEqualTo(divisor)
																		.Accept(() =>
																					{
																						remainder = remainder.Subtract(divisor);
																						return partial.Quotient.DoubleAddOne();
																					},
																				() => partial.Quotient.Double());
											  return DivisionResult.Create(quotient, remainder);
										  });
		}
		#endregion

		#region Comparision Operations
		public static Bool EqualTo(this BinaryNumber x, BinaryNumber y)
		{
			return x.IsZero.And(y.IsZero).Or(() => x.IsOdd.EqualTo(y.IsOdd).And(() => x.Rest.EqualTo(y.Rest)));
		}

		public static Bool LessThan(this BinaryNumber x, BinaryNumber y)
		{
			return x.Accept(y, LessThanFunc.Instance);
		}
		public static Bool LessThanOrEqualTo(this BinaryNumber x, BinaryNumber y)
		{
			return x.Accept(y, LessThanOrEqualToFunc.Instance);
		}

		public static Bool GreaterThan(this BinaryNumber x, BinaryNumber y)
		{
			return y.LessThan(x);
		}
		public static Bool GreaterThanOrEqualTo(this BinaryNumber x, BinaryNumber y)
		{
			return y.LessThanOrEqualTo(x);
		}
		#endregion

		#region Shift Operations
		public static BinaryNumber ShiftLeft(this BinaryNumber x)
		{
			return x.Double();
		}
		public static BinaryNumber ShiftLeft(this BinaryNumber x, BinaryNumber places)
		{
			var result = x;
			places.Repeat(() => result = result.Double());
			return result;
		}

		public static BinaryNumber ShiftRight(this BinaryNumber x)
		{
			return x.Rest;
		}
		public static BinaryNumber ShiftRight(this BinaryNumber x, BinaryNumber places)
		{
			var result = x;
			places.Repeat(() => result = result.Rest);
			return result;
		}
		#endregion
	}
}
