using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField]
    private float velocity;
    private Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.AddForce(Vector2.up * velocity, ForceMode2D.Impulse);
        Destroy(gameObject, 3f);
    }

   
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bubble>())
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.GetComponent<Plataformas>())
        {
            Destroy(gameObject);
        }
    }
}
