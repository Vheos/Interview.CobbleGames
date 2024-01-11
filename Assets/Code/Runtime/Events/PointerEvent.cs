namespace Vheos.Interview.CobbleGames
{
	using UnityEngine;

	[CreateAssetMenu(fileName = nameof(PointerEvent), menuName = AssetMenuPaths.Events + nameof(PointerEvent))]
	public class PointerEvent : ScriptableEvent<Pointer>
	{ }
}