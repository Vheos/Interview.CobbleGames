namespace Vheos.Interview.CobbleGames
{
	using UnityEngine;

	[CreateAssetMenu(fileName = nameof(PointerEvent), menuName = Const.AssetMenuPath + nameof(PointerEvent))]
	public class PointerEvent : ScriptableEvent<Pointer>
	{ }
}