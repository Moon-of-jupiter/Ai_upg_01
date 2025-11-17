using UnityEngine;

public class Alignment_SB : SteeringBehavior
{
    public override Vector3 GetTargetSteering(BoidNeighbourhood agent)
    {
        Vector3 vSum = Vector3.zero;
        float c = 0;

        foreach(var n in agent.neighbours)
        {
            vSum += n.GetVelocity;
            c++;
        }

        if (c == 0) return Vector3.zero;

        Vector3 avrgV = vSum / c;



        return avrgV - agent.agent.GetVelocity ;
    }
}
