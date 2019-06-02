using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] spawnPositions;

    [SerializeField]
    GameObject[] playerPrefabs;

    int players;

    private void Awake()
    {
        players = PlayerPrefs.GetInt("Active_Users");
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < players; i++)
        {
            Instantiate(playerPrefabs[i], spawnPositions[i].transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
