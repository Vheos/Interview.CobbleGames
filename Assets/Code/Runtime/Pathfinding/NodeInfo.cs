namespace Vheos.Interview.CobbleGames
{
	using System;

	public class NodeInfo<T>
	{
		// Fields
		public readonly T Node;
		public readonly float HeuristicCost;
		public NodeInfo<T> Previous;
		public float MoveCost;
		public bool AlreadyTraversed;

		// Constructors
		public NodeInfo(T id, T endNode, Func<T, T, float> heuristicFunc)
		{
			Node = id;
			HeuristicCost = heuristicFunc(id, endNode);
		}

		// Methods
		public float TotalCost
			=> MoveCost + HeuristicCost;
		public string DebugText
			=> $"{Node}   /   {MoveCost:F1} + {HeuristicCost:F1} = {TotalCost:F1}";

	}
}