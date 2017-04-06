﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Resources : MonoBehaviour
{
    [Serializable]
	public float Water = 0f;
	public float Power = 0f;
	public float Food = 0f;
	public float Ice = 0f;
	public float Fuel = 0f;

	public static Resources s_Instance = null;

	public static Resources instance {
		
		get {
			if (s_Instance == null)
				s_Instance = FindObjectOfType (typeof(Resources)) as Resources;
							

			if (s_Instance == null) {
				GameObject resource = new GameObject ("Resources");
				s_Instance = resource.AddComponent (typeof(Resources)) as Resources;
				Debug.Log ("Could not locate a Resource object. / Resource was generated automatically.");
			}

			return s_Instance;
		}	
	}

	void OnApplicationQuit ()
	{
		s_Instance = null;
	}
}

