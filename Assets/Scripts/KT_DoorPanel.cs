using UnityEngine;
using System.Collections;

public class KT_DoorPanel : MonoBehaviour {

    [SerializeField]
    GameObject door;
    [SerializeField]
    Light panelLight;

    [SerializeField]
    GameObject lightOne;
    [SerializeField]
    GameObject lightTwo;

    Color lightOn;
    Color lightOff;

    Animator panelWork;

    [SerializeField]
    float openTimer;

    bool panelReady = false;
    bool panelActivation = false;
    bool clicked = false;
    // Use this for initialization
    void Start()
    {
        panelWork = GetComponent<Animator>();
        lightOn = Color.green;
        lightOff = Color.grey;
        panelLight = GetComponent<Light>();
        panelLight.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        panelActivation = panelWork.GetBool("On");
        if (clicked)
        {
            panelWork.SetBool("On", true);
            openTimer += Time.deltaTime;
            if (openTimer >= .5f)
                door.SetActive(false);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Enemy" && other.gameObject.GetComponent<LabTech>().isControlled)
        {
            panelLight.enabled = true;
            panelReady = true;
            Debug.Log("PanelReady");
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            panelReady = false;
            panelLight.enabled = false;
        }
    }

    public void ReadyToClick()
    {
            Debug.Log("Clicked");
        if (panelReady && panelActivation == false && clicked == false)
        {
            clicked = true;
        }
    }

    void ColorOn()
    {
        lightOne.GetComponent<SpriteRenderer>().color = lightOff;
        lightTwo.GetComponent<SpriteRenderer>().color = lightOn;
    }
}
