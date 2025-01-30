using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect : MonoBehaviour
{
    int coins = 0;

    [SerializeField] Text coinsText;
   //public GameObject zero; //this is such a small detail no onw will ever notice it lmao
    [SerializeField] Text McoinsText;
    [SerializeField] AudioSource coinSound;
    [SerializeField] AudioSource coinSound2;

 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
           coinSound.Play();
            Destroy(other.gameObject);
            coins++;
           coinsText.text = "Fruits:" + coins; 
        }
        if (other.gameObject.CompareTag("MegaCoin"))
        {

         
            coinSound2.Play();
            Destroy(other.gameObject);
            coins++;
            McoinsText.text = "Rare Fruits: " + coins;
         
        }

        }
}
