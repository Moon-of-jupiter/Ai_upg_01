using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class ObsticleDodge_SB : SteeringBehavior
{
    public int res = 6;

    public float radius_mult = 1;

    public float speed = 1;

    public float targetSpeed = 5;

    public bool rightLeaning;

    public override Vector3 GetTargetSteering(BoidNeighbourhood agent)
    {
        var target_v = ObsticleDodge(agent) * targetSpeed;

        Vector3 force = target_v - agent.agent.GetVelocity();

        return force * speed;

    }


    public Vector3 ObsticleDodge(BoidNeighbourhood agent)
    {
        float angleRad = agent.angle;

        float radius = agent.radius * radius_mult;

         

        Vector3 direction = agent.agent.GetVelocity().normalized;

        Vector3 best_direction = direction;

        float best_hit_distance = 0;

        

        if (!agent.Raycast(direction * radius, out NavMeshHit hit))
        {
            return direction;
        }
        else
        {
            best_hit_distance = hit.distance;
        }
       




        for (int i = 0; i <= res; i++)
        {
            float lerpValue = i / (float)res;

            float newAngle = angleRad * lerpValue;

            newAngle *= Mathf.Deg2Rad;

            if (rightLeaning) newAngle *= -1; // alters direction

            Vector3 l = Vector3.RotateTowards(direction, -direction, newAngle, 1) * radius;
            Vector3 r = Vector3.RotateTowards(direction, -direction, -newAngle, 1) * radius;


            

            if (!agent.Raycast(l,out hit))
            {
                return l.normalized ;
            }
            else
            {
                if(hit.distance > best_hit_distance)
                {
                    best_direction = l.normalized;
                }
            }
            

            if (!agent.Raycast(r, out hit))
            {
                return r.normalized ;
            }
            else
            {
                if (hit.distance > best_hit_distance)
                {
                    best_direction = r.normalized;
                }
            }
            



        }

        return best_direction;
    }
}
