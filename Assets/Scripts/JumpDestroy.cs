using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDestroy : MonoBehaviour

{
    public string playerTag = "Player" ;  // Tag to identify the player

    void OnCollisionEnter(Collision collision)
    {
       
            if (collision.collider.CompareTag("playerTag"))
            {
              
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<Rigidbody>().isKinematic = true;
                GetComponent<PlayerMovement>().enabled = false;
            Destroy(collision.transform.parent.gameObject); // hopefully this will destroy the pare
        }
     
    }
}

