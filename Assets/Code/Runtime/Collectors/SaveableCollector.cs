namespace Vheos.Interview.CobbleGames
{
	using UnityEngine;

	[CreateAssetMenu(fileName = nameof(SaveableCollector), menuName = AssetMenuPaths.Collectors + nameof(SaveableCollector))]
	public class SaveableCollector : ScriptableCollector<ISaveable>
	{ }
}