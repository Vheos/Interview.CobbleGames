namespace Vheos.Interview.CobbleGames
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using UnityEngine;

	public static class Extensions
	{
		// Various
		public static int GetMask(this Layer @this)
			=> LayerMask.GetMask(@this.ToString());
		public static Color NewA(this Color @this, float a)
			=> new(@this.r, @this.g, @this.b, a);

		// Vector
		public static Vector3Int Round(this Vector3 @this, Func<float, int> roundingFunc)
			=> new(roundingFunc(@this.x), roundingFunc(@this.y), roundingFunc(@this.z));
		public static Vector3Int Round(this Vector3 @this)
			=> @this.Round(Mathf.RoundToInt);
		public static Vector3Int RoundDown(this Vector3 @this)
			=> @this.Round(Mathf.FloorToInt);
		public static Vector3Int RoundUp(this Vector3 @this)
			=> @this.Round(Mathf.CeilToInt);
		public static bool IsBetween(this Vector3Int @this, Vector3Int min, Vector3Int max)
			=> @this.x >= min.x && @this.x <= max.x
			&& @this.y >= min.y && @this.y <= max.y
			&& @this.z >= min.z && @this.z <= max.z;

		// Collections
		public static void DoForEach<T>(this IEnumerable<T> @this, Action<T> action)
		{
			foreach (var @item in @this)
				action(@item);
		}
		public static Task WhenAll(this IEnumerable<Task> @this)
			=> Task.WhenAll(@this);
		public static TValue GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> @this, TKey key, Func<TValue> addFunc)
			=> @this.TryGetValue(key, out var value)
			? value
			: @this[key] = addFunc();
		public static void InsertDescending<TElement, TValue>(this IList<TElement> @this, TElement element, Func<TElement, TValue> comparer)
			where TValue : IComparable<TValue>
		{
			TValue value = comparer(element);
			int i = @this.Count;
			while (i > 0)
				if (value.CompareTo(comparer(@this[--i])) < 0)
					break;

			@this.Insert(i, element);
		}
	}
}