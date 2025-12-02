using UnityEngine;

public class AgentRemover : MonoBehaviour
{

    public AgentManager agents;

    public GameObject removalParticles;

    

    public void RemoveAgent(Gen_Agent agent)
    {
        agents.agents.Remove(agent);

        if(removalParticles != null)
        {
            var particles = Instantiate(removalParticles, transform);
            
            particles.transform.position = agent.transform.position;
            particles.transform.rotation = agent.transform.rotation;
        }

        Destroy(agent.gameObject);
    }
}
