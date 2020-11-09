using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform enemy;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Transform>();   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        enemy.position += Vector3.down * speed;
        if(enemy.position.y <= -6) {
            Destroy(gameObject);
        }
    }
}
