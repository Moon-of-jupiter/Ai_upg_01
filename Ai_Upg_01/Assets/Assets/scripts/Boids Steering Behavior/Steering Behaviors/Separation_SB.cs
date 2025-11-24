using UnityEngine;

public class Separation_SB : SB_OnCollection
{

    public float speed = 10;
    public override Vector3 GetTargetSteering()
    {
        Vector3 forceSum = Vector3.zero;

        foreach(var n in collection.collection) 
        { 
            Vector3 f = agent.GetPos() - n.GetPos();

            float mag = f.magnitude;

            if (mag <= 0) return Vector3.zero;
            

            f *= 1 / f.magnitude;

            forceSum += f * speed;
        };


        return forceSum;
    }

}
