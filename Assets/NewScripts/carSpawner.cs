using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] cSpawnPositions, carList, moveTo;

    [SerializeField]
    GameObject moveOut, totalCars;

    GameObject car;
    

    [SerializeField]
    int[] TotalCarsToSpawn;

    int moveToNumber, timer;

    // Start is called before the first frame update
    void Start()
    {
        car = null;
        moveToNumber = 0;
        timer = 0;

        for (int i = 0; i < TotalCarsToSpawn.Length; i++)
        {
            totalCars.GetComponent<customer>().totalCustomers += TotalCarsToSpawn[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Vehicle").Length < moveTo.Length && timer <= 0)
        {
            if (TotalCarsToSpawn.Length > 0)
            {
                int ran = Random.Range(0, TotalCarsToSpawn.Length);
                int ranSP = Random.Range(0, cSpawnPositions.Length);
                

                if(TotalCarsToSpawn[ran] != 0)
                {
                    car = Instantiate(carList[ran], cSpawnPositions[ranSP].transform.position, cSpawnPositions[ranSP].transform.rotation);
                    totalCars.GetComponent<customer>().currentCustomers += 1;
                    timer = 100;
                    car.GetComponent<carMovement>().moveTo = moveTo[GameObject.FindGameObjectsWithTag("Vehicle").Length - 1];
                    car.GetComponent<carMovement>().moveToExit = moveOut;
                    TotalCarsToSpawn[ran]--;

                    if (moveTo.Length > 0 && moveToNumber > moveTo.Length)
                    {
                        moveToNumber++;
                    }
                    else
                    {
                        moveToNumber = 0;
                    }

                }
            }
        }
        else
        {
            timer--;
        }
    }
}
