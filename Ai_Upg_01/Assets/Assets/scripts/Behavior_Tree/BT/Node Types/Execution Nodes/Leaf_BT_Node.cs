using UnityEngine;

public abstract class Leaf_BT_Node : BT_Node
{
    public abstract void UpdateCondition();

    public override void Pre_BT_Update()
    {
        base.Pre_BT_Update();
        UpdateCondition();
    }

}
