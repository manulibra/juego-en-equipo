using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento2 : MonoBehaviour
{
    private float speed = 6f;

    private float movement = 0f;

    private float newX;


    private Rigidbody2D rb;

    private Animator animator;

    private SpriteRenderer sr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    

    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal") * speed;
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            sr.flipX = false;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            sr.flipX = true;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetInteger("Velocity", 6);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetInteger("Velocity", 6);
        }
        else
        {
            animator.SetInteger("Velocity", 0);
        }


        rb.MovePosition(rb.position + Vector2.right * movement * Time.fixedDeltaTime);

        newX = Mathf.Clamp(transform.position.x, -8, 8);

        transform.position = new Vector2(newX, transform.position.y);

    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Izquierda")
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                animator.SetInteger("Velocity", 0);
            }
        if (collision.gameObject.tag == "Derecha")
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                animator.SetInteger("Velocity", 0);
            }
        }

        if (collision.gameObject.GetComponent<Bubble>())
        {
            GameManager.Instance.DestroySamba(this);
        }
    }
    
}
