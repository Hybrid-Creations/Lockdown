//Name: Kevin Thomas
//Date: 10/17/16
//Credit: PnP2 Message System Script
//
//Purpose: To devise a message system for the player, from specific entities

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KT_MsgVolume : MonoBehaviour {

    private KT_MsgSystem msg;

    public GameObject whoIsTalking;
    public string msgFrom;
    public string msgBody;
    public float msgTime;

    public bool onlyOnce = false;

    void Start()
    {
        msg = FindObjectOfType<KT_MsgSystem>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            msg.DisplayMessage(msgFrom,msgBody,msgTime, whoIsTalking);
        }
        //Debug.Log(other.name + " Is sitting in here");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" && msg.textShowing == false)
        {
            if (onlyOnce)
            {
                Destroy(gameObject);
            }
        }
    }
}
