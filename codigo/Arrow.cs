using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Vector2 movementDirection;

    public void InitializeArrow(Vector2 movementDirection)
    {
        this.movementDirection = movementDirection;
    }

    private void Update()
    {
        transform.Translate(movementDirection * speed * Time.deltaTime);
    }
}
