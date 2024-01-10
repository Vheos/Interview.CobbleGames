namespace Vheos.Interview.CobbleGames
{
	using System;
	using System.Collections.Generic;
	using UnityEngine;

	public abstract class ScriptableCollector<T> : ScriptableObject, ICollector<T>
	{
		// Fields
		private readonly HashSet<T> items = new();

		// Events
		public event Action<T> OnRegister;
		public event Action<T> OnUnregister;

		// Methods
		public IReadOnlyCollection<T> Items
			=> items;
		public bool Register(T item)
		{
			if (!items.Add(item))
				return false;

			OnRegister?.Invoke(item);
			return true;
		}
		public bool Unregister(T item)
		{
			if (!items.Remove(item))
				return false;

			OnUnregister?.Invoke(item);
			return true;
		}
	}
}