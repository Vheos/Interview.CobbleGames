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
		private readonly HashSet<CharacterPanel> panels = new();

		// Events
		public event Action<CharacterPanel> OnSpawn;

		// Methods
		public CharacterPanel Spawn()
		{
			CharacterPanel newPanel = Instantiate(Prefab);
			panels.Add(newPanel);
			OnSpawn?.Invoke(newPanel);
			return newPanel;
		}
		private void SpawnPanelForCharacter(Character character)
		{
			CharacterPanel newPanel = Spawn();
			newPanel.Character = character;
			newPanel.transform.SetParent(transform, false);
		}
		private void DespawnPanelForCharacter(Character character)
		{
			if (!panels.TryGetFirst(out var panelToDespawn, panel => panel.Character == character))
				return;

			panels.Remove(panelToDespawn);
			Destroy(panelToDespawn.gameObject);
		}

		// Unity
		private void Awake()
			=> CharacterCollector.Items.DoForEach(SpawnPanelForCharacter);
		private void OnEnable()
		{
			CharacterCollector.OnRegister += SpawnPanelForCharacter;
			CharacterCollector.OnUnregister += DespawnPanelForCharacter;
		}
		private void OnDisable()
		{
			CharacterCollector.OnRegister -= SpawnPanelForCharacter;
			CharacterCollector.OnUnregister -= DespawnPanelForCharacter;
		}
	}
}