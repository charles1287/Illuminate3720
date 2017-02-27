using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraScript : MonoBehaviour {

    public Material EffectMaterial;
    //public Color ViewTint;

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        Graphics.Blit(src, dst, EffectMaterial);
    }
    public void SetTint(Color col)
    {
        Shader.SetGlobalColor("_Color", col);
    }
}
