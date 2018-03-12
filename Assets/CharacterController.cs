using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public float speed;
    public float jumpVelocity;
    private float startSpeed;
    private float startJump;

    public Vector3 startPos;

    Rigidbody body;

    private bool canJump = true; //bool to ensure you only jump as landing back down

    Animator anim;
    int jumpHash = Animator.StringToHash("Jump_Rotate");
    int idleHash = Animator.StringToHash("Idle");

    public AudioClip jumpSound;
    public AudioSource jumpSoundSource;

    // Use this for initialization
    void Start()
    {
        if (GetComponent<Rigidbody>() != null) //init ridigbody
            body = GetComponent<Rigidbody>();
        else
            Debug.LogError("no rigidbody attached");

        transform.position = startPos;

        jumpSoundSource.clip = jumpSound;
        startSpeed = speed;
        startJump = jumpVelocity;

        anim = GameObject.Find("Cube").GetComponent<Animator>();
    }

    // FixedUpdate is called once per physics-frame
    void FixedUpdate()
    {
        body.velocity = new Vector3(0, body.velocity.y, 0);
        HandleJump();
        HandleMovement();
    }

    private void HandleMovement()
    {
        //body.velocity += transform.forward * Input.GetAxis("Vertical") * speed;
        body.velocity += transform.right * Input.GetAxis("Horizontal") * speed;
    }


    private void HandleJump()
    {

        canJump = false;

        if (Physics.Raycast(transform.position - new Vector3(0.5f, 0, 0.5f), Vector3.down, 0.6f))
            canJump = true; //check for landing; might have to change 0.5f to new radius
        else if (Physics.Raycast(transform.position - new Vector3(0.5f, 0, -0.5f), Vector3.down, 0.6f))
            canJump = true; //check for landing; might have to change 0.5f to new radius
        else if (Physics.Raycast(transform.position - new Vector3(-0.5f, 0, 0.5f), Vector3.down, 0.6f))
            canJump = true; //check for landing; might have to change 0.5f to new radius
        else if (Physics.Raycast(transform.position - new Vector3(0.5f, 0, -0.5f), Vector3.down, 0.6f))
            canJump = true; //check for landing; might have to change 0.5f to new radius

        if (canJump == true) { 
            anim.SetTrigger(idleHash);

            if (Input.GetKey("space"))
            {
                body.velocity += new Vector3(0, jumpVelocity, 0);
                canJump = false;
                jumpSoundSource.Play();

                anim.SetTrigger(jumpHash);
            }
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
