using Unity.VisualScripting;
using UnityEngine;

public class Toggle_State_BT_Node : Action_BT_Node
{
    [SerializeField] protected GO_Action_Manager actionManager;
    [SerializeField] protected GameObject action;

    public override void OnBehaviorTreeStart(BT_Manager bt_Manager)
    {
        base.OnBehaviorTreeStart(bt_Manager);
        SetManager();
    }
    

    protected void SetManager()
    {
        if(actionManager == null)
        {
            actionManager = bt_Manager.GetOrAddComponent<GO_Action_Manager>();
        }
    }

    protected override BT_Node_State ActivateAction()
    {
        actionManager?.ActivateAction(action);

        return BT_Node_State.RUNNING;
    }

    public override void UpdateCondition()
    {
        if(actionManager.currentlyActiveAction == action)
        {
            UpdateCurrentState(BT_Node_State.RUNNING);
        }
        else
        {
            UpdateCurrentState(BT_Node_State.FAILURE);
        }
    }


}
