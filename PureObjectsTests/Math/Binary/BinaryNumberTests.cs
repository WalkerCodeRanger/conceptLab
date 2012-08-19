using System;
using ConceptLab.PureObjects.Logic;
using ConceptLab.PureObjects.Math.Binary;
using NUnit.Framework;

namespace ConceptLab.PureObjectsTests.Math.Binary
{
	[TestFixture]
	public class BinaryNumberTests
	{
		#region Cast
		[Test]
		public void CastZeroToInt()
		{
			AssertEqual(0, BinaryNumber.Zero);
		}
		[Test]
		public void CastOneToInt()
		{
			AssertEqual(1, BinaryNumber.One);
		}
		[Test]
		public void CastTwoToInt()
		{
			AssertEqual(2, BinaryNumber.Two);
		}
		[Test]
		public void CastThreeToInt()
		{
			AssertEqual(3, BinaryNumber.One.DoubleAddOne());
		}

		[Test]
		[TestCase(0)]
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		[TestCase(7)]
		[TestCase(45777)]
		public void CastRoundTrip(int value)
		{
			Assert.AreEqual(value, (int)(BinaryNumber)value);
		}
		#endregion

		[Test]
		[TestCase(0)]
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(20)]
		public void RepeatTest(int number)
		{
			BinaryNumber binaryNumber = number;
			var count = 0;
			binaryNumber.Repeat(() => count++);
			Assert.AreEqual(number, count);
		}

		#region Increment/Decrement
		[Test]
		[TestCase(0)]
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(20)]
		public void IncrementTest(int number)
		{
			var binaryNumber = (BinaryNumber)number;
			Assert.AreEqual(number+1, (int)binaryNumber.Increment());
		}


		[Test]
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(20)]
		public void DecrementTest(int number)
		{
			var binaryNumber = (BinaryNumber)number;
			Assert.AreEqual(number-1, (int)binaryNumber.Decrement());
		}

		[Test]
		public void CantDecrementZero()
		{
			AssertThrowsNegative(() => BinaryNumber.Zero.Decrement());
		}
		#endregion

		#region Arithmetic
		[Test]
		[TestCase(0, 0)]
		[TestCase(0, 56)]
		[TestCase(12, 0)]
		[TestCase(1, 1)]
		[TestCase(1, 2)]
		[TestCase(345, 276)]
		public void Add(int x, int y)
		{
			AssertEqual(x + y, ((BinaryNumber)x).Add(y));
		}

		[Test]
		[TestCase(0, 0)]
		[TestCase(12, 0)]
		[TestCase(1, 1)]
		[TestCase(345, 276)]
		[TestCase(2, 1)]
		public void Subtract(int x, int y)
		{
			AssertEqual(x - y, ((BinaryNumber)x).Subtract(y));
		}

		[Test]
		[TestCase(0, 56)]
		[TestCase(1, 2)]
		public void SubtractNegativeResult(int x, int y)
		{
			AssertThrowsNegative(() => ((BinaryNumber)x).Subtract(y));
		}

		[Test]
		[TestCase(0, 0)]
		[TestCase(0, 56)]
		[TestCase(12, 0)]
		[TestCase(1, 1)]
		[TestCase(1, 2)]
		[TestCase(14, 1)]
		[TestCase(345, 276)]
		public void Multiply(int x, int y)
		{
			AssertEqual(x * y, ((BinaryNumber)x).Multiply(y));
		}

		[Test]
		[TestCase(0, 56)]
		[TestCase(1, 1)]
		[TestCase(1, 2)]
		[TestCase(14, 1)]
		[TestCase(13, 2)]
		[TestCase(345, 276)]
		public void Divide(int x, int y)
		{
			var result = ((BinaryNumber)x).DivideBy(y);
			int expectedRemainder;
			var expectedQuotient = System.Math.DivRem(x, y, out expectedRemainder);
			AssertEqual(expectedQuotient, result.Quotient);
			AssertEqual(expectedRemainder, result.Remainder);
		}

		[Test]
		[TestCase(0, 0)]
		[TestCase(1, 0)]
		[TestCase(12, 0)]
		public void DivideByZero(int x, int y)
		{
			Assert.Throws<DivideByZeroException>(() => ((BinaryNumber)x).DivideBy(y));
		}
		#endregion

		#region Comparision
		[Test]
		[TestCase(0, 0)]
		[TestCase(4, 0)]
		[TestCase(0, 9)]
		[TestCase(1, 1)]
		[TestCase(456, 456)]
		[TestCase(134, 879)]
		public void EqualTo(int x, int y)
		{
			AssertEqual(x == y, ((BinaryNumber)x).EqualTo(y));
		}

		[Test]
		[TestCase(0, 0)]
		[TestCase(4, 0)]
		[TestCase(0, 9)]
		[TestCase(1, 1)]
		[TestCase(456, 456)]
		[TestCase(134, 879)]
		public void LessThan(int x, int y)
		{
			AssertEqual(x < y, ((BinaryNumber)x).LessThan(y));
		}

		[Test]
		[TestCase(0, 0)]
		[TestCase(4, 0)]
		[TestCase(0, 9)]
		[TestCase(1, 1)]
		[TestCase(456, 456)]
		[TestCase(134, 879)]
		public void LessThanOrEqualTo(int x, int y)
		{
			AssertEqual(x <= y, ((BinaryNumber)x).LessThanOrEqualTo(y));
		}

		[Test]
		[TestCase(0, 0)]
		[TestCase(4, 0)]
		[TestCase(0, 9)]
		[TestCase(1, 1)]
		[TestCase(456, 456)]
		[TestCase(134, 879)]
		public void GreaterThan(int x, int y)
		{
			AssertEqual(x > y, ((BinaryNumber)x).GreaterThan(y));
		}

		[Test]
		[TestCase(0, 0)]
		[TestCase(4, 0)]
		[TestCase(0, 9)]
		[TestCase(1, 1)]
		[TestCase(456, 456)]
		[TestCase(134, 879)]
		public void GreaterThanOrEqualTo(int x, int y)
		{
			AssertEqual(x >= y, ((BinaryNumber)x).GreaterThanOrEqualTo(y));
		}
		#endregion

		#region Shift
		[Test]
		[TestCase(0)]
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		[TestCase(42)]
		public void ShiftLeft(int x)
		{
			AssertEqual(x << 1, ((BinaryNumber)x).ShiftLeft());
		}

		[Test]
		[TestCase(0,3)]
		[TestCase(1,2)]
		[TestCase(2,5)]
		[TestCase(3,3)]
		[TestCase(42,2)]
		public void ShiftLeftBy(int x, int y)
		{
			AssertEqual(x << y, ((BinaryNumber)x).ShiftLeft(y));
		}

		[Test]
		[TestCase(0)]
		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		[TestCase(42)]
		public void ShiftRight(int x)
		{
			AssertEqual(x >> 1, ((BinaryNumber)x).ShiftRight());
		}

		[Test]
		[TestCase(0, 1)]
		[TestCase(1, 1)]
		[TestCase(2, 1)]
		[TestCase(2343, 3)]
		[TestCase(223442, 2)]
		public void ShiftRightBy(int x, int y)
		{
			AssertEqual(x >> y, ((BinaryNumber)x).ShiftRight(y));
		}
		#endregion

		#region Assertions
		private static void AssertEqual(int expected, BinaryNumber value)
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
