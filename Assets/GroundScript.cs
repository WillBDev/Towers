using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 winter_pos = GameObject.Find("Cube").transform.position;
        transform.position = new Vector3(winter_pos.x, -0.5f, winter_pos.z);
	}
}
