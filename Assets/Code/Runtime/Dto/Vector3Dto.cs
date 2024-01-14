namespace Vheos.Interview.CobbleGames
{
	using Newtonsoft.Json;
	using UnityEngine;

	public struct Vector3Dto
	{
		// Fields
		public float X, Y, Z;

		// Methods
		[JsonIgnore]
		public readonly Vector3 UnityVector3
			=> new(X, Y, Z);

		// Constructors
		public Vector3Dto(Vector3 vector3)
		{
			X = vector3.x;
			Y = vector3.y;
			Z = vector3.z;
		}
	}
}