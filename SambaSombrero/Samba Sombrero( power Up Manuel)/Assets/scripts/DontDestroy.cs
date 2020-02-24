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

    public static DontDestroy Instance { get; private set; }
   
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
