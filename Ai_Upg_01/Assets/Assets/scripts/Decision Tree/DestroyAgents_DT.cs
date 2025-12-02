using UnityEngine;

public class DestroyAgents_DT : DT_Node
{
    public AgentCollection targetedAgents;

    public AgentRemover agentRemover;

    

    protected void Start()
    {
        if(agentRemover == null) agentRemover = GetComponentInParent<AgentRemover>();
    }

    protected override void OnRunNode(bool wasActiveLastRun, DescisionTreeManager tree)
    {
        if (targetedAgents == null || agentRemover == null) return;

        foreach (var a in targetedAgents.collection)
        {
            agentRemover.RemoveAgent(a);
        }
    }
}
