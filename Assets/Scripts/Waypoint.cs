//Name: Tristan Burger
//Date: 10/9/2016

//Purpose: Waypoints for movement

using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {
    //Dank Memes

    Waypoint[] waypointsInScene;

    void Start()
    {
        waypointsInScene = FindObjectsOfType<Waypoint>();

        for (int i = 0; i < waypointsInScene.Length; i++)
        {
            Vector2 dank = waypointsInScene[i].transform.position - transform.position;
            Debug.DrawRay(transform.position, dank, Color.blue, Mathf.Infinity);
        }
    }
}
