using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carManager : MonoBehaviour
{

    [SerializeField]
    GameObject coin;

    public int faults;
    public Vector3 carRot;


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
        
        if(faults == 0)
        {
            if (coin != null)
            {
                coin.SetActive(true);
            }
        }
        else
        {
            coin.SetActive(false);
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if (coin.activeSelf)
        {
            if (collision.transform.tag == "Player")
            {
                int index = collision.transform.GetComponent<UserMovement>().charIndexNumber;

                if (Input.GetKey(kc[this.index[index]]))
                {
                    collision.transform.GetComponent<objectLocation>().addCar(gameObject);
                    collision.transform.GetComponent<objectLocation>().addMon(coin);
                    coin.transform.SetParent(collision.transform);
                    coin.transform.localPosition = new Vector3(0, 5, 0);
                }
            }
        }
    }
}
