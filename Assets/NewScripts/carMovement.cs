using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMovement : MonoBehaviour
{

    public GameObject moveTo, moveToExit;
    public bool to, exit;
    // Start is called before the first frame update
    void Start()
    {
        to = true;
        exit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveTo != null && to)
        {
            if (Vector3.Distance(transform.position, moveTo.transform.position) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, moveTo.transform.position, .5f);
            }
            else
            {
                to = false;
            }
        }
        
        if (exit)
        {
            if (Vector3.Distance(transform.position, moveToExit.transform.position) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, moveToExit.transform.position, .7f);
            }
            else
            {
                Destroy(gameObject, 3);
            }
        }
                    
    }
}
