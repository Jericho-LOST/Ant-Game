using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    // haha i havent made a spawner script in a while

        public GameObject[] objectsToSpawn;

        float timeToNextSpawn;                  //Tracks long we should wait before spawning a new object
        float timeSinceLastSpawn = 0.0f;        //maximum amount of time between spawning objects

        public float minSpawnTime = 0.5f;
        public float maxSpawnTime = 3.0f;

        void Start()
        {
            //random.rage returns a fandom float between two values
            timeToNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);
        }

    // Update is called once per frame
    void Update()
    {

        timeSinceLastSpawn = timeSinceLastSpawn + Time.deltaTime;

        if (timeSinceLastSpawn > timeToNextSpawn)
        {
            int selection = Random.Range(0, objectsToSpawn.Length);

            Instantiate(objectsToSpawn[selection]);

            timeToNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);

            timeSinceLastSpawn = 0.0f;
        }
    }
}
