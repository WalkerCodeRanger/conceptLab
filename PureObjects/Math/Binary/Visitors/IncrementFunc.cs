namespace ConceptLab.PureObjects.Math.Binary.Visitors
{
	internal class IncrementFunc : IBinaryNumberFunc<BinaryNumber>
	{
		#region Singleton
		static public readonly IncrementFunc Instance = new IncrementFunc();

		private IncrementFunc()
		{
		}
		#endregion

		public BinaryNumber WhenZero(BinaryNumber host)
		{
			return BinaryNumber.One;
		}

		public BinaryNumber WhenOdd(BinaryNumber host)
		{
			return host.Rest.Accept(this).Double();
		}

		public BinaryNumber WhenEven(BinaryNumber host)
		{
			return host.Rest.DoubleAddOne();
		}
	}
}
