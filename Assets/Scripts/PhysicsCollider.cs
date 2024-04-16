using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCollider : MonoBehaviour
{
    private string status;
    private Vector3 contact;
    private Vector3 normal;

    [SerializeField] private GameObject explosion;

    private void OnCollisionEnter(Collision collision)
    {
        status = "Collision enter: " + collision.gameObject.name;
        contact = collision.GetContact(0).point;
        normal = collision.GetContact(0).normal;

        Instantiate(explosion, contact, Quaternion.LookRotation(normal));
    }

    private void OnCollisionStay(Collision collision)
    {
        status = "Collision stay: " + collision.gameObject.name;
        contact = collision.GetContact(0).point;
        normal = collision.GetContact(0).normal;
    }

    private void OnCollisionExit(Collision collision)
    {
        status = "Collision exit: " + collision.gameObject.name;
        contact = collision.GetContact(0).point;
        normal = collision.GetContact(0).normal;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        status = "Trigger enter: " + other.gameObject.name;
    }

    private void OnTriggerStay(Collider other)
    {
        status = "Trigger stay: " + other.gameObject.name;
    }

    private void OnTriggerExit(Collider other)
    {
        status = "Trigger exit: " + other.gameObject.name;
    }


    private void OnGUI()
    {
        GUI.skin.label.fontSize = 20;
        Vector2 screen = Camera.main.WorldToScreenPoint(transform.position);
        GUI.Label(new Rect(screen.x, Screen.height - screen.y, 250, 70), status);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(contact, 0.1f);
        Gizmos.DrawLine(contact, contact + normal);
    }
}
