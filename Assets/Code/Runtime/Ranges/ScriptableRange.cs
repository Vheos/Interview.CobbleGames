namespace Vheos.Interview.CobbleGames
{
	using UnityEngine;

	public abstract class ScriptableRange<T> : ScriptableEvent
	{
		// Fields
		[field: SerializeField] public T Min { get; private set; }
		[field: SerializeField] public T Max { get; private set; }

		// Methods
		public abstract T Random { get; }
	}
}