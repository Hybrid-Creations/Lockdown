using UnityEngine;
using System.Collections;

public class KT_GetKey : MonoBehaviour
{

    [SerializeField]
    GameObject key;

    [SerializeField]
    Light keyLight;

    public static bool hasKey;

    void Start ()
    {
        keyLight = key.GetComponent<Light>();
        hasKey = false;
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Key")
        {
            key.transform.position = transform.position;
            key.GetComponent<BoxCollider2D>().enabled = false;
            key.transform.parent = transform;
            keyLight.enabled = false;
            hasKey = true;
        }
    }
}
