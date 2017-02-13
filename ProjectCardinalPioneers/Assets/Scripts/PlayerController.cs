using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    const float _speed = 3f;
    Vector2 _direction = Vector2.down;

    public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        #region Movement Input
        //gets raw movement input
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //changes direction if necessary
        if(input != Vector2.zero)
            _direction = input.normalized;
        rb.velocity = _speed * input.normalized;
        #endregion

        #region Interact Input
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit2D hitInfo = Physics2D.Linecast(transform.position, (Vector2)transform.position + _direction, LayerMask.GetMask("Interactables"));
            if (hitInfo)
                print("Interacting");
        }
        #endregion
    }
}
