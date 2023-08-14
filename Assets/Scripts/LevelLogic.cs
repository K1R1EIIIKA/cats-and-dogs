using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLogic : MonoBehaviour
{
    [SerializeField] private Canvas pauseCanvas;

    private bool _isPaused;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_isPaused)
                PauseGame();
            else
                UnpauseGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        _isPaused = true;
        pauseCanvas.gameObject.SetActive(true);
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        _isPaused = false;
        pauseCanvas.gameObject.SetActive(false);
    }
}