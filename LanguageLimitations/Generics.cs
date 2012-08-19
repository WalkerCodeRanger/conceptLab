using System;

namespace ConceptLab.LanguageLimitations
{
    public static class Other
    {
        /// <summary>
        /// Constraining a generic type to be a delegate doesn't work, either with class name or keyword
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void Foo<T>()
            //where T : System.Delegate
            //where T : delegate
        {
        }

        /// <summary>
        /// Constraining a generic type to an enum doesn't work
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T Parse<T>(this string value)
            //where T : Enum
            //where T : enum
        {
           return (T)Enum.Parse(typeof(T), value);
        }

        /// <summary>
        /// Generic Type inference is sometimes too weak
        /// </summary>
        public static void TypeInferenceWeak()
        {
            var bar = new Bar();

            // This call is valid
            ExampleMethod<Bar, int, string>(bar, (b, x, y) => b.Foo(x, y));

            // But the compiler can't infer the type arguments even though there is enough information
            //ExampleMethod(bar, (b, x, y) => b.Foo(x, y));

            // When you are trying to write a clean API, knowing that they will have to specify long complex type parameters
            // every time they call this method means it is better to just come up with a less ideal way of doing it
            // that works with type inference
        }

        public static void ExampleMethod<TValue, TArg1, TArg2>(TValue mock, Action<TValue, TArg1, TArg2> action)
        {
        }

		public class Bar
		{
			public void Foo(int x, string y)
			{
			}
		}

		/// <summary>
		/// Generic visitors are very useful.  However, you don't always need the return value or the argument.  Sometimes you
		/// need more than one argument.
		/// 
		/// What you need is to be able to use "void" as the TReturn type, but that is not allowed.
		/// Instead you are forced either to:
		///		1. Implement different versions of the interface with void return and overload the accept method
		///		2. Implement a special Void or Unit type and use it as the return type
		/// 
		/// What you need for the aguments is actually a list of types (which could be empty)
		/// Instead you are forced either to:
		///		1. Implement different versopns of the interface with differnt number of arguments and overload the accept method
		///		2. Use Tuples as a way to pass multiple arguments, however they are clunky and there is no empty Tuple
		/// 
		/// If you combine solutions both of the first solutions, you have a new problem.  Then it isn't possible to distinguish
		/// a vistor with one parameter and void return from one with no parameters and a return and so on.  This is the problem
		/// that led to the declaration of Func and Action in the framework.  You then have to name your visitors likewise instead
		/// of just visitor.
		/// </summary>
		/// <typeparam name="TReturn"></typeparam>
		/// <typeparam name="TArgument"></typeparam>
		public interface IVisitor<out TReturn, in TArgument>
		{
			TReturn WhenX(TArgument argument);
			TReturn WhenY(TArgument argument);
		}

		public static void ExampleVisitor()
		{
			IVisitor<Unit, Tuple<int, int>> visitor;

			// Can't use Tuple with no types as an empty tuple, it is a static class
			//IVisitor<Unit, Tuple> visitor2;
		}

		public struct Unit
		{
			 
		}
    }
}
