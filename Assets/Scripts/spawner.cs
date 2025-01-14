using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //create a public array of objects to spawn, we will fill this up using the unity editor (i won't really need more than 1 tho )
    public GameObject[] objectsToSpawn;

    float timeToNextSpawn;                  //Tracks long we should wait before spawning a new object
    float timeSinceLastSpawn = 0.0f;        //maximum amount of time between spawning objects

    public float minSpawnTime = 0.5f;
    public float maxSpawnTime = 3.0f;

    void Start()
    {
        //random.rage returns a fandom float between two values
        timeToNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);

        //should create a position between -10 to 10 on the y-axis so it can stay on one axiss
        float Pos = Random.Range(0.0f, -10.0f);
        Vector3 randomPosition = new Vector3(0, Pos, 0);





        // (new Vector3(0, 17));

        // i want to try "variable".transform.translate(new Vector3(0, 17)); or a version of it as a way of making platforms spawn directly below each other
    }

    void Update()
    {
        timeSinceLastSpawn = timeSinceLastSpawn + Time.deltaTime;

        if (timeSinceLastSpawn > timeToNextSpawn)
        {
            int selection = Random.Range(0, objectsToSpawn.Length);

            Instantiate(objectsToSpawn[selection], transform.position, Quaternion.identity);
            timeToNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);
            timeSinceLastSpawn = 0.0f;
        }
    }
}

// Instantiate the object at the spawn position
//Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

