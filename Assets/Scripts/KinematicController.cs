using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] Space space = Space.World;
    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;
        float rotation = 0;

        if (space == Space.World) direction.x = Input.GetAxis("Horizontal");
        else
        {
            rotation = Input.GetAxis("Horizontal");
        }

        direction.z = Input.GetAxis("Vertical");
        direction = Vector3.ClampMagnitude(direction, 1);


        transform.rotation *= Quaternion.Euler(0, rotation * speed, 0);
        transform.Translate(direction * speed * Time.deltaTime, space);
    }

    //rgb
    //xyz

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.forward);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.right);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.up);
    }
}
