
using UnityEngine;

public abstract class BT_Node : MonoBehaviour
{
    [SerializeField] protected bool wasReached;

    public BT_Manager bt_Manager;
    public BT_Node parent_node { get; protected set; }

    private BT_Node_State current_state { get; set; }


    public bool WasReached=>wasReached;

    public virtual void OnBehaviorTreeStart(BT_Manager bt_Manager)
    {
        this.bt_Manager = bt_Manager;
    }

    public virtual void Pre_BT_Update()
    {
        wasReached = false;
    }

    public virtual void UpdateCurrentState(BT_Node_State newState)
    {
        current_state = newState;
    }

    public virtual BT_Node_State GetCurrentState()
    {
        return current_state;
    }

    public void EnterNode()
    {
        wasReached = true;
        OnEnterNode();
    }
    protected abstract void OnEnterNode();


}



public enum BT_Node_State
{
       
    FAILURE,
    SUCCESS,
    RUNNING,
}
