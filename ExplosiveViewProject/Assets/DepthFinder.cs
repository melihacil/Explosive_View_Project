using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public enum DepthLevel
{
    None,
    LevelOne,
    LevelTwo,
    LevelThree,
}


public class DepthFinder : MonoBehaviour
{

    [SerializeField] private GameObject objectToFind;

    void LogDepth(Transform root, int depth)
    {
        var children = root.GetComponentsInChildren<Transform>();
        foreach (var c in children)
        {
            if (c.parent == root)
            {
                //DERÝNLÝK KOD KISMI
                LogDepth(c, depth + 1);
            }
        }
    }


    void LogDepth(Transform root)
    {
        var children = root.GetComponentsInChildren<Transform>();
        if (children == null) 
        { 
            Debug.Log("No Child Found In" + root.gameObject.name); 
            return; 
        }

        Depth rootDepth = root.GetComponent<Depth>();

       
        foreach (var c in children)
        {

            Debug.Log(rootDepth.childObjects);

            if (c.parent == root)
            {
                Depth depth = c.gameObject.AddComponent<Depth>();
                depth.mainTransform = c;
                depth.depthLevelInt = rootDepth.depthLevelInt + 1;
                Debug.Log(depth);
                rootDepth.DepthAdd(depth);
                LogDepth(c);
            }
        }
        
    }


    [ContextMenu("TestDepth")]
    public void TestDepth()
    {
        Depth root = objectToFind.AddComponent<Depth>();
        root.depthLevelInt = 0;
        root.mainTransform = objectToFind.transform;
        LogDepth(objectToFind.transform);
    }

}
