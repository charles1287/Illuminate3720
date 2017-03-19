using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodLinking : MonoBehaviour
{
    public GameObject AirPodPrefab;
    public GameObject WaterPodPrefab;
    public GameObject PowerPodPrefab;

    public void MakeAirPod(GameObject selectMenu)
    {
        Instantiate(AirPodPrefab, transform, false);
        selectMenu.SetActive(false);
    }

    public void MakePowerPod(GameObject selectMenu)
    {
        Instantiate(PowerPodPrefab, transform, false);
        selectMenu.SetActive(false);
    }

    public void MakeWaterPod(GameObject selectMenu)
    {
        Instantiate(WaterPodPrefab, transform, false);
        selectMenu.SetActive(false);
    }
}
