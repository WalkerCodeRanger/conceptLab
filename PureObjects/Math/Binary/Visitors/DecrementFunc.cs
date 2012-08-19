using System;

namespace ConceptLab.PureObjects.Math.Binary.Visitors
{
	internal class DecrementFunc : IBinaryNumberFunc<BinaryNumber>
	{
		#region Singleton
		static public readonly DecrementFunc Instance = new DecrementFunc();

		private DecrementFunc()
		{
		}
		#endregion

		public BinaryNumber WhenZero(BinaryNumber host)
		{
			throw new NotSupportedException("BinaryNumber can't be negative");
		}

		public BinaryNumber WhenOdd(BinaryNumber host)
		{
			return host.Rest.Double();
		}

		public BinaryNumber WhenEven(BinaryNumber host)
		{
			return host.Rest.Accept(this).DoubleAddOne();
		}
	}
}
