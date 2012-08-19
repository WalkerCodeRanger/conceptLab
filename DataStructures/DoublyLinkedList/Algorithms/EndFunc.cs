namespace ConceptLab.DataStructures.DoublyLinkedList.Algorithms
{
	internal class EndFunc<TData>: IAlgorithmFunc<TData, List<TData>>
	{
		#region Singleton
		static public readonly EndFunc<TData> Instance = new EndFunc<TData>();

		private EndFunc()
		{
		}
		#endregion

		public List<TData> WhenEmpty(List<TData> host)
		{
			return host;
		}

		public List<TData> WhenNonEmpty(NonEmptyList<TData> host)
		{
			return host.Accept(this);
		}
	}
}
