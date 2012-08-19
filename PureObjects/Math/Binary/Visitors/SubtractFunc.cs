using System;

namespace ConceptLab.PureObjects.Math.Binary.Visitors
{
	internal class SubtractFunc : IBinaryNumbersFunc<BinaryNumber>
	{
		#region Singleton
		static public readonly SubtractFunc Instance = new SubtractFunc();

		private SubtractFunc()
		{
		}
		#endregion

		public BinaryNumber WhenZeroZero(BinaryNumber host1, BinaryNumber host2)
		{
			return BinaryNumber.Zero;
		}

		public BinaryNumber WhenZeroEven(BinaryNumber host1, BinaryNumber host2)
		{
			throw new NotSupportedException("BinaryNumber can't be negative");
		}
		public BinaryNumber WhenZeroOdd(BinaryNumber host1, BinaryNumber host2)
		{
			throw new NotSupportedException("BinaryNumber can't be negative");
		}

		public BinaryNumber WhenEvenZero(BinaryNumber host1, BinaryNumber host2)
		{
			return host1;
		}
		public BinaryNumber WhenOddZero(BinaryNumber host1, BinaryNumber host2)
		{
			return host1;
		}

		public BinaryNumber WhenEvenEven(BinaryNumber host1, BinaryNumber host2)
		{
			return host1.Rest.Accept(host2.Rest, this).Double();
		}
		public BinaryNumber WhenOddOdd(BinaryNumber host1, BinaryNumber host2)
		{
			return host1.Rest.Accept(host2.Rest, this).Double();
		}

		public BinaryNumber WhenOddEven(BinaryNumber host1, BinaryNumber host2)
		{
			return host1.Rest.Accept(host2.Rest, this).DoubleAddOne();
		}

		public BinaryNumber WhenEvenOdd(BinaryNumber host1, BinaryNumber host2)
		{
			return host1.Rest.Accept(host2.Rest, SubtractBorrowFunc.Instance).DoubleAddOne();
		}
	}

	internal class SubtractBorrowFunc : IBinaryNumbersFunc<BinaryNumber>
	{
		#region Singleton
		static public readonly SubtractBorrowFunc Instance = new SubtractBorrowFunc();

		private SubtractBorrowFunc()
		{
		}
		#endregion

		public BinaryNumber WhenZeroZero(BinaryNumber host1, BinaryNumber host2)
		{
			throw new NotSupportedException("BinaryNumber can't be negative");
		}

		public BinaryNumber WhenZeroEven(BinaryNumber host1, BinaryNumber host2)
		{
			return host2.Accept(DecrementFunc.Instance);
		}
		public BinaryNumber WhenZeroOdd(BinaryNumber host1, BinaryNumber host2)
		{
			return host2.Accept(DecrementFunc.Instance);
		}

		public BinaryNumber WhenEvenZero(BinaryNumber host1, BinaryNumber host2)
		{
			return host1.Accept(DecrementFunc.Instance);
		}
		public BinaryNumber WhenOddZero(BinaryNumber host1, BinaryNumber host2)
		{
			return host1.Accept(DecrementFunc.Instance);
		}

		public BinaryNumber WhenEvenEven(BinaryNumber host1, BinaryNumber host2)
		{
			return host1.Rest.Accept(host2.Rest, this).DoubleAddOne();
		}
		public BinaryNumber WhenOddOdd(BinaryNumber host1, BinaryNumber host2)
		{
			return host1.Rest.Accept(host2.Rest, this).DoubleAddOne();
		}

		public BinaryNumber WhenEvenOdd(BinaryNumber host1, BinaryNumber host2)
		{
			return host1.Rest.Accept(host2.Rest, this).Double();
		}

		public BinaryNumber WhenOddEven(BinaryNumber host1, BinaryNumber host2)
		{
			return host1.Rest.Accept(host2.Rest, SubtractFunc.Instance).Double();
		}
	}
}
