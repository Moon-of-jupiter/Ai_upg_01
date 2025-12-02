using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviorManager : MonoBehaviour
{
    public Movement_Agent agent;

    

    public List<SteeringBehavior> active_behaviors;

    public float maxVel = 5;

    public bool updateAcceleration = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(agent == null)
            agent = GetComponentInParent<Movement_Agent>();
    }

    public void RunBehaviors()
    {
        Vector3 targetSum = Vector3.zero;

        foreach(var behavior in active_behaviors)
        {
            if (!behavior.isActiveAndEnabled) continue;
            targetSum += behavior.GetTargetSteering();
        }

        


        if(targetSum.sqrMagnitude > maxVel * maxVel)
        {
            targetSum = targetSum.normalized;

            targetSum *= maxVel;
        }

        agent.Accelerate(targetSum);
    }

    // Update is called once per frame
    void Update()
    {
        if (updateAcceleration)
            RunBehaviors();
    }
}
