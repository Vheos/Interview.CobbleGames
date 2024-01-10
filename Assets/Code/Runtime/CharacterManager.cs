namespace Vheos.Interview.CobbleGames
{
	using System;
	using UnityEngine;

	public class CharacterManager : MonoBehaviour, ISpawner<Character>
	{
		// Dependencies
		[field: SerializeField] public Camera Camera { get; private set; }
		[field: SerializeField] public CharacterCollector Collector { get; private set; }
		[field: SerializeField] public Character Prefab { get; private set; }
		[field: SerializeField] public PointerEvent OnPointerClicked { get; private set; }

		// Events
		public event Action<Character> OnSpawn;
		public event Action<Character> OnChangeLeader;

		// Fields
		[field: SerializeField] public Character StartingLeader { get; private set; }
		private Character leader;

		// Methods
		public Character Leader
		{
			get => leader;
			set
			{
				if (value == leader)
					return;

				leader = value;

				foreach (var character in Collector.Items)
					SetLeader(character);

				OnChangeLeader?.Invoke(leader);
			}
		}
		public Character Spawn()
		{
			Character newCharacter = Instantiate(Prefab);
			OnSpawn?.Invoke(newCharacter);
			return newCharacter;
		}
		private void SetLeader(Character character)
			=> character.SetTarget(leader.transform);
		private void MoveLeader(Pointer pointer)
		{
			if (leader == null || !pointer.TryGetWalkablePoint(Camera, out var point))
				return;

			// TODO
			leader.MoveTo(point);
			Debug.Log($"Move {(leader != null ? leader.name : "null")} to {point}");
		}

		// Unity
		private void OnEnable()
		{
			Collector.OnRegister += SetLeader;
			OnPointerClicked.Subscribe(MoveLeader);
		}
		private void Start()
			=> Leader = StartingLeader;
#if DEBUG
		private void Update()
		{
			if (Keyboard.current.rKey.wasPressedThisFrame)
			{
				int index = UnityEngine.Random.Range(0, Collector.Items.Count);
				Leader = Collector.Items.ElementAt(index);
			}
		}
#endif
		private void OnDisable()
		{
			Collector.OnRegister -= SetLeader;
			OnPointerClicked.Unsubscribe(MoveLeader);
		}
	}
}