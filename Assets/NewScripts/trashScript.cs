using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashScript : MonoBehaviour
{

    int players;
    int[] index;
    string[] strings;
    KeyCode[] kc;
    private void Awake()
    {
        players = PlayerPrefs.GetInt("Active_Users");
        index = new int[players];
        strings = new string[4] { "one", "two", "three", "four" };
        kc = new KeyCode[4] { KeyCode.Joystick1Button0, KeyCode.Joystick2Button0, KeyCode.Joystick3Button0, KeyCode.Joystick4Button0 };
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < players; i++)
        {
            index[i] = PlayerPrefs.GetInt(strings[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            objectLocation pOL = collision.transform.GetComponent<objectLocation>();
            int index = collision.transform.GetComponent<UserMovement>().charIndexNumber;
            if (Input.GetKey(kc[this.index[index]]))
            {
                if (pOL.sendTag() != "Tool Box")
                {
                    pOL.deleteObj();
                }
            }
            
        }
    }
}
