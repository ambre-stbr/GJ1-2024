using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject echapScreen;
    private bool isPlaying = true;
    private bool isGamePaused = false;
    public string DeadScene;



    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            echapScreen.SetActive(!echapScreen.activeSelf);

            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void GameOver()
    {
        isPlaying = false;

        //Invoke(nameof(ShowGameOverScreen), 0.5f);
    }
    public void ShowGameOverScreen()
    {
        SceneManager.LoadScene(DeadScene);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isGamePaused = true;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        isGamePaused = false;
    }
}
