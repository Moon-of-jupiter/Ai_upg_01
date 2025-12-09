using UnityEngine;

public class Selector_BT_Node : Composite_BT_Node
{
    protected override void OnEnterNode()
    {
        foreach(var child in children)
        {
            if (child == null) continue;

            child.EnterNode();

            var state = child.GetCurrentState();

            if (state == BT_Node_State.FAILURE) continue;

            UpdateCurrentState(state);
            return;

        }

        UpdateCurrentState(BT_Node_State.FAILURE);
    }

    

}
