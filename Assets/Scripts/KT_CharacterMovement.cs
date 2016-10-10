//Name: Kevin Thomas
//Date: 10/9/16
//Credit:
//
//Purpose: To create movement for characters

using UnityEngine;
using System.Collections;

public class KT_CharacterMovement : MonoBehaviour {

    [SerializeField]
    float moveSpeed = 3;

    public GameObject currentControl;

    public static bool up;
    public static bool right;
    public static bool down;
    public static bool left;

    // Use this for initialization
    void Start () {
        currentControl = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        CharacterMovement();
	}

    void CharacterMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            currentControl.transform.position += currentControl.transform.up * moveSpeed;

            up = true;
            right = false;
            down = false;
            left = false;
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            currentControl.transform.position += -currentControl.transform.right * moveSpeed;
            up = false;
            right = false;
            down = false;
            left = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            currentControl.transform.position += currentControl.transform.right * moveSpeed;
            up = false;
            right = true;
            down = false;
            left = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            currentControl.transform.position += -currentControl.transform.up * moveSpeed;
            up = false;
            right = false;
            down = true;
            left = false;
        }
        currentControl.GetComponent<Unit>().lookDirections[0].gameObject.SetActive(up);
        currentControl.GetComponent<Unit>().lookDirections[1].gameObject.SetActive(right);
        currentControl.GetComponent<Unit>().lookDirections[2].gameObject.SetActive(down);
        currentControl.GetComponent<Unit>().lookDirections[3].gameObject.SetActive(left);
    }
}
