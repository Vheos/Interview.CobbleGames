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
			Transform transform = pathfinder.WalkableArea.transform;
			foreach (var node in pathfinder.Nodes)
			{
				Gizmos.color = node.IsWalkable ? Color.green : Color.red;
				Vector3 worldPosition = transform.TransformPoint(node.LocalPosition);
				Gizmos.DrawSphere(worldPosition, pathfinder.WalkerRadius * SphereRadius);

				//Handles.color = Color.black;
				//Handles.Label(worldPosition + Vector3.up, node.Id.ToString(), TextStyle);
			}
		}
	}
}
#endif