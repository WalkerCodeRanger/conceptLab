using ConceptLab.ExtendableObjects;
using NUnit.Framework;

namespace ConceptLab.ExtendableObjectsTests
{
	[TestFixture]
	public class RuntimeAnnotationsTests
	{
		private class Parent: IRuntimeAnnotatable<Parent>
		{
			private readonly IRuntimeAnnotations<Parent> annotations;

			public Parent()
			{
				annotations = RuntimeAnnotations.CreateFor(this);
			}

			public IRuntimeAnnotations<Parent> Annotations
			{
				get { return annotations; }
			}
		}

		private class ParentAnnotation: IRuntimeAnnotation<Parent>
		{
			#region Singleton
			private static readonly ParentAnnotation instance = new ParentAnnotation();

			public static IRuntimeAnnotation<Parent> Instance
			{
				get { return instance; }
			}

			private ParentAnnotation() { }
			#endregion

			public string Name
			{
				get { return "ConceptLab.ExtendableObjectsTests.ParentAnnotation<Parent>"; }
			}
		}

		private class ParentAnnotation<TValue>: IRuntimeAnnotation<Parent, TValue>
		{
			#region Singleton
			private static readonly ParentAnnotation<TValue> instance = new ParentAnnotation<TValue>();

			public static IRuntimeAnnotation<Parent, TValue> Instance
			{
				get { return instance; }
			}

			private ParentAnnotation() { }
			#endregion

			public string Name
			{
				get { return "ConceptLab.ExtendableObjectsTests.ParentAnnotation<Parent, " + typeof(TValue).FullName + ">"; }
			}

			public bool HasDefaultValue { get { return false; } }
			public TValue DefaultValue { get { return default(TValue); } }
		}

		private class Child: Parent, IRuntimeAnnotatable<Child>
		{
			public new IRuntimeAnnotations<Child> Annotations
			{
				get { return (IRuntimeAnnotations<Child>)base.Annotations; }
			}
		}

		private class ChildAnnotation: IRuntimeAnnotation<Child>
		{
			#region Singleton
			private static readonly ChildAnnotation instance = new ChildAnnotation();

			public static IRuntimeAnnotation<Child> Instance
			{
				get { return instance; }
			}

			private ChildAnnotation() { }
			#endregion

			public string Name
			{
				get { return "ConceptLab.ExtendableObjectsTests.ChildAnnotation<Child>"; }
			}
		}

		private class ChildAnnotation<TValue>: IRuntimeAnnotation<Child, TValue>
		{
			#region Singleton
			private static readonly ChildAnnotation<TValue> instance = new ChildAnnotation<TValue>();

			public static IRuntimeAnnotation<Child, TValue> Instance
			{
				get { return instance; }
			}

			private ChildAnnotation() { }
			#endregion

			public string Name
			{
				get { return "ConceptLab.ExtendableObjectsTests.ChildAnnotation<Child, " + typeof(TValue).FullName + ">"; }
			}

			public bool HasDefaultValue { get { return false; } }
			public TValue DefaultValue { get { return default(TValue); } }
		}



		[Test]
		public void VarienceTests()
		{
			// We must be able to provde a parent annotation in cases where a child is expected
			IRuntimeAnnotation<Child> childAnnotation = ParentAnnotation.Instance;

			// We must be able to provide the child when a parent annotatable is expected
			IRuntimeAnnotatable<Parent> parentAnnotable = new Child();

			// To support child specialization, we must be able to assign IRuntimeAnnotations upward
			IRuntimeAnnotations<Parent> parentAnnotations = RuntimeAnnotations.CreateFor(new Child());
		}

		[Test]
		public void TestAdd()
		{
			var parentAnnotatable = new Parent();
			Assert.IsFalse(parentAnnotatable.Annotations.Has(ParentAnnotation.Instance), "Doesn't have ParentAnnotation after instatiation");
			parentAnnotatable.Annotations.Add(ParentAnnotation.Instance);
			Assert.IsTrue(parentAnnotatable.Annotations.Has(ParentAnnotation.Instance), "Has ParentAnnotation after adding");
			// The next line does not compile (which is correct) becuase a child annotation can't be applied to the parent
			//parentAnnotatable.Add(ChildAnnotation.Instance);

			var childAnnotatable = new Child();
			childAnnotatable.Annotations.Add(ParentAnnotation.Instance);
			childAnnotatable.Annotations.Add(ChildAnnotation.Instance);
		}

		[Test]
		[ExpectedException(typeof(RuntimeAnnotationNotFoundException))]
		public void TestGetFailure()
		{
			var annotatable = new Parent();
			annotatable.Annotations.Get(ParentAnnotation<int>.Instance);
		}
	}
}
