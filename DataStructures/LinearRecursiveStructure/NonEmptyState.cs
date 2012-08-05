namespace ConceptLab.DataStructures.LinearRecursiveStructure
{
	internal class NonEmptyState<TData> : ListState<TData>
	{
		private TData first;
		private List<TData> rest = new List<TData>();

		public NonEmptyState(TData first)
		{
			this.first = first;
		}

		public override void InsertAsFirst(List<TData> owner, TData value)
		{
			var newState = new NonEmptyState<TData>(value);
			owner.State = newState;
			owner.Rest.State = this;
		}

		public override TData RemoveFirst(List<TData> owner)
		{
			owner.State = rest.State;
			return first;
		}

		public override TData GetFirst(List<TData> owner)
		{
			return first;
		}

		public override void SetFirst(List<TData> owner, TData first)
		{
			this.first = first;
		}

		public override List<TData> GetRest(List<TData> owner)
		{
			return rest;
		}

		public override void SetRest(List<TData> owner, List<TData> rest)
		{
			this.rest = rest;
		}

		public override TReturn Execute<TArgument, TReturn>(List<TData> owner, IAlgorithmFunc<TData, TArgument, TReturn> algorithm, TArgument arguement)
		{
			return algorithm.NonEmptyCase(owner, arguement);
		}

		public override TReturn Execute<TReturn>(List<TData> owner, IAlgorithmFunc<TData, TReturn> algorithm)
		{
			return algorithm.NonEmptyCase(owner);
		}

		public override void Execute<TArgument>(List<TData> owner, IAlgorithmAction<TData, TArgument> algorithm, TArgument arguement)
		{
			algorithm.NonEmptyCase(owner, arguement);
		}

		public override void Execute(List<TData> owner, IAlgorithmAction<TData> algorithm)
		{
			algorithm.NonEmptyCase(owner);
		}
	}
}
