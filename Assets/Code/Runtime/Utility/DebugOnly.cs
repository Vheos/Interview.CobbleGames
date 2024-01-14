namespace Vheos.Interview.CobbleGames
{
	using UnityEngine;

	public class DebugOnly : MonoBehaviour
	{
		// Fields
		[SerializeField] private Action action;
		[SerializeField] private ActionTiming timing;

		// Methods
		private void PerformAction()
		{
			switch (action)
			{
				case Action.DestroyImmediate:
					DestroyImmediate(gameObject);
					break;
				case Action.Destroy:
					Destroy(gameObject);
					break;
				case Action.InactivateGameObject:
					gameObject.SetActive(false);
					break;
				case Action.DisableMonoBehaviours:
					GetComponents<MonoBehaviour>().DoForEach(mb => mb.enabled = false);
					break;
			}
		}

		// Unity
#if !DEBUG
		private void Awake()
		{
			if (timing == ActionTiming.Awake)
				PerformAction();
		}
		private void OnEnable()
		{
			if (timing == ActionTiming.OnEnable)
				PerformAction();
		}
		private void Start()
		{
			if (timing == ActionTiming.Start)
				PerformAction();
		}
#endif

		// Definitions
		private enum Action
		{
			DestroyImmediate,
			Destroy,
			InactivateGameObject,
			DisableMonoBehaviours,
		}
		private enum ActionTiming
		{
			Awake,
			OnEnable,
			Start,
		}
	}
}