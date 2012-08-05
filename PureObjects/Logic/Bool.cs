using System;

namespace ConceptLab.PureObjects.Logic
{
	public abstract class Bool
	{
		public static readonly Bool True = Logic.True.Instance;
		public static readonly Bool False = Logic.False.Instance;

		public abstract Bool And(Bool value);
		public abstract Bool Or(Bool value);
		public abstract Bool Xor(Bool value);
		public abstract Bool Not();

		public abstract TResult Accept<T, TResult>(IBoolVisitor<T, TResult> visitor, T value);
		public abstract TResult Accept<TResult>(Func<TResult> whenTrue, Func<TResult> whenFalse);
	}
}
