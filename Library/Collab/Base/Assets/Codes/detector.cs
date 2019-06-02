using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detector : MonoBehaviour {

	public GameObject CollidedObject;
	string name;

	// Use this for initialization
	void Start () {

		name = "";
		CollidedObject = null;
		
	}
	
	// Update is called once per frame
	void Update () {
        
		switch(name){

	    	case "Rose_Collider(Clone)":

			    if (Input.GetKeyUp (KeyCode.Joystick1Button1))
                {
                    Debug.Log("hit");
			    	Action (CollidedObject);

		    	}
		    	break;

		    case "Sean_Collider(Clone)":

                Debug.Log("hit22");
                if (Input.GetKeyUp (KeyCode.Joystick2Button1))
                {
                    Debug.Log("hit2");
                    Action (CollidedObject);

			    }
			    break;

            case "Mae_Collider(Clone)":
                
                if (Input.GetKeyUp(KeyCode.Joystick4Button1))
                {

                    Action(CollidedObject);

                }
                break;

            case "Josh_Collider(Clone)":
                
                if (Input.GetKeyUp(KeyCode.Joystick3Button1))
                {

                    Action(CollidedObject);

                }
                break;

        }
		
	}

	public void Action(GameObject a){

		Vector3 position = a.transform.Find ("toolBox_location").localPosition;
		transform.parent.SetParent (a.transform);
		transform.parent.localPosition = position;
        
	}
	void OnCollisionStay(Collision col){

		CollidedObject = col.gameObject;
		name = col.gameObject.name;
	}

	void OnCollisionExit(Collision col){

		CollidedObject = null;
		name = "";

	}
}
