using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);    
    }
    //just add a new scene//level and make sure it is placed first in the Build Settings
}
