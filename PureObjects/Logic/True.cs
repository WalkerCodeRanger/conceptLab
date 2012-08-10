using System;

namespace ConceptLab.PureObjects.Logic
{
	internal class True : Bool
	{
		#region Singleton
		private static readonly True instance = new True();

		public static Bool Instance
		{
			get { return instance; }
		}

		private True()
		{
		}
		#endregion

		public override Bool EqualTo(Bool value)
		{
			return value;
		}

		public override Bool And(Bool value)
		{
			return value;
		}

		public override Bool And(Func<Bool> value)
		{
			return value();
		}

		public override Bool Or(Bool value)
		{
			return True;
		}

		public override Bool Or(Func<Bool> value)
		{
			return True;
		}

		public override Bool Xor(Bool value)
		{
			return value.Not;
		}

		public override Bool Not
		{
			get { return False; }
		}

		public override TResult Accept<T, TResult>(IBoolFunc<T, TResult> func, T value)
		{
			return func.WhenTrue(value);
		}

		public override TResult Accept<TResult>(Func<TResult> whenTrue, Func<TResult> whenFalse)
		{
			return whenTrue();
		}
	}
}
