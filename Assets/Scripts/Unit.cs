//Name: Tristan Burger
//Date: 10/9/2016

//Purpose: management of all type of untits

using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

    public enum Faction {
        CONTROLLABLE,
        UNCONTROLLABLE,
    }

    public bool isControlled;

    public Faction currentFaction = Faction.UNCONTROLLABLE;

    public Waypoint[] waypoints;

    [HideInInspector]
    public int currentWaypoint = 0;

    public GameObject[] lookDirections;

    public float moveSpeed = 1.7f;

    public Vector3 originalPosition;
    [HideInInspector]
    public Vector3 oldPosition;
    Vector3 difference;

    [HideInInspector]
    public float closestDistance;
    [HideInInspector]
    public float section;

    void Start()
    {
        originalPosition = transform.position;
    }

    public void MoveTowardsWaypoint(Vector3 waypointPosition)
    {
        section += Time.deltaTime * 1 / Vector3.Distance(originalPosition, waypointPosition) * moveSpeed;

        if (section > Vector3.Distance(originalPosition, waypointPosition))
        {
            section = 0;
        }
        transform.position = Vector3.Lerp(originalPosition, waypointPosition, section);
        if (Vector3.Distance(transform.position, waypointPosition) <= 0.05f)
        {
            currentWaypoint = UpdateCurrentWaypoint();
        }

        if (oldPosition != transform.position)
        {
            difference = transform.position - oldPosition;
            if (difference.normalized.y > 0.5f)
            {
                LookUp();
            }
            if (difference.normalized.x > 0.5f)
            {
                LookRight();
            }
            if (difference.normalized.y < -0.5f)
            {
                LookDown();
            }
            if (difference.normalized.x < -0.5f)
            {
                LookLeft();
            }
        }
        //Debug.Log(difference.normalized);
        oldPosition = transform.position;
    }

    public int UpdateCurrentWaypoint()
    {
        int i = currentWaypoint;

        i++;

        if (i >= waypoints.Length)
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
        //Debug.Log("looked Up");
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
        }
    }

    public void LookLeft()
    {
        if (lookDirections.Length == 4)
        {
            lookDirections[0].SetActive(false);
            lookDirections[1].SetActive(false);
            lookDirections[2].SetActive(false);
            lookDirections[3].SetActive(true);
        }
    }

    public void FindNearestWaypoint()
    {
        for (int i = 0; i < waypoints.Length; i++)
        {
            if (Vector3.Distance(transform.position, waypoints[i].transform.position) < closestDistance)
            {
                closestDistance = Vector3.Distance(transform.position, waypoints[i].transform.position);
                currentWaypoint = i;
            }
        }
            Debug.Log(currentWaypoint);
    }
}
