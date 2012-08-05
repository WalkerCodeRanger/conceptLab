using ConceptLab.DataStructures.LinearRecursiveStructure;
using NUnit.Framework;

namespace ConceptLab.DataStructuresTests.LinearRecursiveStrucuture
{
	[TestFixture]
	public class ListTests
	{
		[Test]
		public void TestRemovalCausesSharedState()
		{
			var list = new List<string>();
			list.InsertAsFirst("apple");
			list.InsertAsFirst("banana");
			var rest = list.Rest;
			list.RemoveFirst();
			Assert.AreNotEqual(list, rest, "Different lists");

			rest.First = "monkey";
			Assert.AreEqual("monkey", list.First);
		}

		/// <summary>
		/// There is something wrong about this behavior. It doesn't fit
		/// with the fact that removal causes shared state.
		/// </summary>
		[Test]
		public void TestRemovalDoesntShareInsert()
		{
			var list = new List<string>();
			list.InsertAsFirst("apple");
			list.InsertAsFirst("banana");
			var rest = list.Rest;
			list.RemoveFirst();

			rest.InsertAsFirst("dog");
			Assert.AreEqual("apple", list.First);
		}
	}
}
