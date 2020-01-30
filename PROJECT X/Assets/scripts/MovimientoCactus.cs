using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCactus : MonoBehaviour
{
    [SerializeField]
    private float movimientoSpeed = 2;
    private Vector2 inputPlayer;
    private Rigidbody2D rb;
    


    private void Start()
    {
        inputPlayer = Vector2.zero;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        inputPlayer = new Vector2(Input.GetAxis("Horizontal"), 0F);

        rb.MovePosition(rb.position + (inputPlayer.normalized * movimientoSpeed * Time.fixedDeltaTime));

    }
}
