namespace ConceptLab.PureObjects.Logic
{
	public interface IBoolFunc<in T, out TResult>
	{
		TResult WhenTrue(T value);
		TResult WhenFalse(T value);
	}
}
