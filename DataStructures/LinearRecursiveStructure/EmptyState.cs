namespace ConceptLab.DataStructures.LinearRecursiveStructure
{
	internal class EmptyState<TData> : ListState<TData>
	{
		#region Singleton
		private static readonly EmptyState<TData> instance = new EmptyState<TData>();

		public static ListState<TData> Instance
		{
			get { return instance; }
		}

		private EmptyState()
		{
		}
		#endregion

		public override void InsertAsFirst(List<TData> owner, TData value)
		{
			owner.State = new NonEmptyState<TData>(value);
		}

		public override TData RemoveFirst(List<TData> owner)
		{
			return default(TData);
		}

		public override TData GetFirst(List<TData> owner)
		{
			return default(TData);
		}

		public override void SetFirst(List<TData> owner, TData first)
		{
		}

		public override List<TData> GetRest(List<TData> owner)
		{
			return owner;
		}

		public override void SetRest(List<TData> owner, List<TData> rest)
		{
		}

		public override TReturn Execute<TArgument, TReturn>(List<TData> owner, IAlgorithmFunc<TData, TArgument, TReturn> algorithm, TArgument arguement)
		{
			return algorithm.WhenEmpty(owner, arguement);
		}

		public override TReturn Execute<TReturn>(List<TData> owner, IAlgorithmFunc<TData, TReturn> algorithm)
		{
			return algorithm.WhenEmpty(owner);
		}

		public override void Execute<TArgument>(List<TData> owner, IAlgorithmAction<TData, TArgument> algorithm, TArgument arguement)
		{
			algorithm.WhenEmpty(owner, arguement);
		}

		public override void Execute(List<TData> owner, IAlgorithmAction<TData> algorithm)
		{
			algorithm.WhenEmpty(owner);
		}
	}
}
