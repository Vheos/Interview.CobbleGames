namespace Vheos.Interview.CobbleGames
{
	using UnityEngine;

	public class MoveToPosition : StepTowardsTarget<Vector3>
	{
		// Methods
		public override bool IsTargetValid
			=> Target.x != float.NaN
			&& Target.y != float.NaN
			&& Target.z != float.NaN;
		public override Vector3 Direction
			=> (Target - transform.position).normalized;
		public override float Distance
			=> (Target - transform.position).magnitude;
	}
}