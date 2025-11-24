using UnityEngine;

public class KeepSpeed_SB : SteeringBehavior
{
    public float target_speed = 10;
    public float speed = 1;
    public override Vector3 GetTargetSteering()
    {
        var target_v = agent.GetVelocity().normalized * target_speed;

        Vector3 force = target_v - agent.GetVelocity();

        return force * speed;
    }
}
