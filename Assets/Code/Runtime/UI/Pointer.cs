namespace Vheos.Interview.CobbleGames
{
	using UnityEngine;
	using UnityEngine.InputSystem;

	public class Pointer : MonoBehaviour
	{
		// Dependencies
		[field: SerializeField] public InputActionReference ClickAction { get; private set; }
		[field: SerializeField] public InputActionReference PointAction { get; private set; }
		[field: SerializeField] public PointerEvent OnPointerClicked { get; private set; }

		// Methods
		public bool TryGetWalkablePoint(Camera camera, out Vector3 point)
		{
			Ray ray = camera.ScreenPointToRay(transform.position);
			float distance = float.PositiveInfinity;
			int layerMask = Layer.Walkable.GetMask();
			if (Physics.Raycast(ray, out var hit, distance, layerMask, QueryTriggerInteraction.Collide))
			{
				point = hit.point;
				return true;
			}

			point = default;
			return false;
		}
		private void Point(InputAction.CallbackContext context)
			=> transform.position = context.ReadValue<Vector2>();
		private void Click(InputAction.CallbackContext context)
		{
			if (context.ReadValueAsButton())
				OnPointerClicked.Invoke(this);
		}

		// Unity
		private void OnEnable()
		{
			PointAction.action.performed += Point;
			ClickAction.action.performed += Click;
		}

		private void OnDisable()
		{
			PointAction.action.performed -= Point;
			ClickAction.action.performed -= Click;
		}
	}
}