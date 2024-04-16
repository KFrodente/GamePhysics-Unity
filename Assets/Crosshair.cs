using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Camera cam;
    public GameObject cannonBall;

    public Vector2 movement;
    public float speed;


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("right");
        movement.y = Input.GetAxisRaw("up");

        transform.localPosition += (transform.right * movement.x * speed) + (transform.up * movement.y * speed);

        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(cannonBall, transform.position, transform.rotation);

        }
    }
}
