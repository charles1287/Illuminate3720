using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCorrection : MonoBehaviour
{
    //Reset Rotation to zero
	void LateUpdate ()
    {
        transform.rotation = Quaternion.identity;
	}
}
