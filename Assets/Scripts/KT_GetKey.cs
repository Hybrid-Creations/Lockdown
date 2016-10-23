using UnityEngine;
using System.Collections;

public class KT_GetKey : MonoBehaviour
{

    [SerializeField]
    GameObject key;

    [SerializeField]
    Light keyLight;

    GameObject player;

    public static bool hasKey;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        keyLight = key.GetComponent<Light>();
        hasKey = false;
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Key")
        {
            player.GetComponent<KT_UseAudio>().AudClips(3);
            key.transform.position = transform.position;
            key.GetComponent<BoxCollider2D>().enabled = false;
            key.transform.parent = transform;
            keyLight.enabled = false;
            hasKey = true;
        }
    }
}
