using System;
using System.Collections;
using UnityEngine;

public abstract class AgentCollection : MonoBehaviour
{
    public abstract void RunOnAll(Action<Gen_Agent> action);
    
}
