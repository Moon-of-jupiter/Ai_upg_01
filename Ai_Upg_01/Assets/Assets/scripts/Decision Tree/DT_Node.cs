using UnityEngine;

public abstract class DT_Node : MonoBehaviour
{
    

    public bool activateChildren = true;


    public bool RunNode(DescisionTreeManager tree)
    {
        if(!isActiveAndEnabled) return false;

        tree.NotifyRunNode(this);
        OnRunNode(tree.previousRunResult == this, tree);

        return true;
    }

    protected abstract void OnRunNode(bool wasActiveLastRun, DescisionTreeManager tree);

    protected bool ActivateChild(DT_Node child, DescisionTreeManager tree)
    {
        if (!activateChildren) return false;

        if(child == null) return false;

        return child.RunNode(tree);
    }

}
