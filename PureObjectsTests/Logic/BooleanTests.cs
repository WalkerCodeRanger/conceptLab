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
			var result = Bool.True.Accept(new IfVisitor(),6);

			Assert.AreEqual(6*6, result);
		}

		private class IfVisitor: IBoolVisitor<int,int>
		{
			public int VisitTrue(int value)
			{
				return value*value;
			}

			public int VisitFalse(int value)
			{
				Assert.Fail("Should not execute false case");
				return 0;
			}
		}
	}
}
