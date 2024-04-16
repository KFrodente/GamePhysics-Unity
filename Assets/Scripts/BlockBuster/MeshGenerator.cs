using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    Mesh mesh;

    public GameObject ragdoll;

    [SerializeField] MeshCollider mCollider;

    Vector3[] vertices;
    Color[] colors;
    int[] triangles;

    public List<GameObject> layouts = new List<GameObject>();
    [Range(1, 100)] public int spawnRate;

    public int xSize = 20;
    public int zSize = 20;

    private float time;

    [Range(0f, 10f)] public float zoom;
    [Range(0f, 10f)] public float speed;
    [Range(0f, 10f)] public float timeAdder;

    public Gradient gradient;
    public float minTerrainHeight;
    public float maxTerrainHeight;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateMesh();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateMesh();
        }
    }

    public void CreateMesh()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                //float y = Mathf.Sin(time * zoom);
                //float y = Mathf.PerlinNoise(x * zoom + time * speed, z * zoom) * 10;
                float y = Mathf.PerlinNoise(x * zoom + Random.Range(minTerrainHeight, maxTerrainHeight), z * zoom + Random.Range(minTerrainHeight, maxTerrainHeight)) * 10;

                if (y > maxTerrainHeight)
                    maxTerrainHeight = y;
                if (y < minTerrainHeight)
                    minTerrainHeight = y;
                
                vertices[i] = new Vector3(x, y, z);

                int randNum = Random.Range(1, 100);
                if (randNum <= spawnRate)
                {
                    GameObject layout = layouts[Random.Range(0, layouts.Count - 1)];
                    Instantiate(original: layout, new Vector3(vertices[i].x * 2, vertices[i].y + Random.Range(3f, 6f), vertices[i].z * 2), Quaternion.Euler(0, Random.Range(0, 360), 0));
                }


                i++;
                time += timeAdder * Time.deltaTime;
            }

        }

        triangles = new int[xSize * zSize * 6];

        int vert = 0;
        int tris = 0;

        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[tris] = vert;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }


        colors = new Color[vertices.Length];

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float height = Mathf.InverseLerp(minTerrainHeight, maxTerrainHeight, vertices[i].y);
                colors[i] = gradient.Evaluate(height);
                i++;
            }

        }


        UpdateMesh();
    }

    public void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.colors = colors;

        mesh.RecalculateNormals();



        mCollider.sharedMesh = mesh;

    }

}
