using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentSpawner : MonoBehaviour {

    const float _areaRadius = 20f;

    public GameObject Pod;

    public static ComponentSpawner s_Instance = null;

    void Start()
    {
        ComponentSpawner.s_Instance = this;
    }

    public void SpawnPod()
    {
        Vector2 pos = new Vector2(Random.Range(-_areaRadius, _areaRadius), Random.Range(-_areaRadius, _areaRadius));
        Instantiate(Pod, pos, Quaternion.identity);
    }
}
