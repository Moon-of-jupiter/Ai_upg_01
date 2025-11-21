using UnityEngine;

public class ToggleTag : MonoBehaviour
{
    public string added_tag;

    public AgentTags tags;

    private void Awake()
    {
        if(tags == null)
            tags = GetComponentInParent<AgentTags>();
    }

    private void OnEnable()
    {
        if(tags == null)
            tags = GetComponentInParent<AgentTags>();
        tags?.AddTag(added_tag);
    }

    private void OnDisable()
    {
        if (tags == null)
            tags = GetComponentInParent<AgentTags>();
        tags?.RemoveTag(added_tag);
    }

}
