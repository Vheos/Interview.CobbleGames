namespace Vheos.Interview.CobbleGames
{
	using System;

	[Serializable]
	public struct CharacterDto
	{
		// Fields
		public TransformDto LocalTransform;
		public float MoveSpeed;
		public float TurnSpeed;
		public int Health;
		public ColorDto Color;

		// Constructors
		public CharacterDto(Character character)
		{
			LocalTransform = new(character.transform);
			MoveSpeed = character.Attributes.MoveSpeed;
			TurnSpeed = character.Attributes.TurnSpeed;
			Health = character.Attributes.Health;
			Color = new(character.Attributes.Color);
		}
	}
}