using UnityEngine;

public class SteeringBehavior : MonoBehaviour
{
    public virtual Vector3 GetTargetSteering(BoidNeighbourhood agent)
    {
        return Vector3.zero;
    }

    
}
