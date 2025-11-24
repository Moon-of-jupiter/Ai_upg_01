using UnityEngine;

public class ScreenClickable : MonoBehaviour
{
    [Header("hitLocation")]
    public bool isHit;
    public RaycastHit lastHit;
    public Vector3 hitPos;

    



    public virtual void OnMouseHover_Start()
    {
        isHit = true;
    }

    public virtual void OnMouseHover_End()
    {
        isHit = false;
    }

    public virtual void OnMouseHover_Update(RaycastHit hit)
    {
        hitPos = hit.point;
        lastHit = hit;
    }

    

}
