using UnityEngine;
using System.Collections.Generic;
public class AgentNeighbourhood : MonoBehaviour, INeighbourhood
{

    public LinkedList<Gen_Agent> neighbours { get; private set; }
    
    
    
    public Gen_Agent agent;

    public float radius = 6f;

    public int updateTime;
    public int updateCounter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        neighbours = new LinkedList<Gen_Agent>();
        if(agent == null)
            agent = GetComponentInParent<Gen_Agent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (updateCounter++ >= updateTime)
        {
            updateCounter = 0;
            GatherNeighbours(radius);
        }
    }

    public float DistanceSQR(Gen_Agent a, Gen_Agent b)
    {
        return (a.GetPos() - b.GetPos()).sqrMagnitude;
    }
    protected void GatherNeighbours(float radius)
    {
        neighbours.Clear();

        foreach (var n in agent.agentManager.agents)
        {


            if (DistanceSQR(agent,n) > radius * radius) continue;

            if (n == agent) continue;

            neighbours.AddLast(n);


        }


    }
}

public interface INeighbourhood
{
    public LinkedList<Gen_Agent> neighbours { get; }

    public float DistanceSQR(Gen_Agent a, Gen_Agent b);
}
