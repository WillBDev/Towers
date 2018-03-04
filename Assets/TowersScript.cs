using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TowersScript : MonoBehaviour {

    public GameObject platform;

    public int spreadHorizontal = 10;
    public int spreadVertical = 10;
    public int poolSize = 100;
    private int score;
    List<GameObject> platformList;

    int posZ = 0; //how far the level has been generated

    // Use this for initialization
    void Start()
    {
        InitPlatforms();
    }

    private void InitPlatforms(){
        platformList = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = (GameObject)Instantiate(platform);
            obj.SetActive(false);
            platformList.Add(obj);
        }
    }

	// Update is called once per frame
	void Update () {
        HandleObjectPooling();
	    UpdateScore();
	}

    private void UpdateScore()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (platformList[score].transform.position.z < GameObject.Find("Cube").transform.position.z - 5) // remove platform after player has gone 50units past it
            {
                score++;
                var scoreItem = GameObject.Find("Score").GetComponent<UnityEngine.UI.Text>();
                scoreItem.text = score.ToString();
            }
        }
    }

    private void HandleObjectPooling(){
        for (int i = 0; i < poolSize; i++)
        {
            if (!platformList[i].activeInHierarchy)
            {
                float x = (Random.value - 0.5f) * spreadHorizontal; // random horizontal placement
                float y = (Mathf.PerlinNoise(x * 0.1f, posZ * 0.01f) - 0.5f) * spreadVertical; // smoothes out incline/decline
                platformList[i].transform.position = new Vector3(x, y, posZ += 15);
                platformList[i].SetActive(true);
                break;
            }
        }

        for (int i = 0; i < poolSize; i++)
        {
            if (platformList[i].transform.position.z < GameObject.Find("Cube").transform.position.z - 50) // remove platform after player has gone 50units past it
            {
                platformList[i].SetActive(false);
            }
        }
    }

    private void RemovePlatforms(){
        for (int i = 0; i < poolSize; i++){
            Destroy(platformList[i]);
        }
    }

    public void Reset(){
        RemovePlatforms();
        InitPlatforms();
        score = 0;
        GameObject.Find("Score").GetComponent<UnityEngine.UI.Text>().text = score.ToString();
        posZ = 0;
    }
}
