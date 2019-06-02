using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

	private float x; 
	private float z; 
	private string PlayerName;
    int players;
    int[] index;
    string[] strings;
    int roseIdle, seanIdle, joshIdle, maeIdle;

    Animator roseAnim, seanAnim, joshAnim, maeAnim;
    GameObject roseAnimation, seanAnimation, joshAnimation, maeAnimation;

    private void Awake()
    {
        players = PlayerPrefs.GetInt("Active_Users");
        index = new int[players];
        strings = new string[4] { "one", "two", "three", "four" };

        PlayerName = transform.name;

        roseIdle = 0;
        seanIdle = 0;
        joshIdle = 0;
        maeIdle = 0;
    }

    // Use this for initialization
    void Start () {
        
        for (int i = 0; i < players; i++)
        {
            index[i] = PlayerPrefs.GetInt( strings[i]);
        }
        
        roseAnimation = GameObject.Find("RoseAnimation");
        roseAnim = roseAnimation.GetComponent<Animator>();

        seanAnimation = GameObject.Find("SeanAnimation");
        seanAnim = seanAnimation.GetComponent<Animator>();

        if (players >= 3)
        {
            maeAnimation = GameObject.Find("MaeAnimation");
            maeAnim = maeAnimation.GetComponent<Animator>();

            if (players == 4)
            {
                joshAnimation = GameObject.Find("JoshAnimation");
                joshAnim = joshAnimation.GetComponent<Animator>();
            }
        }

	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            RoseStartRepair();
            SeanStartRepair();
            //MaeStartRepair();
            //JoshStartRepair();
        }else if (Input.GetKeyDown(KeyCode.F))
        {
            RoseDoneRepair();
            SeanDoneRepair();
            //MaeDoneRepair();
            //JoshDoneRepair();
        }

        roseAnim.SetInteger("longIdle", roseIdle);
        seanAnim.SetInteger("longIdle", seanIdle);

		switch(PlayerName){

		case "Rose_Collider(Clone)":
                
			    x = Input.GetAxis ((index[0] + 1)+"joyH") * Time.deltaTime * 5f; //50f
			    z = Input.GetAxis ((index[0] + 1) +"joyV") * Time.deltaTime * 5f; //2f
                
                if (x > 0 && z > 0)
                {
                    transform.localRotation = Quaternion.Euler(transform.localRotation.x, 45, transform.localRotation.z);
                }else if(x > 0 && z < 0)
                {
                    transform.localRotation = Quaternion.Euler(transform.localRotation.x, 135, transform.localRotation.z);
                }else if(x < 0 && z < 0)
                {
                    transform.localRotation = Quaternion.Euler(transform.localRotation.x, 225, transform.localRotation.z);
                }
                else if(x < 0 && z > 0)
                {
                    transform.localRotation = Quaternion.Euler(transform.localRotation.x, 315, transform.localRotation.z);
                }
                else if(x > 0)
                {
                    transform.localRotation = Quaternion.Euler(transform.localRotation.x, 90, transform.localRotation.z);
                }
                else if(x < 0)
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
                if(x > 0 || x < 0 || z > 0 || z < 0)
                {
                    //for movement
                    transform.Translate(0, 0, .1f);

                    //for animation
                    roseAnim.SetBool("walk", true);
                }
                else
                {
                    //for animation
                    roseAnim.SetBool("walk", false);
                }

                //testing for dash
                if (Input.GetAxis("Dash_R") > 0.1)
                {
                    transform.Translate(0, 0, 1);
                }

                break;
		
		case "Sean_Collider(Clone)":
                Debug.Log(index[1] + 1);
                x = Input.GetAxis((index[1] + 1) + "joyH") * Time.deltaTime * 5f; //50f
                z = Input.GetAxis((index[1] + 1) + "joyV") * Time.deltaTime * 5f; //2f

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
                if (x > 0 || x < 0 || z > 0 || z < 0)
                {
                    transform.Translate(0, 0, .1f);
                    seanAnim.SetBool("walk", true);
                    seanIdle = 0;
                }
                else
                {
                    seanAnim.SetBool("walk", false);
                }

                break;

		case "Mae_Collider(Clone)":

                x = Input.GetAxis((index[2] + 1) + "joyH") * Time.deltaTime * 5f; //50f
                z = Input.GetAxis((index[2] + 1) + "joyV") * Time.deltaTime * 5f; //2f


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
                if (x > 0 || x < 0 || z > 0 || z < 0)
                {
                    transform.Translate(0, 0, .1f);
                    maeAnim.SetBool("walk", true);
                    maeIdle = 0;
                }
                else
                {
                    maeAnim.SetBool("walk", false);
                }

                break;

		case "Josh_Collider(Clone)":

                x = Input.GetAxis((index[3] + 1) + "joyH") * Time.deltaTime * 5f; //50f
                z = Input.GetAxis((index[3] + 1) + "joyV") * Time.deltaTime * 5f; //2f


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
                if (x > 0 || x < 0 || z > 0 || z < 0)
                {
                    transform.Translate(0, 0, .1f);
                    joshAnim.SetBool("walk", true);
                    joshIdle = 0;
                }
                else
                {
                    joshAnim.SetBool("walk", false);
                }

                break;
		}

	}

    public void RoseStartRepair()
    {
        roseAnim.SetBool("repair", true);
        roseAnimation.transform.position = new Vector3(roseAnimation.transform.position.x, roseAnimation.transform.position.y + 0.24f, roseAnimation.transform.position.z);
    }

    public void RoseDoneRepair()
    {
        roseAnim.SetBool("repair", false);
        roseAnimation.transform.position = new Vector3(roseAnimation.transform.position.x, roseAnimation.transform.position.y - 0.24f, roseAnimation.transform.position.z);
    }

    public void SeanStartRepair()
    {
        seanAnim.SetBool("repair", true);
        seanAnimation.transform.position = new Vector3(seanAnimation.transform.position.x, seanAnimation.transform.position.y + 0.24f, seanAnimation.transform.position.z);
    }

    public void SeanDoneRepair()
    {
        seanAnim.SetBool("repair", false);
        seanAnimation.transform.position = new Vector3(seanAnimation.transform.position.x, seanAnimation.transform.position.y - 0.24f, seanAnimation.transform.position.z);
    }

    public void JoshStartRepair()
    {
        joshAnim.SetBool("repair", true);
    }

    public void JoshDoneRepair()
    {
        joshAnim.SetBool("repair", false);
    }

    public void MaeStartRepair()
    {
        maeAnim.SetBool("repair", true);
    }

    public void MaeDoneRepair()
    {
        maeAnim.SetBool("repair", false);
    }
}
