using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addWheels : MonoBehaviour
{
//this script is to add a new wheel from player to the broken car
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
    //checks if tage of the objects is Player
        if (other.tag == "Player")
        {
        //gets a script attached on the player called objectLocation
            objectLocation pOL = other.GetComponent<objectLocation>();
            if (pOL.sendTag() == "tire")
            {
            //gameObject becomes the new parent of objectLocation obj
                pOL.giveObject(gameObject);
            }
        }
    }
}
