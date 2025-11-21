using UnityEngine;

public class Grazeing_Sheep_SM : Is_Near_GEN_SM
{
    [SerializeField] private AgentNeighbourhood neighbourhood;

    [SerializeField] private BoidNeighbourhood boid_neighbourhood;

    public float distance = 5;

    public int spooked_threshold = 4;
    protected override void InitializeState()
    {
        if (neighbourhood == null) neighbourhood = GetComponentInParent<AgentNeighbourhood>();

        if (boid_neighbourhood == null) boid_neighbourhood = GetComponentInChildren<BoidNeighbourhood>();

        base.InitializeState();
    }

    public override bool CheckSwitchState(out string newState)
    {
        if(HasNearAgentsWithTag("danger", distance, neighbourhood.agent,neighbourhood))
        {
            newState = "Spooked_Sheep_SM";
            return true;
        }

        if (CountNearAgentsWithTag("spooked", distance, boid_neighbourhood.agent, boid_neighbourhood) > spooked_threshold)
        {
            newState = "Spooked_Sheep_SM";
            return true;
        }

        return base.CheckSwitchState(out newState);
    }
}
