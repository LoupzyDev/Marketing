using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public enum GameState
{
    None, 
    MainMenu, 
    StartGame,
    Pause,
    Resume,
    Restart,
    Victory,
    Quit
}

public class GameManager : MonoBehaviour
{
    [SerializeField] float timer;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] GameObject victoryPanel;
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject pausePanel;

    GameState gameState;


    void Start()
    {
        Time.timeScale = 0.0f;

    }

    void Update()
    {
        timer -= Time.deltaTime; 

        if(timer <= 0)
        {
            Time.timeScale = 0f;
            ChangeGameState(GameState.Victory);
        }

        UpdateTimerDisplay();
    }

    void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.RoundToInt(timer).ToString();
        }
    }

    public void ChangeGameState(GameState newState)
    {
        gameState = newState;
        switch (gameState)
        {
            case GameState.None:
                break;
            case GameState.MainMenu:
                ReturnMainMenu();
                break;
            case GameState.StartGame:
                PlayGame();
                break;
            case GameState.Pause:
                PauseGame();
                break;
            case GameState.Resume:
                ResumeGame();
                break;
            case GameState.Restart:
                RestartGame();
                break;
            case GameState.Victory:
                victoryPanel.SetActive(true);
                break;
            case GameState.Quit:
                QuitGame();
                break;
        }
        
    }

    public void ChangeGameStateFromEditor(string newState)
    {
        ChangeGameState((GameState)System.Enum.Parse(typeof(GameState), newState));
    }

    public void PlayGame()
    {
        //SceneManager.LoadScene("Game");
        AllPanelsFalse();
        Time.timeScale = 1.0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        AllPanelsFalse();
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        AllPanelsFalse();
    }

    public void ReturnMainMenu()
    {
        Time.timeScale = 0f;
        AllPanelsFalse();
        mainMenuPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void AllPanelsFalse()
    {
        mainMenuPanel.SetActive(false);
        victoryPanel.SetActive(false);
        pausePanel.SetActive(false);
    }

}
