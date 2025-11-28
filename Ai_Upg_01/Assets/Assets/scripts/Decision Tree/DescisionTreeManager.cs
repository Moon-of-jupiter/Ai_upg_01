using UnityEngine;

public class DescisionTreeManager : MonoBehaviour
{
    [SerializeField] protected DT_Node rootNode;


    public DT_Node currentRunResult;
    public DT_Node previousRunResult;

    public bool dtIsActive => rootNode != null;

    public bool activate;

    // Update is called once per frame
    void Update()
    {
        if (activate)
        {
            RunDT();
            activate = false;
        }
        
    }

    public void RunDT()
    {
        currentRunResult = null;
        rootNode.RunNode(this);

        previousRunResult = currentRunResult;
    }

    public void NotifyRunNode(DT_Node node)
    {
        currentRunResult = node;
    }
}
