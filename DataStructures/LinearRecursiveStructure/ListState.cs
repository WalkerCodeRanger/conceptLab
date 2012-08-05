namespace ConceptLab.DataStructures.LinearRecursiveStructure
{
	/// <summary>
	/// abstract LRS node
	/// All methods from the LRStruct except the accessor methods for the abstract state, are delegated through 
	/// to the concrete state object.    The current node ("host") is provided as an additional input parameter. 
	/// </summary>
	/// <typeparam name="TData"></typeparam>
	internal abstract class ListState<TData>
	{
		public abstract void InsertAsFirst(List<TData> owner, TData value);
		public abstract TData RemoveFirst(List<TData> owner);
		public abstract TData GetFirst(List<TData> owner);
		public abstract void SetFirst(List<TData> owner, TData first);
		public abstract List<TData> GetRest(List<TData> owner);
		public abstract void SetRest(List<TData> owner, List<TData> rest);
		public abstract TReturn Execute<TArgument, TReturn>(List<TData> owner, IAlgorithmFunc<TData, TArgument, TReturn> algorithm, TArgument arguement);
		public abstract TReturn Execute<TReturn>(List<TData> owner, IAlgorithmFunc<TData, TReturn> algorithm);
		public abstract void Execute<TArgument>(List<TData> owner, IAlgorithmAction<TData, TArgument> algorithm, TArgument arguement);
		public abstract void Execute(List<TData> owner, IAlgorithmAction<TData> algorithm);
	}
}
