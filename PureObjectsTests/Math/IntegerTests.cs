using System;
using ConceptLab.PureObjects.Logic;
using ConceptLab.PureObjects.Math;
using NUnit.Framework;

namespace ConceptLab.PureObjectsTests.Math
{
	[TestFixture]
	public class IntegerTests
	{
		#region Cast

		[Test]
		[TestCase(0)]
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		[TestCase(7)]
		[TestCase(45777)]
		[TestCase(-1)]
		[TestCase(-2)]
		[TestCase(-3)]
		[TestCase(-7)]
		[TestCase(-45777)]
		public void CastRoundTrip(int value)
		{
			Assert.AreEqual(value, (int)(Integer)value);
		}
		#endregion

		#region Unary Operations
		[Test]
		[TestCase(-5)]
		[TestCase(-1)]
		[TestCase(0)]
		[TestCase(1)]
		[TestCase(5)]
		public void AbsTest(int number)
		{
			var integer = (Integer)number;
			Assert.AreEqual(System.Math.Abs(number), (int)integer.Abs());
		}

		[Test]
		[TestCase(-5)]
		[TestCase(-1)]
		[TestCase(0)]
		[TestCase(1)]
		[TestCase(5)]
		public void NegateTest(int number)
		{
			var integer = (Integer)number;
			Assert.AreEqual(-number, (int)integer.Negate());
		}

		[Test]
		[TestCase(-5)]
		[TestCase(-1)]
		[TestCase(0)]
		[TestCase(1)]
		[TestCase(5)]
		public void IncrementTest(int number)
		{
			var integer = (Integer)number;
			Assert.AreEqual(number+1, (int)integer.Increment());
		}

		[Test]
		[TestCase(-5)]
		[TestCase(-1)]
		[TestCase(0)]
		[TestCase(1)]
		[TestCase(5)]
		public void DecrementTest(int number)
		{
			var integer = (Integer)number;
			Assert.AreEqual(number-1, (int)integer.Decrement());
		}
		#endregion

		#region Arithmetic Operations
		[Test]
		[TestCase(0, -1)]
		[TestCase(0, 0)]
		[TestCase(0, 1)]
		[TestCase(1, 1)]
		[TestCase(1, 2)]
		[TestCase(1, -1)]
		[TestCase(1, -2)]
		public void Add(int x, int y)
		{
			AssertEqual(x + y, ((Integer)x).Add(y));
		}

		[Test]
		[TestCase(0, -1)]
		[TestCase(0, 0)]
		[TestCase(0, 1)]
		[TestCase(1, 1)]
		[TestCase(1, 2)]
		[TestCase(1, -1)]
		[TestCase(1, 2)]
		[TestCase(-2, 1)]
		public void Subtract(int x, int y)
		{
			AssertEqual(x - y, ((Integer)x).Subtract(y));
		}

		[Test]
		[TestCase(0, 0)]
		[TestCase(0, 56)]
		[TestCase(-12, 0)]
		[TestCase(1, -1)]
		[TestCase(-1, 2)]
		[TestCase(14, 1)]
		[TestCase(345, 276)]
		[TestCase(345, -276)]
		public void Multiply(int x, int y)
		{
			AssertEqual(x * y, ((Integer)x).Multiply(y));
		}

		[Test]
		[TestCase(0, 56)]
		[TestCase(0, -24)]
		[TestCase(1, 1)]
		[TestCase(1, 2)]
		[TestCase(14, 1)]
		[TestCase(-13, 2)]
		[TestCase(345, -276)]
		[TestCase(-42, -5)]
		[TestCase(-42, 5)]
		public void Divide(int x, int y)
		{
			var result = ((Integer)x).DivideBy(y);
			int expectedRemainder;
			var expectedQuotient = System.Math.DivRem(x, y, out expectedRemainder);
			AssertEqual(expectedQuotient, result.Quotient);
			AssertEqual(expectedRemainder, result.Remainder);
		}

		[Test]
		[TestCase(0, 0)]
		[TestCase(1, 0)]
		[TestCase(12, 0)]
		[TestCase(-12, 0)]
		public void DivideByZero(int x, int y)
		{
			Assert.Throws<DivideByZeroException>(() => ((Integer)x).DivideBy(y));
		}
		#endregion

		#region Comparision
		[Test]
		[TestCase(0, 0)]
		[TestCase(4, 0)]
		[TestCase(0, 9)]
		[TestCase(1, 1)]
		[TestCase(-1, 1)]
		[TestCase(-1, -1)]
		[TestCase(456, 456)]
		[TestCase(-456, -456)]
		[TestCase(134, 879)]
		[TestCase(-134, -879)]
		public void EqualTo(int x, int y)
		{
			AssertEqual(x == y, ((Integer)x).EqualTo(y));
		}

		[Test]
		[TestCase(0, 0)]
		[TestCase(4, 0)]
		[TestCase(0, 9)]
		[TestCase(-9, 0)]
		[TestCase(1, 1)]
		[TestCase(-1, 1)]
		[TestCase(1, -1)]
		[TestCase(456, 456)]
		[TestCase(134, 879)]
		[TestCase(-134, 879)]
		public void LessThan(int x, int y)
		{
			AssertEqual(x < y, ((Integer)x).LessThan(y));
		}

