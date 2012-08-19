namespace ConceptLab.PureObjects.Math.Binary
{
	public interface IBinaryNumbersFunc<in T, out TResult>
	{
		TResult WhenZeroZero(BinaryNumber host1, BinaryNumber host2, T param);
		TResult WhenZeroEven(BinaryNumber host1, BinaryNumber host2, T param);
		TResult WhenZeroOdd(BinaryNumber host1, BinaryNumber host2, T param);
		TResult WhenEvenZero(BinaryNumber host1, BinaryNumber host2, T param);
		TResult WhenEvenEven(BinaryNumber host1, BinaryNumber host2, T param);
		TResult WhenEvenOdd(BinaryNumber host1, BinaryNumber host2, T param);
		TResult WhenOddZero(BinaryNumber host1, BinaryNumber host2, T param);
		TResult WhenOddEven(BinaryNumber host1, BinaryNumber host2, T param);
		TResult WhenOddOdd(BinaryNumber host1, BinaryNumber host2, T param);
	}

	public interface IBinaryNumbersFunc<out TResult>
	{
		TResult WhenZeroZero(BinaryNumber host1, BinaryNumber host2);
		TResult WhenZeroEven(BinaryNumber host1, BinaryNumber host2);
		TResult WhenZeroOdd(BinaryNumber host1, BinaryNumber host2);
		TResult WhenEvenZero(BinaryNumber host1, BinaryNumber host2);
		TResult WhenEvenEven(BinaryNumber host1, BinaryNumber host2);
		TResult WhenEvenOdd(BinaryNumber host1, BinaryNumber host2);
		TResult WhenOddZero(BinaryNumber host1, BinaryNumber host2);
		TResult WhenOddEven(BinaryNumber host1, BinaryNumber host2);
		TResult WhenOddOdd(BinaryNumber host1, BinaryNumber host2);
	}
}
