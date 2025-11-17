using UnityEngine;
using UnityEngine.AI;

public class Movement_Agent : MonoBehaviour
{

    public NavMeshAgent controller;

    public AgentManager agentManager;

    [SerializeField] Vector3 acceleration = Vector3.zero;

    public Vector3 velocity;
    
    public Vector3 GetVelocity => velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(agentManager == null) 
            agentManager = GetComponentInParent<AgentManager>();

        if(controller == null)
            controller = GetComponent<NavMeshAgent>();
       
        
    }

    // Update is called once per frame
    void Update()
    {

        velocity += acceleration * Time.deltaTime;
        //transform.forward = GetVelocity.normalized;

        
        controller.velocity = velocity;

        acceleration = Vector3.zero;
    }

    public void OnDrawGizmosSelected()
    {
        if (controller == null) return;

        Debug.DrawRay(transform.position, acceleration, Color.green);
        Debug.DrawRay(transform.position, GetVelocity,Color.cyan);
    }

    public void Accelerate(Vector3 acceleration)
    {
        this.acceleration += acceleration;
    }

    public Vector3 GetPos()
    {
        return transform.position;
    }

    public Vector3 GetForward()
    {
        return transform.forward;
    }

    public Vector3 GetDirection(Movement_Agent other)
    {
        return other.GetPos() - GetPos() ;
    }

    public float GetDistanceSQR(Movement_Agent other)
    {
        return Vector3.SqrMagnitude(GetDirection(other));
    }
}
