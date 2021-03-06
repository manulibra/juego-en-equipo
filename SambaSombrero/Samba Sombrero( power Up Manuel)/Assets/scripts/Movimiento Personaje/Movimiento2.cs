﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento2 : MonoBehaviour
{

    public static Movimiento2 Instance { get; private set; }

    private float speed = 6f;
    private float speedBasica;

    private float movement = 0f;

    private float newX;


    private Rigidbody2D rb;

    private Animator animator;

    private SpriteRenderer sr;

    [HideInInspector]
    public bool isGrounded = true;

    [HideInInspector]
    public bool usingLadder = false;

    public float checkRadius = 0.1f;
    public Transform groundCheck;
    public LayerMask target;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        groundCheck = GetComponent<Transform>();

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        speedBasica = speed;
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

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.MovePosition(rb.position + Vector2.right * movement * Time.fixedDeltaTime);
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, target);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Izquierda") 
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                animator.SetInteger("Velocity", 0);
            }
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

    public float Speed()
    {
        speed = speed * 2f;
        return speed;

    }

    public float Simple()
    {
        speed = speedBasica;
        return speed;

    }
}
