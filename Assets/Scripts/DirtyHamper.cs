﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyHamper : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            animator.SetBool("isDirty", true);
        }
    }
}
