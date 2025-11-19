using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{

    public List<Movement_Agent> agents;


    public void SpawnAgent(GameObject template, Vector3 pos)
    {
        var new_agent = Instantiate(template);

        Movement_Agent agent = new_agent.GetComponentInChildren<Movement_Agent>();

        agents.Add(agent);

        agent.Accelerate(new Vector3(100, 0, 100));

        

        new_agent.transform.position = pos;
    }
}
