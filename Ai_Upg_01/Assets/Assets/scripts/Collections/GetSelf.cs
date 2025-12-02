using System.Collections.Generic;
using UnityEngine;

public class GetSelf : AgentCollection
{
    public List<Gen_Agent> self;

    protected void Start()
    {
        self.Add(gameObject.GetComponentInParent<Gen_Agent>());

        collection = self;
    }
}
