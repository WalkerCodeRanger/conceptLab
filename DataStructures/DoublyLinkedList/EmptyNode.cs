namespace ConceptLab.DataStructures.DoublyLinkedList
{
	internal class EmptyNode<TData>: List<TData>
	{
		private List<TData> next;

		internal EmptyNode(List<TData> next)
		{
			this.next = next;
		}

		internal EmptyNode()
		{
			next = new EmptyNode<TData>(this);
		}

		public override TReturn Accept<TArgument, TReturn>(IAlgorithmFunc<TData, TArgument, TReturn> algorithm, TArgument argument)
		{
			return algorithm.WhenEmpty(this, argument);
		}
		public override TReturn Accept<TReturn>(IAlgorithmFunc<TData, TReturn> algorithm)
		{
			return algorithm.WhenEmpty(this);
		}
		public override void Accept<TArgument>(IAlgorithmAction<TData, TArgument> algorithm, TArgument argument)
		{
			algorithm.WhenEmpty(this, argument);
		}
		public override void Accept(IAlgorithmAction<TData> algorithm)
		{
			algorithm.WhenEmpty(this);
		}

		public override List<TData> Next
		{
			get { return next; }
			internal set { next = value; }
		}

		public override List<TData> Reverse
		{
			get { return this; }
		}
	}
}
