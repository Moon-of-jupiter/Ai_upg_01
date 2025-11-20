using UnityEngine;

public abstract class SM_State : MonoBehaviour
{
    public bool is_active_state;

    public bool is_starting_state;

    public bool is_registerd;

    public Color debug_state_color = Color.magenta;

    public float debug_size = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        OnAwake();
    }

    protected virtual void OnAwake()
    {
        InitializeState();

        gameObject.SetActive(false);

        var fsm = GetComponentInParent<FiniteStateMachine>();
        if (fsm == null) return;

        Register(fsm);
    }

    protected virtual void InitializeState()
    {

    }

    protected virtual void Register(FiniteStateMachine fsm)
    {

        if (!fsm.RegisterState(this))
        {
            return;
        }

        is_registerd = true;



        if (!is_starting_state) return;
        
        if(!fsm.RegisterState(this, fsm.starting_state))
        {
            is_starting_state = false;
        }
            
        


    }

    

    public virtual void ToggleState(bool activeate)
    {
        is_active_state = activeate;
        gameObject.SetActive(activeate);
    }

    public virtual bool CheckSwitchState(out string newState)
    {
        newState = null;

        return false;
    }

    private void OnDrawGizmos()
    {
        if (!is_active_state) return;

        DrawActiveStateGizmos();
    }

    protected virtual void DrawActiveStateGizmos()
    {
        Gizmos.color = debug_state_color;

        Gizmos.DrawSphere(transform.position, debug_size);


        Gizmos.color = Color.white;
    }
}
