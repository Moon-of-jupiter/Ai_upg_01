using UnityEngine;

public class SB_Manager_node_DT : DT_Node
{
    public SteeringBehaviorManager steeringBehaviors;

    private void Awake()
    {
        steeringBehaviors.updateAcceleration = false;
    }


    protected override void OnRunNode(bool wasActiveLastRun, DescisionTreeManager tree)
    {
        steeringBehaviors.RunBehaviors();
    }
}
