using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Vector2 movementDirection;

    public void InitializeBullet(Vector2 movementDirection)
    {
        this.movementDirection = movementDirection;
    }

    private void Update()
    {
        transform.Translate(movementDirection * speed * Time.deltaTime);
    }
}
