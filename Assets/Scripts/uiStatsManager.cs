﻿//Name: Tristan Burger
//Date: 10/9/2016

//Purpose: Updating and keeping values for UI

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class uiStatsManager : MonoBehaviour {

    [SerializeField]
    Slider mindPowerSlider;
    [SerializeField]
    Slider caughtSlider;
    [SerializeField]
    Text valueText;

    Vector2 screenPlacement;

    public GameObject guardWhoCanSee;

    //[HideInInspector]
    public float currentMindPower;
    public float maxMindPower;

    public float currentCaughtValue;
    public float maxcaughtValue;

    public static bool isPaused = false;

    void Start()
    {
        mindPowerSlider.maxValue = maxMindPower;
        mindPowerSlider.minValue = 0;
        currentMindPower = maxMindPower;
        mindPowerSlider.value = maxMindPower;

        caughtSlider.maxValue = maxcaughtValue;
        caughtSlider.minValue = 0;
        caughtSlider.value = currentCaughtValue;
    }

    void Update()
    {
        mindPowerSlider.value = currentMindPower;
        valueText.text = currentMindPower.ToString("0");

        if (Input.GetKeyDown(KeyCode.P) && isPaused == false)
        {
            isPaused = true;
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.P) && isPaused)
        {
            isPaused = false;
            Time.timeScale = 1;
        }

        if (guardWhoCanSee)
        {
            currentCaughtValue += Time.deltaTime;

            caughtSlider.value = currentCaughtValue;

            if (currentCaughtValue > 0.1f)
            {
                screenPlacement = Camera.main.WorldToScreenPoint(guardWhoCanSee.transform.position);
                screenPlacement.y += 95;
                caughtSlider.gameObject.transform.position = screenPlacement;
            }
        }
    }
}
