using UnityEngine;
using System.Collections;

public class Repath : MonoBehaviour {

    public Waypoint firstWaypoint;
    public Waypoint secondWaypoint;

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Enemy")
        {
            col.GetComponent<Unit>().rePath = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Enemy")
        {
            col.GetComponent<Unit>().rePath = false;
        }
    }
}
