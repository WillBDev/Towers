﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameChecker : MonoBehaviour {


	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if(transform.position.y <= 0){
	        GameObject.Find("General UI Script").GetComponent<GeneralUIScript>().deathScreen.SetActive(true);
            GetComponent<CharacterController>().Reset();
            GameObject.Find("Terrain").GetComponent<TowersScript>().Reset();
            GameObject.Find("Terrain").GetComponent<RoadGenerator>().Reset();
            GameObject.Find("Main Camera").GetComponent<CameraReset>().Reset();
	        GameObject.Find("General UI Script").GetComponent<GeneralUIScript>().player.SetActive(false);
        }
	}
}
