using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class Spooked_Sheep_SM : Is_Near_GEN_SM
{
    [SerializeField] private AgentNeighbourhood neighbourhood;

    [SerializeField] private BoidNeighbourhood boid_neighbourhood;

    public float timer;

    public float max_time = 30;

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
        return base.CheckSwitchState(out newState);

        if (CountNearAgentsWithTag("spooked", 100, boid_neighbourhood.agent, boid_neighbourhood) < 5)
        {
            if (Time.time - timer < max_time)
            {
                newState = "Calm_Sheep_SM";
                return true;
            }
        }
        else
        {
            timer = Time.time;

        }

        
    }

   
}
