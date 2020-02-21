using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CintaVelocidad : PowerUps
{
    [SerializeField]
    private float timeAffected = 5f;

    private float timeLeft;

    private Movimiento2 m2;

    private void Awake()
    {
        m2 = FindObjectOfType<Movimiento2>();
    }
    public override void Activate()
    {
        m2.Speed();
        timeLeft = timeAffected;
    }

    private void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0)
            {
                DeActivate();
            }
        }
    }

    public override void DeActivate()
    {
        m2.Simple();
        base.DeActivate();
    }
}
