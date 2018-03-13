using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{
    public float flySpeed;
    public float maxDistance = 20;

    Vector3 startPos;

    // Use this for initialization
    void Start()
    {
        Vector3 temp = GameObject.Find("Cube").transform.position;
        //startPos = new Vector3(temp.x, temp.y + 5.5f, temp.z - 11f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y,GameObject.Find("Cube").transform.position.z - maxDistance);
    }

    public void Reset()
    {
        transform.position = startPos;
    }
}