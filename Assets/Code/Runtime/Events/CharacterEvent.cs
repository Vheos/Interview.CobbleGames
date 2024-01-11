namespace Vheos.Interview.CobbleGames
{
	using UnityEngine;

	[CreateAssetMenu(fileName = nameof(CharacterEvent), menuName = AssetMenuPaths.Events + nameof(CharacterEvent))]
	public class CharacterEvent : ScriptableEvent<Character>
	{ }
}