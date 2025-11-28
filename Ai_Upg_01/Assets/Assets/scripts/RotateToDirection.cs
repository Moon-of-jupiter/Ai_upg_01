using UnityEngine;

public class RotateToDirection : MonoBehaviour
{
    public Movement_Agent agent;
    public float lerpValue = 0.5f;

    public Vector3 targetVector;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(agent == null) agent = GetComponent<Movement_Agent>();

        agent.controller.updateRotation = false;
        agent.controller.updateUpAxis = true;

    }

    // Update is called once per frame
    void Update()
    {
        targetVector = agent.GetVelocity();

        targetVector.y = 0;

        transform.forward = transform.forward * (1 - lerpValue) + targetVector.normalized * lerpValue;
        
    }
}
