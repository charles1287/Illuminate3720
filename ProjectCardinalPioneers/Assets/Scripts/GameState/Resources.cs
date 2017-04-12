using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Resources : MonoBehaviour
{
	public float Water = 0f;
	public float Power = 0f;
	public float Food = 0f;
	public float Ice = 0f;
	public float Fuel = 0f;

	public static Resources s_Instance = null;

	public static Resources instance {
		
		get {
			return Resources.s_Instance;
		}	
	}

	void OnApplicationQuit ()
	{
		s_Instance = null;
	}
}

