using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level_Manager : MonoBehaviour
{
    public static level_Manager Instance;
    public GameObject playerPrefab;
    public Transform respawnPoint;

    private void Awake()
    {
        Instance = this;
    }

    public void Respawn()
    {
        Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
    }
}
