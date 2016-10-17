//Name: Kevin Thomas
//Date: 10/17/16
//Credit: PnP2 Message System Script
//
//Purpose: To devise a message system for the player, from specific entities;

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KT_MsgSystem : MonoBehaviour
{

    private float msgTimer = 0;
    public Text chat;
    public Text from;
    public bool textShowing;


    void Update()
    {
        if (msgTimer > 0)
        {
            msgTimer -= Time.deltaTime;
        }
        else {
            textShowing = false;
        }

        if (textShowing == false)
        {
            chat.text = null;
            from.text = null;
        }
    }

    public void DisplayMessage(string messenger, string body, float displayTime)
    {
        chat.text = body;
        from.text = messenger;
        msgTimer = displayTime;
        textShowing = true;
    }
}
