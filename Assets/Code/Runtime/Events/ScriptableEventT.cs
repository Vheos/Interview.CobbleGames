namespace Vheos.Interview.CobbleGames
{
	using System;
	using UnityEngine;

	public abstract class ScriptableEvent<T> : ScriptableObject
	{
		// Fields
		private Action<T> action;

		// Methods
		public void Subscribe(Action<T> action)
			=> this.action += action;
		public void Unsubscribe(Action<T> action)
			=> this.action -= action;
		public void Invoke(T value)
			=> action?.Invoke(value);
	}
}