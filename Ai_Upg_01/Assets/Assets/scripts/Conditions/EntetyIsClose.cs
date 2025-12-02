using UnityEngine;

public class EntetyIsClose : Condition
{
    public AgentCollection ofAgents;

    public float threshold = 3f;

    public override bool RunCondition(object sender)
    {
        foreach(Gen_Agent a in ofAgents.collection)
        {
            if(a == null) continue;
            if((a.GetPos() - transform.position).sqrMagnitude <= threshold * threshold)
            {
                return true;
            }
        }

        return false;
    }
}
