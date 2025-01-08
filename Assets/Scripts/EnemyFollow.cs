using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform target; // creating variable for the trtet object (in this case the player)
                             //is transform the class we use to get an open input in the inspector

    public float Speed; // enemy moved too fast so i'm trying to controll the speed 
    Rigidbody rb; //using this to shorten movement code
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

   
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); //  these two lines are just taken from player movement, they each controll and direct the speed
        float verticalInput = Input.GetAxis("Vertical");


        transform.position = Vector3.MoveTowards(this.transform.position, target.position, 5*Time.deltaTime); //trying to ajust the time so it's slower T_T
        rb.velocity = new Vector3(horizontalInput * Speed, rb.velocity.y, verticalInput * Speed);
    }
}
