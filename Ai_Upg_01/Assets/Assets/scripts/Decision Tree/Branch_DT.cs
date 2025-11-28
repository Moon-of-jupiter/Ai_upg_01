using UnityEngine;

public class Branch_DT : DT_Node
{

    public Condition condition;

    public DT_Node true_child;
    public DT_Node false_child;

    protected override void OnRunNode(bool wasActiveLastRun, DescisionTreeManager tree)
    {
        if (RunCondition(condition))
        {
            ActivateChild(true_child, tree);
        }
        else
        {
            ActivateChild(false_child, tree);
        }
    }

    protected bool RunCondition(Condition condition)
    {
        if(condition == null) return false;

        return condition.RunCondition(this);
    }
}
