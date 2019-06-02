using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioCont : MonoBehaviour
{
    [SerializeField] AudioSource audioHolder;
    bool toggle, stop;
    int delay;
    void Start()
    {
        delay = 10;
        toggle = false; stop = true;
    }

   
    void Update()
    {
        if (stop)
        {
            if(delay != 0)
            {
                delay--;
            }
            else if (delay == 0)
            {
                toggle = true;
                stop = false;
            }
        }

        if (toggle)
        {
            audioHolder.Play();
            toggle = false;
        }
    }
}
