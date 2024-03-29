namespace GoldParser
{
	/// <summary>
	/// LR parser action type.
	/// </summary>
	public enum LRAction : short
	{
		/// <summary>
		/// No action. Not used.
		/// </summary>
		None = 0,

		/// <summary>
		/// Shift a symbol and go to a state
		/// </summary>
		Shift = 1,

		/// <summary>
		/// Reduce by a specified rule
		/// </summary>
		Reduce = 2,

		/// <summary>
		/// Goto to a state on reduction
		/// </summary>
		Goto = 3,

		/// <summary>
		/// Input successfully parsed
		/// </summary>
		Accept = 4,

		/// <summary>
		/// Error
		/// </summary>
		Error = 5
	}
}
