using UnityEngine;

public class Test_DT : DT_Node
{
    public Color debug_color;
    public Vector3 ray = new Vector3(0,1,0);

    protected override void OnRunNode(bool wasActiveLastRun, DescisionTreeManager tree)
    {
        Debug.DrawRay(transform.position, ray, debug_color);
        Debug.Log("DT Run; " + gameObject.name);
    }
}
