using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour

{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy Body"))
        {
            Destroy(collision.gameObject);
        }
    }

}
