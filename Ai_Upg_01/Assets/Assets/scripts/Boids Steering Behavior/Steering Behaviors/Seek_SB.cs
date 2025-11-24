using UnityEngine;

public class Seek_SB : SteeringBehavior
{
    public Transform target;

    public float speed = 10;

    private void Start()
    {
        if(transform == null) target = transform;
    }

    public override Vector3 GetTargetSteering()
    {



        Vector3 desierd_velocity = (target.position - agent.GetPos() ).normalized * speed;

        return desierd_velocity - agent.GetVelocity();
    }
}
