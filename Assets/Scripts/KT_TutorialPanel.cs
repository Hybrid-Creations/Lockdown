using UnityEngine;
using System.Collections;

public class KT_TutorialPanel : MonoBehaviour
{

    [SerializeField]
    GameObject door;

    Color lightOn;
    Color lightOff;

    [SerializeField]
    GameObject[] lightPath;

    [SerializeField]
    float changeTimer = 0;
    [SerializeField]
    float timeToChange = 0;

    float minTime = 0;
    [SerializeField]
    float maxTime = .5f;

    [SerializeField]
    float randomRange = 1;

    // Use this for initialization
    void Start()
    {
        lightOn = Color.green;
        lightOff = Color.grey;
    }

    // Update is called once per frame
    void Update()
    {
        changeColor();
    }

    void changeColor()
    {
        changeTimer += Time.deltaTime;
        if (changeTimer >= timeToChange)
        {
            timeToChange = Random.Range(minTime, maxTime);
            changeTimer = 0;
            if (FlipCoin() == 0)
            {
                door.SetActive(false);
                ColorOn();
            }
            else
            {
                door.SetActive(true);
                ColorOff();
            }
        }
    }
    void ColorOn()
    {
        for (int i = 0; i < lightPath.Length; i++)
        {
            lightPath[i].GetComponent<SpriteRenderer>().color = lightOn;
        }
    }

    void ColorOff()
    {
        for (int i = 0; i < lightPath.Length; i++)
        {
            lightPath[i].GetComponent<SpriteRenderer>().color = lightOff;
        }
    }

    int FlipCoin()
    {
        return Random.Range(0, 2);
    }

}
