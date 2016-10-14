using UnityEngine;
using System.Collections;

public class KT_Room : MonoBehaviour
{

    [SerializeField]
    GameObject door;

    public Waypoint wayPointIn;
    public Waypoint wayPointOut;

    public enum ColorDoor
    {
        RED,
        YELLOW,
        BLUE,
        GRAY
    }

    public ColorDoor myDoor = ColorDoor.GRAY;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<LabTech>())
        {
            if (myDoor == ColorDoor.RED)
            {
                if (other.gameObject.GetComponent<LabTech>().myType == LabTech.TechType.RED)
                {
                    door.SetActive(false);
                }
            }
            if (myDoor == ColorDoor.BLUE)
            {
                if (other.gameObject.GetComponent<LabTech>().myType == LabTech.TechType.BLUE)
                {
                    door.SetActive(false);
                }
            }
            if (myDoor == ColorDoor.YELLOW)
            {
                if (other.gameObject.GetComponent<LabTech>().myType == LabTech.TechType.YELLOW)
                {
                    door.SetActive(false);
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<LabTech>())
        {
            if (myDoor == ColorDoor.RED)
            {
                if (other.gameObject.GetComponent<LabTech>().myType == LabTech.TechType.RED)
                {
                    door.SetActive(true);
                }
            }
            if (myDoor == ColorDoor.BLUE)
            {
                if (other.gameObject.GetComponent<LabTech>().myType == LabTech.TechType.BLUE)
                {
                    door.SetActive(true);
                }
            }
            if (myDoor == ColorDoor.YELLOW)
            {
                if (other.gameObject.GetComponent<LabTech>().myType == LabTech.TechType.YELLOW)
                {
                    door.SetActive(true);
                }
            }
        }
    }
}
