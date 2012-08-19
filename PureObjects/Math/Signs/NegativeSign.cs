using System;
using ConceptLab.PureObjects.Logic;

namespace ConceptLab.PureObjects.Math.Signs
{
	internal class NegativeSign : Sign
	{
		public override Object Accept(ISignVisitor v, Object param)
		{
			return v.WhenNegative(param);
		}

		public override Sign Negate()
		{
			return Positive;
		}

		public override Bool EqualTo(Sign value)
		{
			return value.IsNegative;
		}

		public override Bool IsOppositeOf(Sign value)
		{
			return value.IsPositive;
		}

		public override Bool IsPositive
		{
			get { return Bool.False; }
		}
		public override Bool IsZero
		{
			get { return Bool.False; }
		}
		public override Bool IsNegative
		{
			get { return Bool.True; }
		}

		public override string ToString()
		{
			return "-";
		}
	}
}
