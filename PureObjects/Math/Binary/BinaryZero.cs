using System;
using ConceptLab.PureObjects.Logic;

namespace ConceptLab.PureObjects.Math.Binary
{
	public sealed class BinaryZero : BinaryNumber
	{
		#region Singleton
		private static readonly BinaryZero instance = new BinaryZero();

		public static BinaryNumber Instance
		{
			get { return instance; }
		}

		private BinaryZero()
		{
		}
		#endregion

		public override Bool IsZero
		{
			get { return Bool.True; }
		}
		public override Bool IsOdd
		{
			get { return Bool.False; }
		}
		public override BinaryNumber Rest
		{
			get { return this; }
		}

		public override BinaryNumber Double()
		{
			return this;
		}

		public override TResult Accept<T, TResult>(IBinaryNumberFunc<T, TResult> func, T param)
		{
			return func.WhenZero(this, param);
		}
		public override TResult Accept<TResult>(IBinaryNumberFunc<TResult> func)
		{
			return func.WhenZero(this);
		}

		public override TResult Accept<T, TResult>(BinaryNumber number2, IBinaryNumbersFunc<T, TResult> func, T param)
		{
			return number2.ZeroAccept(this, func, param);
		}
		internal override TResult ZeroAccept<T, TResult>(BinaryNumber number1, IBinaryNumbersFunc<T, TResult> func, T param)
		{
			return func.WhenZeroZero(number1, this, param);
		}
		internal override TResult EvenAccept<T, TResult>(BinaryNumber number1, IBinaryNumbersFunc<T, TResult> func, T param)
		{
			return func.WhenEvenZero(number1, this, param);
		}
		internal override TResult OddAccept<T, TResult>(BinaryNumber number1, IBinaryNumbersFunc<T, TResult> func, T param)
		{
			return func.WhenOddZero(number1, this, param);
		}

		public override TResult Accept<TResult>(BinaryNumber number2, IBinaryNumbersFunc<TResult> func)
		{
			return number2.ZeroAccept(this, func);
		}
		internal override TResult ZeroAccept<TResult>(BinaryNumber number1, IBinaryNumbersFunc<TResult> func)
		{
			return func.WhenZeroZero(number1, this);
		}
		internal override TResult EvenAccept<TResult>(BinaryNumber number1, IBinaryNumbersFunc<TResult> func)
		{
			return func.WhenEvenZero(number1, this);
		}
		internal override TResult OddAccept<TResult>(BinaryNumber number1, IBinaryNumbersFunc<TResult> func)
		{
			return func.WhenOddZero(number1, this);
		}

		public override void Repeat(Action action)
		{
			// Call action zero times
		}

		public override string ToString()
		{
			return "";
		}
	}
}
