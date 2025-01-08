using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{

    [SerializeField] AudioSource levelSounds;


    // Start is called before the first frame update
    void Start()
    {
       levelSounds.Play();
    }
}
