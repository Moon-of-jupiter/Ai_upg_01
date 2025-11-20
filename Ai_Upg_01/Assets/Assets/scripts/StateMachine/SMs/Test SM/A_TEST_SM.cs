using UnityEngine;

public class A_TEST_SM : SM_State
{
    public bool toggle_state;

    private void OnDisable()
    {
        toggle_state = false;
    }

    public override bool CheckSwitchState(out string newState)
    {
        if (toggle_state)
        {
            newState = "B_TEST_SM";
            return true;
        }

        return base.CheckSwitchState(out newState);
    }
}
