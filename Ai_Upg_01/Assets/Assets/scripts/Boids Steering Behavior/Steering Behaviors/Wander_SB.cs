using UnityEngine;

public class Wander_SB : SteeringBehavior
{

    public float speed = 1;

    public float drift_speed = 1;

    public override Vector3 GetTargetSteering(BoidNeighbourhood agent)
    {
        Vector3 direction = agent.agent.GetVelocity().normalized;

        Vector3 left = new Vector3(direction.z, direction.y, -direction.x);

        Vector3 force = left * GetSmoothRandom(Time.time * drift_speed + agent.agent.rgnSeed % 500);

        Debug.DrawRay(transform.position, force, Color.cyan);
        Debug.DrawRay(transform.position, left, Color.yellow);

        return force * speed;
    }


    public float GetSmoothRandom(float time)
    {
        float value = Mathf.Sin(2 * time) + Mathf.Cos(Mathf.PI * time);

        return value;
    }
}
