using UnityEngine;
using System.Collections;

public class KT_UseAudio : MonoBehaviour {

    [SerializeField]
    AudioSource audSource;

    [SerializeField]
    AudioClip[] clipToPlay;
	// Use this for initialization
	void Start () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        audSource = player.GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "BPPickup")
        {
            AudClips(0);
        }
    }

    public void AudClips(int toPlay)
    {
        audSource.PlayOneShot(clipToPlay[toPlay], 2);
    }
}
