namespace Vheos.Interview.CobbleGames
{
	using UnityEngine;

	[CreateAssetMenu(fileName = nameof(CharacterAttributesRange), menuName = AssetMenuPaths.Root + nameof(CharacterAttributesRange))]
	public class CharacterAttributesRange : ScriptableRange<CharacterAttributes>
	{
		public override CharacterAttributes Random
		{
			get
			{
				Color.RGBToHSV(Min.Color, out var minH, out var minS, out var minV);
				Color.RGBToHSV(Max.Color, out var maxH, out var maxS, out var maxV);
				Color randomHSV = UnityEngine.Random.ColorHSV(minH, maxH, minS, maxS, minV, maxV, Min.Color.a, Max.Color.a);

				return new()
				{
					MoveSpeed = UnityEngine.Random.Range(Min.MoveSpeed, Max.MoveSpeed),
					TurnSpeed = UnityEngine.Random.Range(Min.TurnSpeed, Max.TurnSpeed),
					Health = UnityEngine.Random.Range(Min.Health, Max.Health),
					Color = randomHSV,
				};
			}
		}
	}
}