using UnityEngine;

public class KeepSpeed_SB : SteeringBehavior
{

    public float speed = 1;
    public override Vector3 GetTargetSteering(BoidNeighbourhood agent)
    {
        var direction = agent.agent.GetVelocity.normalized;

        direction *= speed;

        return direction;
    }
}
