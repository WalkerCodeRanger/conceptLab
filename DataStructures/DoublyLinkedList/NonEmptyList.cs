namespace ConceptLab.DataStructures.DoublyLinkedList
{
	public class NonEmptyList<TData>: List<TData>
	{
		private TData data;
		private readonly NonEmptyList<TData> reverse;

		private NonEmptyList(NonEmptyList<TData> reverse)
		{
			this.reverse = reverse;
			data = reverse.Data;
			Next = new EmptyNode<TData>(this);
		}

		internal NonEmptyList(TData value)
		{
			data = value;
			reverse = new NonEmptyList<TData>(this);
			Next = new EmptyNode<TData>(this);
		}

		public override TReturn Accept<TArgument, TReturn>(IAlgorithmFunc<TData, TArgument, TReturn> algorithm, TArgument argument)
		{
			return algorithm.WhenNonEmpty(this, argument);
		}
		public override TReturn Accept<TReturn>(IAlgorithmFunc<TData, TReturn> algorithm)
		{
			return algorithm.WhenNonEmpty(this);
		}
		public override void Accept<TArgument>(IAlgorithmAction<TData, TArgument> algorithm, TArgument argument)
		{
			algorithm.WhenNonEmpty(this, argument);
		}
		public override void Accept(IAlgorithmAction<TData> algorithm)
		{
			algorithm.WhenNonEmpty(this);
		}

		public override List<TData> Next { get; internal set; }


		public override List<TData> Reverse
		{
			get { return reverse; }
		}

		public TData Data
		{
			get { return data; }
			set
			{
				data = value;
				reverse.data = value;
			}
		}
	}
}
