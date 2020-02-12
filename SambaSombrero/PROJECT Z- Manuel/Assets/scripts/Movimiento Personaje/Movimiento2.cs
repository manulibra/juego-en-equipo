using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento2 : MonoBehaviour
{
    float speed = 4f;

    float movement = 0f;

    float newX;

    bool rightWall;

    bool leftWall;

    Rigidbody2D rb;

    Animator animator;

    SpriteRenderer sr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {

    }

    void Update()
    {

        movement = Input.GetAxisRaw("Horizontal") * speed;

        animator.SetInteger("velX", Mathf.RoundToInt(movement));

        if (movement < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }

    }
    private void FixedUpdate()
    {

        if (leftWall)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                speed = 0;
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                speed = 4;
            }
        }

        if (rightWall)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                speed = 0;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                speed = 4;
            }
        }

        rb.MovePosition(rb.position + Vector2.right * movement * Time.fixedDeltaTime);

        //newX = Mathf.Clamp(transform.position.x, -8, 8);

        //transform.position = new Vector2(newX, transform.position.y);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Izquierda")
        {
            leftWall = true;
        }
        else if (collision.gameObject.tag == "Derecha")
        {
            rightWall = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Izquierda")
        {
            leftWall = false;
        }
        else if (collision.gameObject.tag == "Derecha")
        {
            rightWall = false;
        }
    }


}
