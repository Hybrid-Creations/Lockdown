using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KT_GameOver : MonoBehaviour {

    [SerializeField]
    Text Time;

    // Use this for initialization
    void Start()
    {
    }
	// Update is called once per frame
	void Update () {
	
	}

    void DisplayTime()
    {
        Time.text += " " + uiStatsManager.displayTimer.ToString("0:00:00");
    }
}
