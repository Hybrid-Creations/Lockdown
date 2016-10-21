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
            Destroy(gameObject);
        }
    }
}
