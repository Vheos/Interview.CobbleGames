namespace Vheos.Interview.CobbleGames
{
	using UnityEngine;

	public class LookInMoveDirection : MonoBehaviour
	{
		// Fields
		[field: SerializeField, Range(0f, 10f)] public float Speed { get; set; }
		private Vector3 previousPosition;

		// Methods
		private void TryLook()
		{
			if (transform.position == previousPosition)
				return;

			Vector3 direction = (transform.position - previousPosition).normalized;
			transform.forward = Vector3.Lerp(transform.forward, direction, Time.deltaTime * Speed);
			previousPosition = transform.position;
		}

		// Unity
		private void Start()
			=> previousPosition = transform.position;
		private void Update()
			=> TryLook();
	}
}