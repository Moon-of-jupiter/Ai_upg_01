using System.Collections.Generic;
using UnityEngine;

public class GO_Action_Manager : MonoBehaviour
{
    public GameObject currentlyActiveAction { get; private set; }

    public void ActivateAction(GameObject action)
    {
        currentlyActiveAction?.SetActive(false);
        action?.SetActive(true);
    }
}
