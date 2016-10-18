//Name: Tristan Burger
//Date: 10/9/2016

//Purpose: Managing the pressing and use of buttons

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    [SerializeField]
    GameObject controls;

    public bool opening;
    void Start ()
    {
        if(!opening)
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

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
