using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class problemOne : MonoBehaviour
{

    [SerializeField]
    GameObject brokenTireWheel;

    [SerializeField]
    tireManager TM;

    [SerializeField]
    GameObject gameOne;

    GameObject gOne;
    public bool dettachAllowed;


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

        brokenTireWheel.SetActive(true);
        TM.fault += 1;
        dettachAllowed = false;
        gOne = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {

        if (this.enabled)
        {
            if (collision.transform.tag == "Player")
            {
                objectLocation pOL = collision.transform.GetComponent<objectLocation>();

                if (pOL.sendTag() == "Tool Box" && !dettachAllowed)
                {
                    if (Input.GetKeyDown(kc[index[collision.transform.GetComponent<UserMovement>().charIndexNumber]]))
                    {
                        collision.gameObject.GetComponent<UserMovement>().startRepair();
                        if (gOne == null)
                        {
                            gOne = Instantiate(gameOne, transform.position, Quaternion.identity);
                            gOne.GetComponent<gameOne>().ParentWheel = gameObject;
                            gOne.GetComponent<gameOne>().PName = collision.transform.name;
                            collision.transform.GetComponent<UserMovement>().enabled = false;
                            collision.transform.GetComponent<Rigidbody>().isKinematic = true;
                        }

                        brokenTireWheel.SetActive(false);
                    }
                }
                else
                {
                    if (Input.GetKeyDown(kc[index[collision.transform.GetComponent<UserMovement>().charIndexNumber]]))
                    {
                        
                        if (dettachAllowed)
                        {
                            TM.activateCol();
                            GetComponent<BoxCollider>().enabled = false;
                            pOL.placeObject(transform.gameObject);
                        }
                    }
                }

                if (dettachAllowed)
                {
                    collision.transform.GetComponent<UserMovement>().enabled = true;
                    collision.transform.GetComponent<Rigidbody>().isKinematic = false;
                    collision.gameObject.GetComponent<UserMovement>().doneRepair();
                }
            }
        }
    }
}
