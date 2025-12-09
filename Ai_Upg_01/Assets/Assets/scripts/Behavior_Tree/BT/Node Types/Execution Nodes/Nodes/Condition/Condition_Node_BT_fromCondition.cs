using UnityEngine;

public class Condition_Node_BT_fromCondition : Condition_BT_Node
{
    [SerializeField] protected Condition condition;

    protected override bool CheckCondition()
    {
        if(condition == null) return false;

        return condition.RunCondition(this);
    }
    
}
