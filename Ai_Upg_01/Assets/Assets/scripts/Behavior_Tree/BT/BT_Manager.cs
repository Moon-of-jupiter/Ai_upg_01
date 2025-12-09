using System.Collections.Generic;
using UnityEngine;

public class BT_Manager: MonoBehaviour
{
    [SerializeField] protected List<BT_Node> nodes;

    [SerializeField] protected BT_Node root_node;

    [Header("debug")]

    [SerializeField] protected Color Failure_Color = Color.red;
    [SerializeField] protected Color Success_Color = Color.green;
    [SerializeField] protected Color Running_Color = Color.yellow;
    [SerializeField] protected Color Reached_Color = Color.blue;
    [SerializeField] protected float debug_size = 0.1f;

    private void Awake()
    {
        nodes.Clear();
        nodes.AddRange(GetComponentsInChildren<BT_Node>());
    }

    private void Start()
    {
        if (root_node == null && nodes.Count > 0) root_node = nodes[0];

        foreach (var node in nodes)
        {
            node.OnBehaviorTreeStart(this);
        }
    }

    public void Update()
    {
        UpdateBT();
    }

    public void UpdateBT()
    {
        PreUpdateBT();

        root_node?.EnterNode();
    }

    protected void PreUpdateBT()
    {
        foreach (var node in nodes)
        {
            node.Pre_BT_Update();
        }
    }




    //debug

    protected void OnDrawGizmosSelected()
    {
        if(nodes == null) return;
        foreach (var node in nodes)
        {
            var state = node.GetCurrentState();

            if (node.WasReached)
            {
                Gizmos.color = Reached_Color;

                Gizmos.DrawSphere(node.transform.position, debug_size * 1.3f);
            }

            Gizmos.color = GetDebugColorOfNode(state);
            
            Gizmos.DrawSphere(node.transform.position, debug_size);

        }
    }
   
    private Color GetDebugColorOfNode(BT_Node_State state) => state switch
    {
        BT_Node_State.FAILURE => Failure_Color,
        BT_Node_State.SUCCESS => Success_Color,
        BT_Node_State.RUNNING => Running_Color,
        _ => Color.magenta,
    };

}
