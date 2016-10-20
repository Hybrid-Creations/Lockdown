using UnityEditor;
using UnityEngine;
using System.Collections;

public class WaypointHolder : MonoBehaviour {

    [MenuItem("Waypoints/UpdateWaypoints _%W")]
    static void ExampleCallback()
    {
        Object[] all = FindObjectsOfType(typeof(Waypoint));
        Debug.Log( all.Length + " waypoints have been moved.");

        foreach(Waypoint wP in all)
        {
            wP.transform.parent = GameObject.FindGameObjectWithTag("WaypointHolder").transform;
        }
    }
}
