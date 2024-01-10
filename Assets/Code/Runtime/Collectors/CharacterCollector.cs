namespace Vheos.Interview.CobbleGames
{
	using UnityEngine;

	[CreateAssetMenu(fileName = nameof(CharacterCollector), menuName = Const.AssetMenuPath + nameof(CharacterCollector))]
	public class CharacterCollector : ScriptableCollector<Character>
	{ }
}