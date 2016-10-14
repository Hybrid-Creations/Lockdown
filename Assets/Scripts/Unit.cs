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

    public enum AIMode {
        RELAXED,
        ALERT
    }

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


    void Start()
    {
        originalPosition = transform.position;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
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
        if (Vector3.Distance(originalPosition, waypointPosition) < 1)
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
        if (!randomWaypoints)
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
        else
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

    public void PulseLight()
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

            //Debug.Log(pulseTimer);
            //Debug.Log(pulseUp);
            //Debug.Log(Mathf.Lerp(minIntensity, maxIntensity, pulseTimer));
        }
    }

    public void UpdateAI()
    {
        if (!isControlled)
        {
            sightRangeObject.SetActive(true);
            if (!playerPos)
                playerPos = GameObject.FindGameObjectWithTag("Player").transform;

            Vector2 towardsPlayer = sightRangeObject.transform.position - playerPos.position;
            float angle = Vector2.Angle(towardsPlayer, sightRangeObject.transform.right);

            if (Vector2.Distance(sightRangeObject.transform.position, playerPos.position) < sightRange)
            {
                if (angle < sightAngle)
                {
                    currentAIMode = AIMode.ALERT;
                    Debug.Log("I CAN SEE YOU");
                    FindObjectOfType<uiStatsManager>().currentCaughtValue += (Time.deltaTime * 8.5f) / Vector2.Distance(sightRangeObject.transform.position, playerPos.position);
                    FindObjectOfType<uiStatsManager>().guardWhoCanSee = gameObject;
                }
            }
            else
            {
                FindObjectOfType<uiStatsManager>().currentCaughtValue -= Time.deltaTime * 0.75f;
            }

            if (FindObjectOfType<uiStatsManager>().currentCaughtValue <= 0)
            {
                currentAIMode = AIMode.RELAXED;
            }

            if (currentAIMode == AIMode.ALERT)
            {
                float angleT = Mathf.Atan2(towardsPlayer.y, towardsPlayer.x) * Mathf.Rad2Deg;
                Quaternion q = Quaternion.AngleAxis(angleT, sightRangeObject.transform.forward);
                sightRangeObject.transform.rotation = Quaternion.Slerp(sightRangeObject.transform.rotation, q, Time.deltaTime * 4f);

                //Debug.Log(angleT);

                //if(angleT )
            }

            if (currentAIMode == AIMode.RELAXED)
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
