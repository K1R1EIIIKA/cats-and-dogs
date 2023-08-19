using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    public static bool Level1Completed;
    public static bool Level2Completed;
    public static bool Level3Completed;

    public static void LoadMainMenu()
    {
        ClickSound();
        SceneManager.LoadScene("Main Menu");
    }

    public static void LoadLevel1()
    {
        ClickSound();
        SceneManager.LoadScene("Level 1");
    }
    
    public static void LoadLevel2()
    {
        ClickSound();
        
        if (Level1Completed)
            SceneManager.LoadScene("Level 2");
    }
    
    public static void LoadLevel3()
    {
        ClickSound();
        
        if (Level2Completed)
            SceneManager.LoadScene("Level 3");
    }

    public static void RestartLevel()
    {ClickSound();
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerLogic.IsDead = false;
        Time.timeScale = 1;
    }

    public static void ClickSound()
    {
        FindObjectOfType<AudioManager>().Play("Click");
    }
}