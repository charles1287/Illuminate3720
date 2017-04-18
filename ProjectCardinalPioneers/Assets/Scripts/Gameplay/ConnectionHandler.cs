using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionHandler : MonoBehaviour
{
    //public bool Locked = false;
    //const float _gridOffset = 2f;

    public string[] ConnectsTo;

    GameObject _connectedObject = null;

    void OnTriggerStay2D(Collider2D other)
    {

        for (int i = 0; i < ConnectsTo.Length; i++)
        {
            if (other.tag == ConnectsTo[i])
            {
                //must be within a certain distance and angle to the slot
                Transform otherRoot = other.attachedRigidbody.transform;
                float distance = Vector2.Distance(otherRoot.position, transform.position);
                float angleDifference = Mathf.RoundToInt(other.transform.rotation.eulerAngles.z) % 90;
                if (angleDifference < 35)
                {
                    //This pod must be frozen and the other must be free
                    if (GetComponent<BoxCollider2D>().attachedRigidbody.constraints == RigidbodyConstraints2D.FreezeAll)
                        if (other.attachedRigidbody.constraints == RigidbodyConstraints2D.None)
                            SnapConnectionToThis(other);
                }
            }
        }
    }

    void SnapConnectionToThis(Collider2D other)
    {
        //Get root objects
        Transform thisPod = GetComponent<BoxCollider2D>().attachedRigidbody.transform;
        Transform otherPod = other.attachedRigidbody.transform;

        //Set and lock transform on other
        otherPod.position = (Vector2)transform.position;

        Vector3 rotation = otherPod.transform.rotation.eulerAngles;
        float angle = Mathf.Round(rotation.z / 90) * 90;
        otherPod.transform.eulerAngles = new Vector3(0, 0, angle);

        otherPod.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        //Set the connected objects
        SetConnected(other.gameObject);
        other.GetComponent<ConnectionHandler>().SetConnected(gameObject);

        DeactivateConnection(other);

        //Activate the selection menu from the pod shell
        if(otherPod.gameObject.tag == "Pod")
            otherPod.Find("Pod Select Obj").gameObject.SetActive(true);
    }

    void DeactivateConnection(Collider2D other)
    {
        other.enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }

    public void SetConnected(GameObject otherObject)
    {
        _connectedObject = otherObject;
    }
}
