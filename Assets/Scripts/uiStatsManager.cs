//Name: Tristan Burger
//Date: 10/9/2016

//Purpose: Updating and keeping values for UI

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class uiStatsManager : MonoBehaviour {

    [SerializeField]
    Slider mindPowerSlider;
    [SerializeField]
    Slider caughtSlider;
    [SerializeField]
    Text valueText;

    [SerializeField]
    GameObject caughtText;

    Vector2 screenPlacement;

    public GameObject guardWhoCanSee;

    //[HideInInspector]
    public float currentMindPower;
    public float maxMindPower;

    public float currentCaughtValue;
    public float maxcaughtValue;

    public static bool isPaused = false;

    float restartTimer;

    void Start()
    {
        mindPowerSlider.maxValue = maxMindPower;
        mindPowerSlider.minValue = 0;
        currentMindPower = maxMindPower;
        mindPowerSlider.value = maxMindPower;
        isPaused = false;

        if (caughtSlider)
        {
            caughtSlider.maxValue = maxcaughtValue;
            caughtSlider.minValue = 0;
            caughtSlider.value = currentCaughtValue;
            caughtSlider.gameObject.SetActive(false);
        }
        if (caughtText)
            caughtText.gameObject.SetActive(false);
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
            //currentCaughtValue += Time.deltaTime;

            caughtSlider.value = currentCaughtValue;

            if (currentCaughtValue > 0.1f)
            {
                caughtSlider.gameObject.SetActive(true);
                screenPlacement = Camera.main.WorldToScreenPoint(guardWhoCanSee.transform.position);
                screenPlacement.y += 95;
                caughtSlider.gameObject.transform.position = screenPlacement;
            }
            if (currentCaughtValue >= maxcaughtValue)
            {
                currentCaughtValue = maxcaughtValue;
                //caughtText.text = "Caught!";
                Debug.Log("Caught!");
                caughtText.gameObject.SetActive(true);
                restartTimer += Time.deltaTime;
                isPaused = true;

                if (restartTimer > 2)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
            else if (currentCaughtValue <= 0)
            {
                caughtText.gameObject.SetActive(false);
                caughtSlider.gameObject.SetActive(false);
            }
        }
    }
}
