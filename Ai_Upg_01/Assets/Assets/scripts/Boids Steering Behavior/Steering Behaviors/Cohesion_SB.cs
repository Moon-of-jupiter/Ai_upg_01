using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Cohesion_SB : SB_OnCollection
{
    public float speed = 10;

    public override Vector3 GetTargetSteering()
    {
        Vector3 avragePos = Vector3.zero;


        float c = 0;
        foreach(var n in collection.collection)
        {
            avragePos += n.GetPos();
            c++;
        }

        if(c== 0) return Vector3.zero;
        avragePos /= c;


        Vector3 desierd_velocity = (avragePos - agent.GetPos()).normalized * speed;

        return desierd_velocity - agent.GetVelocity();

    }
}
