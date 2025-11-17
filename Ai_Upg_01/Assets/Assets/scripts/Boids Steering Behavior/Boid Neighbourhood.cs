using System.Collections.Generic;
using UnityEngine;

public class BoidNeighbourhood : MonoBehaviour
{
    [SerializeField] float radius = 4;

    [SerializeField] float angle = 90;

    public LinkedList<Movement_Agent> neighbours;

    public Movement_Agent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(agent == null)
            agent = GetComponentInParent<Movement_Agent>();

        neighbours = new LinkedList<Movement_Agent>();
    }

    private void OnDrawGizmosSelected()
    {
        float angleRad =  angle;
        int res = 6;

        for (int i = 0; i <= res ; i++)
        {
            float lerpValue = i / (float)res;

            float newAngle =  angleRad *  lerpValue;
            
            newAngle *= Mathf.Deg2Rad;

            Vector3 l = Vector3.RotateTowards(transform.forward, -transform.forward, newAngle, 1) * radius;
            Vector3 r = Vector3.RotateTowards(transform.forward, -transform.forward, -newAngle, 1) * radius;
            Debug.DrawRay(transform.position,l, Color.blue);
            Debug.DrawRay(transform.position, r, Color.blue);
        }

        if (neighbours == null) return;

        foreach(var n in neighbours)
        {
            Debug.DrawRay(transform.position, agent.GetDirection(n), Color.red);
        }

    }


    public void UpdateNeigbours(LinkedList<Movement_Agent> neighbours, float radius, float angle)
    {
        neighbours.Clear();

        foreach (var n in agent.agentManager.agents)
        {
            if (agent.GetDistanceSQR(n) < radius * radius)
            {
                if(Vector3.Angle(agent.GetForward(),agent.GetDirection(n)) < angle)
                {
                    neighbours.AddLast(n);
                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        UpdateNeigbours(neighbours,radius,angle);
    }
}
