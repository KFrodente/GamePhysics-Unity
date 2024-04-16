using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAim : MonoBehaviour
{

    [SerializeField] private Transform cannonPivot;
    [SerializeField] private GameObject cannonBall;

    [SerializeField] private float rotationSpeed;

    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            cannonPivot.Rotate(rotationSpeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            cannonPivot.Rotate(-rotationSpeed, 0, 0);
        }

    }
}
