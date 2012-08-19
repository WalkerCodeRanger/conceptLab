namespace ConceptLab.PureObjects.Math.Binary
{
	public interface IBinaryNumberFunc<in T1, in T2, out TResult>
	{
		TResult WhenZero(BinaryNumber host, T1 param1, T2 param2);
		TResult WhenOdd(BinaryNumber host, T1 param1, T2 param2);
		TResult WhenEven(BinaryNumber host, T1 param1, T2 param2);
	}

	public interface IBinaryNumberFunc<in T, out TResult>
	{
		TResult WhenZero(BinaryNumber host, T param);
		TResult WhenOdd(BinaryNumber host, T param);
		TResult WhenEven(BinaryNumber host, T param);
	}

	public interface IBinaryNumberFunc<out TResult>
	{
		TResult WhenZero(BinaryNumber host);
		TResult WhenOdd(BinaryNumber host);
		TResult WhenEven(BinaryNumber host);
	}
}
