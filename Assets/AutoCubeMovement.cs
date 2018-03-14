using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCubeMovement : MonoBehaviour
{

    TowersScript towerScript;
    public Rigidbody rb;
    CharacterController controller;
    float score;

    float tempScore; //store previous score

    public float speedIncrement; //increase speed by this number every time
    public float jumpIncrement; //decrease jump by this number every time (prevent cube from flying forward at high speeds)
    public int levelIncrement; //increase speed every ____ levels
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        GameObject terrain = GameObject.Find("Terrain");
        towerScript = terrain.GetComponent<TowersScript>();
        controller = GetComponent<CharacterController>();

        //speedIncrement = 0.25f;
        //jumpIncrement = 0.25f;
        //levelIncrement = 3;
    }

    //// Update is called once per frame
    void FixedUpdate()
    {
     
        score = towerScript.score;
        if (score % levelIncrement == 0 && score != 0 && tempScore != score)
        {
            controller.speed += speedIncrement;
            controller.jumpVelocity -= jumpIncrement;

        }

        rb.MovePosition(transform.position + transform.forward * controller.speed * Time.deltaTime);
        tempScore = score;
    }



}
