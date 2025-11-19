using UnityEngine;

public class RotateToDirection : MonoBehaviour
{
    public Gen_Agent agent;
    public float lerpValue = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(agent == null) agent = GetComponent<Gen_Agent>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = transform.forward * (1 - lerpValue) + agent.GetVelocity().normalized * lerpValue;
    }
}
