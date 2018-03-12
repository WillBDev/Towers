<<<<<<< HEAD:Assets/GameAssets/Scripts/CameraMovementScript.cs
﻿using System;
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
        if (GameObject.Find("Cube").transform.position.z > transform.position.z + maxDistance)
        {
            //is player to far away, speed up camera
            transform.position = new Vector3(transform.position.x, transform.position.y,GameObject.Find("Cube").transform.position.z - maxDistance);
        }
        else //regular; move camera
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + int.Parse(GameObject.Find("Score").GetComponent<UnityEngine.UI.Text>().text) * Time.deltaTime);
        }
    }

    public void Reset()
    {
        transform.position = startPos;
    }
=======
﻿using System;
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
>>>>>>> c81ddc33d837054fd449ff8a590ac66e489cca28:Assets/CameraMovementScript.cs
}