using System.Collections.Generic;
using UnityEngine;

public class GetWithTag : AgentCollection
{
    public AgentCollection ofAgents;
    public LinkedList<Gen_Agent> agents;
    public string ofTag;
    private void Start()
    {
        if(ofAgents == null) ofAgents = GetComponentInParent<AgentCollection>();
        agents = new LinkedList<Gen_Agent>();
        collection = agents;
    }

    private void Update()
    {
        UpdateCollection();
    }

    public void UpdateCollection()
    {
        agents.Clear();

        foreach(Gen_Agent a in ofAgents.collection)
        {
            if (a.tags.HasTag(ofTag))
            {
                agents.AddLast(a);
            }
        }
    }
}
