namespace ConceptLab.DataStructures.DoublyLinkedList
{
	public interface IAlgorithmFunc<TData, in TArgument, out TReturn>
	{
		TReturn WhenEmpty(List<TData> host, TArgument argument);
		TReturn WhenNonEmpty(NonEmptyList<TData> host, TArgument argument);
	}

	public interface IAlgorithmFunc<TData, out TReturn>
	{
		TReturn WhenEmpty(List<TData> host);
		TReturn WhenNonEmpty(NonEmptyList<TData> host);
	}
}
