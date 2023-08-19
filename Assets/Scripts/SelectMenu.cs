using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI level2;
    [SerializeField] private TextMeshProUGUI level3;

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
}