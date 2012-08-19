namespace ConceptLab.PureObjects.Math.Binary.Visitors
{
	internal class MultiplyFunc : IBinaryNumberFunc<BinaryNumber, BinaryNumber>
	{
		#region Singleton
		static public readonly MultiplyFunc Instance = new MultiplyFunc();

		private MultiplyFunc()
		{
		}
		#endregion

		public BinaryNumber WhenZero(BinaryNumber multiplicand, BinaryNumber multiplier)
		{
			return BinaryNumber.Zero;
		}

		public BinaryNumber WhenEven(BinaryNumber multiplicand, BinaryNumber multiplier)
		{
			return multiplicand.Rest.Accept(this, multiplier).Double();
		}

		public BinaryNumber WhenOdd(BinaryNumber multiplicand, BinaryNumber multiplier)
		{
			var partialProduct = multiplicand.Rest.Accept(this, multiplier).Double();
			return partialProduct.Accept(multiplier, AddFunc.Instance);
		}
	}
}
