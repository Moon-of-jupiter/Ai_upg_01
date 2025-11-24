using UnityEngine;

public abstract class SB_Raycaster : SteeringBehavior
{
    [SerializeField] protected BoidNeighbourhood boidNeighbourhood;

    protected override void Initialize()
    {
        base.Initialize();

        if(boidNeighbourhood == null ) 
            boidNeighbourhood = GetComponent<BoidNeighbourhood>();
    }
}
