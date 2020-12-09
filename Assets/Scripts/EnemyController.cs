using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform enemy;

    public float speed;
    private float destructLevel;

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Animator animator;

    private bool dirty = true;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Transform>();
        //destructLevel = GameObject.FindWithTag("Player").transform.position.y; 
        destructLevel = -10.5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        enemy.position += Vector3.down * speed;
        if(enemy.position.y <= destructLevel) {
            if(dirty)
                UpdateLives._updateLives.decreaseLives();
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            spriteRenderer.sprite = newSprite;
            enemy.tag = "Untagged";

            if (dirty == true)
                FindObjectOfType<AudioController>().Play("HitSound");

            dirty = false;
            animator.SetBool("IsShot", true);
        }
    }
}
