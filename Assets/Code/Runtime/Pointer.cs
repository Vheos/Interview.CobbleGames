﻿namespace Vheos.Interview.CobbleGames
{
	using System;
	using UnityEngine;
	using UnityEngine.InputSystem;

	public class Pointer : MonoBehaviour
	{
		// Dependencies
		[field: SerializeField] public InputActionReference ClickAction { get; private set; }
		[field: SerializeField] public InputActionReference Position { get; private set; }
		[field: SerializeField] public PointerEvent OnPointerClicked { get; private set; }

		// Methods
		public Vector2 ScreenPosition
			=> Position.action.ReadValue<Vector2>();
		public bool TryGetWalkablePoint(Camera camera, out Vector3 point)
		{
			Ray ray = camera.ScreenPointToRay(ScreenPosition);
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
		private void Click(InputAction.CallbackContext context)
		{
			if (context.ReadValueAsButton())
				OnPointerClicked.Invoke(this);
		}

		// Unity
		private void OnEnable()
			=> ClickAction.action.performed += Click;
		private void OnDisable()
			=> ClickAction.action.performed -= Click;
	}
}