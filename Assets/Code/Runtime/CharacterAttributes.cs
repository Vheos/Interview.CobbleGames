namespace Vheos.Interview.CobbleGames
{
	using System;
	using UnityEngine;

	[Serializable]
	public class CharacterAttributes
	{
		// Fields
		[Range(0.1f, 10f), Tooltip("Units per second")] public float MoveSpeed;
		[Range(0.1f, 10f), Tooltip("Rotations per second")] public float TurnSpeed;
		[Range(1, 100)] public int Health;
		public Color Color;
	}
}