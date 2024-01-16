#if UNITY_EDITOR
namespace Vheos.Interview.CobbleGames
{
	using UnityEditor;
	using UnityEngine;

	public static class Pathfinder_GizmoDrawer
	{
		private const float SphereRadius = 0.25f;
		private static readonly GUIStyle TextStyle = new()
		{
			normal = new() { textColor = Color.black },
		};

		[DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
		private static void Selected(Pathfinder pathfinder, GizmoType type)
		{
			if (pathfinder.Grid == null)
				return;

			foreach (var node in pathfinder.Grid.Nodes)
			{
				Gizmos.color = pathfinder.IsWalkable(node) ? Color.green : Color.red;
				Vector3 worldPosition = pathfinder.NodeToWorldPosition(node);
				float radius = pathfinder.WalkerRadius * SphereRadius;
				Gizmos.DrawSphere(worldPosition, radius);

				//Handles.color = Color.black;
				//Handles.Label(worldPosition + Vector3.up, node.Id.ToString(), TextStyle);
			}
		}
	}
}
#endif