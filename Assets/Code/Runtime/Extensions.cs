namespace Vheos.Interview.CobbleGames
{
	using UnityEngine;

	public static class Extensions
	{
		public static int GetMask(this Layer @this)
			=> LayerMask.GetMask(@this.ToString());
	}
}