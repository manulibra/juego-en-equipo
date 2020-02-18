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
            Vector2 maxDirectionLeft = (Vector2.up + -Vector2.right).normalized;
            Vector2 maxDirectionRight = (Vector2.up + Vector2.right).normalized;
            float leftSideX = spriteRenderer.bounds.min.x;
            float rightSideX = spriteRenderer.bounds.max.x;
            float maxDistanceX = Mathf.Abs(rightSideX - leftSideX);
            float BubbleDistanceToLeftSide = Mathf.Abs(bubble.transform.position.x - leftSideX);
            bubble.SetMovementDirection(Vector2.Lerp(maxDirectionLeft, maxDirectionRight, BubbleDistanceToLeftSide / maxDistanceX).normalized);
        }
    }
}
