using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterInteraction : MonoBehaviour
{
    BoxCollider2D _drillSlot;

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
                   
            }
        }
    }
}
