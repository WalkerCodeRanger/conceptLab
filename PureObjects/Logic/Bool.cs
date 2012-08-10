using System;

namespace ConceptLab.PureObjects.Logic
{
	public abstract class Bool
	{
		public static readonly Bool True = Logic.True.Instance;
		public static readonly Bool False = Logic.False.Instance;

		public abstract Bool EqualTo(Bool value);
		public abstract Bool And(Bool value);
		public abstract Bool And(Func<Bool> value);
		public abstract Bool Or(Bool value);
		public abstract Bool Or(Func<Bool> value);
		public abstract Bool Xor(Bool value);
		public abstract Bool Not { get; }

		public abstract TResult Accept<T, TResult>(IBoolFunc<T, TResult> func, T value);
		public abstract TResult Accept<TResult>(Func<TResult> whenTrue, Func<TResult> whenFalse);
	}
}
