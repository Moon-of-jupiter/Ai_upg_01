using UnityEngine;
using System.Collections.Generic;
using System.Collections.Concurrent;

public class AgentTags : MonoBehaviour
{
    [SerializeField] private List<string> tags_on_start;

    protected HashSet<string> tags;

    private void Start()
    {
        foreach(var tag in tags_on_start)
        {
            AddTag(tag);
        }
    }

    public bool HasTag(string tag)
    {   
        if(tags == null) tags = new HashSet<string>();

        return tags.Contains(tag);
    }

    public void AddTag(string tag)
    {
        if (tags == null) tags = new HashSet<string>();
        tags.Add(tag);
    }

    public void RemoveTag(string tag)
    {
        if (tags == null) { tags = new HashSet<string>(); return; };
        tags.Remove(tag);
    }

}
