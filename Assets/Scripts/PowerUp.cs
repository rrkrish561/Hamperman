using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public string color;
    private Transform powerUp;

    public GameObject player;
    private bool speedPowerup = false;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        powerUp = GetComponent<Transform>();
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        powerUp.position += Vector3.down * speed;
        if (powerUp.position.y <= -5.5)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {

            if (color == "white")
            {
                speedPowerup = true;
                Destroy(other.gameObject);
                Destroy(gameObject);

            }
        }
    }
    void OnDestroy()
    {
        if (speedPowerup)
        {
            player.GetComponent<PlayerController>().PowerUp("white");
        }
    }
}
