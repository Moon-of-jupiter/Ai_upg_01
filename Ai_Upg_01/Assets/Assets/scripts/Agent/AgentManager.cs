using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{

    public List<Gen_Agent> agents;

    public Transform agent_keeper;

    public int seed;
    private System.Random id_rand;

    private void Awake()
    {
        if (agent_keeper == null) agent_keeper = transform;
        id_rand = new System.Random(seed);
    }

    public void SpawnAgent(GameObject template, Vector3 pos)
    {
        var new_agent = Instantiate(template, agent_keeper);

        Movement_Agent agent = new_agent.GetComponentInChildren<Movement_Agent>();

        agents.Add(agent);

        agent.Accelerate(new Vector3(100, 0, 100));

        

        new_agent.transform.position = pos;

        agent.rgnSeed = id_rand.Next();
    }

    

}
