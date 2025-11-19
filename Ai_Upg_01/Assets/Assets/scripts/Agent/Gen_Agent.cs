using UnityEngine;
using UnityEngine.AI;

public abstract class Gen_Agent : MonoBehaviour
{
    [SerializeField] private AgentTags tags;

    public AgentManager agentManager;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        OnAwake();

    }

    protected virtual void OnAwake()
    {
        if (agentManager == null)
            agentManager = GetComponentInParent<AgentManager>();

    }


    public virtual Vector3 GetVelocity() => Vector3.zero;
    
    public virtual Vector3 GetPos() => transform.position;

}
