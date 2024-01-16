namespace Vheos.Interview.CobbleGames
{
	using System;
	using System.Collections.Generic;
	using UnityEngine;

	public readonly struct Node : IEquatable<Node>
	{
		// Fields
		public readonly Pathfinder Grid;
		public readonly Vector3Int Id;
		public readonly bool IsWalkable;

		// Constructors
		public Node(Pathfinder grid, Vector3Int id)
		{
			Grid = grid;
			Id = id;
			IsWalkable = grid.IsNodeWalkable(id);
		}

		// Methods
		public Vector3 LocalPosition
			=> Grid.IdToLocalPosition(Id);
		public Vector3 WorldPosition
			=> Grid.IdToWorldPosition(Id);
		public IEnumerable<Node> NeighbourNodes
			=> Grid.GetNeighbourNodes(this);
		public bool Equals(Node other)
			=> Grid == other.Grid && Id == other.Id;
		public override bool Equals(object other)
			=> other is not null && other is Node node && Equals(node);
		public override int GetHashCode()
			=> HashCode.Combine(Grid, Id);

		// Operators
		public static bool operator ==(Node a, Node b)
			=> Equals(a, b);
		public static bool operator !=(Node a, Node b)
			=> !Equals(a, b);
	}
}