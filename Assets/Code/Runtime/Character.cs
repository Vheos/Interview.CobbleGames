namespace Vheos.Interview.CobbleGames
{
	using UnityEngine;

	public class Character : MonoBehaviour
	{
		// Dependencies
		[field: SerializeField] public CharacterCollector Collector { get; private set; }

		// Unity
		private void Awake() 
			=> Collector.Register(this);
		private void OnDestroy() 
			=> Collector.Unregister(this);
	}
}