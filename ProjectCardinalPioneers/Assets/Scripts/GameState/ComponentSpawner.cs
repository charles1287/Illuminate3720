using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentSpawner : MonoBehaviour {

    const float _areaWidth = 20f;
    const float _areaHeight = 10f;

    public GameObject Pod;
    public GameObject StraightConnector;
    public GameObject CornerConnector;
    public GameObject TConnector;
    public GameObject CrossConnector;


    public static ComponentSpawner s_Instance = null;

    void Start()
    {
        ComponentSpawner.s_Instance = this;
    }

    public void SpawnPod()
    {
        Vector2 pos = new Vector2(Random.Range(-_areaWidth, _areaWidth), Random.Range(-_areaHeight, _areaHeight));
        Instantiate(Pod, pos, Quaternion.identity);
    }

    public void SpawnConnector()
    {
        int r = Random.Range(0, 4);
        Vector2 pos = new Vector2(Random.Range(-_areaWidth, _areaWidth), Random.Range(-_areaHeight, _areaHeight));        

        if (r <= 1)
            Instantiate(StraightConnector, pos, Quaternion.identity);
        else if (r <= 2)
            Instantiate(CornerConnector, pos, Quaternion.identity);
        else if (r <= 3)
            Instantiate(TConnector, pos, Quaternion.identity);
        else if (r <= 4)
            Instantiate(CrossConnector, pos, Quaternion.identity);
    }
}
