//Name: Tristan Burger
//Date: 10/9/2016

//Purpose: Updating and keeping values for UI

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class uiStatsManager : MonoBehaviour
{
    [Header("Mind Power")]
    public Slider mindPowerSlider;
    [SerializeField]
    Text valueText;
    //[HideInInspector]
    public float currentMindPower;
    public static float maxMindPower = 100;

    [Header("Caught Values")]
    [SerializeField]
    Slider caughtSlider;

    [SerializeField]
    GameObject caughtText;
    [HideInInspector]
    public GameObject guardWhoCanSee;
    public float currentCaughtValue;
    public float maxcaughtValue;

    float restartTimer;
    Vector2 screenPlacement;

    public static bool isPaused = false;

    [Header("Text Popup")]
    [SerializeField]
    GameObject popupGO;
    [SerializeField]
    Text popupName;
    [SerializeField]
    Text popupBody;
    Vector2 screenOffset;
    string nameOfChatter;
    string bodyOfChatter;
    float popupDisplayTime;
    GameObject whoIsTalking;


    public static float gameTimer;
    [Header("Game Timer")]
    [SerializeField]
    Text gameTimerText;
    float displayTimer;
    bool restart = false;

    void Start ()
    {
        if (mindPowerSlider)
        {
            mindPowerSlider.maxValue = maxMindPower;
            mindPowerSlider.minValue = 0;
            currentMindPower = maxMindPower;
            mindPowerSlider.value = maxMindPower;
        }
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

    void Update ()
    {
        if (restart)
        {
            restartTimer += Time.deltaTime;
            if (restartTimer > 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        if (mindPowerSlider)
        {
            mindPowerSlider.value = currentMindPower;
            valueText.text = currentMindPower.ToString("0");
        }

        if (popupDisplayTime > 0)
        {
            DisplayPopUp();
            popupDisplayTime -= Time.deltaTime;
        }
        else
        {
            if(popupGO)
            popupGO.SetActive(false);
        }

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
                restart = true;
            }
            else if (currentCaughtValue <= 0)
            {
                caughtText.gameObject.SetActive(false);
                caughtSlider.gameObject.SetActive(false);
            }

            if (currentCaughtValue < 0)
                currentCaughtValue = 0;
        }

        if(!FindObjectOfType<KT_GameOver>())
        gameTimer += Time.deltaTime;
        //displayTimer = gameTimer * 100;
        if (gameTimerText)
            gameTimerText.text = SetBaseSixty(gameTimer); //displayTimer.ToString("0:00:00");
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

    public void GrabTheMessage (string talker, string body, float timeToDisplay, GameObject whoTalks)
    {
        nameOfChatter = talker;
        bodyOfChatter = body;
        popupDisplayTime = timeToDisplay;
        whoIsTalking = whoTalks;
        Debug.Log("Got the message");
    }

    void DisplayPopUp ()
    {
        popupGO.SetActive(true);
        screenOffset = Camera.main.WorldToScreenPoint(whoIsTalking.transform.position);
        screenOffset.y += 30;
        screenOffset.x += 15;
        popupBody.text = bodyOfChatter;
        popupName.text = nameOfChatter;
        popupGO.gameObject.transform.position = screenOffset;
        Debug.Log("Displaying the message");
    }
}
