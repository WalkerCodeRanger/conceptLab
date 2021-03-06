﻿namespace ConceptLab.DataStructures.LinearRecursiveStructure
{
	/// <summary>
	/// The interface to which all external algorithms on List must adhere.    
	/// The IAlgorithm interface abstracts the variant behavior of an algorithm. There are two methods 
	/// that are specified:  The empty case method and the non-empty case method.     
	/// </summary>
	public interface IAlgorithmAction<TData, in TArgument>
	{
		/// <summary>
		/// This method is called when the algorithm processes an empty list. This method
		/// embodies the base case of the recursive algorithm.
		/// </summary>
		/// <param name="host">A reference to the null node.</param>
		/// <param name="argument">The input parameter passed to the algorithm.</param>
		void WhenEmpty(List<TData> host, TArgument argument);

		/// <summary>
		/// This method is executed when the algorithm processes a non-empty list node.  
		/// This method embodies the inductive case of the recursive algorithm.
		/// </summary>
		/// <param name="host">A reference to the current list node.</param>
		/// <param name="argument">The input parameter passed to the algorithm.</param>
		void WhenNonEmpty(List<TData> host, TArgument argument);
	}

	/// <summary>
	/// The interface to which all external algorithms on List must adhere.    
	/// The IAlgorithm interface abstracts the variant behavior of an algorithm. There are two methods 
	/// that are specified:  The empty case method and the non-empty case method.     
	/// </summary>
	public interface IAlgorithmAction<TData>
	{
		/// <summary>
		/// This method is called when the algorithm processes an empty list. This method
		/// embodies the base case of the recursive algorithm.
		/// </summary>
		/// <param name="host">A reference to the null node.</param>
		void WhenEmpty(List<TData> host);

		/// <summary>
		/// This method is executed when the algorithm processes a non-empty list node.  
		/// This method embodies the inductive case of the recursive algorithm.
		/// </summary>
		/// <param name="host">A reference to the current list node.</param>
		void WhenNonEmpty(List<TData> host);
	}
}
