using UnityEngine;

public class Arival_SB : SteeringBehavior
{

    public Transform target;

    public float slowing_distance = 5f;

    public float max_speed = 10f;

    public float speed = 2f;

    public override Vector3 GetTargetSteering()
    {
        if(target == null)
            return base.GetTargetSteering();

        return ArivalBehavior(target.position);
    }

    protected Vector3 ArivalBehavior(Vector3 target)
    {
        Vector3 target_offset = target - agent.GetPos();
        float distance = target_offset.magnitude;
        float ramped_speed = max_speed *( distance / slowing_distance);
        float truncated_speed = Mathf.Min(ramped_speed, max_speed);

        Vector3 desired_velocity = (truncated_speed / distance) * target_offset;

        return (desired_velocity - agent.GetVelocity()) * speed;

    }
}
