using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour {
    
    [HideInInspector]
    public static float _water = 20f;
    [HideInInspector]
    public static float _ice = 20f;
    [HideInInspector]
    public static float _power = 20f;
    [HideInInspector]
    public static float _fuel = 20f;
    [HideInInspector]
    public static float _food = 20f;

    public float x
    {
        get
        {
            return 1;
        }
    }

    private static void Update()
    {
        _food -= 0.001f;
        print(_food);
    }

}
