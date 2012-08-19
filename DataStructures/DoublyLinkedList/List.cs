using ConceptLab.DataStructures.DoublyLinkedList.Algorithms;

namespace ConceptLab.DataStructures.DoublyLinkedList
{
	public static class List
	{
		public static List<TData> Create<TData>()
		{
			return new EmptyNode<TData>();
		}

		public static NonEmptyList<TData> Create<TData>(TData value)
		{
			return new NonEmptyList<TData>(value);
		}

		public static List<TData> End<TData>(this List<TData> list )
		{
			return list.Execute(EndFunc<TData>.Instance);
		}

		public static int Count<TData>(this List<TData> list)
		{
			return list.End().Next.Execute(CountForwardFunc<TData>.Instance);
		}
	}

	public abstract class List<TData>
	{
		public abstract TReturn Execute<TArgument, TReturn>(IAlgorithmFunc<TData, TArgument, TReturn> algorithm, TArgument argument);
		public abstract TReturn Execute<TReturn>(IAlgorithmFunc<TData, TReturn> algorithm);
		public abstract void Execute<TArgument>(IAlgorithmAction<TData, TArgument> algorithm, TArgument argument);
		public abstract void Execute(IAlgorithmAction<TData> algorithm);

		public abstract List<TData> Next { get; internal set; }
		public abstract List<TData> Reverse { get; }

		/// <summary>
		/// Break a list into two and the current point
		/// </summary>
		/// <returns></returns>
		public List<TData> Break()
		{
			var newStart = new EmptyNode<TData>(Next);
			Next.Reverse.Next = newStart;
			Next = new EmptyNode<TData>(Reverse);
			return newStart;
		}

		/// <summary>
		/// Insert a new node between this one and next
		/// </summary>
		/// <param name="value"></param>
		public void InsertNext(TData value)
		{
			var oldNext = Next;
			var newNode = new NonEmptyList<TData>(value);
			Next = newNode;
			oldNext.Reverse.Next = newNode.Reverse;
			newNode.Next = oldNext;
			newNode.Reverse.Next = Reverse;
		}

		/// <summary>
		/// Visualize this operation as twisting together the two lists at
		/// this point so that two new lists are formed.  Each containing
		/// a half from each of the original lists
		/// </summary>
		/// <param name="list"></param>
		public void JoinWith(List<TData> list)
		{
			var oldNext = Next;
			var oldListPrevious = list.Reverse.Next.Reverse;

			Next = list;
			list.Reverse.Next = Reverse;

			oldListPrevious.Next = oldNext;
			oldNext.Reverse.Next = oldListPrevious.Reverse;
		}
	}
}
