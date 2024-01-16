namespace Vheos.Interview.CobbleGames
{
	using Newtonsoft.Json;
	using System;
	using UnityEngine;

	[Serializable]
	public struct ColorDto
	{
		// Fields
		public float R, G, B, A;

		// Constructors
		public ColorDto(Color color)
		{
			R = color.r;
			G = color.g;
			B = color.b;
			A = color.a;
		}

		// Methods
		[JsonIgnore]
		public readonly Color UnityColor
			=> new(R, G, B, A);
	}
}