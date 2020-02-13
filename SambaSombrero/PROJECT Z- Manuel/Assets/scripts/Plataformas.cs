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
            //Bubble bubble = collision.gameObject.GetComponent<Bubble>();
            //float leftSideX = spriteRenderer.bounds.min.x;
            //float rightSideX = spriteRenderer.bounds.max.x;
            //if (rightSideX > leftSideX)
            //{
            //    bubble.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0), ForceMode2D.Impulse);
            //    bubble.GetComponent<Rigidbody2D>().AddForce(Vector2.right, ForceMode2D.Impulse);
            //}
            //else
            //{
            //    bubble.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0), ForceMode2D.Impulse);
            //    bubble.GetComponent<Rigidbody2D>().AddForce(Vector2.left, ForceMode2D.Impulse);
            //}
            ////if (rightSideX == leftSideX)
            ////{
            ////    int rd = Random.Range(0, 10);
            ////    if (rd %2 == 0)
            ////    {
            ////        bubble.GetComponent<Rigidbody2D>().AddForce(Vector2.right, ForceMode2D.Impulse);
            ////    }
            ////    else
            ////    {
            ////        bubble.GetComponent<Rigidbody2D>().AddForce(Vector2.left, ForceMode2D.Impulse);
            ////    }
            ////}
            
       
        }
    }
}
