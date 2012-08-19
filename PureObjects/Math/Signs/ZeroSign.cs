using System;
using ConceptLab.PureObjects.Logic;

namespace ConceptLab.PureObjects.Math.Signs
{
	internal class ZeroSign : Sign
	{
		public override Object Accept(ISignVisitor v, Object param)
		{
			return v.WhenZero(param);
		}

		public override Sign Negate()
		{
			return this;
		}

		public override Bool EqualTo(Sign value)
		{
			return value.IsZero;
		}

		public override Bool IsOppositeOf(Sign value)
		{
			return Bool.False;
		}

		public override Bool IsPositive
		{
			get { return Bool.False; }
		}
		public override Bool IsZero
		{
			get { return Bool.True; }
		}
		public override Bool IsNegative
		{
			get { return Bool.False; }
		}

		public override string ToString()
		{
			return "";
		}
	}
}
