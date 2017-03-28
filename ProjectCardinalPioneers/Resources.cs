using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour 
{
	public int AirPodprefab = 0;
	public int PowerPodprefab = 0;
	public int MakeWaterpod = 0;


    [HideInInspector]
    public static float Water = 20f;
    [HideInInspector]
    public static float Ice = 20f;
    [HideInInspector]
    public static float Power = 20f;
    [HideInInspector]
    public static float Fuel = 20f;
    [HideInInspector]
    public static float Food = 20f;

    public static void updateResources()
	{
		Air = airRate * AirPodPrefab;
		Water = waterRate * WaterPodPrefab;
		Power = powerRate * PowerPodPrefab;
	}
}

