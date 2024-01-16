namespace Vheos.Interview.CobbleGames
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;

	public class Grid3D
	{
		// Fields
		public Vector3Int Size { get; private set; }

		// Constructors
		public Grid3D(Vector3Int size)
		{
			Size = size;
		}

		// Methods
		public IEnumerable<Vector3Int> Nodes
		{
			get
			{
				for (int z = 0; z < Size.z; z++)
					for (int y = 0; y < Size.y; y++)
						for (int x = 0; x < Size.x; x++)
							yield return new(x, y, z);
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
		public IEnumerable<Vector3Int> GetNeighbourNodes(Vector3Int node)
			=> from direction in NeighbourDirections
			   let id = node + direction
			   where id.IsBetween(Vector3Int.zero, Size - Vector3Int.one)
			   select id;
	}
}