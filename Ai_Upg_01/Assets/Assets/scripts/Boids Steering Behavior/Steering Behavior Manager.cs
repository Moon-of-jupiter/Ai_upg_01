using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviorManager : MonoBehaviour
{
    public BoidNeighbourhood neighbourhood;

    

    public List<SteeringBehavior> active_behaviors;

    public float maxVel = 5;

   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(neighbourhood == null)
            neighbourhood = GetComponent<BoidNeighbourhood>();
    }

    private void RunBehaviors()
    {
        Vector3 targetSum = Vector3.zero;

        foreach(var behavior in active_behaviors)
        {
            if (!behavior.isActiveAndEnabled) continue;
            targetSum += behavior.GetTargetSteering(neighbourhood);
        }

        


        if(targetSum.sqrMagnitude > maxVel * maxVel)
        {
            targetSum = targetSum.normalized;

            targetSum *= maxVel;
        }

        neighbourhood.agent.Accelerate(targetSum);
    }

    // Update is called once per frame
    void Update()
    {
        RunBehaviors();
    }
}
