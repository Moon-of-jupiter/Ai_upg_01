using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CameraRaycaster : MonoBehaviour
{

    [Header("configs")]
    public Camera targetCamera;

    public float maxDistance = 100f;

    [Header("hit data")]

    public bool hasUpdated;

    public Ray lastRay;

    public RaycastHit lastHit;

    public GameObject lastHit_Obj;

    public ScreenClickable screenClickable;

    public bool gameObjectHit;
    public bool validHit => screenClickable != null;

    public bool hit => gameObjectHit && validHit;



    public void Update()
    {
        UpdateCamRraycastFromMouse();
        HoverFromScreen();
    }

    public void UpdateCamRraycastFromMouse()
    {
        UpdateCamRraycast(Input.mousePosition);
    }

    public void UpdateCamRraycast(Vector2 screenPos)
    {
        if (float.IsNaN(screenPos.x) || float.IsNaN(screenPos.y)) return;

        hasUpdated = true;

        
        lastRay = targetCamera.ScreenPointToRay(screenPos);

        gameObjectHit = Physics.Raycast(lastRay, out lastHit, maxDistance);

        if (!gameObjectHit)
        {
            UpdateHitObject(null);
            return;
        }


        

        UpdateHitObject(lastHit.collider.gameObject);

    }

    protected void UpdateHitObject(GameObject lastHit_Obj_new)
    {
        if (lastHit_Obj == lastHit_Obj_new) return;
        lastHit_Obj = lastHit_Obj_new;

        if (lastHit_Obj == null) return;

        ToggleSelected(lastHit_Obj.GetComponentInParent<ScreenClickable>());
        
    }

    protected void ToggleSelected(ScreenClickable newClickable)
    {
        if(screenClickable == newClickable)
        {
            return;
        }

        screenClickable?.OnMouseHover_End();
        newClickable?.OnMouseHover_Start();

        screenClickable = newClickable;
    }

    public void HoverFromScreen()
    {
        if (!hit) return;
        screenClickable.OnMouseHover_Update(lastHit);
    }

    


    private void OnDrawGizmos()
    {
        DrawGizmos();
    }

    protected void DrawGizmos()
    {
        DrawGizmos_Raycast();

        Gizmos.color = Color.white;
    }

    protected void DrawGizmos_Raycast()
    {
        if (!hasUpdated) return;

        if (!hit)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(lastRay.origin, lastRay.direction * maxDistance);
            return;
        }


        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(lastRay.origin, lastHit.point);

        

    }

}

