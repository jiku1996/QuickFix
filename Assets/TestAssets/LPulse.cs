using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LPulse : MonoBehaviour
{

    public float duration;
    public Light ilaw;

    void Start()
    {
        ilaw = GetComponent<Light>(); 
    }

    
    void Update()
    {
        float phi = (Time.time / duration) * 2 * Mathf.PI;
        float amplitude = Mathf.Cos(phi) * 2.5f + 2.5f;
        ilaw.intensity = amplitude;
    }
}
