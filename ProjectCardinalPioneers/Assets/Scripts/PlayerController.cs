using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    const float _speed = 3f;
    Vector2 _direction = Vector2.down;

    Rigidbody2D _rb;
    DistanceJoint2D _hook;
    LineRenderer _wire;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _hook = GetComponent<DistanceJoint2D>();
        _wire = GetComponent<LineRenderer>();
    }
    
	// Update is called once per frame
	void Update () {
        #region Movement Input
        //gets raw movement input
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //changes direction if necessary
        if(input != Vector2.zero)
            _direction = input.normalized;
        _rb.velocity = _speed * input.normalized;
        #endregion

        #region Interact Input
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit2D hitInfo = Physics2D.Linecast(transform.position, (Vector2)transform.position + _direction, LayerMask.GetMask("Interactables"));
            if (hitInfo)
                print("Interacting");
        }

        if(Input.GetMouseButtonDown(0))
        {
            _hook.enabled = false;
            _wire.enabled = false;
            FireHook();
        }
        #endregion

        UpdateWire();
    }

    //Casts a line and hooks up the DistanceJoint2D if necessary
    void FireHook()
    {
        Vector3 ray = Camera.main.ScreenToWorldPoint((Input.mousePosition)) - transform.position;
        Debug.DrawRay(transform.position, ray);

        RaycastHit2D hitInfo = Physics2D.Linecast(transform.position, ray, LayerMask.GetMask("Draggable"));
        if (hitInfo)
        {
            _hook.enabled = true;
            _wire.enabled = true;
            _hook.connectedAnchor = hitInfo.transform.InverseTransformPoint(hitInfo.point);
            _hook.connectedBody = hitInfo.rigidbody;
        }
    }

    private void UpdateWire()
    {
        if(_hook.enabled)
        {
            Vector3[] pos = new Vector3[2];
            pos[0] = transform.TransformPoint(_hook.anchor);
            pos[1] = _hook.connectedBody.transform.TransformPoint(_hook.connectedAnchor);
            _wire.SetPositions(pos);
        }
    } 
}
