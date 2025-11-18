using UnityEngine;
using UnityEngine.AI;

public class NavRaycastTest : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform target;
    public bool hit;
    public NavMeshHit navHit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnDrawGizmos()
    {
        if (target == null) return;

        if(agent == null)
        {
            Debug.DrawLine(transform.position, target.position, Color.cyan);
            return;
        }

        if (hit)
        {
            Debug.DrawLine(transform.position, navHit.position, Color.red);
        }
        else
        {
            Debug.DrawLine(transform.position, navHit.position, Color.green);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        hit = agent.Raycast(target.position, out navHit);
    }
}
