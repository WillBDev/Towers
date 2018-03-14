using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralUIScript : MonoBehaviour {

    public GameObject deathScreen;
    public GameObject mainMenu;
    public GameObject player;
    public GameObject gameUI;
	// Use this for initialization
	void Start () {
        deathScreen = GameObject.Find("Death Screen");
        mainMenu = GameObject.Find("Main Menu");
        player = GameObject.Find("Player");
        gameUI = GameObject.Find("GameUI");
        player.SetActive(false);
        deathScreen.SetActive(false);
        gameUI.SetActive(false);

    }
	
    public void GoToMainMenu()
    {
        deathScreen.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void PlayGame()
    {
        mainMenu.SetActive(false);
        gameUI.SetActive(true);
        player.SetActive(true);
    }

    public void Respawn()
    {
        deathScreen.SetActive(false);
        player.SetActive(true);
        GameObject.Find("Terrain").GetComponent<TowersScript>().Reset();
        player.GetComponent<CharacterController>().Reset();
        GameObject.Find("Terrain").GetComponent<TowersScript>().Reset();
        GameObject.Find("Terrain").GetComponent<RoadGenerator>().Reset();
        GameObject.Find("Main Camera").GetComponent<CameraReset>().Reset();
    }


}
