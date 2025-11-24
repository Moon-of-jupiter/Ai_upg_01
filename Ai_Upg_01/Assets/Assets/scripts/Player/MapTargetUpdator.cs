using UnityEngine;

public class MapTargetUpdator : MonoBehaviour
{
    public ScreenClickable raycastTarget;


    private void Update()
    {
        UpdateTarget();
    }

    protected void UpdateTarget()
    {
        if(raycastTarget == null) return;

        if (!raycastTarget.isHit) return;
        
        transform.position = raycastTarget.hitPos;
        
    }

    
}
