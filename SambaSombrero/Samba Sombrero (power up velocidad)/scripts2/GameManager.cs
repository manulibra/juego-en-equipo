using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

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

    private MovimientoCactus movimientoCactus;
    private int vidas = 1;
    private int impactos = 2;
    private Bala bala;
    private List<Bubble> bubbles;
    private List<Cactus> cactus;
    [SerializeField]
    private Text textoVidas;
    private string prueba;

    private bool gamePaused = false;
    private bool winMenu = false;
    private bool loseMenu = false;

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Start()
    {
        bala = FindObjectOfType<Bala>();
        movimientoCactus = FindObjectOfType<MovimientoCactus>();
        bubbles = new List<Bubble>(FindObjectsOfType<Bubble>());
        winMenu = false;
        loseMenu = false;
        SetGameVictory(winMenu);
        SetGameOver(loseMenu);
        gamePaused = false;
        SetGamePaused(gamePaused);
    }
    //private void Update()
    //{
    //    prueba = "Vidas: " + vidas;
    //    textoVidas.text = prueba;
    //}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SetGamePaused(!gamePaused);
        }
    }

    public MovimientoCactus GetMovimientoCactus()
    {
        return movimientoCactus;
    }

    

    public Bala GetBala()
    {
        return bala;
    }

    public void AddBubble(Bubble bubble)
    {
        bubbles.Add(bubble);
    }

    public void DestroyBubble(Bubble bubble)
    {
        if (bubbles.Contains(bubble))
        {
            bubbles.Remove(bubble);
            Destroy(bubble.gameObject);
            if (bubbles.Count <= 0)
            {
                SetGameVictory(!winMenu);
            }
        }
    }

    public void DestroySamba(MovimientoCactus movimientoCactus)
    {
        vidas = vidas - 1;
        if (vidas <= 0)
        { 
            SetGameOver(!loseMenu);
        }
    }

    
    public void DestroyCactus(Cactus cactu)
    {
        if (cactus.Contains(cactu))
        {
            impactos = impactos - 1;
            if (impactos <= 0)
            {
                cactus.Remove(cactu);
                Destroy(cactu.gameObject);
            }
            if (cactus.Count <= 0)
            {
                SetGameOver(!loseMenu);
            }
        }
        

    }

    public void SetGamePaused(bool value)
    {
        gamePaused = value;
        if (gamePaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        UIManager.Instance.SetPauseMenu(gamePaused);
    }

    public void SetGameVictory(bool value)
    {
        winMenu = value;
        if (winMenu)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        UIManager.Instance.SetGameVictory(winMenu);
    }
    public void SetGameOver(bool value)
    {
        loseMenu = value;
        if (loseMenu)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        UIManager.Instance.SetGameOver(loseMenu);
    }
}
