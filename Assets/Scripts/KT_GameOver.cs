using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KT_GameOver : MonoBehaviour {

    [SerializeField]
    Text Time;

    float timerAmount;
    // Use this for initialization
    void Start()
    {
        timerAmount = uiStatsManager.gameTimer;
    }
	// Update is called once per frame
	void Update () {
	
	}

    void DisplayTime()
    {
        Time.text += " " + timerAmount.ToString("0:00:00");
    }
}
