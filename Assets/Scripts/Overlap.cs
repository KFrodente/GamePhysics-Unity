using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlap : MonoBehaviour
{
    public enum eType
    {
        BoundingBox,
        Sphere
    }

    [SerializeField] private eType type;
    [SerializeField] private float size;
    [SerializeField] private LayerMask layerMask = Physics.AllLayers;

    private Collider[] colliders;

    void Update()
    {
        switch (type)
        {
            case eType.BoundingBox:
                colliders = Physics.OverlapBox(transform.position, Vector3.one * size * .5f, Quaternion.identity, layerMask);
                break;
            case eType.Sphere:
                colliders = Physics.OverlapSphere(transform.position, size * .5f, layerMask);
                break;
        }

        if (Input.GetKey(KeyCode.J))
        {
            Physics.gravity = new Vector3(0, 10, 0);
        }
        else
        {
            Physics.gravity = new Vector3(0, -9.81f, 0);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        switch (type)
        {
            case eType.BoundingBox:
                Gizmos.DrawWireCube(transform.position, Vector3.one * size);
                break;
            case eType.Sphere:
                Gizmos.DrawWireSphere(transform.position, size * 0.5f);
                break;
        }

        Gizmos.color = Color.red;
        if (colliders != null)
        {
            foreach (var collider in colliders)
            {
                Gizmos.DrawWireCube(collider.bounds.center, collider.bounds.size);
            }
        }
    }
}