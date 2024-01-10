namespace Vheos.Interview.CobbleGames
{
	using System;

	public interface ISpawner<T>
	{
		// Events
		public event Action<T> OnSpawn;

		// Methods
		public T Spawn();
	}
}