using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraReset : MonoBehaviour {

    Vector3 startPos;
	// Use this for initialization
	void Start () {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Reset()
    {
        transform.position = startPos;
    }
}
