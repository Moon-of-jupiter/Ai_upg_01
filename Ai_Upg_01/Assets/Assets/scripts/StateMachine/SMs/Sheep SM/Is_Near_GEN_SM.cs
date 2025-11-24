using System.Linq;
using UnityEngine;

public abstract class Is_Near_GEN_SM : SM_State
{
    

    protected int CountNearAgentsWithTag(string tag, float max_distance,Gen_Agent looker, INeighbourhood near)
    {
        if (near.neighbours == null) return 0;

        float distance = max_distance * max_distance;

        return near.neighbours.Count((a) => a.tags.HasTag(tag) && near.DistanceSQR(looker,a) < distance);
    }

    protected bool HasNearAgentsWithTag(string tag, float max_distance, Gen_Agent looker, INeighbourhood near)
    {
        if(near.neighbours == null) return false;

        float distance = max_distance * max_distance;

        foreach (var n in near.neighbours)
        {
            if(!n.tags.HasTag(tag)) continue;

            if(near.DistanceSQR(looker, n) < distance) return true;
        }

        return false;
    }
}
