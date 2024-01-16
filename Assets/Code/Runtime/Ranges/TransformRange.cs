namespace Vheos.Interview.CobbleGames
{
	using UnityEngine;

	[CreateAssetMenu(fileName = nameof(TransformRange), menuName = AssetMenuPaths.Ranges + nameof(TransformRange))]
	public class TransformRange : ScriptableRange<TransformDto>
	{
		public override TransformDto Random
			=> new()
			{
				Position = RandomVector(Min.Position, Max.Position),
				EulerAngles = RandomVector(Min.EulerAngles, Max.EulerAngles),
				Scale = RandomVector(Min.Scale, Max.Scale),
			};
		private Vector3Dto RandomVector(Vector3Dto from, Vector3Dto to)
			=> new()
			{
				X = UnityEngine.Random.Range(from.X, to.X),
				Y = UnityEngine.Random.Range(from.Y, to.Y),
				Z = UnityEngine.Random.Range(from.Z, to.Z),
			};
	}
}