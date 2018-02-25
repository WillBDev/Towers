using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameChecker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(GameObject.Find("Cube").transform.position.y < -5){
            GameObject.Find("Cube").GetComponent<CharacterController>().reset();
            GameObject.Find("Plane").GetComponent<TowersScript>().reset();
            GameObject.Find("Main Camera").GetComponent<CameraMovementScript>().reset();
        }
	}
}
