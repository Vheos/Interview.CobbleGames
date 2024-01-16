namespace Vheos.Interview.CobbleGames
{
	using System;
	using UnityEngine;

	[Serializable]
	public struct TransformDto
	{
		// Fields
		public Vector3Dto Position, EulerAngles, Scale;

		// Constructors
		public TransformDto(Transform transform)
		{
			Position = new(transform.localPosition);
			EulerAngles = new(transform.localEulerAngles);
			Scale = new(transform.localScale);
		}

		// Methods
		public readonly void ApplyTo(Transform transform)
		{
			transform.localPosition = Position.UnityVector3;
			transform.localEulerAngles = EulerAngles.UnityVector3;
			transform.localScale = Scale.UnityVector3;
		}
	}
}