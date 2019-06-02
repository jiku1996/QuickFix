using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class problemTwo : MonoBehaviour
{
    [SerializeField]
    GameObject AirWHeel;

    [SerializeField]
    tireManager TM;

    [SerializeField]
    GameObject gameTwo;

    GameObject gTwo;
    
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

        int rand = Random.Range(0, 10);
        if (rand > 5)
        {
            Debug.Log("hit this ");
            AirWHeel.SetActive(true);
            TM.fault += 1;
        }

        gTwo = null;
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
                if (Input.GetKeyDown(kc[index[collision.transform.GetComponent<UserMovement>().charIndexNumber]]))
                {
                    if (gTwo == null)
                    {
                        gTwo = Instantiate(gameTwo, new Vector3(transform.position.x , 6, transform.position.z), Quaternion.identity);
                        gTwo.GetComponent<gameTwo>().pName = collision.transform.name;
                        gTwo.GetComponent<gameTwo>().summoner = gameObject;
                    }

                    AirWHeel.SetActive(false);
                }
            }
        }
    }

    public void sendTM()
    {
        TM.setAct();
        this.enabled = false;
    }
}
