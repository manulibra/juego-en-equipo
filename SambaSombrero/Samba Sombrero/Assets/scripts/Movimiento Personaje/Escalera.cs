using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escalera : MonoBehaviour
{

    Rigidbody2D rb;
    Animator myAnim;
    Movimiento2 movimiento;

    public BoxCollider2D platformGround;

    [HideInInspector]
    public bool onEscalera = false;

    public float velocidadSubida;
    public float exitHop = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        movimiento = GetComponent<Movimiento2>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Escalera"))
        {
            if (Input.GetAxisRaw("Vertical") != 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, Input.GetAxisRaw("Vertical") * velocidadSubida);
                rb.gravityScale = 0;
                onEscalera = true;
                platformGround.enabled = false;
                movimiento.usingLadder = onEscalera;

                float movement = Input.GetAxisRaw("Vertical") * 8f;
                rb.MovePosition(rb.position + Vector2.up * movement * Time.fixedDeltaTime);
            }
            else if (Input.GetAxisRaw("Vertical") == 0 && onEscalera)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Escalera") && onEscalera)
        {
            rb.gravityScale = 1;
            onEscalera = false;
            movimiento.usingLadder = onEscalera;
            platformGround.enabled = true;

            if (!movimiento.isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, exitHop);
            }
        }
    }
}
