using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class SceneController : MonoBehaviour
{
    public float frequency;
    public float minSpawn;
    public float maxSpawn;
    public float ySpawn;
    //list of Falling Objects to choose from
    public GameObject[] fallingObjects = new GameObject[4];
    //list of PowerUps
    public GameObject[] powerUps = new GameObject[3];
    //player
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnEnemy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnEnemy() 
    {

        float xSpawn, xSpawnPowerups;

        Vector3 spawnPosition;

        while(true) 
        {
            yield return new WaitForSeconds(1.0f / frequency);

            xSpawn = UnityEngine.Random.Range(minSpawn, maxSpawn);

            spawnPosition = new Vector3(xSpawn, ySpawn, 0);

            //get random number
            int num = UnityEngine.Random.Range(0, 4);
            Instantiate(fallingObjects[num], spawnPosition, Quaternion.identity);

            //spawn PowerUp
            //int rand = UnityEngine.Random.Range(0, 10);
            int rand = 5;
            if (rand == 5)
            {

                xSpawnPowerups = UnityEngine.Random.Range(minSpawn, maxSpawn);
                while (xSpawnPowerups <= xSpawn + 2 && xSpawnPowerups >= xSpawn - 2) {
                    xSpawnPowerups = UnityEngine.Random.Range(minSpawn, maxSpawn);
                }

                    spawnPosition = new Vector3(xSpawnPowerups, ySpawn, 0);

                num = UnityEngine.Random.Range(0, 3);
                Instantiate(powerUps[num], spawnPosition, Quaternion.identity);
            }
        }
    }
}
