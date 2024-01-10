namespace Vheos.Interview.CobbleGames
{
	using System;
	using System.Collections.Generic;

	public interface ICollector<T>
	{
		// Events
		public event Action<T> OnRegister;
		public event Action<T> OnUnregister;

		// Methods
		public IReadOnlyCollection<T> Items { get; }
		public bool Register(T item);
		public bool Unregister(T item);
	}
}