using System;

namespace ConceptLab.ExtendableObjects
{
	public class RuntimeAnnotationNotFoundException: ApplicationException
	{
		private readonly IRuntimeAnnotation annotation;

        #region Construction
        /// <summary>
        /// Should only be called with a <see cref="IRuntimeAnnotation{TAnnotated,TValue}"/> or <see cref="IRuntimeAnnotation{TAnnotated}"/>,
        /// which is enforced by the RuntimeAnnotationNotFoundException.Create method.
		/// </summary>
		/// <param name="annotation"></param>
		internal RuntimeAnnotationNotFoundException(IRuntimeAnnotation annotation)
			: base("The annotation " + annotation + " was not found.")
		{
			this.annotation = annotation;
		}

        public static RuntimeAnnotationNotFoundException Create<TAnnotated>(IRuntimeAnnotation<TAnnotated> annotation)
        {
            return new RuntimeAnnotationNotFoundException(annotation);
        }

        public static RuntimeAnnotationNotFoundException Create<TAnnotated, TValue>(IRuntimeAnnotation<TAnnotated, TValue> annotation)
        {
            return new RuntimeAnnotationNotFoundException(annotation);
        }
        #endregion

	    public IRuntimeAnnotation Annotation
	    {
	        get { return annotation; }
	    }
	}
}
