using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = false;
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            spriteRenderer.flipX = true;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetInteger("Velocity", 4);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetInteger("Velocity", 4);
        }
        else
        {
            animator.SetInteger("Velocity", 0);
        }
    }    
}
