using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    public Transform target;

    public float lerpValue;

    

    protected void OnDrawGizmos()
    {
        if (target == null) return;

        Gizmos.DrawLine(transform.position, target.position);
    }

    protected void LerpToTarget(float lerpValue)
    {
        if (target == null) return;

        transform.position = target.position * lerpValue + transform.position * (1 - lerpValue);
    }

    // Update is called once per frame
    void Update()
    {
        LerpToTarget(lerpValue);
    }
}
