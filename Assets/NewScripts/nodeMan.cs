using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nodeMan : MonoBehaviour
{
    [SerializeField]
    GameObject[] childNodes, nextNodes;

    [SerializeField]
    GameObject prevNode;

    GameObject requestFrom;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector3 findNode(string nodeName, GameObject magnet)
    {
        if (childNodes.Length > 0)
        {
            bool sendNextNode = false;
            for (int i = 0; i < childNodes.Length; i++)
            {

                if (childNodes[i].name == nodeName)
                {
                    sendNextNode = true;
                    break;
                }

            }

            if (sendNextNode)
            {
                for (int i = 0; i < nextNodes.Length; i++)
                {
                    if (nextNodes[i].GetComponent<nodeMan>().childExists(nodeName))
                    {
                        magnet.GetComponent<magnetMove>().tempNode = nextNodes[i].gameObject;
                        return nextNodes[i].transform.position;
                    }

                }

            }
        }

        if (prevNode != null)
        {
            magnet.GetComponent<magnetMove>().tempNode = prevNode.gameObject;
            return prevNode.transform.position;
        }

        magnet.GetComponent<magnetMove>().tempNode = gameObject;
        return transform.position;
    }

    public bool childExists(string name)
    {
        if (transform.name == name)
            return true;

        foreach (GameObject a in nextNodes)
        {
            if (a.name == name)
            {
                return true;
            }

        }

        return false;
    }
}
