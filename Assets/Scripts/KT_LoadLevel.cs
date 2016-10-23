using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class KT_LoadLevel : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D other)
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (uiStatsManager.maxMindPower > 110)
                uiStatsManager.maxMindPower = 110;
        }
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            if (uiStatsManager.maxMindPower > 120)
                uiStatsManager.maxMindPower = 120;
        }
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            if (uiStatsManager.maxMindPower > 130)
                uiStatsManager.maxMindPower = 130;
        }

        if (other.tag == "Player")
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
