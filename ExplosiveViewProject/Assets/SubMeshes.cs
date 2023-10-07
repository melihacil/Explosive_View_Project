using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SubMeshes: MonoBehaviour
{
    public MeshRenderer meshRenderer;

    public Vector3 originalPosition;

    public Vector3 explodedPosition;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
}
