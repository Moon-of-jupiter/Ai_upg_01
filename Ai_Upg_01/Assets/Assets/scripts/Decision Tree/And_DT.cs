using System.Collections.Generic;
using UnityEngine;

public class And_DT : DT_Node
{
    public List<DT_Node> nodes = new List<DT_Node>();

    protected override void OnRunNode(bool wasActiveLastRun, DescisionTreeManager tree)
    {
        foreach (var n in nodes)
        {
            ActivateChild(n, tree);
        }
    }
}
