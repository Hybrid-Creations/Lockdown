//Name: Tristan Burger
//Date: 10/9/2016

//Purpose: Management of Lab Techs

using UnityEngine;
using System.Collections;

public class LabTech : Unit
{
    //[Header("")]
    //leave this please
    bool bruteBlock;
    [HideInInspector]
    public GameObject BruteBlock;

    public enum TechType
    {
        RED,
        YELLOW,
        BLUE
    }

    [Header("")]
    public TechType myType = TechType.RED;

    // Use this for initialization
    void Start ()
    {
        originalPosition = transform.position;
        currentWaypoint = waypoints[0];
    }

    // Update is called once per frame
    void Update ()
    {
        if (!isTutorial)
        {
            UpdateAI();
        }

        if (!bruteBlock)
        {
            if (!isControlled && currentAIMode != AIMode.ALERT)
                MoveTowardsWaypoint(currentWaypoint.gameObject.transform.position);
        }
        if (isControlled)
            PulseLight();



        //RaycastHit2D hit;

        //if (hit = Physics2D.Raycast(transform.position, difference.normalized, difference.normalized.magnitude))
        //{
        //    if (hit.collider.gameObject.tag == "BruteBlock")
        //    {
        //        bruteBlock = true;
        //        BruteBlock = hit.collider.gameObject;
        //    }
        //    else
        //    {
        //        if (hit.collider.gameObject.tag == "BruteBlock")
        //        {
        //            bruteBlock = false;
        //            BruteBlock = null;
        //        }
        //    }
        //}

    }

    void OnCollisionStay2D (Collision2D other)
    {
        if (other.collider.gameObject.tag == "BruteBlock")
        {
            bruteBlock = true;
            BruteBlock = other.collider.gameObject;
            BruteBlock.GetComponent<Rigidbody2D>().isKinematic = true;
            BruteBlock.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    void OnCollisionExit2D (Collision2D other)
    {
        if (other.collider.gameObject.tag == "BruteBlock")
        {
            //BruteBlock.GetComponent<Rigidbody2D>().isKinematic = false;
            bruteBlock = false;
            BruteBlock = null;
        }
    }
}