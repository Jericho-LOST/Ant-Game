using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour
{
    public AudioSource press;

    public void StartMiniGame()
    {    press.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }
    //just add a new scene//level and make sure it is placed first in the Build Settings
}