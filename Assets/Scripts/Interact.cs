using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    //Add this to player
    //rrmeber to put animations in and create a lil "C to climb" pop up (i'll put that on the climable object script)


    //this was originally just a climb script but i thought it wold be easier to use the same detection radius for picking up
        //ive also separated the two funtions so i wont get confused like the player movement script lmao

 
    //CLIMBING
    public float climbSpeed = 3f;        
    public LayerMask climbableLayer;    // LayerMask to identify climbable walls
    public float detectionRadius = 1.5f; // this is the weird radius circle thing to detect climbable walls

    private Rigidbody rb;        
    private bool isClimbing = false;  


    //PICK UP
    public LayerMask pickupLayer;     //should i do this with tags instead of layers??...CAN i do this with taggs instead of layers??
    private GameObject heldObject;     // Reference to the currently held object
    public Transform holdPoint;        // this will hopefully position the object where we wnt (like the hands or on the back if this is the ant game)
                                            // i need to figure out how to create an inventory smpace thing...
    
    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //CLIMB
        if (Input.GetKey(KeyCode.C) && CanClimb()) //C for climb makes sence, right? 
        {
            StartClimbing();
        }
        else
        {
            StopClimbing(); //took me too long to remember to add this in 
        }

        //PICK UP
        {
            if (Input.GetKeyDown(KeyCode.E)) //using E for pick up does not make sense..
            {
                if (heldObject == null)
                {
                    APickupObject();
                }
                else
                {
                    DropObject();
                }
            }
        }
    }

    //CLIMB.. again
    private bool CanClimb()
    {
        // this checks if the player is near a climbable wall
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius, climbableLayer); //ive typed out "climbable" so many times it doesn't sound like a word anymore T-T
        return hitColliders.Length > 0; //hopefully i can use a similar detection for the 'C to climb notif' script 
    }

    private void StartClimbing()
    {
        isClimbing = true;

        // Disable gravity while climbing 
        rb.useGravity = false;

        // Move the player upward
        rb.velocity = new Vector3(rb.velocity.x, climbSpeed, rb.velocity.z);
    }

    private void StopClimbing()
    {
        if (isClimbing)
        {
            isClimbing = false;

            // Re-enable gravity when climbing stops
            rb.useGravity = true;
        }
    }

    private void OnDrawGizmos() // This is the detection radius 
    {
        // creates a green sphere thing around the player to help visualize the detection radius
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    //PICK UP 
    // 
    void APickupObject()
    {
        // Check for objects within range
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, detectionRadius, pickupLayer))
        {
            // Pick up the object
            PickupObject(hit.collider.gameObject); }
    }

    void PickupObject(GameObject obj) 
    { 
        
        Rigidbody objRigidbody = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false; // i think this disables the physics on the object
            rb.isKinematic = true;
        }

        // Set the object as a child of the hold point
        obj.transform.position = holdPoint.position;
        obj.transform.SetParent(holdPoint);

        heldObject = obj;
    }

    void DropObject()
    {
        if (heldObject != null)
        {
            // Re-enable physics on the object
            Rigidbody rb = heldObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.useGravity = true;
               rb.isKinematic = false;
            }

            // Unparent the object
            heldObject.transform.SetParent(null);
            heldObject = null;
        }
    }
}
//god this scrip got so long T-T
