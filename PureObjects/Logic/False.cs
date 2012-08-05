using System;

namespace ConceptLab.PureObjects.Logic
{
	internal class False: Bool
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

		public override Bool And(Bool value)
		{
			return False;
		}

		public override Bool Or(Bool value)
		{
			return value;
		}

		public override Bool Xor(Bool value)
		{
			return value;
		}

		public override Bool Not()
		{
			return True;
		}

		public override TResult Accept<T, TResult>(IBoolVisitor<T, TResult> visitor, T value)
		{
			return visitor.VisitFalse(value);
		}

		public override TResult Accept<TResult>(Func<TResult> whenTrue, Func<TResult> whenFalse)
		{
			return whenFalse();
		}
	}
}
