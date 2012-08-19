using System;
using ConceptLab.PureObjects.Logic;

namespace ConceptLab.PureObjects.Math.Binary
{
	/// <summary>
	/// Note: the reason the Double() and DoubleAddOne() methods are the only way to create non-zero
	/// binary numbers is it makes it impossible to make numbers with leading zeros
	/// </summary>
	public abstract class BinaryNumber
	{
		public static readonly BinaryNumber Zero = BinaryZero.Instance;
		public static readonly BinaryNumber One = Zero.DoubleAddOne();
		public static readonly BinaryNumber Two = One.Double();

		public abstract Bool IsZero { get; }
		public abstract Bool IsOdd { get; }
		public abstract BinaryNumber Rest { get; }

		public virtual BinaryNumber Double()
		{
			return new EvenBinaryNumber(this);
		}
		public virtual BinaryNumber DoubleAddOne()
		{
			return new OddBinaryNumber(this);
		}

		public abstract TResult Accept<T, TResult>(IBinaryNumberFunc<T, TResult> func, T param);
		public abstract TResult Accept<TResult>(IBinaryNumberFunc<TResult> func);

		public abstract TResult Accept<T, TResult>(BinaryNumber number2, IBinaryNumbersFunc<T, TResult> func, T param);
		// Protected access on these methods doesn't allow the subclasses to call them
		internal abstract TResult ZeroAccept<T, TResult>(BinaryNumber number1, IBinaryNumbersFunc<T, TResult> func, T param);
		internal abstract TResult EvenAccept<T, TResult>(BinaryNumber number1, IBinaryNumbersFunc<T, TResult> func, T param);
		internal abstract TResult OddAccept<T, TResult>(BinaryNumber number1, IBinaryNumbersFunc<T, TResult> func, T param);


		public abstract TResult Accept<TResult>(BinaryNumber number2, IBinaryNumbersFunc<TResult> func);
		// Protected access on these methods doesn't allow the subclasses to call them
		internal abstract TResult ZeroAccept<TResult>(BinaryNumber number1, IBinaryNumbersFunc<TResult> func);
		internal abstract TResult EvenAccept<TResult>(BinaryNumber number1, IBinaryNumbersFunc<TResult> func);
		internal abstract TResult OddAccept<TResult>(BinaryNumber number1, IBinaryNumbersFunc<TResult> func);

		public abstract void Repeat(Action action);


		public static implicit operator BinaryNumber(int value)
		{
			// Becuase of the interaction with procedural functions, we go ahead and use control constructs here
			if(value < 0)
				throw new InvalidCastException("Can't convert negative value to BinaryNumber");

			if(value == 0)
				return Zero;

			var rest = (BinaryNumber)(value >> 1);
			return (value & 1) > 0 ? rest.DoubleAddOne() : rest.Double();
		}

		public static explicit operator int(BinaryNumber value)
		{
			// Becuase of the interaction with procedural functions, we go ahead and use control constructs here
			if(value.IsZero)
				return 0;

			return ((int)value.Rest << 1) + (value.IsOdd ? 1 : 0);
		}
	}
}
