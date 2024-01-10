namespace Vheos.Interview.CobbleGames
{
	using UnityEngine;

	public class Character : MonoBehaviour
	{
		// Dependencies
		[field: SerializeField] public CharacterCollector Collector { get; private set; }
		[field: SerializeField] public MoveToPosition Mover { get; private set; }
		[field: SerializeField] public MoveToTransform Follower { get; private set; }
		[field: SerializeField] public CharacterAttributesRange AttributesRange { get; private set; }

		// Fields
		public CharacterAttributes Attributes { get; private set; }

		// Methods
		public void Follow(Transform target)
		{
			Follower.Target = target;
			Follower.enabled = true;
			Mover.enabled = false;
		}
		public void MoveTo(Vector3 position)
		{
			Mover.Target = position;
			Mover.enabled = true;
			Follower.enabled = false;
		}

		// Unity
		private void Awake()
		{
			Attributes = AttributesRange.Random;
			Mover.Speed = Follower.Speed = Attributes.MoveSpeed;
			Collector.Register(this);
		}
		private void OnDestroy()
			=> Collector.Unregister(this);
	}
}