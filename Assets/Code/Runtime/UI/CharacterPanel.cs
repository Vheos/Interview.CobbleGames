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

		// Fields
		[field: SerializeField, Range(0f, 1f)] public float BackgroundOpacity { get; private set; }
		private Character character;

		// Events
		[field: SerializeField] public CharacterEvent OnClicked { get; private set; }

		// Methods
		public Character Character
		{
			get => character;
			set
			{
				if (value == character && value)
					return;

				if (character != null)
					character.OnAttributesChanged -= ApplyCharacterAttributes;

				character = value;
				ApplyCharacterAttributes(character.Attributes);

				if (character != null)
					character.OnAttributesChanged += ApplyCharacterAttributes;
			}
		}
		private void ApplyCharacterAttributes(CharacterAttributes attributes)
		{
			Button.image.color = attributes.Color.NewA(BackgroundOpacity);
			LeaderImage.color = attributes.Color;
			MoveSpeedText.text = attributes.MoveSpeed.ToString("F1");
			TurnSpeedText.text = attributes.TurnSpeed.ToString("F1");
			HealthText.text = attributes.Health.ToString();
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