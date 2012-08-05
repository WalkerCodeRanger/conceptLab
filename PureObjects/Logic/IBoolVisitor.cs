namespace ConceptLab.PureObjects.Logic
{
	public interface IBoolVisitor<in T, out TResult>
	{
		TResult VisitTrue(T value);
		TResult VisitFalse(T value);
	}
}
