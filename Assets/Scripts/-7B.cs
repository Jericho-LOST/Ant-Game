using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BacktoMenu : MonoBehaviour
{
    public AudioSource press; //hehe lil button sounds
    public void okg()
    {

        press.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 7);
    }
   //feel like i shouldn't be making this many button scripts...
}