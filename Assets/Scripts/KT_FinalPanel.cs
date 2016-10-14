using UnityEngine;
using System.Collections;

public class KT_FinalPanel : MonoBehaviour {

    [SerializeField]
    GameObject finalDoor;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy" && Input.GetMouseButtonDown(0))
        {
            finalDoor.SetActive(false);
        }
    }
}
