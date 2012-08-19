namespace ConceptLab.PureObjects.Math
{
	public struct DivisionResult<TValue>
	{
		public readonly TValue Quotient;
		public readonly TValue Remainder;

		public DivisionResult(TValue quotient, TValue remainder)
		{
			Quotient = quotient;
			Remainder = remainder;
		}
	}

	public static class DivisionResult
	{
		public static DivisionResult<TValue> Create<TValue>(TValue quotient, TValue remainder)
		{
			return new DivisionResult<TValue>(quotient, remainder);
		}
	}
}
