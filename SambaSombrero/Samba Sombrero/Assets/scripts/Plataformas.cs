using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataformas : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bubble>())
        {
            Bubble bubble = collision.gameObject.GetComponent<Bubble>();
            bubble.GetComponent<Rigidbody2D>().AddForce(Vector2.zero, ForceMode2D.Impulse);

        }
    }
}
