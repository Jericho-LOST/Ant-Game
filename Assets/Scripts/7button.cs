using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsLevel : MonoBehaviour
{
    public AudioSource press;
    
    public void gg()
    {press.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 7);
    }
    //just add a new scene//level and make sure it is placed first in the Build Settings
}