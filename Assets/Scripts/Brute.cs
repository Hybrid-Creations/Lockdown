//Name: Tristan Burger
//Date: 10/9/2016

//Purpose: Management of the Brute enemy type

using UnityEngine;
using System.Collections;

public class Brute : Unit {
    [Header("")]
    //leave this please

    public GameObject dank;
    [SerializeField]
    GameObject memes;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 movementDir;
        movementDir = waypoints[currentWaypoint].gameObject.transform.position - transform.position;
	}
}
