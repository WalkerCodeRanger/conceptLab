namespace ConceptLab.PureObjects.Logic
{
	public interface IBooleanVisitor<in T, out TResult>
	{
		TResult VisitTrue(T value);
		TResult VisitFalse(T value);
	}
}
