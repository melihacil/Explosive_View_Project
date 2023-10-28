using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Depth : MonoBehaviour
{
    public DepthLevel depthLevel = DepthLevel.None;
    public List<Depth> childObjects;
    public Transform mainTransform;
    public int depthLevelInt = 0;

    public void DepthInitialize()
    {

    }

    public void DepthAdd(Depth child) 
    { 
        if (childObjects == null)
        {
            childObjects = new List<Depth>();
        }
        childObjects.Add(child);
    
    }
}
