namespace ConceptLab.PureObjects.Logic
{
	public abstract class Boolean
	{
		public static readonly Boolean True = Logic.True.Instance;
		public static readonly Boolean False = Logic.False.Instance;

		public abstract TResult Accept<T, TResult>(IBooleanVisitor<T, TResult> visitor, T value);
	}
}
