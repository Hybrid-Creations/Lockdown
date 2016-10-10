//Name: Tristan Burger
//Date: 10/9/2016

//Purpose: management of all type of untits

using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

    public Waypoint[] waypoints;

    [HideInInspector]
    public int currentWaypoint = 0;

    public float moveSpeed = 0.7f;

    public enum Faction {
        CONTROLLABLE,
        UNCONTROLLABLE,
    }

    public Faction currentFaction = Faction.UNCONTROLLABLE;

    public GameObject[] lookDirections;

    public Vector3 originalPosition;
    public Vector3 oldPosition;

    float section;

    void Start()
    {
        originalPosition = transform.position;
    }

    public void MoveTowardsWaypoint(Vector3 waypointPosition)
    {
        section += Time.deltaTime * 1 / Vector3.Distance(originalPosition, waypointPosition) * 1.7f;

        if(section > Vector3.Distance(originalPosition, waypointPosition))
        {
            section = 0;
        }
        transform.position = Vector3.Lerp(originalPosition, waypointPosition, section);
        if(Vector3.Distance(transform.position, waypointPosition) <= 0.05f)
        {
            currentWaypoint = UpdateCurrentWaypoint();
        }
        if(oldPosition != transform.position)
        {
            Vector3 difference = transform.position - oldPosition;
            if(difference.normalized == Vector3.up)
            {
                LookUp();
            }
            if (difference.normalized == Vector3.right)
            {
                LookRight();
            }
            if (difference.normalized == -Vector3.up)
            {
                LookDown();
            }
            if (difference.normalized == -Vector3.right)
            {
                LookLeft();
            }
        }
        oldPosition = transform.position;
    }

    public int UpdateCurrentWaypoint()
    {
        int i = currentWaypoint;

        i++;

        if( i >= waypoints.Length)
        {
            i = 0;
        }
        originalPosition = transform.position;
        section = 0;
        return i;
    }

    public void LookUp()
    {
        if (lookDirections.Length == 4)
        {
            lookDirections[0].SetActive(true);
            lookDirections[1].SetActive(false);
            lookDirections[2].SetActive(false);
            lookDirections[3].SetActive(false);
        }
    }

    public void LookRight()
    {
        if (lookDirections.Length == 4)
        {
            lookDirections[0].SetActive(false);
            lookDirections[1].SetActive(true);
            lookDirections[2].SetActive(false);
            lookDirections[3].SetActive(false);
        }
    }

    public void LookDown()
    {
        if (lookDirections.Length == 4)
        {
            lookDirections[0].SetActive(false);
            lookDirections[1].SetActive(false);
            lookDirections[2].SetActive(true);
            lookDirections[3].SetActive(false);
        } }

    public void LookLeft()
    {
        if (lookDirections.Length == 4)
        {
            lookDirections[0].SetActive(false);
            lookDirections[1].SetActive(false);
            lookDirections[2].SetActive(false);
            lookDirections[3].SetActive(true);
        } }
}
