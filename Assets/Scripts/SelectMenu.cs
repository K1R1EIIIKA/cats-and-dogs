using System;
using System.Collections;
using System.Collections.Generic;
using Audio;
using TMPro;
using UnityEngine;

public class SelectMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI level2;
    [SerializeField] private TextMeshProUGUI level3;

    [SerializeField] private Canvas mainCanvas;
    [SerializeField] private Canvas selectCanvas;

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Menu");
    }

    private void Update()
    {
        if (MenuNavigation.Level1Completed)
            level2.text = "2";
        else
            level2.text = "No";

        if (MenuNavigation.Level2Completed)
            level3.text = "3";
        else
            level3.text = "No";
    }

    public void OpenSelect()
    {
        mainCanvas.gameObject.SetActive(false);
        selectCanvas.gameObject.SetActive(true);
        MenuNavigation.ClickSound();
    }
    
    public void OpenMain()
    {
        mainCanvas.gameObject.SetActive(true);
        selectCanvas.gameObject.SetActive(false);
        MenuNavigation.ClickSound();
    }
}