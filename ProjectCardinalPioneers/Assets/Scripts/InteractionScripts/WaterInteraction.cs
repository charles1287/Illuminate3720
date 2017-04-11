﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WaterInteraction : MonoBehaviour
{
    BoxCollider2D _drillSlot;

    public float Power = 0f;
    public float Ice = 0f;
    public float Water = 0f;
    public float iceToWaterRate = 2f;

    public GameObject ConnectedDrill;

    public Button processButton;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Drill" && ConnectedDrill == null)
        {
            ConnectDrill(other);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Drill")
            other.GetComponent<drillScript>().canDrill = true;
    }

    public void ConnectDrill(Collider2D other)
    {
        other.transform.parent = transform;
        other.transform.position = transform.position;
        other.transform.rotation = transform.rotation;

        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        ConnectedDrill = other.gameObject;

        other.GetComponent<drillScript>().canDrill = false;
    }

    public void DisconnectDrill()
    {
        if (ConnectedDrill != null)
        {
            ConnectedDrill.transform.parent = null;

            Rigidbody2D rb = ConnectedDrill.GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.None;
            ConnectedDrill = null;
        }
    }

  

    


}
