using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public string color;
    private Transform powerUp;

    GameObject player;
    private bool powerup = false;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        powerUp = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        powerUp.position += Vector3.down * speed;
        if (powerUp.position.y <= -10.5)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            powerup = true;
            Destroy(other.gameObject);
            Destroy(gameObject);

            FindObjectOfType<AudioManager>().Play("PowerUpSound");

        }
    }
    void OnDestroy()
    {
        if (powerup)
        {
            player.GetComponent<PlayerController>().PowerUp(color);
        }
    }
}
