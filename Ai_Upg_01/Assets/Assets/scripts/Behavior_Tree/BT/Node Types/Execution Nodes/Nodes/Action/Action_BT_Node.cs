using UnityEngine;

public abstract class Action_BT_Node : Leaf_BT_Node
{
    protected override void OnEnterNode()
    {
        // success means "can continue"
        // failure means "restart"
        // running means "wait"

        if (GetCurrentState() != BT_Node_State.FAILURE) { return; }

        UpdateCurrentState(ActivateAction());
    }

    

    protected abstract BT_Node_State ActivateAction();
    
}
