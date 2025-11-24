using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Flee_Near_SB : SB_OnCollection
{

    

    public float speed = 15f;

    public override Vector3 GetTargetSteering()
    {
        Vector3 sum = Vector3.zero;


        foreach (var n in collection.collection)
        {
            sum += Flee(n.GetPos(), speed, agent);
            
        }


        return sum;
    }

    protected Vector3 Flee(Vector3 target, float speed, Gen_Agent agent)
    {
        Vector3 desierd_velocity = -(target - agent.GetPos()).normalized * speed;

        return desierd_velocity - agent.GetVelocity();

    }
}
