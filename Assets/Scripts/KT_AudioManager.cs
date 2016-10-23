using UnityEngine;
using System.Collections;

public class KT_AudioManager : MonoBehaviour {

    [SerializeField]
    AudioSource audManager;
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

	// Use this for initialization
	void Start () {
        audManager = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
