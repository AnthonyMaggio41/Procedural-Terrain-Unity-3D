using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    // The size of the terrain
    public int terrainWidth = 256;
    public int terrainHeight = 256;

    // The maximum height of the terrain
    public float heightScale = 20.0f;

    // The noise scale of the terrain
    public float noiseScale = 0.3f;

    // The number of octaves of noise to use
    public int octaves = 6;

    // The persistence of the noise
    public float persistence = 0.6f;

    // The lacunarity of the noise
    public float lacunarity = 2.0f;

    // The height offset of the terrain
    public float heightOffset = 0.0f;

    // The seed for the random number generator
    public int seed = 0;

    // The offset of the noise
    public Vector2 offset = Vector2.zero;

    // The terrain object
    private Terrain terrain;

    void Start()
    {
        // Get the terrain component
        terrain = GetComponent<Terrain>();

        // Generate the height map
        GenerateHeightMap();
    }

    void GenerateHeightMap()
    {
        // Create an array to hold the height map
        float[,] heightMap = new float[terrainWidth, terrainHeight];

        // Set the random seed
        Random.InitState(seed);

        // Loop through the height map and apply the Perlin noise
        for (int x = 0; x < terrainWidth; x++)
        {
            for (int y = 0; y < terrainHeight; y++)
            {
                // Get the current height
                float height = 0.0f;

                // Set the initial frequency and amplitude
                float frequency = noiseScale;
                float amplitude = 1.0f;

                // Loop through the octaves
                for (int i = 0; i < octaves; i++)
                {
                    // Get the sample point
                    float sampleX = (x + offset.x) / terrainWidth * frequency;
                    float sampleY = (y + offset.y) / terrainHeight * frequency;

                    // Get the noise value
                    float noise = Mathf.PerlinNoise(sampleX, sampleY) * 2.0f - 1.0f;

                    // Add the noise to the height
                    height += noise * amplitude;

                    // Increase the frequency and decrease the amplitude
                    frequency *= lacunarity;
                    amplitude *= persistence;
                }

                // Set the height of the current point
                heightMap[x, y] = height;
            }
        }

        // Set the height map of the terrain
        terrain.terrainData.SetHeights(0, 0, heightMap);
    }
}
