using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoCamPlayerMove : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground; // asigns layer option to the inspector 
    float xRotation = 0f;
   
   // [SerializeField] AudioSource jumpSound; //the first jump sound is grass or the "default sound"

    //[SerializeField] AudioSource jumpSoundTwo;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
       // Cursor.lockState = CursorLockMode.Locked; //it locks the curser...


    }

    void Update()
    {


        float horizontalInput = Input.GetAxis("Horizontal"); // character movement 
        float verticalInput = Input.GetAxis("Vertical");


        { rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed); }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
           //  rb.velocity = new Vector3 (rb.velocity.x, jumpForce, rb.velocity.z);
            // Debug.Log(IsGrounded());
            Jump();
        }
    }
    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.2f, ground);

    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        //jumpSound.Play();


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();

        }

        if (collision.gameObject.CompareTag("Wood")) // i want it to play a different sound depending on the texture of the object
        {                                              // hopefully this works lol
           // jumpSoundTwo.Play();
        }

    }

}
