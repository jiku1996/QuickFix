using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class mapping : MonoBehaviour {

    string jsn, jsButton;
    int jn;
    KeyCode run, throww, drop, interact;
    bool change;

	// Use this for initialization
	void Start () {
        jn = 1;
        jsn = "Joystick" + jn;
        run = KeyCode.Joystick1Button7;
        //throww = (KeyCode)System.Enum.Parse(typeof(KeyCode), jsButton);
        change = false;
	}
	
	// Update is called once per frame
	void Update () {

        //foreach (KeyCode Pkey in System.Enum.GetValues(typeof(KeyCode)))
        //{
        //    if (Input.GetKeyDown(Pkey))
        //    {
        //        Debug.Log(Pkey.ToString() + " was Pressed");
        //    }
        //}

        if (Input.GetKeyDown(run))
        {
            Debug.Log("Run was pressed");
        }

        //string test = ("my boi");
        //if ((test.Contains("boi")))
        //{
        //    Debug.Log("Boi is there");
        //}

        if (change)
        {
            Debug.Log("Awaiting Input");
            foreach (KeyCode Pkey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(Pkey))
                {
                    Debug.Log(Pkey.ToString() + " was Pressed");
                    check(Pkey);
                    change = false;
                }
            }
        }
    }

    public void remap()
    {
        change = true;
    }

    public void check(KeyCode isit)
    {
        string checking = isit.ToString();
        if ((checking.Contains("Joystick1")))
        {
            run = isit;
        }
        else
        {
            Debug.Log("Different Joystick number");
        }
        return;
    }
}

//﻿using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class input : MonoBehaviour
//{

//    bool changing;
//    KeyCode Defkey;

//    // Start is called before the first frame update
//    void Start()
//    {
//        Defkey = KeyCode.Space;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKeyDown(Defkey))
//        {
//            Debug.Log("Pressed: " + Defkey.ToString());
//        }

//        if (changing)
//        {
//            Debug.Log("Awaiting Input");
//            foreach (KeyCode Pkey in System.Enum.GetValues(typeof(KeyCode)))
//            {
//                if (Input.GetKeyDown(Pkey))
//                {
//                    Debug.Log(Pkey.ToString() + " was Pressed");
//                    Defkey = Pkey;
//                    changing = false;
//                }
//            }
//        }
//    }

//    public void changer()
//    {
//        changing = true;
//    }
//}
