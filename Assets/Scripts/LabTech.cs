//Name: Tristan Burger
//Date: 10/9/2016

//Purpose: Management of Lab Techs

using UnityEngine;
using System.Collections;

public class LabTech : Unit {
    //[Header("")]
    //leave this please

    public enum TechType {
        RED,
        YELLOW,
        BLUE
    }

    [Header("")]
    public TechType myType = TechType.RED;

    // Use this for initialization
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isControlled && currentAIMode != AIMode.ALERT)
            MoveTowardsWaypoint(waypoints[currentWaypoint].gameObject.transform.position);
        if (isControlled)
            PulseLight();

        UpdateAI();
    }
}
