using UnityEngine;
using System.Collections;

public class BPPickup : MonoBehaviour {

    [SerializeField]
    int maxBPIncreaseBy;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            uiStatsManager.maxMindPower += maxBPIncreaseBy;
            FindObjectOfType<uiStatsManager>().currentMindPower += maxBPIncreaseBy;
            FindObjectOfType<uiStatsManager>().mindPowerSlider.maxValue += maxBPIncreaseBy;
            FindObjectOfType<uiStatsManager>().GrabTheMessage("Brain Power + 10!", "Your Brain Power Has Incrased!", 3, gameObject);

            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            GetComponentInChildren<Light>().enabled = false;
            Destroy(gameObject, 4);
        }
    }
}
