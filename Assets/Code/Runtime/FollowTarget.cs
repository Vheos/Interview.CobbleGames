namespace Vheos.Interview.CobbleGames
{
	using UnityEngine;

	public class FollowTarget : MonoBehaviour
	{
		// Fields
		[field: SerializeField] public Transform Target { get; private set; }
		[field: SerializeField, Range(0f, 10f)] public float MaxDistance { get; private set; }
		[field: SerializeField, Range(0f, 10f)] public float MinDistance { get; private set; }
		[field: SerializeField, Range(0f, 10f)] public float Speed { get; private set; }

		// Methods
		private void TryFollow()
		{
			if (Target == null || Target == transform)
				return;

			Vector3 offset = Target.position - transform.position;
			float distance = offset.magnitude;
			if (distance >= MinDistance && distance <= MaxDistance)
				return;

			Vector3 direction = offset.normalized;
			Vector3 step = Time.deltaTime * Speed * direction;
			transform.position += distance > MaxDistance ? step : -step;
		}

		// Unity
		private void Update()
			=> TryFollow();
	}
}