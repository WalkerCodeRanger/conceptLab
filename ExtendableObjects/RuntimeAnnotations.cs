using System;
using System.Collections.Generic;

namespace ConceptLab.ExtendableObjects
{
	public static class RuntimeAnnotations
	{
		public static IRuntimeAnnotations<TAnnotatable> CreateFor<TAnnotatable>(TAnnotatable instance)
			where TAnnotatable: IRuntimeAnnotatable<TAnnotatable>
		{
			var type = instance.GetType();
			return (IRuntimeAnnotations<TAnnotatable>)Activator.CreateInstance(typeof(RuntimeAnnotations<>).MakeGenericType(type));
		}
	}


	internal class RuntimeAnnotations<TAnnotatable>: IRuntimeAnnotations<TAnnotatable>
		where TAnnotatable: IRuntimeAnnotatable<TAnnotatable>
	{
		private readonly Dictionary<IRuntimeAnnotation, object> values = new Dictionary<IRuntimeAnnotation, object>();

		public int Count
		{
			get { return values.Count; }
		}

		public bool Has(IRuntimeAnnotation<TAnnotatable> annotation)
		{
			return values.ContainsKey(annotation);
		}
		public bool Has<TValue>(IRuntimeAnnotation<TAnnotatable, TValue> annotation)
		{
			return values.ContainsKey(annotation);
		}

		public void Add(IRuntimeAnnotation<TAnnotatable> annotation)
		{
			values.Add(annotation, null);
		}
		public void Add<TValue>(IRuntimeAnnotation<TAnnotatable, TValue> annotation, TValue value)
		{
			values.Add(annotation, value);
		}
		public bool Remove(IRuntimeAnnotation<TAnnotatable> annotation)
		{
			return values.Remove(annotation);
		}
		public bool Remove<TValue>(IRuntimeAnnotation<TAnnotatable, TValue> annotation)
		{
			return values.Remove(annotation);
		}

		public TValue Get<TValue>(IRuntimeAnnotation<TAnnotatable, TValue> annotation)
		{
			object value;
			if(values.TryGetValue(annotation, out value))
				return (TValue)value;
			else if(annotation.HasDefaultValue)
				return annotation.DefaultValue;
			else
				throw RuntimeAnnotationNotFoundException.Create(annotation);
		}
		public void Set<TValue>(IRuntimeAnnotation<TAnnotatable, TValue> annotation, TValue value)
		{
			values[annotation] = value;
		}
	}
}
