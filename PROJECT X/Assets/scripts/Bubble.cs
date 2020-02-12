using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField]
    private float movementImpulse = 5f;
    [SerializeField]
    private Vector2 initialMovementDirection = Vector2.down;
    [SerializeField]
    private int impactos = 2;

    private Vector2 movementDirection;
    private new Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        movementDirection = initialMovementDirection.normalized;
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(movementDirection * movementImpulse, ForceMode2D.Impulse);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Bounds spriteBounds = spriteRenderer.bounds;
        Boundaries.CameraWorldBounds cameraWorldBounds = Boundaries.GetCameraWorldBounds();
        float minX = cameraWorldBounds.minX + spriteBounds.size.x / 2f;
        float maxX = cameraWorldBounds.maxX - spriteBounds.size.x / 2f;
        float minY = cameraWorldBounds.minY + spriteBounds.size.y / 2f;
        float maxY = cameraWorldBounds.maxY - spriteBounds.size.y / 2f;

        if (transform.position.x < minX)
        {
            movementDirection = rigidbody2D.velocity.normalized;
            movementDirection.x *= -1f;
            Vector2 targetPosition = transform.position;
            targetPosition.x = minX;
            transform.position = targetPosition;
            SetMovementDirection(movementDirection);
        }
        else if (transform.position.x > maxX)
        {
            movementDirection = rigidbody2D.velocity.normalized;
            movementDirection.x *= -1f;
            Vector2 targetPosition = transform.position;
            targetPosition.x = maxX;
            transform.position = targetPosition;
            SetMovementDirection(movementDirection);
        }
        else if (transform.position.y > maxY)
        {
            movementDirection = rigidbody2D.velocity.normalized;
            movementDirection.y *= -1f;
            Vector2 targetPosition = transform.position;
            targetPosition.y = maxY;
            transform.position = targetPosition;
            SetMovementDirection(movementDirection);
            
        }
        else if (transform.position.y < minY)
        {
            movementDirection = Vector2.Lerp((Vector3.left + Vector3.up).normalized, (Vector3.right + Vector3.up).normalized, Random.Range(0.1f, 0.9f)).normalized;
            Vector2 targetPosition = transform.position;
            targetPosition.y = minY;
            transform.position = targetPosition;
            SetMovementDirection(movementDirection);
        }

        movementDirection = rigidbody2D.velocity.normalized;
    }

    public Vector2 GetMovementDirection()
    {
        return movementDirection;
    }

    public void SetMovementDirection(Vector2 movementDirection)
    {
        this.movementDirection = movementDirection.normalized;
        rigidbody2D.velocity = Vector2.zero;
        rigidbody2D.AddForce(this.movementDirection * movementImpulse, ForceMode2D.Impulse);
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
    }

    public void DestroyBubble()
    {
        GameManager.Instance.DestroyBubble(this);
    }

    public void DivisionBubble(int impactos)
    {
        Bubble bubble1 = Instantiate(this, transform.position + new Vector3(-1f, 0f, 0f), this.transform.rotation);
        Bubble bubble2 = Instantiate(this, transform.position + new Vector3(1f, 0f, 0f), this.transform.rotation);
        bubble1.transform.localScale = transform.localScale / 2;
        bubble2.transform.localScale = transform.localScale / 2;
        bubble1.Initialize(impactos - 1);
        bubble2.Initialize(impactos - 1);
        GameManager.Instance.AddBubble(bubble1);
        GameManager.Instance.AddBubble(bubble2);
        GameManager.Instance.DestroyBubble(this);

    }

    public void Initialize(int impactos)
    {
        this.impactos = impactos;
    }
}
