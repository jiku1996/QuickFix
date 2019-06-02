using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EPulse : MonoBehaviour
{
    public float duration;
    
    void Update()
    {
        float phi = Time.time / duration * 2 * Mathf.PI;
        float amplitude = Mathf.Cos(phi) * 0.5f + 0.5f;
        float G = amplitude;
        float B = amplitude;

        Material myMat = GetComponent<Renderer>().material;
        myMat.SetColor("_EmissionColor", new Color(0f, G, B));
    }
}
