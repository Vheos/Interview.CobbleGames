namespace Vheos.Interview.CobbleGames
{
	using System;
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

		// Fields
		IEnumerator<Vector3> pathEnumerator;

		// Events
		public event Action<CharacterAttributes> OnAttributesChanged;

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

				OnAttributesChanged?.Invoke(attributes);
			}
		}
		public void Follow(Transform target)
		{
			Follower.Target = target;
			Follower.enabled = true;
			LeaderIndicator.enabled = false;
			Mover.enabled = false;
			pathEnumerator = null;
		}
		public void Lead()
		{
			Follower.enabled = false;
			LeaderIndicator.enabled = true;
		}
		public void MoveTo(Vector3 position)
		{
			Debug.Log($"Moving to {position}");
			Mover.Target = position;
			Mover.enabled = true;
		}
		public void MoveAlong(IEnumerable<Vector3> worldPositions)
		{
			pathEnumerator = worldPositions.GetEnumerator();
			TryMoveToNextPosition();
		}

		private void TryMoveToNextPosition()
		{
			if (pathEnumerator != null && pathEnumerator.MoveNext())
				MoveTo(pathEnumerator.Current);
		}
		public void SaveData(SaveableData data)
			=> data.CharactersByGuid[GuidHolder.Guid] = new(this);
		public void LoadData(SaveableData data)
		{
			if (!data.CharactersByGuid.TryGetValue(GuidHolder.Guid, out var dto))
				return;

			Mover.enabled = false;
			dto.LocalTransform.ApplyTo(transform);
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
		private void OnEnable()
			=> Mover.OnTargetReached += TryMoveToNextPosition;
		private void OnDisable()
			=> Mover.OnTargetReached -= TryMoveToNextPosition;
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