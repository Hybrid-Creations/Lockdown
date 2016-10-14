using UnityEngine;
using System.Collections;

public class KT_LockedRoom : MonoBehaviour
{

    [SerializeField]
    GameObject door;

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
        if (myDoor == ColorDoor.GRAY && KT_GetKey.hasKey)
        {
            if (other.gameObject.GetComponent<LabTech>().myType == LabTech.TechType.RED)
            {
                door.SetActive(false);
            }
        }

    }

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (myDoor == ColorDoor.RED && KT_GetKey.hasKey)
    //    {
    //        if (other.gameObject.GetComponent<LabTech>().myType == LabTech.TechType.RED)
    //        {
    //            door.SetActive(true);
    //        }
    //    }
    //    if (myDoor == ColorDoor.BLUE && KT_GetKey.hasKey)
    //    {
    //        if (other.gameObject.GetComponent<LabTech>().myType == LabTech.TechType.BLUE)
    //        {
    //            door.SetActive(true);
    //        }
    //    }
    //    if (myDoor == ColorDoor.YELLOW && KT_GetKey.hasKey)
    //    {
    //        if (other.gameObject.GetComponent<LabTech>().myType == LabTech.TechType.YELLOW)
    //        {
    //            door.SetActive(true);
    //        }
    //    }
    //}
}
