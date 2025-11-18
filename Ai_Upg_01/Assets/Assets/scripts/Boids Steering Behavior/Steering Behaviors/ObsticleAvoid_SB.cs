using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ObsticleAvoid_SB : SteeringBehavior
{
    public int res = 6;

    public float speed = 1;

    public override Vector3 GetTargetSteering(BoidNeighbourhood agent)
    {
        float angleRad = agent.angle;

        Vector3 direction = transform.forward;

        Vector3 force_sum = Vector3.zero;

        

        if (agent != null)
        {
            direction = agent.agent.GetVelocity.normalized;
        }

        if(Raycast(agent.agent.velocity.normalized * agent.radius, agent))
        {
            force_sum += agent.agent.velocity.normalized * speed;
        }
        



        for (int i = 0; i <= res; i++)
        {
            float lerpValue = i / (float)res;

            float newAngle = angleRad * lerpValue;

            newAngle *= Mathf.Deg2Rad;



            Vector3 l = Vector3.RotateTowards(transform.forward, -transform.forward, newAngle, 1) * agent.radius;
            Vector3 r = Vector3.RotateTowards(transform.forward, -transform.forward, -newAngle, 1) * agent.radius;

            if (Raycast(l, agent))
            {
                force_sum += l.normalized * speed;
            }
            

            if (Raycast(r, agent))
            {
                force_sum += r.normalized * speed;
            }
            

        }


        return -force_sum;
    }

    public bool Raycast(Vector3 ray, BoidNeighbourhood agent)
    {

        bool succsess = agent.agent.controller.Raycast(transform.position + ray, out var hit);

        

        if (succsess)
        {
            Debug.DrawLine(transform.position, hit.position, Color.red);
        }
        else
        {
            Debug.DrawLine(transform.position, hit.position, Color.green);
        }

        return succsess;
    }

}
