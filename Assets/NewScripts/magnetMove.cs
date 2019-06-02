using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnetMove : MonoBehaviour
{
    [SerializeField]
    GameObject defaultNode, currentNode;

    int trig;
    string nodeNine, destin;
    bool go;
    public GameObject tempNode;
    GameObject car;
    Vector3 moveToPos; 
    public Vector3 magRot; public int stationNo;

    // Start is called before the first frame update
    void Start()
    {
        destin = "";
        trig = 0;
        nodeNine = "nodeOne";
        moveToPos = defaultNode.transform.position;
        go = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (currentNode.name == "nodeOne" && car == null)
        {
            transform.GetComponent<BoxCollider>().enabled = true;
        }
        if (currentNode.name == "nodeOne" && currentNode.name!="ExitNode" && car != null)
        {
            rotateMag(magRot, stationNo);
        }
        if (currentNode.name == "ExitNode")
        {
            gameObject.transform.localEulerAngles = new Vector3(0, 180, 0);
        }

        if (car != null)
        {

            if (Vector3.Distance(transform.position, moveToPos) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, moveToPos, .5f);
            }
            else
            {
                if (currentNode.name != nodeNine)
                {
                    moveToPos = currentNode.GetComponent<nodeMan>().findNode(nodeNine, gameObject);
                }

                if (destin == currentNode.name)
                {
                    car.transform.parent = null;
                    car = null;
                    destin = "";
                    nodeNine = "nodeOne";

                }

                if (tempNode != null)
                {
                    currentNode = tempNode;
                }
                tempNode = null;
            }
        }

        else if (car == null)
        {

            if (Vector3.Distance(transform.position, moveToPos) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, moveToPos, .5f);
            }
            else
            {
                if (currentNode.name != nodeNine)
                {
                    moveToPos = currentNode.GetComponent<nodeMan>().findNode(nodeNine, gameObject);
                }

                if (tempNode != null)
                {
                    currentNode = tempNode;
                }
                tempNode = null;
            }
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Vehicle")
        {
            car = collision.transform.gameObject;
            car.transform.SetParent(transform);
            GetComponent<BoxCollider>().enabled = false;
            destin = "";
        }
    }

    public void goTo(string name)
    {
        nodeNine = name;
        destin = name;
        go = true;
    }

    public void rotateMag(Vector3 rot, int ind)
    {
        switch (ind)
        {
            case 3:
                gameObject.transform.localEulerAngles = new Vector3(rot.x, rot.y, rot.z);
                break;
            case 4:
                gameObject.transform.localEulerAngles = new Vector3(rot.x, rot.y, rot.z);
                break;
            case 5:
                gameObject.transform.localEulerAngles = new Vector3(rot.x, rot.y, rot.z);
                break;
        }
    }
}
