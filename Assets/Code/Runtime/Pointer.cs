namespace Vheos.Interview.CobbleGames
{
	using System;
	using UnityEngine;
	using UnityEngine.InputSystem;

	public class Pointer : MonoBehaviour, IClicker
	{
		// Dependencies
		[field: SerializeField] public Camera Camera { get; private set; }
		[field: SerializeField] public InputActionReference ClickAction { get; private set; }
		[field: SerializeField] public InputActionReference Position { get; private set; }

		// Events
		public event Action OnClick;

		// Methods
		public Vector2 ScreenPosition
			=> Position.action.ReadValue<Vector2>();
		public void Click()
		{
#if DEBUG
			Debug.Log($"Clicked at {ScreenPosition}");
#endif
			Camera.ScreenPointToRay(ScreenPosition);
			OnClick?.Invoke();
		}
		private void Click(InputAction.CallbackContext _)
			=> Click();

		// Unity
		private void OnEnable()
			=> ClickAction.action.performed += Click;
		private void OnDisable()
			=> ClickAction.action.performed -= Click;
	}
}