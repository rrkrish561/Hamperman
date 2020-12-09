using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Transform player;
    private float speed = 0.14f;
    public float maxBound, minBound;

    public GameObject[] shot = new GameObject[2];
    public Transform shotSpawn;
    private float fireRate = 0.5f;

    private float nextFire;

    //variables for animation
    public Animator animator;
    public bool right;

    //powerup stuff
    private float speedTimer = 0f;
    private float sprayTimer = 0f;
    private float powerUpTime = 15f;
    private bool speedActive = false;
    private bool sprayActive = false;
    public int shotNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform> ();
        right = true;
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis ("Horizontal");

        if(player.position.x < minBound && h < 0)
            h = 0;
        else if (player.position.x > maxBound && h > 0)
            h = 0;

        if (h > 0 && !right)
            Flip();

        else if (h < 0 && right)
            Flip();

        player.position += Vector3.right * h * speed;
    }

    void Update() {
        bool isShootWalking, IsShooting, isWalking;
        isShootWalking = false;
        IsShooting = false;
        isWalking = false;
        if (Input.GetKey("space") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot[shotNum], shotSpawn.position, shotSpawn.rotation);
        }

        //animation
        if (Input.GetKey("space")) {
            if (Input.GetAxisRaw("Horizontal") != 0)
                isShootWalking = true;
            else
            {
                isShootWalking = false;
                IsShooting = true;
            }
            
            isWalking = false;
        }
        else if (Input.GetAxisRaw("Horizontal") != 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
        animator.SetBool("IsWalking", isWalking);
        animator.SetBool("IsShootWalking", isShootWalking);
        animator.SetBool("IsShooting", IsShooting);

        //powerup stuff 
        if (speedActive){
            speedTimer += Time.deltaTime;
            if (speedTimer > powerUpTime)
            {
                speedTimer = 0;
                speedActive = false;
                speed = 0.14f;
            }
        }
        if (sprayActive)
        {
            sprayTimer += Time.deltaTime;
            if (sprayTimer > powerUpTime)
            {
                sprayTimer = 0;
                sprayActive = false;
                fireRate = 0.5f;
            }
        }

    }

    void Flip() {
        right = !right;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    public void PowerUp(string color)
    {
        if (color == "white")
        {
            speedTimer = 0;
            speed = 0.25f;
            speedActive = true;
        }
        else if (color == "red")
        {
            UpdateLives._updateLives.increaseLives();
        }
        else if (color == "green") {
            sprayTimer = 0;
            sprayActive = true;
            fireRate = 0.2f;
        }
    }
}
