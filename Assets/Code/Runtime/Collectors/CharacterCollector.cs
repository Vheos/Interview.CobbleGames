namespace Vheos.Interview.CobbleGames
{
	using UnityEngine;

	[CreateAssetMenu(fileName = nameof(CharacterCollector), menuName = AssetMenuPaths.Collectors + nameof(CharacterCollector))]
	public class CharacterCollector : ScriptableCollector<Character>
	{ }
}