using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1); // this moves on to the next level acording to the order of the scene manager...i want to go back to spawn point though
        }
    }
}
