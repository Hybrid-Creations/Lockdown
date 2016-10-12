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

    [SerializeField]
    float maxDist = 5;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        psyGlow = player.GetComponent<Light>();
        psyGlow.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void CanControl()
    {
        RaycastHit2D hit;
        //Ray2D inSight = new Ray2D(transform.position, Vector2.right);
        hit = Physics2D.Raycast(transform.position, Vector2.right, maxDist);
       
        if(hit.collider.gameObject.GetComponent<Unit>() != null)
        {
            if(hit.collider.gameObject.GetComponent<Unit>().isControlled == false && hit.collider.gameObject.GetComponent<Unit>().currentFaction == Unit.Faction.CONTROLLABLE)
            {
                GetComponent<Unit>().isControlled = false;
                hit.collider.gameObject.GetComponent<Unit>().isControlled = true;
            }
        }
    }
}
