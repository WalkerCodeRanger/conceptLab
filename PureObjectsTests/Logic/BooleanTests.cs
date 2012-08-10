using ConceptLab.PureObjects.Logic;
using NUnit.Framework;

namespace ConceptLab.PureObjectsTests.Logic
{
	[TestFixture]
	public class BooleanTests
	{
		[Test]
		public void CanUseVisitorInPlaceOfIf()
		{
			var result = Bool.True.Accept(new IfFunc(), 6);

			Assert.AreEqual(6*6, result);
		}

		private class IfFunc: IBoolFunc<int, int>
		{
			public int WhenTrue(int value)
			{
				return value*value;
			}

			public int WhenFalse(int value)
			{
				Assert.Fail("Should not execute false case");
				return 0;
			}
		}
	}
}
