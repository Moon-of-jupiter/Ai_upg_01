using UnityEngine;
using System.Collections.Generic;
using System;
public class FiniteStateMachine : MonoBehaviour
{
    public Dictionary<string, SM_State> registerd_states = new Dictionary<string, SM_State>();

    public SM_State active_state;

    public readonly string starting_state = "_starting_state";

    private void Start()
    {
        SwitchState(starting_state);
    }

    private void FixedUpdate()
    {
        CheckSwitchState();
    }

    public bool RegisterState(SM_State state)
    {
        return RegisterState(state, state.GetType().Name);

        
    }

    public bool RegisterState(SM_State state, string key)
    {
        return registerd_states.TryAdd(key, state);


    }

    public void SwitchState(string newStateKey)
    {
        active_state?.ToggleState(false);

        active_state = GetStateAtKey(newStateKey);

        active_state?.ToggleState(true);
    }

    public SM_State GetStateAtKey(string state_key)
    {
        if( !registerd_states.TryGetValue(state_key, out var state))
        {
            Debug.Log("missing state, " + state_key);
        }

       

        return state;
    }

    public void CheckSwitchState()
    {
        if (active_state == null) return;

        if(active_state.CheckSwitchState(out string state))
        {
            SwitchState(state);
        }
    }
}
