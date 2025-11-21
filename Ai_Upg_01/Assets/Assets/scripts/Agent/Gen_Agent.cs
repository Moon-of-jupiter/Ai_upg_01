using UnityEngine;
using UnityEngine.AI;

public class Gen_Agent : MonoBehaviour
{
    public AgentTags tags;

    public AgentManager agentManager;

    public int rgnSeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        

        OnAwake();

    }

    protected virtual void OnAwake()
    {
        if(tags == null)
            tags = GetComponent<AgentTags>();

        if (agentManager == null)
            agentManager = GetComponentInParent<AgentManager>();

    }


    public virtual Vector3 GetVelocity() => Vector3.zero;
    
    public virtual Vector3 GetPos() => transform.position;

}
