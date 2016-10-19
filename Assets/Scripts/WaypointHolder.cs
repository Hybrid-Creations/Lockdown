using UnityEditor;
using UnityEngine;
using System.Collections;

public class WaypointHolder : MonoBehaviour {

    [MenuItem("Waypoints/Hierarchy Window Changed")]
    static void Example()
    {
        EditorApplication.hierarchyWindowChanged += ExampleCallback;
    }
    static void ExampleCallback()
    {
        Object[] all = FindObjectsOfType(typeof(Waypoint));
        Debug.Log("There are " + all.Length + " waypoints at the moment.");

        foreach(Waypoint wP in all)
        {
            wP.transform.parent = GameObject.FindGameObjectWithTag("WaypointHolder").transform;
        }
    }
}
