namespace Vheos.Interview.CobbleGames
{
	using UnityEngine;

	public class LookAtTarget : MonoBehaviour
	{
		// Fields
		[field: SerializeField] public Transform Target { get; set; }
		[field: SerializeField, Range(0f, 10f)] public float Speed { get; private set; }

		// Methods
		private void TryLookAt()
		{
			if (Target == null || Target == transform)
				return;

			Vector3 direction = (Target.position - transform.position).normalized;
			transform.forward = Vector3.Lerp(transform.forward, direction, Time.deltaTime * Speed);
		}

		// Unity
		private void Update()
			=> TryLookAt();
	}
}