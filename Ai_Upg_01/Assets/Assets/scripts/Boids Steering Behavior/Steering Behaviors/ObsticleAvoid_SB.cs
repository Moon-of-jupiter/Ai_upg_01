using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ObsticleAvoid_SB : SteeringBehavior
{
    public int res = 6;

    public float speed = 1;

    public float radius_mult = 1f;

    public override Vector3 GetTargetSteering(BoidNeighbourhood agent)
    {
        float angleRad = agent.angle;

        float radius = agent.radius * radius_mult;

        Vector3 direction = agent.agent.GetVelocity().normalized;

        Vector3 force_sum = Vector3.zero;


        
        if(agent.Raycast(agent.agent.GetVelocity().normalized * radius))
        {
            

            force_sum += agent.agent.GetVelocity().normalized ;
        }
        



        for (int i = 0; i <= res; i++)
        {
            float lerpValue = i / (float)res;

            float newAngle = angleRad * lerpValue;

            newAngle *= Mathf.Deg2Rad;



            Vector3 l = Vector3.RotateTowards(transform.forward, -transform.forward, newAngle, 1) * radius;
            Vector3 r = Vector3.RotateTowards(transform.forward, -transform.forward, -newAngle, 1) * radius;

            if (agent.Raycast(l))
            {
                
                force_sum += l.normalized ;
            }
            

            if (agent.Raycast(r))
            {
                
                force_sum += r.normalized ;
            }
            

        }

        

        force_sum = force_sum.normalized * speed;

        return -force_sum;
    }

    

}
