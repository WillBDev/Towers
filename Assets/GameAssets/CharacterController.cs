using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD:Assets/GameAssets/CharacterController.cs
public class CharacterController : MonoBehaviour {
=======
public class CharacterController : MonoBehaviour
{
>>>>>>> c81ddc33d837054fd449ff8a590ac66e489cca28:Assets/CharacterController.cs

    public float speed;
    public float jumpVelocity;
    private float startSpeed;
    private float startJump;

    public Vector3 startPos;

    Rigidbody body;

    private bool canJump = true; //bool to ensure you only jump as landing back down

<<<<<<< HEAD:Assets/GameAssets/CharacterController.cs
    public AudioClip jumpSound;
    public AudioSource jumpSoundSource;

	// Use this for initialization
	void Start () {
        if (GetComponent<Rigidbody>()) //init ridigbody
=======
    Animator anim;
    int jumpHash = Animator.StringToHash("Jump_Rotate");
    int idleHash = Animator.StringToHash("Idle");

    public AudioClip jumpSound;
    public AudioSource jumpSoundSource;

    // Use this for initialization
    void Start()
    {
        if (GetComponent<Rigidbody>() != null) //init ridigbody
>>>>>>> c81ddc33d837054fd449ff8a590ac66e489cca28:Assets/CharacterController.cs
            body = GetComponent<Rigidbody>();
        else
            Debug.LogError("no rigidbody attached");

        transform.position = startPos;

        jumpSoundSource.clip = jumpSound;
        startSpeed = speed;
        startJump = jumpVelocity;

<<<<<<< HEAD:Assets/GameAssets/CharacterController.cs
	}
	
	// FixedUpdate is called once per physics-frame
	void FixedUpdate () {
        body.velocity = new Vector3(0, body.velocity.y, 0);
        HandleJump();
        HandleMovement();
	}

    private void HandleMovement(){
=======
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
>>>>>>> c81ddc33d837054fd449ff8a590ac66e489cca28:Assets/CharacterController.cs
        //body.velocity += transform.forward * Input.GetAxis("Vertical") * speed;
        body.velocity += transform.right * Input.GetAxis("Horizontal") * speed;
    }

<<<<<<< HEAD:Assets/GameAssets/CharacterController.cs
    private void HandleJump(){
        if(canJump){
=======

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

>>>>>>> c81ddc33d837054fd449ff8a590ac66e489cca28:Assets/CharacterController.cs
            if (Input.GetKey("space"))
            {
                body.velocity += new Vector3(0, jumpVelocity, 0);
                canJump = false;
                jumpSoundSource.Play();
<<<<<<< HEAD:Assets/GameAssets/CharacterController.cs
            }
        }else{
            canJump = Physics.Raycast(transform.position, Vector3.down, 0.5f); //check for landing; might have to change 0.5f to new radius
        }
    }

=======

                anim.SetTrigger(jumpHash);
            }
        }
    }


>>>>>>> c81ddc33d837054fd449ff8a590ac66e489cca28:Assets/CharacterController.cs
    public void Reset()
    {
        transform.position = startPos;
        speed = startSpeed;
        jumpVelocity = startJump;
        body.velocity = Vector3.zero;
        canJump = true;
    }
}
