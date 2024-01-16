namespace Vheos.Interview.CobbleGames
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;
	using NodeInfo = NodeInfo<UnityEngine.Vector3Int>;
	using Stopwatch = System.Diagnostics.Stopwatch;

	public class Pathfinder : MonoBehaviour
	{
		// Dependencies
		[field: SerializeField] public BoxCollider WalkableArea { get; private set; }
		[field: SerializeField] public Event OnObstacleTransformChanged { get; private set; }


		// Fields
		[field: SerializeField, Range(0.1f, 1f)] public float WalkerRadius { get; private set; }
		[field: SerializeField] public bool CenterGrid { get; private set; }
		public Grid3D Grid { get; private set; }
		private Vector3 startCorner;
		private int layerMask;
		private readonly HashSet<Vector3Int> unwalkableNodes = new();
		private bool isDirty;

		// Methods
		private float MoveCost
			=> 1f;
		private void Initialize()
		{
			if (WalkerRadius <= 0f)
				return;

			Vector3 nodeSize = WalkableArea.size / WalkerRadius;
			Vector3Int gridSize = Vector3Int.one + nodeSize.RoundDown();
			Grid = new(gridSize);

			startCorner = WalkableArea.center - WalkableArea.size / 2f;
			if (CenterGrid)
				startCorner += (nodeSize - nodeSize.RoundDown()) / 2f;

			layerMask = Layer.Obstacle.GetMask();

		}
		private float CalculateHeuristicCost(Vector3Int fromNode, Vector3Int toNode)
			=> (toNode - fromNode).magnitude;
		public bool IsWalkable(Vector3Int node)
			=> !unwalkableNodes.Contains(node);
		private void UpdateWalkability()
		{
			unwalkableNodes.Clear();
			foreach (var node in Grid.Nodes)
				if (Physics.CheckSphere(NodeToWorldPosition(node), WalkerRadius, layerMask))
					unwalkableNodes.Add(node);
		}
		private void RequestWalkabilityUpdate()
			=> isDirty = true;
		private IEnumerator UpdateWalkability_Delayed()
		{
			yield return new WaitForEndOfFrame();
			UpdateWalkability();
		}
		private IReadOnlyCollection<Vector3Int> FindShortestPath(Vector3Int fromNode, Vector3Int toNode)
		{
			if (fromNode == toNode || !IsWalkable(toNode))
				return Array.Empty<Vector3Int>();

#if DEBUG
			Stopwatch stopwatch = Stopwatch.StartNew();
#endif

			Dictionary<Vector3Int, NodeInfo> infosByNode = new();
			NodeInfo GetNodeInfo(Vector3Int node)
				=> infosByNode.GetOrAdd(node, () => new(node, toNode, CalculateHeuristicCost));

			NodeInfo start = GetNodeInfo(fromNode);
			NodeInfo end = GetNodeInfo(toNode);
			List<NodeInfo> potentials = new() { start };

			while (potentials.Count > 0)
			{
				NodeInfo current = potentials.Last();
				if (current == end)
					break;

				potentials.Remove(current);
				current.AlreadyTraversed = true;

				var validNeighbours =
					from node in Grid.GetNeighbourNodes(current.Node)
					let info = GetNodeInfo(node)
					where IsWalkable(node) && !info.AlreadyTraversed
					select info;

				foreach (var neighbour in validNeighbours)
				{
					bool alreadyInPotentials = potentials.Contains(neighbour);
					float moveCost = current.MoveCost + MoveCost;
					if (alreadyInPotentials && moveCost >= neighbour.MoveCost)
						continue;

					neighbour.Previous = current;
					neighbour.MoveCost = moveCost;
					if (!alreadyInPotentials)
						potentials.InsertDescending(neighbour, n => n.TotalCost);
				}
			}

			Stack<Vector3Int> path = new();
			for (NodeInfo i = end; i != null; i = i.Previous)
				path.Push(i.Node);

#if DEBUG
			stopwatch.Stop();
			Debug.Log($"Found path from {fromNode} to {toNode} in {path.Count} moves / {stopwatch.ElapsedMilliseconds}ms:\n" +
				$"Evaluated cost of >{infosByNode.Count} nodes\n" +
				string.Join("", path.Select(node => $"• {node}\n")));
#endif

			return path;
		}
		public IEnumerable<Vector3> FindShortestPath(Vector3 fromWorld, Vector3 toWorld)
			=> FindShortestPath(WorldPositionToNode(fromWorld), WorldPositionToNode(toWorld))
			.Select(NodeToWorldPosition);

		// Conversions
		public Vector3 NodeToLocalPosition(Vector3Int node)
			=> startCorner + (Vector3)node * WalkerRadius;
		public Vector3 NodeToWorldPosition(Vector3Int node)
			=> WalkableArea.transform.TransformPoint(NodeToLocalPosition(node));
		public Vector3Int LocalPositionToNode(Vector3 localPosition)
			=> ((localPosition - startCorner) / WalkerRadius).Round();
		public Vector3Int WorldPositionToNode(Vector3 worldPosition)
			=> LocalPositionToNode(WalkableArea.transform.InverseTransformPoint(worldPosition));

		// Unity
		private void Awake()
		{
			Initialize();
			RequestWalkabilityUpdate();
		}
		private void OnEnable()
			=> OnObstacleTransformChanged.Subscribe(RequestWalkabilityUpdate);
		private void FixedUpdate()
		{
			if (isDirty)
			{
				StartCoroutine(UpdateWalkability_Delayed());
				isDirty = false;
			}
		}
		private void OnDisable()
			=> OnObstacleTransformChanged.Unsubscribe(RequestWalkabilityUpdate);
	}
}