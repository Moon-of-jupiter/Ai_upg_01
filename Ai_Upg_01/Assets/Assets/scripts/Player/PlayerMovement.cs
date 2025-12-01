using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    


    [Header("coupeling")]
    public Movement_Agent agent;

    [Header("variables")]
    public float speed = 15f;
    public float speed_mult = 1f;
    public float lerpValue = 0.5f;

    [Header("data")]
    public Vector2 inputVector;
    public Vector3 target_target_v;
    public Vector3 current_target_v;


    
    public void OnMove(InputValue input)
    {
        inputVector = input.Get<Vector2>().normalized;
        target_target_v.x = inputVector.x;
        target_target_v.y = 0;
        target_target_v.z = inputVector.y;
    }

    protected void LerpV()
    {
        current_target_v = target_target_v * lerpValue + current_target_v * (1 - lerpValue);
    }

    protected void UpdateMovement()
    {
        Vector3 current = agent.GetVelocity();
        Vector3 offset = current_target_v * speed - current;


        agent.Accelerate(offset * speed_mult);
    }

    protected void Update()
    {
        LerpV();
        UpdateMovement();
    }

}
