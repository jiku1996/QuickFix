using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserMovement : MonoBehaviour
{

    [SerializeField]
    public int charIndexNumber;

    [SerializeField]
    Animator charAnim;

    float x, z, run;

    int players;
    int[] index;
    string[] strings;
    

    private void Awake()
    {
        players = PlayerPrefs.GetInt("Active_Users");
        index = new int[players];
        strings = new string[4] { "one", "two", "three", "four" };

        x = 0f;
        z = 0f;
        run = 0f;
        
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
        if (Input.GetKeyDown(KeyCode.S))
        {
            startRepair();
        }else if (Input.GetKeyDown(KeyCode.F))
        {
            doneRepair();
        }
        
        x = Input.GetAxis(index[charIndexNumber] + 1 + "joyH");
        z = Input.GetAxis(index[charIndexNumber] + 1 + "joyV");
        run = Input.GetAxis("Dash_R" + (index[charIndexNumber] + 1));

        if (x != 0 || z != 0)
        {

            charAnim.SetFloat("walk", 0.2f);
            if (run > 0.1)
            {
                charAnim.SetBool("run", true);
                transform.Translate(0, 0, .13f);
            }
            else
            {

                charAnim.SetBool("run", false);
                transform.Translate(0, 0, .1f);
            }
        }
        else
        {
            charAnim.SetFloat("walk", 0);
        }



        if (x > 0 && z > 0)
        {
            transform.localRotation = Quaternion.Euler(transform.localRotation.x, 45, transform.localRotation.z);
        }
        else if (x > 0 && z < 0)
        {
            transform.localRotation = Quaternion.Euler(transform.localRotation.x, 135, transform.localRotation.z);
        }
        else if (x < 0 && z < 0)
        {
            transform.localRotation = Quaternion.Euler(transform.localRotation.x, 225, transform.localRotation.z);
        }
        else if (x < 0 && z > 0)
        {
            transform.localRotation = Quaternion.Euler(transform.localRotation.x, 315, transform.localRotation.z);
        }
        else if (x > 0)
        {
            transform.localRotation = Quaternion.Euler(transform.localRotation.x, 90, transform.localRotation.z);
        }
        else if (x < 0)
        {
            transform.localRotation = Quaternion.Euler(transform.localRotation.x, 270, transform.localRotation.z);
        }

        else if (z > 0)
        {
            transform.localRotation = Quaternion.Euler(transform.localRotation.x, 0, transform.localRotation.z);
        }
        else if (z < 0)
        {
            transform.localRotation = Quaternion.Euler(transform.localRotation.x, 180, transform.localRotation.z);
        }
        
    }

    public void startRepair()
    {
        charAnim.SetBool("repair", true);
    }
    public void doneRepair()
    {
        charAnim.SetBool("repair", false);
    }

    public void startPump()
    {
        charAnim.SetBool("pump", true);
    }
    public void donePump()
    {
        charAnim.SetBool("pump", false);
    }
}
