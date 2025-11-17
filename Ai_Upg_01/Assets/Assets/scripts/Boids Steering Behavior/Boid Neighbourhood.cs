using System.Collections.Generic;
using UnityEngine;

public class BoidNeighbourhood : MonoBehaviour
{
    [SerializeField] public float radius = 4;

    [SerializeField] public float angle = 90;

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

        Vector3 direction = transform.forward;

        if(agent != null)
        {
            direction = agent.GetVelocity.normalized;
        }

        Vector3[] l_vectors = new Vector3[res + 1];
        Vector3[] r_vectors = new Vector3[res + 1];


        for (int i = res; i >= 0 ; i--)
        {
            float lerpValue = i / (float)res;

            float newAngle =  angleRad *  lerpValue;
            
            newAngle *= Mathf.Deg2Rad;


            
            Vector3 l = Vector3.RotateTowards(transform.forward, -transform.forward, newAngle, 1) * radius;
            Vector3 r = Vector3.RotateTowards(transform.forward, -transform.forward, -newAngle, 1) * radius;

            l_vectors[i] = l;
            r_vectors[i ] = r;
            
        }

        Vector3[] vectors = new Vector3[l_vectors.Length * 2 + 1];

        for(int i = 0; i < l_vectors.Length; i++)
        {
            vectors[i] = l_vectors[i];
        }

        for (int i = 0; i < r_vectors.Length; i++)
        {
            vectors[vectors.Length - i - 1] = r_vectors[i];
        }


        for (int i = 0; i < vectors.Length; i++)
        {
            var color = Color.blue * i / (float)vectors.Length;
            color.a = 1;


            

            Debug.DrawLine(transform.position + vectors[i], transform.position + vectors[(i + 1) % vectors.Length], color);
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
            

            if (agent.GetDistanceSQR(n) > radius * radius) continue;

            if (n == agent) continue;

            if (Vector3.Angle(agent.GetForward(),agent.GetDirection(n)) > angle) continue;
            

            neighbours.AddLast(n);
            
            
        }
    }


    // Update is called once per frame
    void Update()
    {
        UpdateNeigbours(neighbours,radius,angle);
    }
}
