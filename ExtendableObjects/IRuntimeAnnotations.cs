namespace ConceptLab.ExtendableObjects
{
	/// <summary>
	/// The IRuntimeAnnotations interface provides a convenient and type safe implemention
	/// of adding "annotations" at runtime to an object.  These annotations are very much
	/// like dynamically added properties to an object.  In order to allow objects of a class
	/// to be annotated, implement the <see cref="IRuntimeAnnotatable{TAnnotated}"/> interface.
	/// 
	/// To create an instance of IRuntimeAnnotations, use the RuntimeAnnotations.CreateFor static
	/// factory method.
	/// </summary>
	/// <typeparam name="TAnnotated">The class being annotated</typeparam>
	public interface IRuntimeAnnotations<out TAnnotated>
		where TAnnotated: IRuntimeAnnotatable<TAnnotated>
	{
		int Count { get; }

		bool Has(IRuntimeAnnotation<TAnnotated> annotation);
		bool Has<TValue>(IRuntimeAnnotation<TAnnotated, TValue> annotation);

		void Add(IRuntimeAnnotation<TAnnotated> annotation);
		void Add<TValue>(IRuntimeAnnotation<TAnnotated, TValue> annotation, TValue value);
		bool Remove(IRuntimeAnnotation<TAnnotated> annotation);
		bool Remove<TValue>(IRuntimeAnnotation<TAnnotated, TValue> annotation);

		TValue Get<TValue>(IRuntimeAnnotation<TAnnotated, TValue> annotation);
		void Set<TValue>(IRuntimeAnnotation<TAnnotated, TValue> annotation, TValue value);
	}
}
