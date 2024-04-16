using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGLauncher : MonoBehaviour
{
    public float launchForce;
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * launchForce, ForceMode.Impulse);
    }
}
