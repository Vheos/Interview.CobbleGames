namespace Vheos.Interview.CobbleGames
{
	using System;
	using UnityEngine;

	public abstract class ScriptableEvent : ScriptableObject
	{
		// Fields
		private Action action;

		// Methods
		public void Subscribe(Action action)
			=> this.action += action;
		public void Unsubscribe(Action action)
			=> this.action -= action;
		public void Invoke()
			=> action?.Invoke();
	}
}