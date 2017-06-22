//Name: Tristan Burger
//Date: 10/9/2016

//Purpose: Management of the Brute enemy type

using UnityEngine;
using System.Collections;

public class Brute : Unit {

    public enum TypeOf
    {
        BRUTE
    }

    public TypeOf myType = TypeOf.BRUTE;

    void Start ()
    {
        originalPosition = transform.position;
        currentWaypoint = waypoints[0];
    }

    void Update()
    {
        if (!isTutorial)
        {
            UpdateAI();
        }

        if (!isControlled && currentAIMode != AIMode.ALERT)
            MoveTowardsWaypoint(currentWaypoint.gameObject.transform.position);
        if (isControlled)
            PulseLight();
    }

    void OnCollisionStay2D (Collision2D other)
    {
        if(other.collider.gameObject.tag == "BruteBlock")
        {
            other.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            other.collider.gameObject.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
        }
    }

    void OnCollisionExit2D (Collision2D other)
    {
        if (other.collider.gameObject.tag == "BruteBlock")
        {
            other.collider.gameObject.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
            other.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }
}
