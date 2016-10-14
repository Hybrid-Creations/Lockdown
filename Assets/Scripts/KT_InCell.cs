using UnityEngine;
using System.Collections;

public class KT_InCell : MonoBehaviour {

    public static bool inCell;

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            inCell = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            inCell = false;
        }
    }
}
