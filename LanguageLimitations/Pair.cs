
namespace ConceptLab.LanguageLimitations
{
    public class Pair<TFirst, TSecond>
    {
        public TFirst First { get; set; }
        public TSecond Second { get; set; }

        // <summary>
        // This method cannot be implemented on this class.  There are multiple problems:
        //     1. Can't create a constraint on a class level type parameter on the method
        //     2. Not possible to express a type equality constraint
        //         a. no type equality operator
        //         b. not allowed to do a bi-directional inheritance constraint
        // </summary>
        // <typeparam name="Foo"></typeparam>
        //public void Swap<Foo>()
        //    where TFirst == TSecond // equality constraints don't exist
        //    where TFirst : TSecond // These next two will be marked as circular even though they should mean equality when taken together
        //    where TSecond : TFirst
        //{
        //}
    }

    public static class PairExtensions
    {
        /// <summary>
        /// In this simple case, it can be worked around by use of an extension methid.  I first had this problem when
        /// extension method weren't in the language, and more complex examples can't be solved even with extension methods
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pair"></param>
        public static void Swap<T>(this Pair<T,T> pair)
        {
            var temp = pair.First;
            pair.First = pair.Second;
            pair.Second = temp;
        }
    }
}
