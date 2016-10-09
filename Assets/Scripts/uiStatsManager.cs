using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class uiStatsManager : MonoBehaviour {

    [SerializeField]
    Slider mindPowerSlider;

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
    }
}
//Dank Memes
