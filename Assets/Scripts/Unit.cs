//Name: Tristan Burger
//Date: 10/9/2016

//Purpose: management of all type of untits

using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

    public Waypoint[] waypoints;

    public int currentWaypoint = 0;

    public float moveSpeed = 0.7f;

    public enum Faction {
        CONTROLLABLE,
        UNCONTROLLABLE,
    }

    public Faction currentFaction = Faction.UNCONTROLLABLE;

    public GameObject[] lookDirections;
}
