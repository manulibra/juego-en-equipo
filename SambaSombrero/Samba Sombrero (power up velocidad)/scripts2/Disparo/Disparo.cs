using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{

    
    [SerializeField]
    private Bala bulletPrefab;

    [SerializeField]
    private AudioClip shoot;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        MovimientoCactus movimientoCactus = GameManager.Instance.GetMovimientoCactus();
        Instantiate(bulletPrefab, movimientoCactus.transform.position + new Vector3(-0.1f, 1.7f), bulletPrefab.transform.rotation);
        SoundManager.Instance.PlaySoundEffect(shoot);

    }

}
