using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CarController;

public class CarController : MonoBehaviour
{
    [System.Serializable]
    public struct Wheel
    {
        public WheelCollider collider;
        public Transform transform;
    }

    [System.Serializable]
    public struct Axle
    {
        public Wheel leftWheel;
        public Wheel rightWheel;
        public bool isMotor;
        public bool isSteering;
    }

    [SerializeField] Axle[] axles;
    [SerializeField] float maxMotorTorque;
    [SerializeField] float maxSteeringAngle;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 20000, ForceMode.Impulse);
        }
    }

    public void FixedUpdate()
    {
        float motor = Input.GetAxis("Vertical") * maxMotorTorque;
        float steering = Input.GetAxis("Horizontal") * maxSteeringAngle;

        foreach (Axle axle in axles)
        {
            if (axle.isSteering)
            {
                axle.leftWheel.collider.steerAngle = steering;
                axle.rightWheel.collider.steerAngle = steering;
            }

            if (axle.isMotor)
            {
                axle.leftWheel.collider.motorTorque = motor;
                axle.rightWheel.collider.motorTorque = motor;
            }

            UpdateWheelTransform(axle.leftWheel);
            UpdateWheelTransform(axle.rightWheel);
        }
    }

    public void UpdateWheelTransform(Wheel wheel)
    {
        wheel.collider.GetWorldPose(out Vector3 position, out Quaternion rotation);

        wheel.transform.position = position;
        wheel.transform.rotation = rotation;
    }
}
