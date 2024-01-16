namespace Vheos.Interview.CobbleGames
{
	using System;

	public class NodeInfo
	{
		// Fields
		public readonly Node Node;
		public readonly float HeuristicCost;
		public NodeInfo Previous;
		public float MoveCost;
		public bool AlreadyTraversed;

		// Constructors
		public NodeInfo(Node node, Node endNode, Func<Node, Node, float> heuristicFunc)
		{
			Node = node;
			HeuristicCost = heuristicFunc(node, endNode);
		}

		// Methods
		public float TotalCost
			=> MoveCost + HeuristicCost;
		public string DebugText
			=> $"{Node.Id}   /   {MoveCost:F1} + {HeuristicCost:F1} = {TotalCost:F1}";

	}
}