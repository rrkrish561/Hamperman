using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class SceneController : MonoBehaviour
{
    public GameObject fallingObject;
    public float frequency;
    public float minSpawn;
    public float maxSpawn;
    public float ySpawn;

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

        float xSpawn;

        Vector3 spawnPosition;

        while(true) 
        {
            yield return new WaitForSeconds(1.0f / frequency);

            xSpawn = UnityEngine.Random.Range(minSpawn, maxSpawn);

            spawnPosition = new Vector3(xSpawn, ySpawn, 0);

            Instantiate(fallingObject, spawnPosition, Quaternion.identity);
        }
    }
}
