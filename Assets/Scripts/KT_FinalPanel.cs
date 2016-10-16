using UnityEngine;
using System.Collections;

public class KT_FinalPanel : MonoBehaviour {

    [SerializeField]
    GameObject finalDoor;
    [SerializeField]
    Light panelLight;


    bool panelReady = false;
    // Use this for initialization
    void Start()
    {
        panelLight = GetComponent<Light>();
        panelLight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

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
        if (panelReady)
        {
            finalDoor.SetActive(false);
        }
    }
}
