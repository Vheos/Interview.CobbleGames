namespace Vheos.Interview.CobbleGames
{
	using System;
	using System.Collections.Generic;
	using UnityEngine;

	public class CharacterPanelManager : MonoBehaviour, ISpawner<CharacterPanel>
	{
		// Dependencies
		[field: SerializeField] public CharacterCollector CharacterCollector { get; private set; }
		[field: SerializeField] public CharacterPanel Prefab { get; private set; }

		// Fields
		private readonly Dictionary<Character, CharacterPanel> panels = new();

		// Events
		[field: SerializeField] public CharacterEvent OnLeaderChanged { get; private set; }
		public event Action<CharacterPanel> OnSpawn;

		// Methods
		public CharacterPanel Spawn()
		{
			CharacterPanel newPanel = Instantiate(Prefab);
			OnSpawn?.Invoke(newPanel);
			return newPanel;
		}
		private void SpawnPanelForCharacter(Character character)
		{
			CharacterPanel newPanel = Spawn();
			newPanel.Character = character;
			newPanel.transform.SetParent(transform, false);
			newPanel.LeaderImage.enabled = character.IsLeader;
			panels[character] = newPanel;
		}
		private void DespawnPanelForCharacter(Character character)
		{
			if (!panels.TryGetValue(character, out var panelToDespawn))
				return;

			panels.Remove(character);
			Destroy(panelToDespawn.gameObject);
		}
		private void UpdateLeaderIndicators(Character leader)
		{
			foreach (var (character, panel) in panels)
				panel.LeaderImage.enabled = character == leader;
		}

		// Unity
		private void Awake()
			=> CharacterCollector.Items.DoForEach(SpawnPanelForCharacter);
		private void OnEnable()
		{
			CharacterCollector.OnRegister += SpawnPanelForCharacter;
			CharacterCollector.OnUnregister += DespawnPanelForCharacter;
			OnLeaderChanged.Subscribe(UpdateLeaderIndicators);
		}
		private void OnDisable()
		{
			CharacterCollector.OnRegister -= SpawnPanelForCharacter;
			CharacterCollector.OnUnregister -= DespawnPanelForCharacter;
			OnLeaderChanged.Unsubscribe(UpdateLeaderIndicators);
		}
	}
}