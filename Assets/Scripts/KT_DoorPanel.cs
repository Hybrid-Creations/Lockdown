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

    [SerializeField]
    GameObject thingToActivate;

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
            panelReady = false;
            panelLight.enabled = false;
        }
    }

    public void ReadyToClick()
    {
        Debug.Log("Clicked");
        if (panelReady && panelActivation == false && clicked == false)
        {
            player.GetComponent<KT_UseAudio>().AudClips(1);
            clicked = true;
            if(thingToActivate)
            thingToActivate.SetActive(true);
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
