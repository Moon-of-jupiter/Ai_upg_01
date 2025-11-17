using UnityEngine;

public class SteeringBehaviorManager : MonoBehaviour
{
    public BoidNeighbourhood neighbourhood;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(neighbourhood == null)
            neighbourhood = GetComponent<BoidNeighbourhood>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
