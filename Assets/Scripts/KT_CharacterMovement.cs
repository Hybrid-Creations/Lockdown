//Name: Kevin Thomas
//Date: 10/9/16
//Credit:
//
//Purpose: To create movement for characters

using UnityEngine;
using System.Collections;

public class KT_CharacterMovement : MonoBehaviour {

    [SerializeField]
    Light psyGlow;

    [SerializeField]
    GameObject player;

    [SerializeField]
    float distanceToTarget;

    public float maxDist = 4;

    [SerializeField]
    float moveSpeed = 1;

    [SerializeField]
    float maxSpeed = 5;

    [SerializeField]
    GameObject thingToSwitchTo;

    public GameObject currentControl;

    [SerializeField]
    float rechargeTimer;

    bool up;
    bool right;
    bool down;
    bool left;
    bool lightOn = false;
    bool rechargePower = false;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentControl = GameObject.FindGameObjectWithTag("Player");
        currentControl.GetComponent<Unit>().lightObj.enabled = false;
        down = true;
    }

    // Update is called once per frame
    void Update()
    {
        psyGlow = currentControl.GetComponent<Unit>().lightObj;
        //if (currentControl == player)
        {
            if (lightOn)
                psyGlow.enabled = true;
            else
            {
                psyGlow.enabled = false;
            }
        }

        MindPower();
        if (!uiStatsManager.isPaused)
        {
            CharacterMovement();
            CanControl();
        }
    }

    void MindPower()
    {
        float distancetoControl = Vector2.Distance(currentControl.transform.position, player.transform.position);
        Mathf.Round(distancetoControl);

        if (currentControl != player)
        {
            FindObjectOfType<uiStatsManager>().currentMindPower -= (Time.deltaTime * distancetoControl) * 3f;
        }
        else
        {
            if (FindObjectOfType<uiStatsManager>().currentMindPower < uiStatsManager.maxMindPower)
            {
                rechargePower = true;
                if (rechargePower)
                {
                    rechargeTimer += Time.deltaTime;
                    if (rechargeTimer >= 1)
                    {
                        FindObjectOfType<uiStatsManager>().currentMindPower += Time.deltaTime * 10;
                        if (FindObjectOfType<uiStatsManager>().currentMindPower >= uiStatsManager.maxMindPower)
                        {
                            FindObjectOfType<uiStatsManager>().currentMindPower = uiStatsManager.maxMindPower;
                            rechargeTimer = 0;
                            rechargePower = false;
                        }
                    }
                }
            }
        }

        if (FindObjectOfType<uiStatsManager>().currentMindPower <= 0)
        {
            FindObjectOfType<uiStatsManager>().currentMindPower = 0;
            NewSelection(player);
        }
    }

    void CharacterMovement()
    {
        if (currentControl.GetComponent<Rigidbody2D>().velocity.y < maxSpeed)
        {
            if (Input.GetKey(KeyCode.W))
            {
                currentControl.GetComponent<Rigidbody2D>().velocity += Vector2.up * moveSpeed;

                up = true;
                right = false;
                down = false;
                left = false;

            }
        }
        if (currentControl.GetComponent<Rigidbody2D>().velocity.y > -maxSpeed)
        {
            if (Input.GetKey(KeyCode.S))
            {
                currentControl.GetComponent<Rigidbody2D>().velocity += -Vector2.up * moveSpeed;
                up = false;
                right = false;
                down = true;
                left = false;
            }
        }
        if (currentControl.GetComponent<Rigidbody2D>().velocity.x > -maxSpeed)
        {
            if (Input.GetKey(KeyCode.A))
            {
                currentControl.GetComponent<Rigidbody2D>().velocity += -Vector2.right * moveSpeed;
                up = false;
                right = false;
                down = false;
                left = true;
            }
        }
        if (currentControl.GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
        {
            if (Input.GetKey(KeyCode.D))
            {
                currentControl.GetComponent<Rigidbody2D>().velocity += Vector2.right * moveSpeed;
                up = false;
                right = true;
                down = false;
                left = false;
            }
        }  

        if (Input.GetKeyUp(KeyCode.W))
        {
            Vector2 newVel = currentControl.GetComponent<Rigidbody2D>().velocity;
            newVel.y = 0;
            currentControl.GetComponent<Rigidbody2D>().velocity = newVel;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            Vector2 newVel = currentControl.GetComponent<Rigidbody2D>().velocity;
            newVel.x = 0;
            currentControl.GetComponent<Rigidbody2D>().velocity = newVel;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            Vector2 newVel = currentControl.GetComponent<Rigidbody2D>().velocity;
            newVel.y = 0;
            currentControl.GetComponent<Rigidbody2D>().velocity = newVel;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            Vector2 newVel = currentControl.GetComponent<Rigidbody2D>().velocity;
            newVel.x = 0;
            currentControl.GetComponent<Rigidbody2D>().velocity = newVel;
        }

        currentControl.GetComponent<Unit>().lookDirections[0].gameObject.SetActive(up);
        currentControl.GetComponent<Unit>().lookDirections[1].gameObject.SetActive(right);
        currentControl.GetComponent<Unit>().lookDirections[2].gameObject.SetActive(down);
        currentControl.GetComponent<Unit>().lookDirections[3].gameObject.SetActive(left);
        //Debug.Log(currentControl.GetComponent<Rigidbody2D>().velocity);

        if (uiStatsManager.isPaused)
            currentControl.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    void CanControl()
    {
        Debug.Log(uiStatsManager.isPaused);
        Vector2 drawDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - currentControl.transform.position);
        //currentControl.layer = 2;

        RaycastHit2D hit;
        Debug.DrawRay(currentControl.transform.position, drawDirection, Color.magenta);

        hit = Physics2D.Raycast(currentControl.transform.position, drawDirection, drawDirection.magnitude);

        if (hit)
        {
            if (hit.collider.GetComponent<Unit>() && hit.collider.GetComponent<Unit>().currentFaction != Unit.Faction.UNCONTROLLABLE)
            {
                //    Debug.Log(hit.collider.name);
                if (drawDirection.magnitude < maxDist)
                {

                    //Debug.Log(hit.collider.name);
                    if (hit.collider.gameObject.GetComponent<Unit>() != null)
                    {
                        if (currentControl == player)
                            lightOn = true;
                        if (hit.collider.gameObject.GetComponent<Unit>().isControlled == false && hit.collider.gameObject.GetComponent<Unit>().currentFaction == Unit.Faction.CONTROLLABLE)
                        {
                            if (Input.GetButtonDown("Fire1") && hit.collider.gameObject.GetComponent<Unit>().currentAIMode == Unit.AIMode.RELAXED)
                            {
                                NewSelection(hit.collider.gameObject);
                            }
                        }
                    }
                    else if (currentControl == player)
                        lightOn = false;
                }
                else if (currentControl == player)
                    lightOn = false;
            }
            else if (currentControl == player)
            {
                lightOn = false;
            }
        }
        else if (currentControl == player)
        {
            lightOn = false;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            NewSelection(player);
        }
    }

    void NewSelection(GameObject newObject)
    {
        currentControl.GetComponent<Unit>().originalPosition = currentControl.transform.position;
        currentControl.GetComponent<Unit>().section = 0;
        currentControl.GetComponent<Unit>().closestDistance = Mathf.Infinity;
        currentControl.GetComponent<Unit>().FindNearestWaypoint();
        currentControl.GetComponent<Unit>().isControlled = false;
        currentControl.GetComponent<Unit>().lightObj.intensity = .5f;
        if (currentControl == player)
        {
            currentControl.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            currentControl.GetComponent<Rigidbody2D>().isKinematic = true;
        }

        if (currentControl != player)
        {
            currentControl.GetComponent<Unit>().lightObj.enabled = false;
        }
        currentControl.layer = 0;
        currentControl = newObject;
        if (currentControl == player)
        {
            currentControl.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            currentControl.GetComponent<Rigidbody2D>().isKinematic = false;
            player.GetComponent<Unit>().lightObj.intensity = 1.5f;
        }
        currentControl.GetComponent<Unit>().isControlled = true;
        //Debug.Log("player controlled");
        lightOn = true;
    }
}
