namespace Vheos.Interview.CobbleGames
{
	using UnityEngine;

	[CreateAssetMenu(fileName = nameof(SaveableCollector), menuName = AssetMenuPaths.Root + nameof(SaveableCollector))]
	public class SaveableCollector : ScriptableCollector<ISaveable>
	{ }
}