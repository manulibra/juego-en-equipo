using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

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

    //[SerializeField]
    //private GameObject pauseMenu;
    [SerializeField]
    private GameObject gameVictory;
    [SerializeField]
    private GameObject gameOver;


    //public void SetPauseMenu(bool value)
    //{
    //    pauseMenu.SetActive(value);
    //}

    //public void ExitMenu()
    //{
    //    GameManager.Instance.SetGamePaused(false);
    //    SceneManager.LoadScene("MainMenu");
    //}

    internal void SetGameVictory(bool value)
    {
        gameVictory.SetActive(value);
    }
    internal void SetGameOver(bool value)
    {
        gameOver.SetActive(value);
    }
}
