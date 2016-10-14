using UnityEngine;
using System.Collections;

public class KT_GetKey : MonoBehaviour {

    [SerializeField]
    GameObject key;

    public static bool hasKey;
	// Use this for initialization
	void Start () {
        hasKey = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Key")
        {
            key.transform.position = transform.position;
            key.GetComponent<BoxCollider2D>().enabled = false;
            key.transform.parent = transform;
            hasKey = true;
        }
    }
}
