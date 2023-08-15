using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_death : MonoBehaviour
{
    private bool hasEnterted;
    public GameObject DeathScreen;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Enemy") && !hasEnterted)
        {
            Destroy(gameObject);
            DeathScreen.SetActive(true);
        }
    }
}
