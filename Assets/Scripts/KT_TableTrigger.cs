using UnityEngine;
using System.Collections;

public class KT_TableTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<BoxCollider2D>().isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
