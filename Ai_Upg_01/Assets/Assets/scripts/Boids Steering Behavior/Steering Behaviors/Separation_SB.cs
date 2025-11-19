using UnityEngine;

public class Separation_SB : SteeringBehavior
{

    public float speed = 10;
    public override Vector3 GetTargetSteering(BoidNeighbourhood agent)
    {
        Vector3 forceSum = Vector3.zero;

        foreach(var n in agent.neighbours)
        {
            Vector3 f = agent.agent.GetPos() - n.GetPos();

            float mag = f.magnitude;

            if(mag <= 0) return Vector3.zero;

            f *= 1 / f.magnitude;

            forceSum += f * speed;
        }


        return forceSum;
    }

}
