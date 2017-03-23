using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodSlotHandler : MonoBehaviour
{
    public bool Locked = false;

    const float _gridOffset = 2f;
    GameObject _connectedObject = null;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Connection")
        {
            if (Vector2.Distance(other.transform.position, transform.position) < 0.5)
            {
                //This pod must be frozen and the other must be free
                if (GetComponent<BoxCollider2D>().attachedRigidbody.constraints == RigidbodyConstraints2D.FreezeAll)
                    if (other.attachedRigidbody.constraints == RigidbodyConstraints2D.None)
                        SnapConnectionToThis(other);
            }
        }
    }

    void SnapConnectionToThis(Collider2D other)
    {
        Transform thisPod = GetComponent<BoxCollider2D>().attachedRigidbody.transform;
        Transform otherPod = other.attachedRigidbody.transform;

        //Set and lock transform on other
        otherPod.position = (Vector2)transform.position;
        otherPod.rotation = transform.rotation;
        otherPod.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        //Set the connected objects
        SetConnected(other.gameObject);
        other.GetComponent<PodSlotHandler>().SetConnected(gameObject);

        //Activate the selection menu from the pod shell
        other.transform.parent.parent.Find("Pod Select").gameObject.SetActive(true);
    }

    public void SetConnected(GameObject otherObject)
    {
        _connectedObject = otherObject;
    }
}
