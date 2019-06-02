using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnItems : MonoBehaviour
{
    [SerializeField]
    GameObject itemToSpawn;

    GameObject tempObj;

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
        tempObj = null;
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
            if (Input.GetKeyDown(kc[index[collision.transform.GetComponent<UserMovement>().charIndexNumber]]))
            {
                tempObj = Instantiate(itemToSpawn, transform.position, Quaternion.identity);
                pOL.placeObject(tempObj);
            }
            
        }
    }
}
