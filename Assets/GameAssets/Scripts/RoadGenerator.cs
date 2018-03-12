using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{

    public GameObject dot;

    public int width;
    public int minDistFromTower = 5;
    public int roadRightMost = 100;
    public int roadLeftMost = 100;
    List<Vector3> roadVerticiesRight;
    List<Vector3> roadVerticiesLeft;
    List<GameObject> roadDots;

    int numGenerated = 0; //how far the road has been generated

    Mesh mesh;

    // Use this for initialization
    void Start()
    {
        InitVerticies();
        roadDots = new List<GameObject>();
    }

    private void InitVerticies()
    {
        //initialized the verticies for the left and right roads
        roadVerticiesRight = new List<Vector3>();
        roadVerticiesLeft = new List<Vector3>();
        for (int i = 0; i < GetComponent<TowersScript>().poolSize * 4; i++)
        {
            roadVerticiesRight.Add(new Vector3());
            roadVerticiesLeft.Add(new Vector3());
        }
    }

    Vector3 getNextPlatformPositionRight()
    {

        int head = numGenerated % GetComponent<TowersScript>().poolSize;

        List<Vector3> platformPositions = GetComponent<TowersScript>().getPlatformPositions();
        float minX = platformPositions[head].x + minDistFromTower;
        float maxX = roadRightMost;
        float posX = (Random.value * (maxX - minX)) + minX;

        return new Vector3(posX, 0, platformPositions[head].z);
    }

    Vector3 getNextPlatformPositionLeft()
    {

        int head = numGenerated % GetComponent<TowersScript>().poolSize;

        List<Vector3> platformPositions = GetComponent<TowersScript>().getPlatformPositions();
        float maxX = platformPositions[head].x - minDistFromTower;
        float minX = roadLeftMost;
        float posX = (Random.value * (maxX - minX)) + minX;

        return new Vector3(posX, 0, platformPositions[head].z);
    }

    // Update is called once per frame
    void Update()
    {
        generateVerticies();
    }

    private void generateVerticies()
    {

        bool changed = false;

        while (numGenerated < GetComponent<TowersScript>().getNumGenerated())
        {
            //instantiate left-Verticies

            int head = numGenerated % GetComponent<TowersScript>().poolSize;

            Vector3 pos = getNextPlatformPositionRight();
            float tower_length = GetComponent<TowersScript>().platform.GetComponent<BoxCollider>().size.z;

            Vector3 posDownLeft = new Vector3(pos.x, 0, pos.z - tower_length / 2);
            Vector3 posUpLeft = new Vector3(pos.x, 0, pos.z + tower_length / 2);
            Vector3 posDownRight = new Vector3(pos.x + width, 0, pos.z - tower_length / 2);
            Vector3 posUpRight = new Vector3(pos.x + width, 0, pos.z + tower_length / 2);
            roadVerticiesRight[head * 4] = posDownLeft;
            roadVerticiesRight[head * 4 + 1] = posDownRight;
            roadVerticiesRight[head * 4 + 2] = posUpLeft;
            roadVerticiesRight[head * 4 + 3] = posUpRight;

            GameObject obj = Instantiate(dot);
            obj.transform.position = new Vector3((posDownLeft.x + posDownRight.x) / 2, 0f, posDownLeft.z + GameObject.Find("Terrain").transform.position.z);
            roadDots.Add(obj);
            obj = Instantiate(dot);
            obj.transform.position = new Vector3((posUpLeft.x + posUpRight.x) / 2, 0f, posUpLeft.z + GameObject.Find("Terrain").transform.position.z);
            roadDots.Add(obj);


            pos = getNextPlatformPositionLeft();
            posDownRight = new Vector3(pos.x, 0, pos.z - tower_length / 2);
            posUpRight = new Vector3(pos.x, 0, pos.z + tower_length / 2);
            posDownLeft = new Vector3(pos.x - width, 0, pos.z - tower_length / 2);
            posUpLeft = new Vector3(pos.x - width, 0, pos.z + tower_length / 2);
            roadVerticiesLeft[head * 4] = posDownLeft;
            roadVerticiesLeft[head * 4 + 1] = posDownRight;
            roadVerticiesLeft[head * 4 + 2] = posUpLeft;
            roadVerticiesLeft[head * 4 + 3] = posUpRight;

            obj = Instantiate(dot);
            obj.transform.position = new Vector3((posDownLeft.x + posDownRight.x) / 2, 0f, posDownLeft.z + GameObject.Find("Terrain").transform.position.z);
            roadDots.Add(obj);
            obj = Instantiate(dot);
            obj.transform.position = new Vector3((posUpLeft.x + posUpRight.x) / 2, 0f, posUpLeft.z + GameObject.Find("Terrain").transform.position.z);
            roadDots.Add(obj);

            numGenerated++;
            changed = true;
        }

        if (changed)
            generateMesh();
    }

    void generateMesh()
    {

        mesh = GetComponent<MeshFilter>().mesh;

        mesh.Clear();
        List<Vector3> list1 = new List<Vector3>(roadVerticiesRight);
        List<Vector3> temp = list1.GetRange(0, numGenerated % GetComponent<TowersScript>().poolSize * 4);
        list1.RemoveRange(0, numGenerated % GetComponent<TowersScript>().poolSize * 4);
        list1.AddRange(temp);


        List<Vector3> list2 = new List<Vector3>(roadVerticiesLeft);
        temp = list2.GetRange(0, numGenerated % GetComponent<TowersScript>().poolSize * 4);
        list2.RemoveRange(0, numGenerated % GetComponent<TowersScript>().poolSize * 4);
        list2.AddRange(temp);
        List<Vector3> tempList = new List<Vector3>();
        tempList.AddRange(list1);
        tempList.AddRange(list2);

        mesh.vertices = tempList.ToArray();

        int[] triangles = new int[(GetComponent<TowersScript>().poolSize * 4 - 2) * 6];

        for (int ti = 0, vi = 0, x = 0; x < GetComponent<TowersScript>().poolSize * 2 - 1; x++, ti += 6, vi += 2)
        {
            triangles[ti] = vi;
            triangles[ti + 3] = triangles[ti + 2] = vi + 1;
            triangles[ti + 4] = triangles[ti + 1] = vi + 2;
            triangles[ti + 5] = vi + 3;
        }


        for (int ti = (GetComponent<TowersScript>().poolSize * 4 - 2) * 3, vi = GetComponent<TowersScript>().poolSize * 4, x = 0; x < GetComponent<TowersScript>().poolSize * 2 - 1; x++, ti += 6, vi += 2)
        {
            triangles[ti] = vi;
            triangles[ti + 3] = triangles[ti + 2] = vi + 1;
            triangles[ti + 4] = triangles[ti + 1] = vi + 2;
            triangles[ti + 5] = vi + 3;
        }

        mesh.triangles = triangles;

    }

    public void Reset()
    {
        numGenerated = 0;

        for (int i = 0; i < roadDots.Count; i++)
            Destroy(roadDots[i]);

        roadDots = new List<GameObject>();
        InitVerticies();
    }
}
