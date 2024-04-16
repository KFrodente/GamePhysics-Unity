using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class BBBlock : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float pointValue;

    private bool beenHit = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    public void GetHit()
    {
        if (!beenHit)
        {
            beenHit = true;
            rb.useGravity = true;
            Score.instance.score += pointValue;
        }
    }
}
