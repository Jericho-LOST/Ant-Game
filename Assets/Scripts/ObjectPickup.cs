using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    //lmao attempt 3

    public Transform holdPoint;        // The position where the object will be held
    public float pickupRange = 2f;     // Maximum range to pick up objects
    public LayerMask pickupLayer;      // Layer mask for pickupable objects

    private GameObject heldObject;     // Reference to the currently held object

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null)
            {
                TryPickupObject();
            }
            else
            {
                DropObject();
            }
        }
    }


    void TryPickupObject()
    {
        // Check for objects within range
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, pickupRange, pickupLayer))
        {
            // Pick up the object
            PickupObject(hit.collider.gameObject);
        }
    }

    void PickupObject(GameObject obj)
    {
        // Disable physics on the object
        Rigidbody objRigidbody = obj.GetComponent<Rigidbody>();
        if (objRigidbody != null)
        {
            objRigidbody.useGravity = false;
            objRigidbody.isKinematic = true;
        }

        // this sets the object as a child of the hold point (i need to figure out why this is )
        obj.transform.position = holdPoint.position;
        obj.transform.SetParent(holdPoint);

        heldObject = obj;
    }

    void DropObject()
    {
        if (heldObject != null)
        {
            // Re-enable physics on the object
            Rigidbody objRigidbody = heldObject.GetComponent<Rigidbody>();
            if (objRigidbody != null)
            {
                objRigidbody.useGravity = true;
                objRigidbody.isKinematic = false;
            }

            // Unparent the object
            heldObject.transform.SetParent(null);
            heldObject = null;
        }
    }
}
