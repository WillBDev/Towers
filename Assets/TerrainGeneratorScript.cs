using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGeneratorScript : MonoBehaviour {

    public GameObject road;

    public int width;
    public int minDistFromTower = 5;
    public int roadRightMost = 100;
    List<Vector2> roadVerticies;

    int posZ = 0; //how far the terrain has been generated

    // Use this for initialization
    void Start()
    {
        InitVerticies();
    }

    private void InitVerticies()
    {
        roadVerticies = new List<Vector2>();
    }

    Vector3 getNextPlatformPosition()
    {
        float x = (Random.value - 0.5f) * spreadHorizontal; // random horizontal placement
        float y = (Mathf.PerlinNoise(x * 0.1f, posZ * 0.01f) - 0.5f) * spreadVertical; // smoothes out incline/decline
        posZ += GetComponent<TowersScript>().distIncrement;

        return new Vector3(x, y, posZ);
    }

    // Update is called once per frame
    void Update()
    {
        generateVerticies();
    }

    private void generateVerticies()
    {

        int head = GetComponent<TowersScript>().getHead();

        while (posZ < GetComponent<TowersScript>().getPosZ())
        {
            //instantiate left-Verticies
            List<Vector3> platformPositions = GetComponent<TowersScript>().getPlatformPositions();
            float minX = platformPositions[head].x;
            float maxX = roadRightMost;
            float posX = (Random.value * (maxX - minX)) + minX;
            float tower_length = GetComponent<TowersScript>().platform.GetComponent<Collider>().bounds.size.y;
            roadVerticies.Add(new Vector2(posX, platformPositions[i].y - tower_length / 2));
            roadVerticies.Add(new Vector2(posX, platformPositions[i].y + tower_length / 2));
            posZ += GetComponent<TowersScript>().distIncrement;
        }
    }

    private void RemovePlatforms()
    {
        for (int i = 0; i < poolSize; i++)
        {
            Destroy(platformList[i]);
        }
    }

    public void Reset()
    {
        RemovePlatforms();
        posZ = 0;
        InitPlatforms();
    }
}
