using UnityEngine;
using System.Collections;

public class PulseLight : MonoBehaviour {

    [SerializeField]
    Light lightObj;

    bool pulseUp;
    float pulseTimer;

    [SerializeField]
    float pulseSpeedMult;
    [SerializeField]
    float minIntensity;
    [SerializeField]
    float maxIntensity;

    void Update()
    {
        PulseLightObj();
    }

    public void PulseLightObj()
    {
        if (lightObj.enabled == false)
            lightObj.enabled = true;
        if (lightObj.gameObject.activeInHierarchy == false)
            lightObj.gameObject.SetActive(true);

        if (pulseUp)
        {
            pulseTimer += Time.deltaTime * pulseSpeedMult;
        }

        if (!pulseUp)
        {
            pulseTimer -= Time.deltaTime * pulseSpeedMult;
        }
        lightObj.intensity = Mathf.Lerp(minIntensity, maxIntensity, pulseTimer);

        if (pulseTimer <= 0)
            pulseUp = true;
        if (pulseTimer >= 1)
            pulseUp = false;
    }
}
