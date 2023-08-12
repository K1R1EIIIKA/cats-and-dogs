using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
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
        SceneManager.LoadScene("Level 1-test");
    }
}
