namespace Vheos.Interview.CobbleGames
{
	using System.Collections.Generic;
	using UnityEngine;

	public class Obstacle : MonoBehaviour, ISaveable
	{
		// Dependencies
		[field: SerializeField] public GuidHolder GuidHolder { get; private set; }
		[field: SerializeField] public SaveableCollector SaveableCollector { get; private set; }
		[field: SerializeField] public Collider Collider { get; private set; }
		[field: SerializeField] public TransformRange TransformRange { get; private set; }
		[field: SerializeField] public Event OnTransformChanged { get; private set; }


		// Methods
		public void SaveData(SaveableData data)
			=> data.ObstacleTransformsByGuid[GuidHolder.Guid] = new(transform);
		public void LoadData(SaveableData data)
		{
			if (!data.ObstacleTransformsByGuid.TryGetValue(GuidHolder.Guid, out var dto))
				return;

			UpdateTransform(dto);
		}
		public void UpdateTransform(TransformDto dto)
		{
			dto.ApplyTo(transform);
			OnTransformChanged.Invoke();
		}

		// Unity
		private void Awake()
		{
			UpdateTransform(TransformRange.Random);
			SaveableCollector.Register(this);
		}
		private void OnDestroy()
			=> SaveableCollector.Unregister(this);
	}



	#region SaveableData
	public partial class SaveableData
	{
		// Fields
		public Dictionary<string, TransformDto> ObstacleTransformsByGuid = new();
	}
	#endregion
}