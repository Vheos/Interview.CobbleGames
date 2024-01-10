namespace Vheos.Interview.CobbleGames
{
	using UnityEngine;

	public class MoveToTransform : StepTowardsTarget<Transform>
	{
		// Methods
		public override bool IsTargetValid
			=> Target != null && Target != transform;
		public override Vector3 Direction
			=> (Target.position - transform.position).normalized;
		public override float Distance
			=> (Target.position - transform.position).magnitude;
	}
}