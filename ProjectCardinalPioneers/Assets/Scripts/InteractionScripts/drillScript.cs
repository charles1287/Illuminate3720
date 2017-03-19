using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drillScript : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown("e"))
            StartCoroutine("Drill");       
    }

    public void Drill(GameObject drill)
    {
        // Function to transform drill and mine resources
    
    }

}
