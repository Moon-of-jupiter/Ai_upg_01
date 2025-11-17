using UnityEngine;

public class Spawner : MonoBehaviour
{
    public AgentManager agentManager;

    public int amount;

    public GameObject template;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (agentManager == null || template == null) return;

        while(amount > 0)
        {
            amount--;

            agentManager.SpawnAgent(template, transform.position);
        }
    }
}
