using UnityEngine;

public class UpdateAnimation_Speed : MonoBehaviour
{
    public Animator animator;
    public Movement_Agent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (animator == null) 
            animator = GetComponent<Animator>();

        if(agent == null)
            agent = GetComponentInParent<Movement_Agent>();

        if(animator == null || animator == null)
        {
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("speed",agent.GetVelocity().magnitude);
    }
}
