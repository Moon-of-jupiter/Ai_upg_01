using UnityEngine;

public abstract class Condition_BT_Node : Leaf_BT_Node
{
    [SerializeField] protected bool condition_result;

    protected override void OnEnterNode()
    {
        if (condition_result)
        {
            UpdateCurrentState(BT_Node_State.SUCCESS);
        }
        else
        {
            UpdateCurrentState(BT_Node_State.FAILURE);
        }
    }

    public override void UpdateCondition()
    {
        condition_result = CheckCondition();
    }

    protected abstract bool CheckCondition();

}
