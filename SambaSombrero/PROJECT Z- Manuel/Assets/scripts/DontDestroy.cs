using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DontDestroy : MonoBehaviour
{
    public static DontDestroy dd;
    private int vidas = 3;
    [SerializeField]
    private Text textoVidas;

    private void Awake()
    {
        if (dd == null)
        {
            dd = this;
        }
        else if (dd != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        UpdateVidas();
    }
    public void PerdidaVida()
    {
        vidas = vidas - 1;
        PlayerPrefs.SetInt("vidas", vidas);
    }

    public void UpdateVidas()
    {
        textoVidas.text = "Vidas: " + vidas.ToString();
    }

    public int LoadVidas()
    {
        vidas = PlayerPrefs.GetInt("vidas");
        return vidas;
    }
}
