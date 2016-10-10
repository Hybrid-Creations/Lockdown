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
            //currentControl.GetComponent<Unit>().;
        }
        if (Input.GetKey(KeyCode.A))
        {
            currentControl.transform.position += -currentControl.transform.right * moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            currentControl.transform.position += currentControl.transform.right * moveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            currentControl.transform.position += -currentControl.transform.up * moveSpeed;
        }
    }
}
