using System;

namespace ConceptLab.PureObjects.Logic
{
	internal class True: Bool
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

		public override Bool And(Bool value)
		{
			return value;
		}

		public override Bool Or(Bool value)
		{
			return True;
		}

		public override Bool Xor(Bool value)
		{
			return value.Not();
		}

		public override Bool Not()
		{
			return False;
		}

		public override TResult Accept<T, TResult>(IBoolVisitor<T, TResult> visitor, T value)
		{
			return visitor.VisitTrue(value);
		}

		public override TResult Accept<TResult>(Func<TResult> whenTrue, Func<TResult> whenFalse)
		{
			return whenTrue();
		}
	}
}
