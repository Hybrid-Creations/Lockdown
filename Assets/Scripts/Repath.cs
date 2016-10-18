using UnityEngine;
using System.Collections;

public class Repath : MonoBehaviour {

    public Waypoint[] roomWaypoints;

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            col.GetComponent<Unit>().rePath = true;
            Debug.Log("DANK MEMES??????");
            col.GetComponent<Unit>().roomWaypoints = roomWaypoints;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            col.GetComponent<Unit>().rePath = false;
        }
    }
}
