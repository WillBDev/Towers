using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TowersScript : MonoBehaviour
{

    public GameObject platform;

    public int spreadHorizontal = 10;
    public int spreadVertical = 10;
    public int poolSize = 100;
    public int platformDist = 15;
    private int virtualScore;
    public int score;
    private int bestScore = 0;
    List<GameObject> platformList;
    List<Vector3> platformPositions;

    int numGenerated = 0; //number of platforms generated

    public int getNumGenerated(){
        return numGenerated;
    }

    public List<Vector3> getPlatformPositions()
    {
        return platformPositions;
    }

    // Use this for initialization
    void Start()
    {
        InitPlatforms();
    }

    private void InitPlatforms()
    {
        platformList = new List<GameObject>();
        platformPositions = new List<Vector3>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = (GameObject)Instantiate(platform);
            obj.SetActive(false);
            platformList.Add(obj);

            platformPositions.Add(getNextPosition());
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleObjectPooling();
        UpdateScore();
    }

    private void UpdateScore()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (platformList.Count > virtualScore)
            {
                if (platformList[virtualScore].transform.position.z < GameObject.Find("Cube").transform.position.z - 5 && GameObject.Find("Cube").transform.position.y > 5) // remove platform after player has gone 5 units past it
                {
                    virtualScore++;
                    score++;
                    var scoreItem = GameObject.Find("Score_Text").GetComponent<UnityEngine.UI.Text>();
                    scoreItem.text = score.ToString();
                }
            }
            else
            {
                virtualScore = 0;
            }
        }
    }

    Vector3 getNextPosition()
    {
        numGenerated++;
        float x = (Random.value - 0.5f) * spreadHorizontal; // random horizontal placement
        float y = (Mathf.PerlinNoise(x * 0.1f, numGenerated * 0.1f) - 0.5f) * spreadVertical; // smoothes out incline/decline
        return new Vector3(x, y, numGenerated * platformDist);
    }

    private void HandleObjectPooling()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (!platformList[i].activeInHierarchy)
            {
                platformList[i].transform.position = platformPositions[i];
                platformList[i].SetActive(true);
                break;
            }
        }

        for (int i = 0; i < poolSize; i++)
        {
            if (platformList[i].transform.position.z < GameObject.Find("Cube").transform.position.z - 50) // remove platform after player has gone 50 units past it
            {
                platformPositions[i] = getNextPosition();
                platformList[i].SetActive(false);
            }
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
        numGenerated = 0;
        RemovePlatforms();
        InitPlatforms();
        if (score > bestScore)
        {
            bestScore = score;
        }

        if (GameObject.Find("General UI Script").GetComponent<GeneralUIScript>().deathScreen.active)
        {
            GameObject.Find("Final_Score").GetComponent<UnityEngine.UI.Text>().text = score.ToString();   
        }
        score = 0;
        virtualScore = 0;
        GameObject.Find("Best_Score_Text").GetComponent<UnityEngine.UI.Text>().text = bestScore.ToString();
        GameObject.Find("Score_Text").GetComponent<UnityEngine.UI.Text>().text = score.ToString();
    }
}
