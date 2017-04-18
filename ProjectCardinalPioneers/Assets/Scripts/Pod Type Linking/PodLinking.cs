using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodLinking : MonoBehaviour
{
    public GameObject AirPodPrefab;
    public GameObject WaterPodPrefab;
    public GameObject PowerPodPrefab;

	public float airRate = 2f;
	public float waterRate = 2f;
	public float powerRate = 2f;

    public void MakeAirPod(GameObject selectMenu)
    {
        Instantiate(AirPodPrefab, transform, false);
        selectMenu.SetActive(false);

		Resources.instance.airPod += 1;
    }

    public void MakePowerPod(GameObject selectMenu)
    {
        Instantiate(PowerPodPrefab, transform, false);
        selectMenu.SetActive(false);

        Resources.instance.powerPod += 1;
    }

    public void MakeWaterPod(GameObject selectMenu)
    {
        Instantiate(WaterPodPrefab, transform, false);
        selectMenu.SetActive(false);

        Resources.instance.waterPod += 1;
    }
}
