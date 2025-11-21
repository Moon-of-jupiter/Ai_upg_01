using UnityEngine;

public class Flee_Sheep_SM : Is_Near_GEN_SM
{
    [SerializeField] private AgentNeighbourhood neighbourhood;

    [SerializeField] private BoidNeighbourhood boid_neighbourhood;

    public float timer;

    public float max_time = 5;

    public float distance = 5f;
    protected void OnEnable()
    {
        timer = Time.time;
    }

    protected override void InitializeState()
    {
        if (neighbourhood == null) neighbourhood = GetComponentInParent<AgentNeighbourhood>();

        if (boid_neighbourhood == null) boid_neighbourhood = GetComponentInChildren<BoidNeighbourhood>();

        base.InitializeState();
    }

    public override bool CheckSwitchState(out string newState)
    {
        

        if (!HasNearAgentsWithTag("danger", distance, neighbourhood.agent, neighbourhood))
        {
            if (Time.time - timer > max_time)
            {
                newState = "Spooked_Sheep_SM";
                return true;
            }
        }
        else
        {
            timer = Time.time;

        }

        return base.CheckSwitchState(out newState);

    }
}
