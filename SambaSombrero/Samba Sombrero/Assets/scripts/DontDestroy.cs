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
        TextVidas();
    }
    private void Update()
    {
        TextVidas();
    }
    public int PerdidaVida()
    {
        vidas--;
        return vidas;
        
    }

    public int Vidas()
    {
        return vidas;
    }

    public string TextVidas()
    {
        textoVidas.text = "Vidas: " + vidas.ToString();
        return textoVidas.text;
    }

    
}
