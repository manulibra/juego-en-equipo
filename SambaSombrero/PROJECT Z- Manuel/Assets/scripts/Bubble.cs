using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{

    Rigidbody2D rb;

    [SerializeField]
    private int impactos = 1;

    [SerializeField]
    private AudioClip Destroy;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        int rd = Random.Range(0, 10);
        if (rd % 2 == 0)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right, ForceMode2D.Impulse);
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left, ForceMode2D.Impulse);
        }
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
            SoundManager.Instance.PlaySoundEffect(Destroy);
        }
        if (collision.gameObject.GetComponent<Plataformas>())
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.zero, ForceMode2D.Impulse);
        }
        if (collision.gameObject.tag == "Abajo")
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up, ForceMode2D.Impulse);
        }
        if (collision.gameObject.tag == "Izquierda")
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right, ForceMode2D.Impulse);
        }
        if (collision.gameObject.tag == "Derecha")
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left, ForceMode2D.Impulse);
        }
    }

    public void DestroyBubble()
    {
        
        GameManager.Instance.DestroyBubble(this);
    }

    public void DivisionBubble(int impactos)
    {
        Bubble bubble1 = Instantiate(this, rb.position + Vector2.right / 1, Quaternion.identity);
        Bubble bubble2 = Instantiate(this, rb.position + Vector2.left / 1, Quaternion.identity);
        bubble1.GetComponent<Rigidbody2D>().AddForce(new Vector2(2, 1), ForceMode2D.Impulse);
        bubble2.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2, 1), ForceMode2D.Impulse);
        bubble1.transform.localScale = transform.localScale / 2;
        bubble2.transform.localScale = transform.localScale / 2;
        bubble1.Initialize(impactos - 1);
        bubble2.Initialize(impactos - 1);
        GameManager.Instance.AddBubble(bubble1);
        GameManager.Instance.AddBubble(bubble2);
        GameManager.Instance.DestroyBubble(this);
        SoundManager.Instance.PlaySoundEffect(Destroy);

    }

    public void Initialize(int impactos)
    {
        this.impactos = impactos;
    }

   
}
