using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBAim : MonoBehaviour
{
    public float moveSpeed;

    public GameObject objectToMove;

    public Transform pivot;

    Vector2 movement = Vector2.zero;

    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        transform.Rotate(0, moveSpeed * -movement.x, 0);

        objectToMove.transform.localPosition = new Vector3(objectToMove.transform.localPosition.x, Mathf.Clamp(objectToMove.transform.localPosition.y + (movement.y * moveSpeed), 1, 10), objectToMove.transform.localPosition.z);
    }
}
