using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    [SerializeField]
    private AudioClip shoot;

    [SerializeField]
    private Bala bulletPrefab;

    ////public static Disparo Instance { get; private set; }
    ////private void Awake()
    ////{
    ////    if (Instance != null && Instance != this)
    ////    {
    ////        Destroy(gameObject);
    ////    }
    ////    else
    ////    {
    ////        Instance = this;
    ////    }
    ////    DontDestroyOnLoad(gameObject);
    ////}
    //private void Start()
    //{
    //    bulletPrefab = FindObjectOfType<Bala>();
    //}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Movimiento2 movimiento2 = GameManager.Instance.GetMovimiento2();
        SoundManager.Instance.PlaySoundEffect(shoot);
        Instantiate(bulletPrefab, movimiento2.transform.position + new Vector3(0.1f, 1f), bulletPrefab.transform.rotation);
       

    }

}
