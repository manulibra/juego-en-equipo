using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsManager : MonoBehaviour
{
    public static PowerUpsManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private List<PowerUps> PowerUpsList;

    private void Start()
    {
        PowerUpsList = new List<PowerUps>();
    }

    public void AddPowerUps(PowerUps PowerUpsPrefab)
    {
        foreach (PowerUps m in PowerUpsList)
        {
            if (m.GetType() == PowerUpsPrefab.GetType())
            {
                return;
            }
        }

        PowerUps PowerUpsCreated = Instantiate(PowerUpsPrefab, transform);

        PowerUpsList.Add(PowerUpsCreated);
        PowerUpsCreated.Activate();
    }

    public void RemovePowerUps(PowerUps PowerUps)
    {
        PowerUpsList.Remove(PowerUps);
        Destroy(PowerUps.gameObject);
    }
}
