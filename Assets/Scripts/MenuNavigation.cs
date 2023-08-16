using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    public static bool Level1Completed;
    public static bool Level2Completed;
    public static bool Level3Completed;
    
    public static void LoadLevelSelect()
    {
        SceneManager.LoadScene("Level Select");
    }

    public static void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public static void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }
    
    public static void LoadLevel2()
    {
        if (Level1Completed)
            SceneManager.LoadScene("Level 2");
    }
    
    public static void LoadLevel3()
    {
        if (Level2Completed)
            SceneManager.LoadScene("Level 3");
    }

    public static void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerLogic.IsDead = false;
        Time.timeScale = 1;
    }
}