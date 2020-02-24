using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    [SerializeField]
    private AudioClip shoot;

    [SerializeField]
    private Bala bulletPrefab;


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
        Instantiate(bulletPrefab, movimiento2.transform.position + new Vector3(0.1f, 1.31f), bulletPrefab.transform.rotation);
        SoundManager.Instance.PlaySoundEffect(shoot);

    }

}
