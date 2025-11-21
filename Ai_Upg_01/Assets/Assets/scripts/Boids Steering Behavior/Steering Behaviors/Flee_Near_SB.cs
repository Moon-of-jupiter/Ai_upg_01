using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Flee_Near_SB : SteeringBehavior
{

    public string target_tag;

    public float speed = 15f;

    public override Vector3 GetTargetSteering(BoidNeighbourhood agent)
    {
        Vector3 sum = Vector3.zero;


        foreach (var n in agent.neighbourhood.neighbours)
        {

            if (n.tags.HasTag(target_tag))
            {
                sum += Flee(n.GetPos(), speed, agent);
            }
        }


        return sum;
    }

    protected Vector3 Flee(Vector3 target, float speed, BoidNeighbourhood agent)
    {
        Vector3 desierd_velocity = -(target - agent.agent.GetPos()).normalized * speed;

        return desierd_velocity - agent.agent.GetVelocity();

    }
}
