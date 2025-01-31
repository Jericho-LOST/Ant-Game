using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNewLevel: MonoBehaviour
{
    public AudioSource press;
    
    public void MiniGameCatch()
    {press.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
    //just add a new scene//level and make sure it is placed first in the Build Settings
}