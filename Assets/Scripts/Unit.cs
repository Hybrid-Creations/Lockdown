//Name: Tristan Burger
//Date: 10/9/2016

//Purpose: management of all type of untits

using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{
    [Header("")]
    public bool isTutorial;

    public enum Faction
    {
        CONTROLLABLE,
        UNCONTROLLABLE,
    }

    public enum AIMode
    {
        RELAXED,
        ALERT
    }

    [Header("")]
    public bool isControlled;

    public bool randomWaypoints;

    public AIMode currentAIMode = AIMode.RELAXED;

    public Faction currentFaction = Faction.UNCONTROLLABLE;

    [Header("Light")]
    public Light lightObj;

    float pulseSpeedMult = 2;
    float minIntensity = 0.5f;
    float maxIntensity = 1.5f;
    [HideInInspector]
    public float pulseTimer;
    [HideInInspector]
    public bool pulseUp;

    [Header("Movement")]
    public Waypoint[] waypoints;

    [HideInInspector]
    public int currentWaypoint = 0;

    public GameObject[] lookDirections;

    public float moveSpeed = 1.7f;

    [HideInInspector]
    public Vector3 originalPosition;
    [HideInInspector]
    public Vector3 oldPosition;
    Vector3 difference;

    [HideInInspector]
    public float closestDistance;
    [HideInInspector]
    public float section;

    [Header("AI Values")]
    public float sightAngle = 30;
    public float sightRange = 3.7f;

    public GameObject sightRangeObject;

    Transform playerPos;

    void Start ()
    {
        originalPosition = transform.position;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        
    }

    public void MoveTowardsWaypoint (Vector3 waypointPosition)
    {
        section += Time.deltaTime * 1 / Vector3.Distance(originalPosition, waypointPosition) * moveSpeed;

        if (section > Vector3.Distance(originalPosition, waypointPosition))
        {
            section = 0;
        }
        //The actual movement
        transform.position = Vector3.Lerp(originalPosition, waypointPosition, section);

        if (Vector3.Distance(transform.position, waypointPosition) <= 0.05f)
        {
            currentWaypoint = UpdateCurrentWaypoint();
        }
        else if (Vector3.Distance(originalPosition, waypointPosition) < 0.9f)
        {
            currentWaypoint = UpdateCurrentWaypoint();
        }

        if (oldPosition != transform.position)
        {
            if (!isTutorial)
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
   }

    public int UpdateCurrentWaypoint ()
    {
        Debug.Log(waypoints.Length);
        if (randomWaypoints)
        {
            int l = currentWaypoint;

            int i = Random.Range(0, waypoints.Length);

            if (i == l)
            {
                i++;
            }
            if (i >= waypoints.Length)
            {
                i = 0;
            }

            originalPosition = transform.position;
            section = 0;
            return i;

        }
        else
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
    }

    public void LookUp ()
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

    public void LookRight ()
    {
        if (lookDirections.Length == 4)
        {
            lookDirections[0].SetActive(false);
            lookDirections[1].SetActive(true);
            lookDirections[2].SetActive(false);
            lookDirections[3].SetActive(false);
        }
    }

    public void LookDown ()
    {
        if (lookDirections.Length == 4)
        {
            lookDirections[0].SetActive(false);
            lookDirections[1].SetActive(false);
            lookDirections[2].SetActive(true);
            lookDirections[3].SetActive(false);
        }
    }

    public void LookLeft ()
    {
        if (lookDirections.Length == 4)
        {
            lookDirections[0].SetActive(false);
            lookDirections[1].SetActive(false);
            lookDirections[2].SetActive(false);
            lookDirections[3].SetActive(true);
        }
    }

    public void FindNearestWaypoint ()
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

    public void PulseLight ()
    {
        if (isControlled)
        {
            if (lightObj.enabled == false)
                lightObj.enabled = true;
            if (lightObj.gameObject.activeInHierarchy == false)
                lightObj.gameObject.SetActive(true);

            if (pulseUp)
            {
                pulseTimer += Time.deltaTime * pulseSpeedMult;
            }

            if (!pulseUp)
            {
                pulseTimer -= Time.deltaTime * pulseSpeedMult;
            }
            lightObj.intensity = Mathf.Lerp(minIntensity, maxIntensity, pulseTimer);

            if (pulseTimer <= 0)
                pulseUp = true;
            if (pulseTimer >= 1)
                pulseUp = false;
        }
    }

    public void UpdateAI ()
    {
        if (!isControlled)
        {
            sightRangeObject.SetActive(true);
            if (!playerPos)
                playerPos = GameObject.FindGameObjectWithTag("Player").transform;

            //DotTest
            Vector2 lookThisWay = playerPos.position - sightRangeObject.transform.position;
            Vector2 toMe = sightRangeObject.transform.position - playerPos.position;
            float distance = lookThisWay.magnitude;

            float dotForwardResult = Vector2.Dot(lookThisWay.normalized, -sightRangeObject.transform.right);
            float angle = Mathf.Acos(dotForwardResult);
            angle = Mathf.Rad2Deg * angle;

            if (!KT_InCell.inCell)
            {
                if (angle < sightAngle && lookThisWay.magnitude < sightRange)
                {
                    //Debug.Log("MEMES????");
                    currentAIMode = AIMode.ALERT;

                    Debug.Log("I CAN SEE YOU");
                    FindObjectOfType<uiStatsManager>().currentCaughtValue += (Time.deltaTime * 6.6f) / distance;
                    FindObjectOfType<uiStatsManager>().guardWhoCanSee = gameObject;

                }
                else if (currentAIMode == AIMode.ALERT)
                {
                    FindObjectOfType<uiStatsManager>().currentCaughtValue -= Time.deltaTime;
                }
            }
            else if (currentAIMode == AIMode.ALERT)
            {
                FindObjectOfType<uiStatsManager>().currentCaughtValue -= Time.deltaTime;
            }

            if (FindObjectOfType<uiStatsManager>().currentCaughtValue <= 0)
            {
                currentAIMode = AIMode.RELAXED;
            }

            if (currentAIMode == AIMode.ALERT)
            {
                float angleT = Mathf.Atan2(-lookThisWay.y, -lookThisWay.x) * Mathf.Rad2Deg;
                Quaternion q = Quaternion.AngleAxis(angleT, sightRangeObject.transform.forward);
                sightRangeObject.transform.rotation = Quaternion.Slerp(sightRangeObject.transform.rotation, q, Time.deltaTime * 4f);
            }
            else if (currentAIMode == AIMode.RELAXED)
            {
                float angleT = Mathf.Atan2(-difference.y, -difference.x) * Mathf.Rad2Deg;
                Quaternion q = Quaternion.AngleAxis(angleT, sightRangeObject.transform.forward);
                sightRangeObject.transform.rotation = Quaternion.Slerp(sightRangeObject.transform.rotation, q, Time.deltaTime * 10);
            }
        }
        else if (isControlled)
        {
            sightRangeObject.SetActive(false);
        }
    }
}
