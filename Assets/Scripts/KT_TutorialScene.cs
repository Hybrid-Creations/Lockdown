using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KT_TutorialScene : MonoBehaviour
{

    GameObject door;

    [SerializeField]
    GameObject redLab;

    [SerializeField]
    Text redChat;

    float endTimer;

    bool startTime;
    void Start()
    {
        redChat.text = null;
        redLab.SetActive(false);
        door = GameObject.Find("FinalDoor");
    }

    void Update()
    {
        if (startTime)
        {
            endTimer += Time.deltaTime;
            if(endTimer >= 4)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !door.activeInHierarchy)
        {
            redLab.SetActive(true);
            uiStatsManager.isPaused = true;
            redChat.text = "Red Guard: " + "\"What do you think you're doing here?! Come on, back to your cell!\"";
            startTime = true;
        }
    }
}
