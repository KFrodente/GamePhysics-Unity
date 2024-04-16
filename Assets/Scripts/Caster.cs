using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caster : MonoBehaviour
{
    public enum eType
    {
        Ray,
        Sphere,
        Box
    }

    [SerializeField] private eType type = eType.Ray;
    [SerializeField] private float size;
    [SerializeField] private float distance;
    [SerializeField] LayerMask layerMask = Physics.AllLayers;

    RaycastHit[] hits;

    void Update()
    {
        Vector3 forward = transform.rotation * Vector3.forward;

        switch (type)
        {
            case eType.Ray:
                hits = Physics.RaycastAll(transform.position, transform.forward, distance, layerMask);
                break;
            case eType.Sphere:
                hits = Physics.SphereCastAll(transform.position, size * .5f, transform.forward, distance, layerMask);
                break;
            case eType.Box:
                hits = Physics.BoxCastAll(transform.position, Vector3.one * size * .5f, transform.forward, Quaternion.identity, distance, layerMask);
                break;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        switch (type)
        {
            case eType.Ray:
                Gizmos.DrawRay(transform.position, transform.forward * distance);
                break;
            case eType.Sphere:
                Gizmos.DrawRay(transform.position, transform.forward * distance);
                Gizmos.DrawWireSphere(transform.position + transform.forward * distance, size * .5f);
                break;
            case eType.Box:
                Gizmos.DrawRay(transform.position, transform.forward * distance);
                Gizmos.DrawWireCube(transform.position + transform.forward * distance, Vector3.one * size);
                break;
        }


        if (hits != null)
        {
            Gizmos.color = Color.red;
            foreach(var hit in hits)
            {
                Gizmos.DrawWireCube(hit.collider.transform.position, hit.collider.bounds.size);
            }
        }
    }
}
