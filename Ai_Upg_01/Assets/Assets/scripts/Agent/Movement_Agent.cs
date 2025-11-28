using UnityEngine;
using UnityEngine.AI;

public class Movement_Agent : Gen_Agent
{

    public NavMeshAgent controller;

    

    [SerializeField] protected Vector3 acceleration = Vector3.zero;

    [SerializeField] protected Vector3 velocity;
    
    

    protected override void OnAwake()
    {
        base.OnAwake();

        if (controller == null)
            controller = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity.y = controller.velocity.y;

        if (float.IsNaN(acceleration.z)) acceleration = Vector3.zero;

        velocity += acceleration * Time.deltaTime;
        //transform.forward = GetVelocity.normalized;

        //velocity.y *= 0.1f;
        
        if(float.IsNaN(velocity.z)) velocity = Vector3.zero;

        

        controller.velocity = velocity;

        acceleration = Vector3.zero;
    }

    public void OnDrawGizmosSelected()
    {
        if (controller == null) return;

        Debug.DrawRay(transform.position, acceleration, Color.green);
        Debug.DrawRay(transform.position, GetVelocity(),Color.cyan);
    }

    public void Accelerate(Vector3 acceleration)
    {
        this.acceleration += acceleration;
    }

    public override Vector3 GetVelocity() => velocity;

    
    

    //public Vector3 GetForward()
    //{
    //    return transform.forward;
    //}

    //public Vector3 GetDirection(Movement_Agent other)
    //{
    //    return other.GetPos() - GetPos() ;
    //}

    //public float GetDistanceSQR(Movement_Agent other)
    //{
    //    return Vector3.SqrMagnitude(GetDirection(other));
    //}
}
