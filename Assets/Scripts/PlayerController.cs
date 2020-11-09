using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Transform player;
    public float speed;
    public float maxBound, minBound;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    //variables for animation
    public Animator animator;
    public bool right;

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
        {
            Flip();
        }
        else if (h < 0 && right) {
            Flip();
        }

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
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }

        //animation
        if (Input.GetKey("space")) {
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                isShootWalking = true;
                
            }
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
    }

    void Flip() {
        right = !right;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
