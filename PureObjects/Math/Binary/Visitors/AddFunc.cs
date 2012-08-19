namespace ConceptLab.PureObjects.Math.Binary.Visitors
{
	internal class AddFunc : IBinaryNumbersFunc<BinaryNumber>
	{
		#region Singleton
		static public readonly AddFunc Instance = new AddFunc();

		private AddFunc()
		{
		}
		#endregion

		public BinaryNumber WhenZeroZero(BinaryNumber host1, BinaryNumber host2)
		{
			return BinaryNumber.Zero;
		}

		public BinaryNumber WhenZeroEven(BinaryNumber host1, BinaryNumber host2)
		{
			return host2;
		}
		public BinaryNumber WhenZeroOdd(BinaryNumber host1, BinaryNumber host2)
		{
			return host2;
		}

		public BinaryNumber WhenOddZero(BinaryNumber host1, BinaryNumber host2)
		{
			return host1;
		}
		public BinaryNumber WhenEvenZero(BinaryNumber host1, BinaryNumber host2)
		{
			return host1;
		}

		public BinaryNumber WhenEvenEven(BinaryNumber host1, BinaryNumber host2)
		{
			return host1.Rest.Accept(host2.Rest, this).Double();
		}

		public BinaryNumber WhenEvenOdd(BinaryNumber host1, BinaryNumber host2)
		{
			return host1.Rest.Accept(host2.Rest, this).DoubleAddOne();
		}
		public BinaryNumber WhenOddEven(BinaryNumber host1, BinaryNumber host2)
		{
			return host1.Rest.Accept(host2.Rest, this).DoubleAddOne();
		}

		public BinaryNumber WhenOddOdd(BinaryNumber host1, BinaryNumber host2)
		{
			return host1.Rest.Accept(host2.Rest, AddCarryFunc.Instance).Double();
		}
	}


	internal class AddCarryFunc : IBinaryNumbersFunc<BinaryNumber>
	{
		#region Singleton
		static public readonly AddCarryFunc Instance = new AddCarryFunc();

		private AddCarryFunc()
		{
		}
		#endregion

		public BinaryNumber WhenZeroZero(BinaryNumber host1, BinaryNumber host2)
		{
			return BinaryNumber.One;
		}

		public BinaryNumber WhenZeroEven(BinaryNumber host1, BinaryNumber host2)
		{
			return host2.Accept(IncrementFunc.Instance);
		}
		public BinaryNumber WhenZeroOdd(BinaryNumber host1, BinaryNumber host2)
		{
			return host2.Accept(IncrementFunc.Instance);
		}

		public BinaryNumber WhenEvenZero(BinaryNumber host1, BinaryNumber host2)
		{
			return host1.Accept(IncrementFunc.Instance);
		}
		public BinaryNumber WhenOddZero(BinaryNumber host1, BinaryNumber host2)
		{
			return host1.Accept(IncrementFunc.Instance);
		}

		public BinaryNumber WhenEvenEven(BinaryNumber host1, BinaryNumber host2)
		{
			return host1.Rest.Accept(host2.Rest, AddFunc.Instance).DoubleAddOne();
		}

		public BinaryNumber WhenEvenOdd(BinaryNumber host1, BinaryNumber host2)
		{
			return host1.Rest.Accept(host2.Rest, this).Double();
		}
		public BinaryNumber WhenOddEven(BinaryNumber host1, BinaryNumber host2)
		{
			return host1.Rest.Accept(host2.Rest, this).Double();
		}

		public BinaryNumber WhenOddOdd(BinaryNumber host1, BinaryNumber host2)
		{
			return host1.Rest.Accept(host2.Rest, this).DoubleAddOne();
		}
	}
}