		[Test]
		[TestCase(0, 0)]
		[TestCase(4, 0)]
		[TestCase(0, 9)]
		[TestCase(1, 1)]
		[TestCase(-1, 1)]
		[TestCase(1, -1)]
		[TestCase(456, 456)]
		[TestCase(134, 879)]
		[TestCase(-134, 879)]
		public void LessThanOrEqualTo(int x, int y)
		{
			AssertEqual(x <= y, ((Integer)x).LessThanOrEqualTo(y));
		}

		[Test]
		[TestCase(0, 0)]
		[TestCase(4, 0)]
		[TestCase(0, 9)]
		[TestCase(0, -9)]
		[TestCase(1, 1)]
		[TestCase(456, 456)]
		[TestCase(134, 879)]
		[TestCase(-134, 12)]
		public void GreaterThan(int x, int y)
		{
			AssertEqual(x > y, ((Integer)x).GreaterThan(y));
		}

		[Test]
		[TestCase(0, 0)]
		[TestCase(4, 0)]
		[TestCase(0, 9)]
		[TestCase(0, -9)]
		[TestCase(1, 1)]
		[TestCase(456, 456)]
		[TestCase(134, 879)]
		[TestCase(-134, 12)]
		public void GreaterThanOrEqualTo(int x, int y)
		{
			AssertEqual(x >= y, ((Integer)x).GreaterThanOrEqualTo(y));
		}
		#endregion

		#region Shift
		[Test]
		[TestCase(0)]
		[TestCase(1)]
		[TestCase(-1)]
		[TestCase(2)]
		[TestCase(-2)]
		[TestCase(3)]
		[TestCase(-3)]
		[TestCase(42)]
		[TestCase(-42)]
		public void ShiftLeft(int x)
		{
			AssertEqual(x << 1, ((Integer)x).ShiftLeft());
		}

		[Test]
		[TestCase(0, 3)]
		[TestCase(0, -3)]
		[TestCase(1, 2)]
		[TestCase(-1, 2)]
		[TestCase(1, -2)]
		[TestCase(-1, -2)]
		[TestCase(2, 5)]
		[TestCase(-2, 5)]
		[TestCase(2, -5)]
		[TestCase(-2, -5)]
		[TestCase(3, 3)]
		[TestCase(-3, 3)]
		[TestCase(3, -3)]
		[TestCase(-3, -3)]
		[TestCase(42, 2)]
		[TestCase(-42, 2)]
		[TestCase(42, -2)]
		[TestCase(-42, -2)]
		public void ShiftLeftBy(int x, int y)
		{
			var sign = System.Math.Sign(x);
			var val = System.Math.Abs(x);
			var expected = y > 0 ? val << y : val >> -y;
			AssertEqual(sign * expected, ((Integer)x).ShiftLeft((Integer)y));
		}

		[Test]
		[TestCase(0)]
		[TestCase(1)]
		[TestCase(-1)]
		[TestCase(2)]
		[TestCase(-2)]
		[TestCase(3)]
		[TestCase(-3)]
		[TestCase(42)]
		[TestCase(-42)]
		public void ShiftRight(int x)
		{
			var sign = System.Math.Sign(x);
			var val = System.Math.Abs(x);
			AssertEqual(sign * (val >> 1), ((Integer)x).ShiftRight());
		}

		[Test]
		[TestCase(0, 1)]
		[TestCase(0, -1)]
		[TestCase(1, 1)]
		[TestCase(-1, 1)]
		[TestCase(1, -1)]
		[TestCase(-1, -1)]
		[TestCase(2, 1)]
		[TestCase(-2, 1)]
		[TestCase(2, -1)]
		[TestCase(-2, -1)]
		[TestCase(2343, 3)]
		[TestCase(-2343, 3)]
		[TestCase(2343, -3)]
		[TestCase(-2343, -3)]
		[TestCase(223442, 2)]
		[TestCase(-223442, 2)]
		[TestCase(223442, -2)]
		[TestCase(-223442, -2)]
		public void ShiftRightBy(int x, int y)
		{
			var sign = System.Math.Sign(x);
			var val = System.Math.Abs(x);
			var expected = y > 0 ? val >> y : val << -y;
			AssertEqual(sign * expected, ((Integer)x).ShiftRight((Integer)y));
		}
		#endregion

		#region Assertions
		private static void AssertEqual(int expected, Integer value)
		{
			Assert.AreEqual(expected, (int)value);
		}
		private static void AssertEqual(bool expected, Bool value)
		{
			Assert.AreEqual(expected, (bool)value);
		}
		private static void AssertThrowsNegative(TestDelegate action)
		{
			var ex = Assert.Throws<NotSupportedException>(action);
			Assert.AreEqual("BinaryNumber can't be negative", ex.Message);
		}
		#endregion
	}
}
