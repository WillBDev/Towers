using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour {

    GameObject player;
    Component script;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        player.SetActive(false);
        gameObject.SetActive(true);

    }

    public void PlayGame()
    {
        player.SetActive(true);
        gameObject.SetActive(false);

        
    }
	
}
