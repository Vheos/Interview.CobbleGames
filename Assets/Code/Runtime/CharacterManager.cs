namespace Vheos.Interview.CobbleGames
{
	using System;
	using System.Linq;
	using UnityEngine;

	public class CharacterManager : MonoBehaviour, ISpawner<Character>
	{
		// Dependencies
		[field: SerializeField] public Camera Camera { get; private set; }
		[field: SerializeField] public CharacterCollector Collector { get; private set; }
		[field: SerializeField] public Character Prefab { get; private set; }

		// Fields
		private Character leader;

		// Events
		[field: SerializeField] public PointerEvent OnPointerClicked { get; private set; }
		[field: SerializeField] public CharacterEvent OnCharacterPanelClicked { get; private set; }
		[field: SerializeField] public CharacterEvent OnLeaderChanged { get; private set; }
		public event Action<Character> OnSpawn;

		// Methods
		public Character Leader
		{
			get => leader;
			set
			{
				if (value == leader)
					return;

				leader = value;

				Collector.Items.DoForEach(SetAsFollower);
				leader.Lead();

				OnLeaderChanged.Invoke(leader);
			}
		}
		public Character Spawn()
		{
			Character newCharacter = Instantiate(Prefab);
			OnSpawn?.Invoke(newCharacter);
			return newCharacter;
		}
		private void SetAsLeaderOrFollower(Character character)
		{
			if (leader == null)
				SetAsLeader(character);
			else
				SetAsFollower(character);
		}
		private void SetAsLeader(Character character)
			=> Leader = character;
		private void SetAsFollower(Character character)
			=> character.Follow(leader.transform);
		private void TrySetNewLeader(Character character)
		{
			if (character != leader || Collector.Items.Count == 0)
				return;

			Leader = Collector.Items.First();
		}
		private void MoveLeader(Pointer pointer)
		{
			if (leader == null || !pointer.TryGetWalkablePoint(Camera, out var point))
				return;

			leader.MoveTo(point);
		}

		// Unity
		private void Awake()
			=> Collector.Items.DoForEach(SetAsLeaderOrFollower);
		private void OnEnable()
		{
			Collector.OnRegister += SetAsLeaderOrFollower;
			Collector.OnUnregister += TrySetNewLeader;
			OnCharacterPanelClicked.Subscribe(SetAsLeader);
			OnPointerClicked.Subscribe(MoveLeader);
		}
		private void OnDisable()
		{
			Collector.OnRegister -= SetAsLeaderOrFollower;
			Collector.OnUnregister -= TrySetNewLeader;
			OnCharacterPanelClicked.Unsubscribe(SetAsLeader);
			OnPointerClicked.Unsubscribe(MoveLeader);
		}
	}
}