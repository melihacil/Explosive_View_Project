using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class E_VManager : MonoBehaviour
{
    #region PublicVariables


    public List<SubMeshes> childMeshRenderers;

    #endregion

    #region PrivateVariables
    [SerializeField] private GameObject m_ObjectToExplode;
    [SerializeField] private float m_ExplosionSpeed = 0.1f;
    [SerializeField] private float m_ExplosionDuration = 2f;
    bool isMoving = false;
    bool isInExplodedView = false;
    #endregion

    #region UnityFunctions


    private void Awake()

    {

        childMeshRenderers = new List<SubMeshes>();


        if (m_ObjectToExplode != null)
        {
            foreach (var item in m_ObjectToExplode.GetComponentsInChildren<MeshRenderer>())

            {

                SubMeshes mesh = new SubMeshes();

                mesh.meshRenderer = item;

                mesh.originalPosition = item.transform.position;

                mesh.explodedPosition = item.bounds.center * 1.5f;

                childMeshRenderers.Add(mesh);

            }
        }

        

    }


    private void Update()

    {

        if (isMoving)

        {

            if (isInExplodedView)

            {

                foreach (var item in childMeshRenderers)

                {

                    //item.meshRenderer.transform.position = Vector3.Lerp(item.meshRenderer.transform.position, item.explodedPosition, m_ExplosionSpeed);

                    item.meshRenderer.transform.DOMove(item.explodedPosition, m_ExplosionSpeed);
                    if (Vector3.Distance(item.meshRenderer.transform.position, item.explodedPosition) < 0.001f)

                    {

                        isMoving = false;

                    }

                }

            }

            else

            {

                foreach (var item in childMeshRenderers)

                {

                    //item.meshRenderer.transform.position = Vector3.Lerp(item.meshRenderer.transform.position, item.originalPosition, m_ExplosionSpeed);
                    item.meshRenderer.transform.DOMove(item.originalPosition, m_ExplosionSpeed);

                    if (Vector3.Distance(item.meshRenderer.transform.position, item.originalPosition) < 0.001f)

                    {

                        isMoving = false;

                    }

                }

            }

        }

    }


    #endregion


    #region CustomFunctions

    public void AssignNewObject()
    {
        childMeshRenderers = new List<SubMeshes>();


        if (m_ObjectToExplode != null)
        {
            foreach (var item in m_ObjectToExplode.GetComponentsInChildren<MeshRenderer>())

            {

                SubMeshes mesh = new SubMeshes();

                mesh.meshRenderer = item;

                mesh.originalPosition = item.transform.position;

                mesh.explodedPosition = item.bounds.center * 1.5f;

                childMeshRenderers.Add(mesh);

            }
        }
    }


    [ContextMenu("TestMove FUNCTÝON")]
    public void TestMove()
    {
        foreach (var item in childMeshRenderers)

        {

            //item.meshRenderer.transform.position = Vector3.Lerp(item.meshRenderer.transform.position, item.explodedPosition, m_ExplosionSpeed);

            item.meshRenderer.transform.DOMove(item.explodedPosition, m_ExplosionDuration).SetEase(Ease.InOutBounce);
            if (Vector3.Distance(item.meshRenderer.transform.position, item.explodedPosition) < 0.001f)

            {

                isMoving = false;

            }

        }
    }
    [ContextMenu("TestMoveIn FUNCTÝON")]
    public void TestMoveIn()
    {
        foreach (var item in childMeshRenderers)

        {

            //item.meshRenderer.transform.position = Vector3.Lerp(item.meshRenderer.transform.position, item.explodedPosition, m_ExplosionSpeed);

            //item.meshRenderer.transform.DOMove(item.explodedPosition, m_ExplosionDuration);
            item.meshRenderer.transform.DOMove(item.originalPosition, m_ExplosionDuration);
            if (Vector3.Distance(item.meshRenderer.transform.position, item.explodedPosition) < 0.001f)

            {

                isMoving = false;

            }

        }
    }




    [ContextMenu("CheckExplodedView")]
    public void ToggleExplodedView()

    {

        if (isInExplodedView)

        {

            isInExplodedView = false;

            isMoving = true;

        }

        else

        {

            isInExplodedView = true;

            isMoving = true;

        }

    }


    #endregion
}
