using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] AudioSource deathSound;
    bool dead = false;
 private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Body"))
        {

            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerMovement>().enabled = false;
            Die();
        }
    }
    void Die()
    {
        Invoke(nameof(ReloadLVL), 1.3f);
        dead = true;
    }

 
    private void Update()
    {
        if (transform.position.y <-0.5f && !dead)
            {
            deathSound.Play();
            Die() ;
        }
    }

    void ReloadLVL()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
