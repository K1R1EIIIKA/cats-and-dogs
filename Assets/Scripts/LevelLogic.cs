using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class LevelLogic : MonoBehaviour
{
    [SerializeField] private Canvas pauseCanvas;
    [SerializeField] private Canvas deathCanvas;
    [SerializeField] private Canvas winCanvas;
    [SerializeField] private TextMeshProUGUI winText;
    [SerializeField] private TextMeshProUGUI winButtonText;

    [SerializeField] private Transform playerObject;
    [SerializeField] private Transform spawnPoint;

    private bool _isPaused;

    public static bool IsWin;

    private void Start()
    {
        SetPlayer();
        Time.timeScale = 1;
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

        if (IsWin)
            Win();
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
        PlayerLogic.IsDead = false;
        PlayerLogic.HasKey = false;
        IsWin = false;
        playerObject.position = spawnPoint.position;
    }

    private void Win()
    {
        Time.timeScale = 0;
        winCanvas.gameObject.SetActive(true);
        
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level 1":
                winText.text = "Level 1\ncompleted";
                winButtonText.text = "Level 2";
                MenuNavigation.Level1Completed = true;
                break;
            
            case "Level 2":
                winText.text = "Level 2\ncompleted";
                winButtonText.text = "Level 3";
                MenuNavigation.Level2Completed = true;
                break;
            
            case "Level 3":
                winText.text = "Level 3\ncompleted";
                MenuNavigation.Level3Completed = true;
                break;
        }
    }
}