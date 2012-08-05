namespace ConceptLab.PureObjects.Logic
{
	internal class False: Boolean
	{
		#region Singleton
		private static readonly False instance = new False();

		public static Boolean Instance
		{
			get { return instance; }
		}

		private False()
		{
		}
		#endregion

		public override TResult Accept<T, TResult>(IBooleanVisitor<T, TResult> visitor, T value)
		{
			return visitor.VisitFalse(value);
		}
	}
}
