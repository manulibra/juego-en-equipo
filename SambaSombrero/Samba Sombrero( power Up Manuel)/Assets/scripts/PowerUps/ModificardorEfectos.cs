using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModificardorEfectos : MonoBehaviour
{
    [SerializeField]
    private PowerUps modifierPrefab;

    bool inGround;

    //public Sprite[] powerUpsStatic;
    //SpriteRenderer sr;

    //private void Awake()
    //{
    //    sr = GetComponent<SpriteRenderer>();
    //}
    //private void Start()
    //{
    //    Destroy(gameObject, 5f);
    //}

    void Update()
    {
        if (!inGround)
        {
            transform.position += Vector3.down * Time.deltaTime * 2;
        }
        //int aleatory = Random.Range(0, 2);
        //if (aleatory == 0)
        //{
        //  sr.sprite = powerUpsStatic[Random.Range(0, powerUpsStatic.Length)];
        //  gameObject.name = sr.sprite.name;
        //}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jugador")
        {
            PowerUpsManager.Instance.AddPowerUps(modifierPrefab);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Abajo")
        {
            inGround = true;
            Destroy(gameObject, 5);
        }
    }
}
