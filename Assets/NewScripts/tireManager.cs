using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tireManager : MonoBehaviour
{
    [SerializeField]
    problemOne probOne;

    [SerializeField]
    problemTwo probTwo;

    [SerializeField]
    int problemsActivated;

    public GameObject nameSpawn;

    public int fault;
    bool sendScore;

    // Start is called before the first frame update
    void Start()
    {
        fault = 0;
        sendScore = true;

        int ran = Random.Range(0, 10);

        if (problemsActivated == 1)
        {
            if (ran < 7 )
            {
                probOne.enabled = true;
            }
        }
        else if (problemsActivated > 1)
        {
            if (ran < 8)
            {
                int rand = Random.Range(0, 10);

                if (rand < 5)
                {
                    probOne.enabled = true;
                }
                else
                {
                    probTwo.enabled = true;
                }
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(problemsActivated == 0)
        {
            if (sendScore)
            {
                if (GetComponentInParent<carManager>())
                {

                    GetComponentInParent<carManager>().faults -= 1;
                    sendScore = false;
                }

            }
        }

        if (fault != 0)
        {
            if (sendScore)
            {
                if (GetComponentInParent<carManager>())
                {

                    GetComponentInParent<carManager>().faults += fault;
                    sendScore = false;
                }

            }
        }
        
    }

    public void activateCol()
    {
        nameSpawn.GetComponent<BoxCollider>().enabled = true;
    }

    public void setAct()
    {
        problemsActivated = 0;
        sendScore = true ;
    }
}
