#if(UNITY_EDITOR)
using UnityEditor;
#endif
using UnityEngine;
using System.Collections;

public class WaypointHolder : MonoBehaviour {

#if(UNITY_EDITOR)
    [MenuItem("Waypoints/UpdateWaypoints _%;")]
    static void ExampleCallback()
    {
        Object[] all = FindObjectsOfType(typeof(Waypoint));
        Debug.Log( all.Length + " waypoints have been moved.");

        foreach(Waypoint wP in all)
        {
            wP.transform.parent = GameObject.FindGameObjectWithTag("WaypointHolder").transform;
        }
    }
#endif
}
