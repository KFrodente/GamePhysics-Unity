using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    [SerializeField] private float turnSpeed;

    [SerializeField] private float moveSpeed;

    private Vector3 force = Vector3.zero;
    private Vector3 torque = Vector3.zero;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float rotation = 0;
        Vector3 direction = Vector3.zero;
        
        rotation = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");


        force = direction * moveSpeed;
        torque = Vector3.up * rotation * turnSpeed;
        
    }

    private void FixedUpdate()
    {
        rb.AddRelativeForce(force);
        rb.AddTorque(torque);
    }
}
