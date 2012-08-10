using System;

namespace ConceptLab.PureObjects.Logic
{
	internal class False : Bool
	{
		#region Singleton
		private static readonly False instance = new False();

		public static Bool Instance
		{
			get { return instance; }
		}

		private False()
		{
		}
		#endregion

		public override Bool EqualTo(Bool value)
		{
			return value.Not;
		}

		public override Bool And(Bool value)
		{
			return False;
		}

		public override Bool And(Func<Bool> value)
		{
			return False;
		}

		public override Bool Or(Bool value)
		{
			return value;
		}

		public override Bool Or(Func<Bool> value)
		{
			return value();
		}

		public override Bool Xor(Bool value)
		{
			return value;
		}

		public override Bool Not
		{
			get { return True; }
		}

		public override TResult Accept<T, TResult>(IBoolFunc<T, TResult> func, T value)
		{
			return func.WhenFalse(value);
		}

		public override TResult Accept<TResult>(Func<TResult> whenTrue, Func<TResult> whenFalse)
		{
			return whenFalse();
		}
	}
}
