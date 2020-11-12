using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class SceneController : MonoBehaviour
{
    //public GameObject fallingObject;
    public float frequency;
    public float minSpawn;
    public float maxSpawn;
    //list of Falling Objects to choose from
    public GameObject[] fallingObjects = new GameObject[4];

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

        float ySpawn = 7.5f;
        float xSpawn;

        Vector3 spawnPosition;

        while(true) 
        {
            yield return new WaitForSeconds(1.0f / frequency);

            xSpawn = UnityEngine.Random.Range(minSpawn, maxSpawn);

            spawnPosition = new Vector3(xSpawn, ySpawn, 0);

            //Instantiate(fallingObject, spawnPosition, Quaternion.identity);
            
            //get random number
            int num = UnityEngine.Random.Range(0, 3);
            Instantiate(fallingObjects[num], spawnPosition, Quaternion.identity);
        }
    }
}
