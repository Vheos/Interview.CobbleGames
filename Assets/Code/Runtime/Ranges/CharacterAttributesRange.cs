namespace Vheos.Interview.CobbleGames
{
	using UnityEngine;

	[CreateAssetMenu(fileName = nameof(CharacterAttributesRange), menuName = Const.AssetMenuPath + nameof(CharacterAttributesRange))]
	public class CharacterAttributesRange : ScriptableRange<CharacterAttributes>
	{
		public override CharacterAttributes Random
			=> new()
			{
				MoveSpeed = UnityEngine.Random.Range(Min.MoveSpeed, Max.MoveSpeed),
				TurnSpeed = UnityEngine.Random.Range(Min.TurnSpeed, Max.TurnSpeed),
				Health = UnityEngine.Random.Range(Min.Health, Max.Health),
			};
	}
}