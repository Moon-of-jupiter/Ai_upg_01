using UnityEngine;

public class SB_OnCollection : SteeringBehavior
{
    [SerializeField] protected AgentCollection collection;

    protected override void Initialize()
    {
        base.Initialize();

        if(collection == null)
            collection = GetComponent<AgentCollection>();
    }


}

