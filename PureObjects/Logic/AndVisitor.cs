using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConceptLab.PureObjects.Logic
{
	internal class AndVisitor: IBooleanVisitor<Boolean, Boolean>
	{
		#region Singleton
		private static readonly AndVisitor instance = new AndVisitor();

		public static AndVisitor Instance
		{
			get { return instance; }
		}

		private AndVisitor()
		{
		}
		#endregion

		public Boolean VisitTrue(Boolean value)
		{
			return value;
		}

		public Boolean VisitFalse(Boolean value)
		{
			return Boolean.False;
		}
	}
}
