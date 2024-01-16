namespace Vheos.Interview.CobbleGames
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;

	public partial class Pathfinder : MonoBehaviour
	{
		// Dependencies
		[field: SerializeField] public BoxCollider WalkableArea { get; private set; }

		// Fields
		[field: SerializeField, Range(0.1f, 1f)] public float WalkerRadius { get; private set; }
		[field: SerializeField] public bool CenterGrid { get; private set; }
		private Node[,,] nodes = new Node[0, 0, 0];
		private Vector3Int lengths;
		private Vector3 startCorner;
		private int layerMask;

		// Methods
		public IEnumerable<Node> Nodes
		{
			get
			{
				foreach (var node in nodes)
					yield return node;
			}
		}
		private IEnumerable<Vector3Int> NeighbourDirections
		{
			get
			{
				yield return new(+1, 0, 0);
				yield return new(-1, 0, 0);
				yield return new(0, +1, 0);
				yield return new(0, -1, 0);
				yield return new(0, 0, +1);
				yield return new(0, 0, -1);
			}
		}
		private float NodeMoveCost
			=> 1f;
		private void Initialize()
		{
			if (WalkerRadius <= 0f)
				return;

			Vector3 nodeSize = WalkableArea.size / WalkerRadius;
			lengths = Vector3Int.one + nodeSize.RoundDown();
			nodes = new Node[lengths.x, lengths.y, lengths.z];
			startCorner = WalkableArea.center - WalkableArea.size / 2f;
			if (CenterGrid)
				startCorner += (nodeSize - nodeSize.RoundDown()) / 2f;
			layerMask = Layer.Obstacle.GetMask();

			for (int x = 0; x < lengths.x; x++)
				for (int y = 0; y < lengths.y; y++)
					for (int z = 0; z < lengths.z; z++)
						nodes[x, y, z] = new(this, new(x, y, z));
		}
		private float CalculateHeuristicCost(Node from, Node to)
			=> (to.Id - from.Id).magnitude;
		public bool IsNodeWalkable(Vector3Int id)
			=> !Physics.CheckSphere(IdToWorldPosition(id), WalkerRadius, layerMask);
		public IEnumerable<Node> GetNeighbourNodes(Node node)
			=> from direction in NeighbourDirections
			   let id = node.Id + direction
			   where id.IsBetween(Vector3Int.zero, lengths - Vector3Int.one)
			   select GetNode(id);

		// Conversions
		public Vector3 IdToLocalPosition(Vector3Int id)
			=> startCorner + (Vector3)id * WalkerRadius;
		public Vector3 IdToWorldPosition(Vector3Int id)
			=> WalkableArea.transform.TransformPoint(IdToLocalPosition(id));
		public Vector3Int LocalPositionToId(Vector3 localPosition)
			=> ((localPosition - startCorner) / WalkerRadius).Round();
		public Vector3Int WorldPositionToId(Vector3 worldPosition)
			=> LocalPositionToId(WalkableArea.transform.InverseTransformPoint(worldPosition));
		public Node LocalPositionToNode(Vector3 localPosition)
			=> GetNode(LocalPositionToId(localPosition));
		public Node WorldPositionToNode(Vector3 worldPosition)
			=> GetNode(WorldPositionToId(worldPosition));

		// Core
		public Node GetNode(Vector3Int id)
			=> nodes[id.x, id.y, id.z];
		public IReadOnlyCollection<Node> FindShortestPath(Vector3 from, Vector3 to)
			=> FindShortestPath(WorldPositionToNode(from), WorldPositionToNode(to));
		public IReadOnlyCollection<Node> FindShortestPath(Node startNode, Node endNode)
		{
			if (!endNode.IsWalkable)
				return Array.Empty<Node>();

			Dictionary<Node, NodeInfo> infosByNode = new();
			NodeInfo GetNodeInfo(Node node)
				=> infosByNode.GetOrAdd(node, () => new(node, endNode, CalculateHeuristicCost));

			NodeInfo start = GetNodeInfo(startNode);
			NodeInfo end = GetNodeInfo(endNode);
			List<NodeInfo> potentials = new() { start };

			while (potentials.Count > 0)
			{
				NodeInfo current = potentials.Last();
				if (current == end)
					break;

				potentials.Remove(current);
				current.AlreadyTraversed = true;

				var validNeighbours =
					from node in current.Node.NeighbourNodes
					let info = GetNodeInfo(node)
					where node.IsWalkable && !info.AlreadyTraversed
					select info;

				foreach (var neighbour in validNeighbours)
				{
					bool isPotential = potentials.Contains(neighbour);
					float moveCost = current.MoveCost + NodeMoveCost;
					if (isPotential && moveCost >= neighbour.MoveCost)
						continue;

					neighbour.Previous = current;
					neighbour.MoveCost = moveCost;
					if (!isPotential)
						potentials.InsertDescending(neighbour, n => n.TotalCost);
				}
			}

			Stack<Node> path = new();
			for (NodeInfo i = end; i != null; i = i.Previous)
				path.Push(i.Node);

			return path;
		}

		// Unity
		private void Start() => Initialize();
	}
}