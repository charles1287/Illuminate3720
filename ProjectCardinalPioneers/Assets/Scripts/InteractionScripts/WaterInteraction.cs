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
                //Set transform
                other.gameObject.transform.position = (Vector2)transform.position;
                other.gameObject.transform.rotation = transform.rotation;

                //Freeze transform
                Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
                rb.constraints = RigidbodyConstraints2D.FreezeAll;

                GetComponent<Collider2D>().enabled = false;

                //Activate the selection menu
                other.transform.Find("Pod Select").gameObject.SetActive(true);
            }
        }
    }
}
