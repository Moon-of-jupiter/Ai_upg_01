using UnityEngine;
using System.Collections.Generic;
public class GetClosestAgent : AgentCollection
{
    public AgentCollection ofAgents;
    protected Gen_Agent[] closest;

    public float closestDist;

    protected void Start()
    {
        closest = new Gen_Agent[1];
        collection = closest;
    }

    protected void OnDrawGizmosSelected()
    {
        if (closest == null||closest.Length < 1 || closest[0] == null) return;

        Gizmos.DrawLine(transform.position, closest[0].GetPos());
    }

    public void Update()
    {
        UpdateList();
    }

    public void UpdateList()
    {
        closest[0] = null;
        closestDist = float.PositiveInfinity;

        foreach (Gen_Agent agent in ofAgents.collection)
        {
            float distance = (agent.GetPos() - transform.position).sqrMagnitude;

            if(distance < closestDist)
            {
                closestDist = distance;
                closest[0] = agent;
            }
        }
    }
}
