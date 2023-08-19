using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    [SerializeField] private Sprite openedDoor;
    [SerializeField] private Sprite closedDoor;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (PlayerLogic.HasKey)
            _spriteRenderer.sprite = openedDoor;
        else
            _spriteRenderer.sprite = closedDoor;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (PlayerLogic.HasKey)
            LevelLogic.IsWin = true;
    }
}
