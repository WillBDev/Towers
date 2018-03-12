<<<<<<< HEAD:Assets/GameAssets/Scripts/EndGameChecker.cs
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameChecker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(GameObject.Find("Cube").transform.position.y < -5){
            GameObject.Find("Cube").GetComponent<CharacterController>().Reset();
            GameObject.Find("Terrain").GetComponent<TowersScript>().Reset();
            GameObject.Find("Terrain").GetComponent<RoadGenerator>().Reset();
            GameObject.Find("Main Camera").GetComponent<CameraReset>().Reset();
        }
	}
}
=======
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
            GetComponent<CharacterController>().Reset();
            GameObject.Find("Terrain").GetComponent<TowersScript>().Reset();
            GameObject.Find("Terrain").GetComponent<RoadGenerator>().Reset();
            GameObject.Find("Main Camera").GetComponent<CameraReset>().Reset();
        }
	}
}
>>>>>>> c81ddc33d837054fd449ff8a590ac66e489cca28:Assets/EndGameChecker.cs
