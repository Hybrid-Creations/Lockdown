using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KT_Opening : MonoBehaviour
{

    float levelTimer = 10.49f;
    [SerializeField]
    Text countdown;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        levelTimer -= Time.deltaTime;

        countdown.text = "" + Mathf.RoundToInt(levelTimer);
        if (levelTimer <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
