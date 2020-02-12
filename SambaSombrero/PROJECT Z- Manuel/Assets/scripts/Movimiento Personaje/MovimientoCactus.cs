using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCactus : MonoBehaviour
{
    [SerializeField]
    private float movimientoSpeed = 6f;

    private Animator animator;
    private SpriteRenderer spriteRenderer;


    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        //Marcando el limite de la pantalla
        float spriteWidth = spriteRenderer.bounds.size.x;
        Boundaries.CameraWorldBounds cameraWorldBounds = Boundaries.GetCameraWorldBounds();
        float minX = cameraWorldBounds.minX + spriteWidth / 2f;
        float maxX = cameraWorldBounds.maxX - spriteWidth / 2f;
        //Mover al personaje
        Vector3 targetPosition = transform.position;
        targetPosition.x += Input.GetAxis("Horizontal") * movimientoSpeed * Time.deltaTime;
        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
        transform.position = targetPosition;
        //Animacion de andar
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            spriteRenderer.flipX = true;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetInteger("Velocity", 4);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetInteger("Velocity", 4);
        }
        else
        {
            animator.SetInteger("Velocity", 0);
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bubble>())
        {
            GameManager.Instance.DestroySamba(this);
        }
    }

    
}
