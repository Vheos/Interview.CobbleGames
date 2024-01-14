namespace Vheos.Interview.CobbleGames
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using UnityEngine;

	public static class Extensions
	{
		public static int GetMask(this Layer @this)
			=> LayerMask.GetMask(@this.ToString());
		public static Color NewA(this Color @this, float a)
			=> new(@this.r, @this.g, @this.b, a);
		public static void DoForEach<T>(this IEnumerable<T> @this, Action<T> action)
		{
			foreach (var @item in @this)
				action(@item);
		}
		public static bool TryGetFirst<T>(this IEnumerable<T> @this, out T element, Func<T, bool> predicate)
		{
			element = @this.FirstOrDefault(predicate);
			return element != null;
		}

		public static Task WhenAll(this IEnumerable<Task> @this)
			=> Task.WhenAll(@this);
	}
}