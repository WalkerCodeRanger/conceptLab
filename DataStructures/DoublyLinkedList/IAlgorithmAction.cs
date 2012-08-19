namespace ConceptLab.DataStructures.DoublyLinkedList
{
	public interface IAlgorithmAction<TData, in TArgument>
	{
		void WhenEmpty(List<TData> host, TArgument argument);
		void WhenNonEmpty(NonEmptyList<TData> host, TArgument argument);
	}

	public interface IAlgorithmAction<TData>
	{
		void WhenEmpty(List<TData> host);
		void WhenNonEmpty(NonEmptyList<TData> host);
	}
}
