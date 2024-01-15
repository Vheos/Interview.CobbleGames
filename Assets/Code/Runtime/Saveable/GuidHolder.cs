namespace Vheos.Interview.CobbleGames
{
	using UnityEngine;

	public class GuidHolder : MonoBehaviour, IGuid<string>
	{
		// Fields
		[field: SerializeField, ReadOnly] public string Guid { get; private set; }

		// Methods
		[ContextMenu(nameof(GenerateNewGuid))]
		public string GenerateNewGuid()
			=> Guid = System.Guid.NewGuid().ToString();
		[ContextMenu(nameof(ResetGuid))]
		public string ResetGuid()
			=> Guid = string.Empty;

		// Unity
		private void Awake()
		{
			if (string.IsNullOrEmpty(Guid))
				GenerateNewGuid();
		}
	}
}