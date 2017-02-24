﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D _rb;
    DistanceJoint2D _hook;
    LineRenderer _wire;

    public float TowcableDistance;
    public float InteractDistance;
    public float MovementScale;

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

        _rb.AddForce(MovementScale * input.normalized);
        #endregion

        #region Interact Input
        if (Input.GetMouseButtonDown(1))
        {
            FireInteract();
        }

        if(Input.GetMouseButtonDown(0))
        {
            if (!_hook.enabled)
                FireHook();
            else
            {
                _hook.enabled = false;
                _wire.enabled = false;
            }
            
        }
        #endregion

        UpdateWire();
    }
    //Casts a ray and interacts with hit object
    void FireInteract()
    {
        Vector3 ray = Camera.main.ScreenToWorldPoint((Input.mousePosition)) - transform.position;
        Debug.DrawRay(transform.position, ray, Color.cyan, 0.5f, false);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, ray, InteractDistance, LayerMask.GetMask("Interactables"));
        if (hitInfo)
        {
            print("Interacting");
        }
    }

    //Casts a ray and hooks up the DistanceJoint2D if necessary
    void FireHook()
    {
        Vector3 ray = Camera.main.ScreenToWorldPoint((Input.mousePosition)) - transform.position;
        Debug.DrawRay(transform.position, ray, Color.cyan, 0.5f);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, ray, TowcableDistance, LayerMask.GetMask("Draggable"));
        if (hitInfo)
        {
            _hook.enabled = true;
            _wire.enabled = true;
            _hook.connectedAnchor = hitInfo.collider.transform.InverseTransformPoint(hitInfo.point);
            _hook.connectedBody = hitInfo.rigidbody;
        }
    }

    //Updates position of the LineRenderer to match the DistanceJoint2D
    void UpdateWire()
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