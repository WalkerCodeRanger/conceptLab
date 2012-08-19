using System;

namespace ConceptLab.PureObjects.Math
{
	public interface ISignVisitor
	{
		Object WhenPositive(Object param);

		Object WhenNegative(Object param);

		Object WhenZero(Object param);
	}
}
