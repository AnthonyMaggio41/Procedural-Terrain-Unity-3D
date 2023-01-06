using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class MeshGenerator : MonoBehaviour
{
    // The size of the mesh
    public int width = 256;
    public int height = 256;

    // The maximum height of the mesh
    public float heightScale = 20.0f;

    // The amplitude of the noise
    public float amplitude = 1.0f;

    // The noise scale of the mesh
    public float noiseScale = 0.3f;

    // The number of octaves of noise to use
    public int octaves = 6;

    // The persistence of the noise
    public float persistence = 0.6f;

    // The lacunarity of the noise
    public float lacunarity = 2.0f;

    // The height offset of the mesh
    public float heightOffset = 0.0f;

    // The seed for the random number generator
    public int seed = 0;

    // The offset of the noise
    public Vector2 offset = Vector2.zero;

    // The mesh object
    private Mesh mesh;

    // The lists of vertices and triangles
    private List<Vector3> vertices;
    private List<int> triangles;

    void Start()
    {
        // Create a new mesh
        mesh = new Mesh();

        // Set the mesh on the game object
        GetComponent<MeshFilter>().mesh = mesh;

        // Add a MeshCollider component to the game object
        MeshCollider collider = gameObject.AddComponent<MeshCollider>();

        // Generate the mesh
        GenerateMesh();

        // Set the mesh on the MeshCollider
        collider.sharedMesh = mesh;
    }

    void GenerateMesh()
    {
        // Create lists to hold the vertices and triangles of the mesh
        vertices = new List<Vector3>();
        triangles = new List<int>();

        // Set the random seed
        Random.InitState(seed);

        // Loop through the mesh and apply the Perlin noise
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Get the current vertex
                Vector3 vertex = new Vector3(x, 0, y);

                // Set the initial frequency and amplitude
                float frequency = noiseScale;
                float amplitude = 1.0f;

                // Loop through the octaves
                for (int i = 0; i < octaves; i++)
                {
                    // Get the sample point
                    float sampleX = (x + offset.x) / width * frequency;
                    float sampleY = (y + offset.y) / height * frequency;

                    // Get the noise value
                    float noise = Mathf.PerlinNoise(sampleX, sampleY) * 2.0f - 1.0f;

                    // Add the noise to the height
                    vertex.y += noise * amplitude;

                    // Increase the frequency and decrease the amplitude
                    frequency *= lacunarity;
                    amplitude *= persistence;
                }

                // Set the height of the current vertex
                vertex.y = vertex.y * heightScale + heightOffset;

                // Add the vertex to the list
                vertices.Add(vertex);

                // Create the triangles for the current quad
                if (x < width - 1 && y < height - 1)
                {
                    int a = x + y * width;
                    int b = x + (y + 1) * width;
                    int c = (x + 1) + (y + 1) * width;
                    int d = (x + 1) + y * width;

                    triangles.Add(a);
                    triangles.Add(b);
                    triangles.Add(c);
                    triangles.Add(a);
                    triangles.Add(c);
                    triangles.Add(d);
                }
            }
        }

        // Set the vertices and triangles on the mesh
        mesh.SetVertices(vertices);
        mesh.SetTriangles(triangles, 0);

        // Recalculate the normals
        mesh.RecalculateNormals();
    }
}
