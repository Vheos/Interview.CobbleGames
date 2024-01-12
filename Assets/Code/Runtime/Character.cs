namespace Vheos.Interview.CobbleGames
{
	using UnityEngine;

	public class Character : MonoBehaviour
	{
		// Dependencies
		[field: SerializeField] public CharacterCollector Collector { get; private set; }
		[field: SerializeField] public MoveToPosition Mover { get; private set; }
		[field: SerializeField] public MoveToTransform Follower { get; private set; }
		[field: SerializeField] public LookInMoveDirection Looker { get; private set; }
		[field: SerializeField] public CharacterAttributesRange AttributesRange { get; private set; }
		[field: SerializeField] public Renderer Renderer { get; private set; }
		[field: SerializeField] public SpriteRenderer LeaderIndicator { get; private set; }
		private CharacterAttributes attributes;

		// Methods
		public bool IsLeader
			=> Follower.Target == transform;
		public CharacterAttributes Attributes
		{
			get => attributes;
			private set
			{
				if (value == attributes)
					return;

				attributes = value;
				Mover.Speed = Follower.Speed = attributes.MoveSpeed;
				Looker.Speed = attributes.TurnSpeed;
				Renderer.material.color = attributes.Color;
				LeaderIndicator.color = attributes.Color;
			}
		}
		public void Follow(Transform target)
		{
			Follower.Target = target;
			Follower.enabled = true;
			LeaderIndicator.enabled = false;
			Mover.enabled = false;
		}
		public void Lead()
		{
			Follower.enabled = false;
			LeaderIndicator.enabled = true;
		}
		public void MoveTo(Vector3 position)
		{
			Mover.Target = position;
			Mover.enabled = true;
		}

		// Unity
		private void Awake()
		{
			Attributes ??= AttributesRange.Random;
			Collector.Register(this);
		}
		private void OnDestroy()
			=> Collector.Unregister(this);
	}
}