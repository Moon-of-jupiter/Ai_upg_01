using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ObsticleAvoid_SB : SB_Raycaster
{
    public int res = 6;

    public float speed = 1;

    public float radius_mult = 1f;

    public override Vector3 GetTargetSteering()
    {
        float angleRad = boidNeighbourhood.angle;

        float radius = boidNeighbourhood.radius * radius_mult;

        Vector3 direction = boidNeighbourhood.agent.GetVelocity().normalized;

        Vector3 force_sum = Vector3.zero;


        
        if(boidNeighbourhood.Raycast(agent.GetVelocity().normalized * radius))
        {
            

            force_sum += agent.GetVelocity().normalized ;
        }
        



        for (int i = 0; i <= res; i++)
        {
            float lerpValue = i / (float)res;

            float newAngle = angleRad * lerpValue;

            newAngle *= Mathf.Deg2Rad;



            Vector3 l = Vector3.RotateTowards(transform.forward, -transform.forward, newAngle, 1) * radius;
            Vector3 r = Vector3.RotateTowards(transform.forward, -transform.forward, -newAngle, 1) * radius;

            if (boidNeighbourhood.Raycast(l))
            {
                
                force_sum += l.normalized ;
            }
            

            if (boidNeighbourhood.Raycast(r))
            {
                
                force_sum += r.normalized ;
            }
            

        }

        

        force_sum = force_sum.normalized * speed;

        return -force_sum;
    }

    

}
