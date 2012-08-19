using System;
using ConceptLab.PureObjects.Logic;

namespace ConceptLab.PureObjects.Math.Binary
{
	internal class OddBinaryNumber : BinaryNumber
	{
		private readonly BinaryNumber rest;

		public OddBinaryNumber(BinaryNumber rest)
		{
			this.rest = rest;
		}

		public override Bool IsZero
		{
			get { return Bool.False; }
		}
		public override Bool IsOdd
		{
			get { return Bool.True; }
		}
		public override BinaryNumber Rest
		{
			get { return rest; }
		}

		public override TResult Accept<T, TResult>(IBinaryNumberFunc<T, TResult> func, T param)
		{
			return func.WhenOdd(this, param);
		}
		public override TResult Accept<TResult>(IBinaryNumberFunc<TResult> func)
		{
			return func.WhenOdd(this);
		}

		public override TResult Accept<T, TResult>(BinaryNumber number2, IBinaryNumbersFunc<T, TResult> func, T param)
		{
			return number2.OddAccept(this, func, param);
		}
		internal override TResult ZeroAccept<T, TResult>(BinaryNumber number1, IBinaryNumbersFunc<T, TResult> func, T param)
		{
			return func.WhenZeroOdd(number1, this, param);
		}
		internal override TResult EvenAccept<T, TResult>(BinaryNumber number1, IBinaryNumbersFunc<T, TResult> func, T param)
		{
			return func.WhenEvenOdd(number1, this, param);
		}
		internal override TResult OddAccept<T, TResult>(BinaryNumber number1, IBinaryNumbersFunc<T, TResult> func, T param)
		{
			return func.WhenOddOdd(number1, this, param);
		}

		public override TResult Accept<TResult>(BinaryNumber number2, IBinaryNumbersFunc<TResult> func)
		{
			return number2.OddAccept(this, func);
		}
		internal override TResult ZeroAccept<TResult>(BinaryNumber number1, IBinaryNumbersFunc<TResult> func)
		{
			return func.WhenZeroOdd(number1, this);
		}
		internal override TResult EvenAccept<TResult>(BinaryNumber number1, IBinaryNumbersFunc<TResult> func)
		{
			return func.WhenEvenOdd(number1, this);
		}
		internal override TResult OddAccept<TResult>(BinaryNumber number1, IBinaryNumbersFunc<TResult> func)
		{
			return func.WhenOddOdd(number1, this);
		}

		public override void Repeat(Action action)
		{
			// Call action twice the amount of rest plus one
			rest.Repeat(action);
			rest.Repeat(action);
			action();
		}

		public override string ToString()
		{
			return rest + "1";
		}
	}
}
