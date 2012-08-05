namespace ConceptLab.PureObjects.Logic
{
	internal class True: Boolean
	{
		#region Singleton
		private static readonly True instance = new True();

		public static Boolean Instance
		{
			get { return instance; }
		}

		private True()
		{
		}
		#endregion

		public override TResult Accept<T, TResult>(IBooleanVisitor<T, TResult> visitor, T value)
		{
			return visitor.VisitTrue(value);
		}
	}
}
