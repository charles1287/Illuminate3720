using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WaterInteraction : MonoBehaviour
{
    BoxCollider2D _drillSlot;

    public float Ice = drillScript.drillIce;
    public float iceToWaterRate = 2f;

	bool connected = false;

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
		connected = true;
    }

    public void DisconnectDrill()
    {
        if (ConnectedDrill != null)
        {
            ConnectedDrill.transform.parent = null;

            Rigidbody2D rb = ConnectedDrill.GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            ConnectedDrill = null;
        }

		connected = false;
    }

	IEnumerator processIce()
	{
		
		while (connected == true && Resources.instance.Power > 0 && Ice > 0)
		{
			Resources.instance.Water += Ice * iceToWaterRate;
			Ice--;
			Resources.instance.Power--;
		}
		yield return null;
	}

}