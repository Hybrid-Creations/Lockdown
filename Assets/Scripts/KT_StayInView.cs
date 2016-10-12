//Name: Kevin Thomas
//Date: 10/8/2016
//Credit: http://answers.unity3d.com/questions/799656/how-to-keep-an-object-within-the-camera-view.html
//
//Purpose: To keep the background from falling out of camera dependant on the resolution

using UnityEngine;
using System.Collections;

public class KT_StayInView : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
