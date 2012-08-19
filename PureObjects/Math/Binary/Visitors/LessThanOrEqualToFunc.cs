using ConceptLab.PureObjects.Logic;

namespace ConceptLab.PureObjects.Math.Binary.Visitors
{
	internal class LessThanOrEqualToFunc : IBinaryNumbersFunc<Bool>
	{
		#region Singleton
		static public readonly LessThanOrEqualToFunc Instance = new LessThanOrEqualToFunc();

		private LessThanOrEqualToFunc()
		{
		}
		#endregion

		public Bool WhenZeroZero(BinaryNumber host1, BinaryNumber host2)
		{
			return Bool.True;
		}
		public Bool WhenZeroEven(BinaryNumber host1, BinaryNumber host2)
		{
			return Bool.True;
		}
		public Bool WhenZeroOdd(BinaryNumber host1, BinaryNumber host2)
		{
			return Bool.True;
		}

		public Bool WhenEvenZero(BinaryNumber host1, BinaryNumber host2)
		{
			return Bool.False;
		}
		public Bool WhenOddZero(BinaryNumber host1, BinaryNumber host2)
		{
			return Bool.False;
		}

		public Bool WhenEvenEven(BinaryNumber host1, BinaryNumber host2)
		{
			return host1.Rest.Accept(host2.Rest, this);
		}
		public Bool WhenOddOdd(BinaryNumber host1, BinaryNumber host2)
		{
			return host1.Rest.Accept(host2.Rest, this);
		}
		public Bool WhenEvenOdd(BinaryNumber host1, BinaryNumber host2)
		{
			return host1.Rest.Accept(host2.Rest, this);
		}

		public Bool WhenOddEven(BinaryNumber host1, BinaryNumber host2)
		{
			return host1.Rest.Accept(host2.Rest, LessThanFunc.Instance);
		}
	}
}
