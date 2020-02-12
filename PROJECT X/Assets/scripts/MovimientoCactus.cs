using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCactus : MonoBehaviour
{
    [SerializeField]
    private float movimientoSpeed = 6f;
    

    private SpriteRenderer spriteRenderer;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        float spriteWidth = spriteRenderer.bounds.size.x;
        Boundaries.CameraWorldBounds cameraWorldBounds = Boundaries.GetCameraWorldBounds();
        float minX = cameraWorldBounds.minX + spriteWidth / 2f;
        float maxX = cameraWorldBounds.maxX - spriteWidth / 2f;
        Vector3 targetPosition = transform.position;
        targetPosition.x += Input.GetAxis("Horizontal") * movimientoSpeed * Time.deltaTime;
        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
        transform.position = targetPosition;
           }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bubble>())
        {
            GameManager.Instance.DestroySamba(this);
        }
    }

    
}
