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
    private int vidas;
    private int impactos = 2;
    private Bala bala;
    private List<Bubble> bubbles;
    private List<Cactus> cactus;

    //private bool gamePaused = false;
    //private bool gameVictory = false;
    //private bool gameOver = false;

    private void Start()
    {
        bala = FindObjectOfType<Bala>();
        movimientoCactus = FindObjectOfType<MovimientoCactus>();
        bubbles = new List<Bubble>(FindObjectsOfType<Bubble>());
        cactus = new List<Cactus>(FindObjectsOfType<Cactus>());

        //gameVictory = false;
        //gameOver = false;
        //SetGameVictory(gameVictory);
        //SetGameOver(gameOver);
    }
    

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.P))
    //    {
    //        SetGamePaused(!gamePaused);
    //    }
    //}

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
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void DestroySamba(MovimientoCactus movimientoCactus)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        

    }
    
    //public void SetGameVictory(bool value)
    //{
    //    gameVictory = value;
    //    if (gameVictory)
    //    {
    //        Time.timeScale = 0f;
    //    }
    //    else
    //    {
    //        Time.timeScale = 1f;
    //    }
    //    
    //}
    //public void SetGameOver(bool value)
    //{
    //    gameOver = value;
    //    if (gameOver)
    //    {
    //        Time.timeScale = 0f;
    //    }
    //    else
    //    {
    //        Time.timeScale = 1f;
    //    }
    //    UIManager.Instance.SetGameOver(gameOver);
    //}
}
