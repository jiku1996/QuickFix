using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnWheels : MonoBehaviour
{
    [SerializeField]
    GameObject carWheel, car, fixedTire;

    GameObject wheel;

    // Start is called before the first frame update
    void Start()
    {
        int ran = Random.Range(0, 10);

        if (fixedTire != null)
        {

            if(ran < 4)
            {
                wheel = Instantiate(fixedTire, transform.position, transform.rotation);
                wheel.GetComponent<tireManager>().nameSpawn = gameObject;
                wheel.transform.SetParent(car.transform);
            }
            else
            {
                ran = 0;
            }

        }
        else
        {
            ran = 0;
        }

        if (ran == 0)
        {
            wheel = Instantiate(carWheel, transform.position, transform.rotation);
            wheel.GetComponent<tireManager>().nameSpawn = gameObject;
            wheel.transform.SetParent(car.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
