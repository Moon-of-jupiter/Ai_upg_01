using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoidNeighbourhood : AgentCollection, INeighbourhood
{
    [SerializeField] public float radius = 4;

    [SerializeField] public float angle = 90;

    public LinkedList<Gen_Agent> neighbours { get; private set; }

    public Movement_Agent agent;

    public AgentNeighbourhood neighbourhood;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if(agent == null)
            agent = GetComponentInParent<Movement_Agent>();

        if(neighbourhood == null)
            neighbourhood = GetComponentInParent<AgentNeighbourhood>();


        neighbours = new LinkedList<Gen_Agent>();

        collection = neighbours;

    }

    private void OnDrawGizmosSelected()
    {


        float angleRad =  angle;
        int res = 6;

        Vector3 direction = transform.forward;

        if(agent != null)
        {
            direction = agent.GetVelocity().normalized;
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
            Debug.DrawRay(transform.position, GetDirection(agent,n), Color.red);
        }

    }

    
    public void UpdateNeigbours(LinkedList<Gen_Agent> neighbours, float radius, float angle)
    {
        neighbours.Clear();

        foreach (var n in neighbourhood.neighbours)
        {
            

            if (GetDirection(agent, n).sqrMagnitude > radius * radius) continue;

            if (n == agent) continue;

            if (Vector3.Angle(agent.GetVelocity(), GetDirection(agent, n)) > angle) continue;
            

            neighbours.AddLast(n);
            
            
        }
    }

    public float DistanceSQR(Gen_Agent a, Gen_Agent b)
    {
        return (a.GetPos() - b.GetPos()).sqrMagnitude;
    }

    private Vector3 GetDirection(Gen_Agent a, Gen_Agent b)
    {
        return b.GetPos() - a.GetPos(); 
    }


    // Update is called once per frame
    void Update()
    {
        
        UpdateNeigbours(neighbours, radius, angle);

    }


    public bool Raycast(Vector3 ray)
    {

        return Raycast(ray, out var hit);
    }

    public bool Raycast(Vector3 ray, out NavMeshHit hit)
    {

        bool succsess = agent.controller.Raycast(transform.position + ray, out hit);



        if (succsess)
        {
            Debug.DrawLine(transform.position, hit.position, Color.yellow);
        }

        return succsess;
    }
}
