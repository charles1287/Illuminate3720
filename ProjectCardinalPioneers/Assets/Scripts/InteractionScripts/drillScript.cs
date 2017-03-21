using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drillScript : MonoBehaviour
{
    public float drillIceCapacity = 100f;
    public float Ice = 0f;
    public float drillIceRate = 15f;

    public bool drillOn = false;
    public bool canDrill = true;

    public void StartDrill()
    {
        if(!drillOn && canDrill)
            StartCoroutine("BeginDrilling");
    }

    void Update()
    {
        if (Input.GetKeyDown("e"))
            StartCoroutine("BeginDrilling");
    }

    void SetDrillState(bool on)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (on)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            drillOn = true;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.None;
            drillOn = false;
        }
    }

    // Generate x amount of ice in Drill from y amount of Power over time.deltaTime
    IEnumerator BeginDrilling()
    {
        if (drillOn == false)
        {
            SetDrillState(true);

            while (Ice < drillIceCapacity)
            {
                Ice += Time.deltaTime * drillIceRate;
                yield return null;
            }
            
            Ice = drillIceCapacity;
            SetDrillState(false);
        }
    }
}
