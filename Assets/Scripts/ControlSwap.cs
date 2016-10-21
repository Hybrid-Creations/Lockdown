using UnityEngine;
using System.Collections;

public class ControlSwap : MonoBehaviour {

    public bool canControl;

    [SerializeField]
    GameObject canCon;

    [SerializeField]
    GameObject cantCon;

    GameObject controlled;

    void Start()
    {
    }

    void Update()
    {
        controlled = FindObjectOfType<KT_CharacterMovement>().currentControl;

        if (!transform.parent.GetComponent<Unit>().isControlled)
        {
            if (Vector2.Distance(controlled.transform.position, transform.position) < FindObjectOfType<KT_CharacterMovement>().maxDist)
                canControl = true;
            else
                canControl = false;

            canCon.SetActive(canControl);
            cantCon.SetActive(!canControl);
        }
        else
        {
            canCon.SetActive(false);
            cantCon.SetActive(false);

        }
    }
}
