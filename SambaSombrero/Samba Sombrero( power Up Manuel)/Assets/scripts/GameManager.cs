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

        DontDestroyOnLoad(gameObject);
    }

    [SerializeField]
    private AudioClip shit;

    private Movimiento2 movimiento2;
    private int vidas;
    private int impactos = 2;
    private Bala bala;
    private List<Bubble> bubbles;
    private List<Cactus> cactus;

    private bool gamePaused = false;
    private bool winMenu = false;
    private bool loseMenu = false;

    //private DontDestroy dd;
    ////private int vidasRestantes;
    //private Text text;


    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        loseMenu = false;
    }

    private void Start()
    {
        bala = FindObjectOfType<Bala>();
        movimiento2 = FindObjectOfType<Movimiento2>();
        bubbles = new List<Bubble>(FindObjectsOfType<Bubble>());
        cactus = new List<Cactus>(FindObjectsOfType<Cactus>());

        winMenu = false;
        loseMenu = false;
        SetGameVictory(winMenu);
        SetGameOver(loseMenu);
        gamePaused = false;
        SetGamePaused(gamePaused);

        //dd = FindObjectOfType<DontDestroy>();
        ////vidasRestantes = dd.Vidas();
        //text.text = dd.TextVidas();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SetGamePaused(!gamePaused);
        }
    }

    public Movimiento2 GetMovimiento2()
    {
        return movimiento2;
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

    public void DestroySamba(Movimiento2 movimiento2)
    {
        //dd.PerdidaVida();
        //if (dd.Vidas() <= 0)
        //{
            SetGameOver(!loseMenu);
        //}
        //ResetGame();
        SoundManager.Instance.PlaySoundEffect(shit);
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
                //dd.PerdidaVida();
                //if (dd.Vidas() <= 0)
                //{
                    SetGameOver(!loseMenu);
                //}
                //ResetGame();
                SoundManager.Instance.PlaySoundEffect(shit);
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
