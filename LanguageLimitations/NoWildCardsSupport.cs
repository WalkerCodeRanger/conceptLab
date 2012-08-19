
namespace ConceptLab.LanguageLimitations
{
    /// <summary>
	/// C# lacks a feature of Java generics called wildcards.  It achieves some of the same things with type constraints
    /// however wildcards let you do a limited form of existential types that can be helpful sometimes.
    /// </summary>
    public class NoWildCardsSupport
    {
        // Here we have a pair that we only care about the first part of, we know there must be some second but it doesn't matter what it is to us.
        // we can't use Pair<int, object> becuase then a Pair<int, string> would not be assignable into it.  We can't use a type parameter here
		// becuase then it would have to be a parameter of our class, but it isn't relevant to this class, indeed it could be set to different pair
        // types over the lifetime of this object so no single type would be correct.
        // The java syntax is shown below
        //private Pair<int, ?> p;

        //public NoWildCardsSupport(Pair<int, ?> p)
        //{
        //  this.p = p;
        //}
    }
}
