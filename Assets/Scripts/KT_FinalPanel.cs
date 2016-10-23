using UnityEngine;
using System.Collections;

public class KT_FinalPanel : MonoBehaviour {

    [SerializeField]
    GameObject[] finalDoor;
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

    [SerializeField]
    GameObject[] lightPath;

    GameObject player;

    bool panelReady = false;
    bool panelActivation = false;
    bool clicked = false;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        panelWork = GetComponent<Animator>();
        lightOn = Color.green;
        lightOff = Color.grey;
        panelLight = GetComponent<Light>();
        panelLight.enabled = false;
        finalDoor = GameObject.FindGameObjectsWithTag("FinalDoor");
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
                for(int i = 0; i < finalDoor.Length; i++)
                {                   
                finalDoor[i].SetActive(false);
                }
            }
            LightPathOn();
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
            panelLight.enabled = false;
            panelReady = false;
        }
    }

    public void ReadyToClick()
    {
        if (panelReady && panelActivation == false && clicked == false)
        {
            clicked = true;
            player.GetComponent<KT_UseAudio>().AudClips(1);
            Debug.Log("Clicked");
        }
    }

    void ColorOn()
    {
        lightOne.GetComponent<SpriteRenderer>().color = lightOff;
        lightTwo.GetComponent<SpriteRenderer>().color = lightOn;
    }

    void LightPathOn()
    {
        if (clicked)
        {
            for (int i = 0; i < lightPath.Length; i++)
            {
                lightPath[i].GetComponent<SpriteRenderer>().color = Color.green;
            }
        }
    }
}
