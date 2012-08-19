using System;

namespace ConceptLab.LanguageLimitations
{
    /// <summary>
    /// This was some code I was playing around with for mocking
    /// </summary>
    public class Mock<TMocked>
    {
        // An implicit conversion to the mocked type makes sense
        public static implicit operator TMocked(Mock<TMocked> predicate)
        {
            return default(TMocked);
        }

        public void ExpectSomeCall()
        {
        }
    }

    public class MockingTest
    {
        public void UnitTest()
        {
            var mock = new Mock<IDisposable>();
            mock.ExpectSomeCall();

            // We would like this to work, but it doesn't compile because implicit conversion to an interface is not allowed.
            // MethodBeingTested(mock);

            // But this works
            MethodBeingTested((IDisposable)mock);
        }

        public void MethodBeingTested(IDisposable value)
        {
        }
    }
}
