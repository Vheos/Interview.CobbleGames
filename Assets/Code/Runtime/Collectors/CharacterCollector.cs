namespace Vheos.Interview.CobbleGames
{
	using UnityEngine;

	[CreateAssetMenu(fileName = nameof(CharacterCollector), menuName = AssetMenuPaths.Root + nameof(CharacterCollector))]
	public class CharacterCollector : ScriptableCollector<Character>
	{ }
}