using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Plus4LVL : MonoBehaviour
{//for the portal box on level 2 // last leve;// axolotl lvl
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4); //finishing this at 3:08am so this better work
        }
    }
}
