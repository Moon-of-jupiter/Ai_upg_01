using UnityEngine;

public class Alignment_SB : SB_OnCollection
{

    public float speed = 1;
    public override Vector3 GetTargetSteering()
    {
        Vector3 vSum = Vector3.zero;
        float c = 0;

        foreach(var n in collection.collection)
        {
            vSum += n.GetVelocity();
            c++;
        }

        if (c == 0) return Vector3.zero;

        Vector3 avrgV = vSum / c * speed;



        return avrgV - agent.GetVelocity();
    }
}
