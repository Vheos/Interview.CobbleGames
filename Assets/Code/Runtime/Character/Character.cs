namespace Vheos.Interview.CobbleGames
{
	using System.Collections.Generic;
	using UnityEngine;

	public class Character : MonoBehaviour, ISaveable
	{
		// Dependencies
		[field: SerializeField] public GuidHolder GuidHolder { get; private set; }
		[field: SerializeField] public CharacterCollector CharacterCollector { get; private set; }
		[field: SerializeField] public SaveableCollector SaveableCollector { get; private set; }
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
		public void SaveData(SaveableData data)
			=> data.CharactersByGuid[GuidHolder.Guid] = new(this);

		public void LoadData(SaveableData data)
		{
			if (!data.CharactersByGuid.TryGetValue(GuidHolder.Guid, out var dto))
				return;

			transform.position = dto.Position.UnityVector3;
			Attributes = new()
			{
				MoveSpeed = dto.MoveSpeed,
				TurnSpeed = dto.TurnSpeed,
				Health = dto.Health,
				Color = dto.Color.UnityColor,
			};
		}

		// Unity
		private void Awake()
		{
			Attributes ??= AttributesRange.Random;
			CharacterCollector.Register(this);
			SaveableCollector.Register(this);
		}
		private void OnDestroy()
		{
			CharacterCollector.Unregister(this);
			SaveableCollector.Unregister(this);
		}
	}



	#region SaveableData
	public partial class SaveableData
	{
		// Fields
		public Dictionary<string, CharacterDto> CharactersByGuid = new();

	}
	#endregion
}