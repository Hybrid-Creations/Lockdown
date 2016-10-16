//Name: Tristan Burger
//Date: 10/9/2016

//Purpose: Managing the pressing and use of buttons

using UnityEngine;
using System.Collections;

public class ButtonManager : MonoBehaviour
{

    [SerializeField]
    GameObject controls;

    void Start ()
    {
        controls.SetActive(false);
    }


    public void Quit ()
    {
        Application.Quit();
    }

    public void ToggleControles ()
    {
        controls.SetActive(!controls.activeInHierarchy);
        uiStatsManager.isPaused = !uiStatsManager.isPaused;
        if (uiStatsManager.isPaused)
            Time.timeScale = 0;
        if (!uiStatsManager.isPaused)
            Time.timeScale = 1;
    }
}
