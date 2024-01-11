namespace Vheos.Interview.CobbleGames
{
	using System;
	using TMPro;
	using UnityEngine;
	using UnityEngine.UI;

	public class CharacterPanel : MonoBehaviour
	{
		// Dependencies
		[field: SerializeField] public Button Button { get; private set; }
		[field: SerializeField] public Image LeaderImage { get; private set; }
		[field: SerializeField] public TextMeshProUGUI MoveSpeedText { get; private set; }
		[field: SerializeField] public TextMeshProUGUI TurnSpeedText { get; private set; }
		[field: SerializeField] public TextMeshProUGUI HealthText { get; private set; }
		[field: SerializeField] public CharacterEvent OnClicked { get; private set; }
		private Character character;

		// Fields
		[field: SerializeField, Range(0f, 1f)] public float BackgroundOpacity { get; private set; }

		// Methods
		public Character Character
		{
			get => character;
			set
			{
				if (value == character)
					return;

				character = value;
				Button.image.color = character.Attributes.Color.NewA(BackgroundOpacity);
				LeaderImage.color = character.Attributes.Color;
				MoveSpeedText.text = character.Attributes.MoveSpeed.ToString("F1");
				TurnSpeedText.text = character.Attributes.TurnSpeed.ToString("F1");
				HealthText.text = character.Attributes.Health.ToString();
			}
		}
		private void InvokeOnPanelClicked()
			=> OnClicked.Invoke(character);

		// Unity
		private void OnEnable()
			=> Button.onClick.AddListener(InvokeOnPanelClicked);
		private void OnDisable()
			=> Button.onClick.RemoveListener(InvokeOnPanelClicked);
	}
}