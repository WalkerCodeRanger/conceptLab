using ConceptLab.PureObjects.Logic;
using ConceptLab.PureObjects.Math.Binary;
using ConceptLab.PureObjects.Math.Signs;

namespace ConceptLab.PureObjects.Math
{
	public abstract class Sign
	{
		public static Sign Positive = new PositiveSign();
		public static Sign Zero = new ZeroSign();
		public static Sign Negative = new NegativeSign();


		public static Sign Create(Bool positive)
		{
			return positive.Accept(() => Positive, () => Negative);
		}

		public Sign CheckZero(BinaryNumber number)
		{
			return number.IsZero.Accept(() => Zero, () => this);
		}

		public abstract object Accept(ISignVisitor v, object param);

		public abstract Sign Negate();

		public abstract Bool EqualTo(Sign value);
		public abstract Bool IsOppositeOf(Sign value);

		public abstract Bool IsPositive { get; }
		public abstract Bool IsZero { get; }
		public abstract Bool IsNegative { get; }

		public abstract override string ToString();
	}
}
