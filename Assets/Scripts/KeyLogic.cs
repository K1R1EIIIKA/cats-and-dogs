using System;
using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;

public class KeyLogic : MonoBehaviour
{
    [SerializeField] private float pickCooldown = 0.5f;
    
    private float _startTime;

    private void Start()
    {
        _startTime = Time.time;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Time.time - _startTime > pickCooldown)
        {
            FindObjectOfType<AudioManager>().Play("Key");
            PlayerLogic.HasKey = true;
            Destroy(gameObject);
        }
    }
}
