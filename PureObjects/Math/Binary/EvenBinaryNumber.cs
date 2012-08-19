using System;
using ConceptLab.PureObjects.Logic;

namespace ConceptLab.PureObjects.Math.Binary
{
	internal class EvenBinaryNumber : BinaryNumber
	{
		private readonly BinaryNumber rest;

		public EvenBinaryNumber(BinaryNumber rest)
		{
			this.rest = rest;
		}

		public override Bool IsZero
		{
			get { return Bool.False; }
		}
		public override Bool IsOdd
		{
			get { return Bool.False; }
		}
		public override BinaryNumber Rest
		{
			get { return rest; }
		}

		public override TResult Accept<T, TResult>(IBinaryNumberFunc<T, TResult> func, T param)
		{
			return func.WhenEven(this, param);
		}
		public override TResult Accept<TResult>(IBinaryNumberFunc<TResult> func)
		{
			return func.WhenEven(this);
		}

		public override TResult Accept<T, TResult>(BinaryNumber number2, IBinaryNumbersFunc<T, TResult> func, T param)
		{
			return number2.EvenAccept(this, func, param);
		}
		internal override TResult ZeroAccept<T, TResult>(BinaryNumber number1, IBinaryNumbersFunc<T, TResult> func, T param)
		{
			return func.WhenZeroEven(number1, this, param);
		}
		internal override TResult EvenAccept<T, TResult>(BinaryNumber number1, IBinaryNumbersFunc<T, TResult> func, T param)
		{
			return func.WhenEvenEven(number1, this, param);
		}
		internal override TResult OddAccept<T, TResult>(BinaryNumber number1, IBinaryNumbersFunc<T, TResult> func, T param)
		{
			return func.WhenOddEven(number1, this, param);
		}

		public override TResult Accept<TResult>(BinaryNumber number2, IBinaryNumbersFunc<TResult> func)
		{
			return number2.EvenAccept(this, func);
		}
		internal override TResult ZeroAccept<TResult>(BinaryNumber number1, IBinaryNumbersFunc<TResult> func)
		{
			return func.WhenZeroEven(number1, this);
		}
		internal override TResult EvenAccept<TResult>(BinaryNumber number1, IBinaryNumbersFunc<TResult> func)
		{
			return func.WhenEvenEven(number1, this);
		}
		internal override TResult OddAccept<TResult>(BinaryNumber number1, IBinaryNumbersFunc<TResult> func)
		{
			return func.WhenOddEven(number1, this);
		}

		public override void Repeat(Action action)
		{
			// Call action twice the amount of rest
			rest.Repeat(action);
			rest.Repeat(action);
		}

		public override string ToString()
		{
			return rest + "0";
		}
	}
}
