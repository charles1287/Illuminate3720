using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSetup : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        if (Resources.s_Instance == null)
            Resources.s_Instance = FindObjectOfType(typeof(Resources)) as Resources;


        if (Resources.s_Instance == null)
        {
            Resources.s_Instance = gameObject.AddComponent(typeof(Resources)) as Resources;
            Debug.Log("Could not locate a Resource object. / Resource was generated automatically.");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
