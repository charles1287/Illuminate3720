using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drillScript : MonoBehaviour
{
    float drillIceCapacity = 100f;
    public float Ice = 0f;
    public float drillIceRate = 2;
    bool drillOn = false;

    private void Update()
    {
        if (Input.GetKeyDown("e"))
            StartCoroutine("Interact");
    }

    // Generate x amount of ice in Drill from y amount of Power over time.deltaTime
    IEnumerator Interact()
    {
        if (drillOn == false)
        {
            drillOn = true;

            while (Ice < drillIceCapacity)
            {
                Ice += Time.deltaTime * drillIceRate;
                yield return null;
            }
            Ice = drillIceCapacity;

            drillOn = false;
        }


      
    }
}
