namespace Vheos.Interview.CobbleGames
{
	public struct CharacterDto
	{
		// Fields
		public Vector3Dto Position;
		public float MoveSpeed;
		public float TurnSpeed;
		public int Health;
		public ColorDto Color;

		// Constructors
		public CharacterDto(Character character)
		{
			Position = new(character.transform.position);
			MoveSpeed = character.Attributes.MoveSpeed;
			TurnSpeed = character.Attributes.TurnSpeed;
			Health = character.Attributes.Health;
			Color = new(character.Attributes.Color);
		}
	}
}