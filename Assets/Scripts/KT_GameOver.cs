using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KT_GameOver : MonoBehaviour {

    [SerializeField]
    Text Time;

    public float timerAmount;
    // Use this for initialization
    void Start()
    {
        timerAmount = uiStatsManager.gameTimer;
        DisplayTime();
    }
	// Update is called once per frame
	void Update () {
	
	}

    void DisplayTime()
    {
        //timerAmount = timerAmount * 100;
        Time.text += " " + SetBaseSixty(timerAmount);
    }

    public string SetBaseSixty(float timer)
    {
        //gameTimer -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60F);
        float seconds = timer - minutes * 60;
        float sec = seconds * 100;
        //int miliseconds = Mathf.FloorToInt(sec * 100);
        //if(miliseconds / 100 > 1)
        //{
        //    miliseconds = miliseconds / 100;
        //}
        return string.Format("{0:0}:{1:00:00}", minutes, sec);
    }
}
