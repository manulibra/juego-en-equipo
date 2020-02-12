using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{

    Rigidbody2D rb;

    [SerializeField]
    private int impactos = 1;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bala>())
        {
            if (impactos == 0)
            {
                DestroyBubble();
            }
            else
            {

                 DivisionBubble(impactos);
                impactos = impactos - 1;
            }
        }
        if (collision.gameObject.tag == "Abajo")
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up, ForceMode2D.Impulse);
        }
        if (collision.gameObject.GetComponent<Plataformas>())
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right, ForceMode2D.Impulse);
        }
    }

    public void DestroyBubble()
    {
        GameManager.Instance.DestroyBubble(this);
    }

    public void DivisionBubble(int impactos)
    {
        Bubble Bubble1 = Instantiate(this, rb.position + Vector2.right / 2, Quaternion.identity);
        Bubble Bubble2 = Instantiate(this, rb.position + Vector2.left / 2, Quaternion.identity);
        Bubble1.GetComponent<Rigidbody2D>().AddForce(new Vector2(2, 2), ForceMode2D.Impulse);
        Bubble2.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2, 2), ForceMode2D.Impulse);
        Bubble1.transform.localScale = transform.localScale / 2;
        Bubble2.transform.localScale = transform.localScale / 2;
        Bubble1.Initialize(impactos - 1);
        Bubble2.Initialize(impactos - 1);
        GameManager.Instance.AddBubble(Bubble1);
        GameManager.Instance.AddBubble(Bubble2);
        GameManager.Instance.DestroyBubble(this);

    }

    public void Initialize(int impactos)
    {
        this.impactos = impactos;
    }

   
}
