namespace Vheos.Interview.CobbleGames
{
	using System;
	using UnityEngine;

	public abstract class StepTowardsTarget<T> : MonoBehaviour
	{
		// Fields
		[field: SerializeField] public T Target { get; set; }
		[field: SerializeField, Range(0f, 10f)] public float Speed { get; set; }
		[field: SerializeField, Range(0f, 10f)] public float MaxDistance { get; private set; }
		[field: SerializeField, Range(0f, 10f)] public float MinDistance { get; private set; }
		[field: SerializeField] public bool Autorestart { get; private set; }

		// Events
		public event Action OnTargetReached;

		// Methods
		public abstract bool IsTargetValid { get; }
		public abstract Vector3 Direction { get; }
		public abstract float Distance { get; }
		private DistanceThreshold Threshold
		{
			get
			{
				float distance = Distance;
				return distance < MinDistance ? DistanceThreshold.TooClose
					: distance > MaxDistance ? DistanceThreshold.TooFar
					: DistanceThreshold.Within;
			}
		}

		private void Step()
		{
			DistanceThreshold threshold = Threshold;
			if (threshold == DistanceThreshold.Within)
				return;

			Vector3 step = Time.deltaTime * Speed * Direction;
			transform.position += threshold == DistanceThreshold.TooFar ? step : -step;

			if (Threshold != DistanceThreshold.Within)
				return;

			OnTargetReached?.Invoke();
			if (!Autorestart)
				enabled = false;
		}

		// Unity
		private void Update()
		{
			if (IsTargetValid)
				Step();
		}

		// Definitions
		private enum DistanceThreshold
		{
			TooFar,
			Within,
			TooClose,
		}
	}
}