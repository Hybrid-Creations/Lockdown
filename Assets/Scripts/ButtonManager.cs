//Name: Tristan Burger
//Date: 10/9/2016

//Purpose: Managing the pressing and use of buttons

using UnityEngine.SceneManagement;
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

    public void ToggleControls ()
    {
        controls.SetActive(!controls.activeInHierarchy);
        uiStatsManager.isPaused = !uiStatsManager.isPaused;
        if (uiStatsManager.isPaused)
            Time.timeScale = 0;
        if (!uiStatsManager.isPaused)
            Time.timeScale = 1;
    }

    public void LoadSceneByName (string nameOfScene)
    {
        SceneManager.LoadSceneAsync(nameOfScene);
    }
}
