using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Resources : MonoBehaviour
{
	public float Water = 0f;
	public float Food = 0f;
	public float Fuel = 0f;
    public float Air = 0f;

	public int airPod = 0;
	public int waterPod = 0;
	public int powerPod = 0;

	public float Power = 0f;
	public float powerRate = 0.5f;

	public static Resources s_Instance = null;

	public static Resources instance {
		
		get 
		{
			return Resources.s_Instance;
		}	
	}

	void OnApplicationQuit ()
	{
		s_Instance = null;
	}

	public static void updateResources()
	{
		Resources.instance.Power += Resources.instance.powerPod * Resources.instance.powerRate;
	}
}

