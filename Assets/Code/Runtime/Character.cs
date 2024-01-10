namespace Vheos.Interview.CobbleGames
{
	using UnityEngine;

	public class Character : MonoBehaviour
	{
		// Dependencies
		[field: SerializeField] public CharacterCollector Collector { get; private set; }
		[field: SerializeField] public CharacterAttributesRange AttributesRange { get; private set; }

		// Fields
		public CharacterAttributes Attributes { get; private set; }

		// Unity
		private void Awake()
		{
			Attributes = AttributesRange.Random;
			Collector.Register(this);
		}

		private void OnDestroy()
			=> Collector.Unregister(this);
	}
}