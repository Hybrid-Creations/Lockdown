using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KT_TutorialScene : MonoBehaviour
{

    private float msgTimer = 0;
    [SerializeField]
    Text chat;
    [SerializeField]
    Text from;
    bool textShowing;

    public string msgFrom;
    public string msgBody;
    public float msgTime;

    public bool onlyOnce;

    [SerializeField]
    GameObject door;

    [SerializeField]
    GameObject redLab;

    float endTimer;

    bool startTime;
    void Start()
    {
        chat.text = null;
        from.text = null;
        redLab.SetActive(false);
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

        if (msgTimer > 0)
        {
            msgTimer -= Time.deltaTime;
        }
        else {
            textShowing = false;
        }

        if (textShowing == false)
        {
            chat.text = null;
            from.text = null;
        }
    }

    public void DisplayMessage(string messenger, string body, float displayTime)
    {
        chat.text = body;
        from.text = messenger;
        msgTimer = displayTime;
        textShowing = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !door.activeInHierarchy)
        {
            redLab.SetActive(true);
            uiStatsManager.isPaused = true;
            DisplayMessage(msgFrom, msgBody, msgTime);
            startTime = true;
        }
    }
}
