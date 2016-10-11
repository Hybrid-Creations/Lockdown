//Name: Kevin Thomas
//Date: 10/9/2016
//Credit:
//
//Purpose: Allow the player to mind control an enemy

using UnityEngine;
using System.Collections;

public class KT_MindControl : MonoBehaviour {
    [SerializeField]
    Light psyGlow;

    [SerializeField]
    GameObject player;

    [SerializeField]
    float distanceToTarget;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        psyGlow = player.GetComponent<Light>();
        psyGlow.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CanControl()
    {
        RaycastHit hit;
        Ray inSight = new Ray(transform.position, Vector3.right);
        if (Physics.Raycast(inSight, out hit, distanceToTarget))
        {

        }
    }
}
