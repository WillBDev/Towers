using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    public float speed;
    public float jumpVelocity;

    public Vector3 startPos;

    Rigidbody body;

	// Use this for initialization
	void Start () {
        if (GetComponent<Rigidbody>()) //init ridigbody
            body = GetComponent<Rigidbody>();
        else
            Debug.LogError("no rigidbody attached");

        transform.position = startPos;
	}
	
	// FixedUpdate is called once per physics-frame
	void FixedUpdate () {
        body.velocity = new Vector3(0, body.velocity.y, 0);
        handleJump();
        handleMovement();
	}

    private void handleMovement(){
        body.velocity += transform.forward * Input.GetAxis("Vertical") * speed;
        body.velocity += transform.right * Input.GetAxis("Horizontal") * speed;
    }

    private void handleJump(){

        if (Input.GetKey("space") && Physics.Raycast(transform.position, Vector3.down, 0.5f)) //check for landing; might have to change 0.5f to new radius)
        {
            body.velocity += new Vector3(0, jumpVelocity, 0);

        }
    }

    public void reset()
    {
        transform.position = startPos;
        body.velocity = Vector3.zero;
    }
}
