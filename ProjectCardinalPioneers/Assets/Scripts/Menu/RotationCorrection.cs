using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCorrection : MonoBehaviour
{
    //Reset Rotation to zero
	void LateUpdate ()
    {
        GetComponent<RectTransform>().rotation = Quaternion.identity;
	}
}
