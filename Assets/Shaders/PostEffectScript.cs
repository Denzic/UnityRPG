using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PostEffectScript : MonoBehaviour {

    public Material mat; 
    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        //src is the full rensered scene that you would normally send directly to the monitor.

        Graphics.Blit(src, dest, mat);
        
    }
}
