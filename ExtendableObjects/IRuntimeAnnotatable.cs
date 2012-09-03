namespace ConceptLab.ExtendableObjects
{
	/// <summary>
	/// All classes which are runtime annotatable should implement this interface.  A typical
	/// implemention would be:
	/// <example>
	/// <![CDATA[
	/// private class Parent: IRuntimeAnnotatable<Parent>
	/// {
	///		private readonly IRuntimeAnnotations<Parent> annotations;
	/// 
	///		public Parent()
	///		{
	///			annotations = RuntimeAnnotations.CreateFor(this);
	///		}
	///
	///		public IRuntimeAnnotations<Parent> Annotations { get { retrun annotations; }}
	/// }
	/// ]]>
	/// </example>
	/// Becuase of the way RuntimeAnnotations.CreateFor(this); works, the IRuntimeAnnotations will actually
	/// be for the concrete type of this.  Thus allowing subclasses to extend the IRuntimeAnnotatable like so:
	/// <example>
	/// <![CDATA[
	/// private class Child: Parent, IRuntimeAnnotatable<Child>
	/// {
	///		public new IRuntimeAnnotations<Child> Annotations { get { (IRuntimeAnnotations<Child>)retrun base.Annotations; }}
	/// }
	/// ]]>
	/// </example>
	/// The cast in the child implementation is safe.
	/// </summary>
	/// <typeparam name="TAnnotatable">The class to which annotations are being attached</typeparam>
	public interface IRuntimeAnnotatable<out TAnnotatable>
		where TAnnotatable: IRuntimeAnnotatable<TAnnotatable>
	{
		IRuntimeAnnotations<TAnnotatable> Annotations { get; }
	}
}
