using System;
using ConceptLab.PureObjects.Logic;

namespace ConceptLab.PureObjects.Math.Signs
{
	internal class PositiveSign : Sign
	{
		public override Object Accept(ISignVisitor v, Object param)
		{
			return v.WhenPositive(param);
		}

		public override Sign Negate()
		{
			return Negative;
		}

		public override Bool EqualTo(Sign value)
		{
			return value.IsPositive;
		}

		public override Bool IsOppositeOf(Sign value)
		{
			return value.IsNegative;
		}

		public override Bool IsPositive
		{
			get { return Bool.True; }
		}
		public override Bool IsZero
		{
			get { return Bool.False; }
		}
		public override Bool IsNegative
		{
			get { return Bool.False; }
		}

		public override string ToString()
		{
			return "+";
		}
	}
}
