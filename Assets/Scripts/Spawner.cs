using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject ragdoll;
    [SerializeField] KeyCode spawnKey;

    private void Update()
    {
        if (Input.GetKey(spawnKey))
        {
            Instantiate(original: ragdoll, transform.position, transform.rotation);
        }
    }
}
