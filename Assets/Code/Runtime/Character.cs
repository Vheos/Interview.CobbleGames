﻿namespace Vheos.Interview.CobbleGames
{
	using System;
	using System.Threading.Tasks;
	using UnityEngine;

	public class Character : MonoBehaviour
	{
		// Dependencies
		[field: SerializeField] public CharacterCollector Collector { get; private set; }
		[field: SerializeField] public FollowTarget FollowTarget { get; private set; }
		[field: SerializeField] public LookAtTarget LookAtTarget { get; private set; }
		[field: SerializeField] public CharacterAttributesRange AttributesRange { get; private set; }

		// Fields
		public CharacterAttributes Attributes { get; private set; }

		// Methods
		public void SetTarget(Transform target)
			=> FollowTarget.Target = LookAtTarget.Target = target;
		public Task MoveTo(Vector3 point)
			=> throw new NotImplementedException();

		// Unity
		private void Awake()
		{
			Attributes = AttributesRange.Random;
			Collector.Register(this);
		}

		private void OnDestroy()
			=> Collector.Unregister(this);
	}
}