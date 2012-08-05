namespace ConceptLab.DataStructures.LinearRecursiveStructure
{
	/// <summary>
	/// "Linear Recursive Structure":  
	/// A state design pattern list that implements a mutable linked list.   
	/// It represents the entirety of a list in its entirety, not just a single node.
	/// It encapsulates the invariant behavior of a list.
	/// It can transition from the empty state to the non-empty state without creating a new list instance.
	/// it provides 6 public manipulation methods that can be used to build any recursive algorithm on the list.
	/// A public method for extensibility is provided to execute external algorithms on the list via a visitor
	/// design pattern implementation.
	/// 
	/// see http://www.cse.buffalo.edu/faculty/alphonce/Courses/Spring2010/cse116/Lectures/Lectures/LinkedList-2.pdf
	/// </summary>
	/// <typeparam name="TData"></typeparam>
	public class List<TData>
	{
		private ListState<TData> state;

		/// <summary>
		/// Construct an empty list
		/// </summary>
		public List()
		{
			state = EmptyState<TData>.Instance;
		}

		/// <summary>
		/// Inserts the supplied data as the first of a new node at the head of the list.  The insertion is
		/// done in place without the generation of a new list.  References to the List are not distrurbed.
		/// </summary>
		/// <param name="value">data to insert at this node</param>
		public void InsertAsFirst(TData value)
		{
			state.InsertAsFirst(this, value);
		}

		/// <summary>
		/// Removes the head node of the list, returning its first.   The removal is done
		/// in place, without disturbing references to the list.   No effect if the list is empty.
		/// </summary>
		/// <returns>Returns the first item in the list (the one removed) or default(TData) when empty</returns>
		public TData RemoveFirst()
		{
			return state.RemoveFirst(this);
		}

		/// <summary>
		/// Accessor method for the head node's first.  Returns default(TData) if the list is empty.
		/// </summary>
		public TData First
		{
			get { return state.GetFirst(this); }
			set { state.SetFirst(this, value); }
		}

		/// <summary>
		/// Accessor method for the rest of the head node.   Returns the same list if the list is empty
		/// </summary>
		public List<TData> Rest
		{
			get { return state.GetRest(this); }
			set { state.SetRest(this, value); }
		}

		internal ListState<TData> State
		{
			get { return state; }
			set { state = value; }
		}

		/// <summary>
		/// A method that allows an external algorithm to be executed on the list.  The algorithm must
		/// conform to an IAlgorithmFunc or IAlgorithmAction interface which specifies the empty and non-empty case methods of a 
		/// recursive algorithm.  Arguments can be passed to the algorithm and it can return a value. The current node is also made available
		/// to the algorithm at any point during its recursion.
		/// </summary>
		/// <typeparam name="TArgument"></typeparam>
		/// <typeparam name="TReturn"></typeparam>
		/// <param name="algorithm">The algorithm to be executed</param>
		/// <param name="arguement">The argument to pass to the algorithm.</param>
		/// <returns></returns>
		public TReturn Execute<TArgument, TReturn>(IAlgorithmFunc<TData, TArgument, TReturn> algorithm, TArgument arguement)
		{
			return state.Execute(this, algorithm, arguement);
		}
		public TReturn Execute<TReturn>(IAlgorithmFunc<TData, TReturn> algorithm)
		{
			return state.Execute(this, algorithm);
		}
		public void Execute<TArgument>(IAlgorithmAction<TData, TArgument> algorithm, TArgument argument)
		{
			state.Execute(this, algorithm, argument);
		}
		public void Execute(IAlgorithmAction<TData> algorithm)
		{
			state.Execute(this, algorithm);
		}
	}
}
