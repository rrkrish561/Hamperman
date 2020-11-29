using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform enemy;

    public float speed;

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        enemy.position += Vector3.down * speed;
        if(enemy.position.y <= -5.5) {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            spriteRenderer.sprite = newSprite;
            animator.SetBool("IsShot", true);
            //Destroy(gameObject);

            ++UpdateScore.gameScore;
        }
    }
}
