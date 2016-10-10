//Name: Tristan Burger
//Date: 10/9/2016

//Purpose: Updating and keeping values for UI

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class uiStatsManager : MonoBehaviour {

    [SerializeField]
    Slider mindPowerSlider;
    [SerializeField]
    Text valueText;

    //[HideInInspector]
    public float currentMindPower;
    public float maxMindPower;

    void Start()
    {
        mindPowerSlider.maxValue = maxMindPower;
        mindPowerSlider.minValue = 0;
        currentMindPower = maxMindPower;
        mindPowerSlider.value = maxMindPower;
    }

    void Update()
    {
        mindPowerSlider.value = currentMindPower;
        valueText.text = currentMindPower.ToString();
    }
}
