using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WaterInteraction : MonoBehaviour
{
    BoxCollider2D _drillSlot;

    public float Power = 0f;
    public float Ice = Resources.Ice;
    public float Water = 0f;
    public float iceToWaterRate = 2f;

    public bool drillConnected;

    public Button processButton;

    public void iceToWaterConversion()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Drill")
        {
            if (Vector2.Distance(other.transform.position, transform.position) < 0.5)
            {
                other.transform.position = transform.position;
                other.transform.rotation = transform.rotation;

                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                rb.constraints = RigidbodyConstraints2D.FreezeAll;

                drillConnected = true;
            }
            drillConnected = false;
        }
    }

