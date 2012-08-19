namespace ConceptLab.DataStructures.DoublyLinkedList.Algorithms
{
	internal class CountForwardFunc<TData>: IAlgorithmFunc<TData, int>
	{
		#region Singleton
		static public readonly CountForwardFunc<TData> Instance = new CountForwardFunc<TData>();

		private CountForwardFunc()
		{
		}
		#endregion

		public int WhenEmpty(List<TData> host)
		{
			return 0;
		}

		public int WhenNonEmpty(NonEmptyList<TData> host)
		{
			return 1 + host.Next.Accept(this);
		}
	}
}
