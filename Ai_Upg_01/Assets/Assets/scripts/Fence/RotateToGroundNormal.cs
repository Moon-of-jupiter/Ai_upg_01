using UnityEngine;

public class RotateToGroundNormal : MonoBehaviour
{
    public Transform rotator;
    public float lerpValue = 1;

    public RaycastHit hit;
    public bool hitGround;


    public bool updateRotation = true;
    

    // Update is called once per frame
    void Update()
    {
        if (updateRotation)
        {
            UpdateRotateToGround();
            updateRotation = false;
        }
    }

    public void UpdateRotateToGround()
    {
        UpdateRaycastToGround();
        RotateToRaycast();
    }

    public void UpdateRaycastToGround()
    {
        hitGround = Physics.Raycast(transform.position, Vector3.down, out hit);
    }

    public void RotateToRaycast()
    {
        if (!hitGround) return;
        //rotator.position = new Vector3(rotator.position.x, hit.point.y, rotator.position.x);
        rotator.up = transform.up * (1- lerpValue) + hit.normal * lerpValue;
    }
}
