using UnityEngine;

public class SteeringBehavior : MonoBehaviour
{
    [SerializeField] protected Movement_Agent agent;

    private void Awake()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        if (agent == null)
            agent = GetComponentInParent<Movement_Agent>();
    }

    public virtual Vector3 GetTargetSteering()
    {
        return Vector3.zero;
    }

    
}
