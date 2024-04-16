using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour
{

    public float launchForce;

    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * launchForce);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<BBBlock>(out BBBlock block))
        {
            block.GetHit();
        }
    }
}
