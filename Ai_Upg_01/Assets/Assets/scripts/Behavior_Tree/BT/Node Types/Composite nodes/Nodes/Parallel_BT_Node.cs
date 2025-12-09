using UnityEngine;

public class Parallel_BT_Node : Composite_BT_Node
{
    public int success_threshold;
    public bool count_running = true;

    protected override void OnEnterNode()
    {
        

        int success_c = 0;
        int failure_c = 0;
        int child_count = children.Count;
        foreach (var child in children)
        {
            if (child == null) 
            {
                child_count--;
                continue; 
            }

            child.EnterNode();

            var state = child.GetCurrentState();

            if      (state == BT_Node_State.SUCCESS)    success_c++;
            else if (state == BT_Node_State.FAILURE)    failure_c++;

        }

        if(success_c >= success_threshold)
        {
            UpdateCurrentState(BT_Node_State.SUCCESS);
            return;
        }


        if (failure_c >= (child_count - success_threshold + 1))
        {
            UpdateCurrentState(BT_Node_State.FAILURE);
            return;
        }


        UpdateCurrentState(BT_Node_State.RUNNING);
    }
}
