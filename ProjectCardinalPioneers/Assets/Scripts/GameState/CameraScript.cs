using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {


    public Material EffectMaterial;
    public Transform FollowTarget;


    void Update()
    {
        Vector3 lerp = Vector2.Lerp(transform.position, FollowTarget.position, 0.03f);
        transform.position = new Vector3(lerp.x, lerp.y, transform.position.z);
    }

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        Graphics.Blit(src, dst, EffectMaterial);
    }

    public void SetTint(Color col)
    {
        Shader.SetGlobalColor("_Color", col);
    }


}
