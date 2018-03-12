using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    public float speed;
    public float jumpVelocity;
    private float startSpeed;
    private float startJump;

    public Vector3 startPos;

    Rigidbody body;

    private bool canJump = true; //bool to ensure you only jump as landing back down

    public AudioClip jumpSound;
    public AudioSource jumpSoundSource;

	// Use this for initialization
	void Start () {
        if (GetComponent<Rigidbody>()) //init ridigbody
            body = GetComponent<Rigidbody>();
        else
            Debug.LogError("no rigidbody attached");

        transform.position = startPos;

        jumpSoundSource.clip = jumpSound;
        startSpeed = speed;
        startJump = jumpVelocity;

	}
	
	// FixedUpdate is called once per physics-frame
	void FixedUpdate () {
        body.velocity = new Vector3(0, body.velocity.y, 0);
        HandleJump();
        HandleMovement();
	}

    private void HandleMovement(){
        //body.velocity += transform.forward * Input.GetAxis("Vertical") * speed;
        body.velocity += transform.right * Input.GetAxis("Horizontal") * speed;
    }

    private void HandleJump(){
        if(canJump){
            if (Input.GetKey("space"))
            {
                body.velocity += new Vector3(0, jumpVelocity, 0);
                canJump = false;
                jumpSoundSource.Play();
            }
        }else{
            canJump = Physics.Raycast(transform.position, Vector3.down, 0.5f); //check for landing; might have to change 0.5f to new radius
        }
    }

    public void Reset()
    {
        transform.position = startPos;
        speed = startSpeed;
        jumpVelocity = startJump;
        body.velocity = Vector3.zero;
        canJump = true;
    }
}
