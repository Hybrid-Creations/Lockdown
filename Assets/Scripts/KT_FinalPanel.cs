using UnityEngine;
using System.Collections;

public class KT_FinalPanel : MonoBehaviour {

    [SerializeField]
    GameObject finalDoor;
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
        finalDoor = GameObject.Find("FinalDoor");
    }

    // Update is called once per frame
    void Update()
    {
        panelActivation = panelWork.GetBool("On");
        if (clicked)
        {
            panelWork.SetBool("On", true);
            openTimer += Time.deltaTime;
            if(openTimer >= .5f)
            {
                finalDoor.SetActive(false);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            panelLight.enabled = true;
            panelReady = true;
        }

        //if (other.tag == "Enemy" && Input.GetMouseButtonDown(0))
        //{
        //    finalDoor.SetActive(false);
        //}
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            panelLight.enabled = false;
        }
    }

    public void ReadyToClick()
    {
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
