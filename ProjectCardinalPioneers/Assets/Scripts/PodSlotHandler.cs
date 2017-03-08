using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodSlotHandler : MonoBehaviour {

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Pod")
        {
            if(Vector2.Distance(other.transform.position, transform.position) < 0.5)
            {
                //Set transform
                other.transform.parent = transform.parent;
                other.gameObject.transform.position = (Vector2) transform.position;
                other.gameObject.transform.rotation = transform.rotation;

                //Freeze transform
                Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
                rb.constraints = RigidbodyConstraints2D.FreezeAll;

                GetComponent<Collider2D>().enabled = false;
            }
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
