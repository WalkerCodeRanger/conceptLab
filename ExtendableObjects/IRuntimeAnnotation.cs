namespace ConceptLab.ExtendableObjects
{
	/// <summary>
	/// Interface allowing the two types of runtime annotations to be dealt with the same way.
    /// It should not be directly implemented.  Instead implement <see cref="IRuntimeAnnotation{TAnnotated}"/>
    /// for annotations without a value and <see cref="IRuntimeAnnotation{TAnnotated, TValue}"/> for
    /// annotations with a value.
	/// </summary>
    public interface IRuntimeAnnotation
	{
        /// <summary>
        /// The name of this annotation.  The standard form of annotation names is:
        /// FullNamespace.ClassName{AnnotatedType, FullyQualifiedValueType} except the curly
        /// braces should be replaced with angle brackets.  Note that the full namespace of
        /// the annotated type is generally not included since it can be deduced from
        /// the annotation.  The value type is fully qualified with its namespace unless
        /// it is a standard C# type i.e. int, string, object, double etc. If this annotation
        /// has no value then the value type is omitted.
        /// </summary>
		string Name { get; }
	}

    /// <summary>
    /// Interface for annotations that do not have a value.  All implementations should be
    /// sealed singleton classes.
    /// </summary>
    /// <typeparam name="TAnnotated">The type being annotated</typeparam>
    public interface IRuntimeAnnotation<in TAnnotated> : IRuntimeAnnotation
    {
    }

    /// <summary>
    /// Interface for annotations that have a value.  All implementations should be sealed
    /// singleton classes.
    /// </summary>
    /// <typeparam name="TAnnotated">The type being annotated</typeparam>
    /// <typeparam name="TValue">The type of the value for this annotation (note: TValue should not be covarient)</typeparam>
    public interface IRuntimeAnnotation<in TAnnotated, TValue> : IRuntimeAnnotation
    {
        /// <summary>
        /// Tells whether there is a default value for this annotation that should be returned
        /// for all objects that do not have this annotation.
        /// </summary>
        bool HasDefaultValue { get; }

        /// <summary>
        /// The default value for this RuntimeAnnotation (if an object doesn't have the annotation,
        /// this value will be returned when <see cref="HasDefaultValue"/> returns true).
        /// </summary>
        TValue DefaultValue { get; }
    }
}
