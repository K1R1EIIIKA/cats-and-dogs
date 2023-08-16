using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelLogic : MonoBehaviour
{
    [SerializeField] private Canvas pauseCanvas;
    [SerializeField] private Canvas deathCanvas;

    [SerializeField] private Transform playerObject;
    [SerializeField] private Transform spawnPoint;

    private bool _isPaused;

    private void Start()
    {
        SetPlayer();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_isPaused)
                PauseGame();
            else
                UnpauseGame();
        }
        
        if (PlayerLogic.IsDead)
            Death();
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

    private void Death()
    {
        Time.timeScale = 0;
        deathCanvas.gameObject.SetActive(true);
    }

    private void SetPlayer()
    {
        playerObject.position = spawnPoint.position;
    }
}