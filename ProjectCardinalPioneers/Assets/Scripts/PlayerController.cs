using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    const float _speed = 3f;

    public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = _speed * new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
	}
}
