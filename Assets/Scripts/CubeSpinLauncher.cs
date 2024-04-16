using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CubeSpinLauncher : MonoBehaviour
{
    [SerializeField] private GameObject ragdoll;
    [SerializeField] private int spawnAmount;

    private Transform spawnPos;

    private Rigidbody rb;
    private bool startForces = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawnPos = transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(SpawnRagdolls());
        }

        if (startForces)
        {
            rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            rb.AddTorque(Vector3.up * 10, ForceMode.Impulse);
        }
    }

    private IEnumerator SpawnRagdolls()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            Instantiate(ragdoll, new Vector3(spawnPos.position.x + Random.Range(-1.5f, 1.5f), spawnPos.position.y + Random.Range(15f, 17.5f), spawnPos.position.z + Random.Range(-1.5f, 1.5f)), Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
        }
        yield return new WaitForSeconds(Random.Range(.5f, 1f));
        startForces = true;

    }
}
