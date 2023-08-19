using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Video;

public class Cutscene : MonoBehaviour
{
    private VideoPlayer _player;
    private float _startTime;

    [SerializeField] private Canvas button;
    [SerializeField] private GameObject square;
    
    void Awake()
    {
        Time.timeScale = 1;
        _player = GetComponent<VideoPlayer>();
        _startTime = Time.time;
    }

    void Update()
    {
        if (!_player.isPlaying && Time.time - _startTime > 2f)
        {
            button.gameObject.SetActive(true);
            square.SetActive(false);
        }
    }
}
