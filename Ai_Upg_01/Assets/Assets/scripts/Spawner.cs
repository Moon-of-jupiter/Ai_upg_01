using UnityEngine;

public class Spawner : MonoBehaviour
{
    public AgentManager agentManager;

    public int amount;

    public GameObject template;
    public float timer_speed = 10;

    public float timer_counter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (agentManager == null || template == null) return;
        if (amount <= 0) return;

        timer_counter += timer_speed;

        while (timer_counter > 0)
        {

            timer_counter--;

            if (amount <= 0) break;




            amount--;

            agentManager.SpawnAgent(template, transform.position);
        }

        
    }
}
