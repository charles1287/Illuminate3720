using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodLinking : MonoBehaviour
{
    public GameObject AirPodPrefab;
    public GameObject WaterPodPrefab;
    public GameObject PowerPodPrefab;

    public void MakeAirPod(GameObject closeMenu)
    {
        Instantiate(AirPodPrefab, transform);
        closeMenu.SetActive(false);
    }

    public void MakePowerPod(GameObject closeMenu)
    {
        Instantiate(PowerPodPrefab, transform);
        closeMenu.SetActive(false);
    }

    public void MakeWaterPod(GameObject closeMenu)
    {
        Instantiate(WaterPodPrefab, transform);
        closeMenu.SetActive(false);
    }
}
