using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CreditsRoll : MonoBehaviour

//"huh, you actually finished, good job" (back to main menu buttton)
{

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 5);
    }
    //just add a new scene//level and make sure it is placed first in the Build Settings
}
