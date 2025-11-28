using UnityEngine;

public class Test_Condition : Condition
{
    public bool result;


    public override bool RunCondition(object sender)
    {
        return result;
    }
}
