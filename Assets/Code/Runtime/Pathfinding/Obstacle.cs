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

		// Methods
		public void SaveData(SaveableData data)
			=> data.ObstacleTransformsByGuid[GuidHolder.Guid] = new(transform);
		public void LoadData(SaveableData data)
		{
			if (!data.ObstacleTransformsByGuid.TryGetValue(GuidHolder.Guid, out var dto))
				return;

			dto.ApplyTo(transform);
		}

		// Unity
		private void Awake()
		{
			TransformRange.Random.ApplyTo(transform);
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