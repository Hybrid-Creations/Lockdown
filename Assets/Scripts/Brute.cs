//Name: Tristan Burger
//Date: 10/9/2016

//Purpose: Management of the Brute enemy type

using UnityEngine;
using System.Collections;

public class Brute : Unit
{
    [Header("")]
    //leave this please

    public GameObject dank;
    [SerializeField]
    GameObject memes;

    void Update ()
    {
        if (!isControlled)
            MoveTowardsWaypoint(waypoints[currentWaypoint].gameObject.transform.position);
    }
}
