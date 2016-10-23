using UnityEngine;
using System.Collections;

public class Repath : MonoBehaviour {

    public enum WhoCanPath {
        RED,
        BLUE,
        YELLOW,
        PURPLE,
        GREEN,
        ORANGE,
        GREY
    }

    public WhoCanPath myRoomType = WhoCanPath.GREY;

    public Waypoint[] roomWaypoints;

    public bool giveNewPath;

    public Waypoint[] newPath;

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            //All
            if(myRoomType == WhoCanPath.GREY)
            {
                col.GetComponent<Unit>().rePath = true;
                col.GetComponent<Unit>().roomWaypoints = roomWaypoints;
            }

            //Red
            if (myRoomType == WhoCanPath.RED)
            {
                if (col.GetComponent<LabTech>().myType == LabTech.TechType.RED)
                {
                    col.GetComponent<Unit>().rePath = true;
                    Debug.Log("DANK MEMES??????");
                    col.GetComponent<Unit>().roomWaypoints = roomWaypoints;
                }
            }
            //Purple
            if (myRoomType == WhoCanPath.PURPLE)
            {
                if (col.GetComponent<LabTech>().myType == LabTech.TechType.RED || col.GetComponent<LabTech>().myType == LabTech.TechType.BLUE)
                {
                    col.GetComponent<Unit>().rePath = true;
                    Debug.Log("DANK MEMES??????");
                    col.GetComponent<Unit>().roomWaypoints = roomWaypoints;
                }
            }

            //Blue
            if (myRoomType == WhoCanPath.BLUE)
            {
                if (col.GetComponent<LabTech>().myType == LabTech.TechType.BLUE)
                {
                    col.GetComponent<Unit>().rePath = true;
                    Debug.Log("DANK MEMES??????");
                    col.GetComponent<Unit>().roomWaypoints = roomWaypoints;
                }
            }
            //Green
            if (myRoomType == WhoCanPath.GREEN)
            {
                if (col.GetComponent<LabTech>().myType == LabTech.TechType.BLUE || col.GetComponent<LabTech>().myType == LabTech.TechType.YELLOW)
                {
                    col.GetComponent<Unit>().rePath = true;
                    Debug.Log("DANK MEMES??????");
                    col.GetComponent<Unit>().roomWaypoints = roomWaypoints;
                }
            }

            //Yellow
            if (myRoomType == WhoCanPath.YELLOW)
            {
                if (col.GetComponent<LabTech>().myType == LabTech.TechType.YELLOW)
                {
                    col.GetComponent<Unit>().rePath = true;
                    Debug.Log("DANK MEMES??????");
                    col.GetComponent<Unit>().roomWaypoints = roomWaypoints;
                }
            }
            //Orange
            if (myRoomType == WhoCanPath.ORANGE)
            {
                if (col.GetComponent<LabTech>().myType == LabTech.TechType.YELLOW || col.GetComponent<LabTech>().myType == LabTech.TechType.RED)
                {
                    col.GetComponent<Unit>().rePath = true;
                    Debug.Log("DANK MEMES??????");
                    col.GetComponent<Unit>().roomWaypoints = roomWaypoints;
                }
            }

            if (giveNewPath)
            {
                col.GetComponent<Unit>().waypoints = newPath;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            col.GetComponent<Unit>().rePath = false;
        }
    }
}
