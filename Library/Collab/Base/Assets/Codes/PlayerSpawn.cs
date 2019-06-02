using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {

	[SerializeField]
	GameObject[] Characters;

	[SerializeField]
	GameObject[] PlayerSpawners;

    int players_Active;
    void Awake()
    {
        players_Active = PlayerPrefs.GetInt("Active_Users");
    }

    // Use this for initialization
    void Start () {
        
        for(int i = 0; i < players_Active; i++)
        {
            PlayerSpawners[i] = Instantiate(Characters[i], PlayerSpawners[i].transform.position, PlayerSpawners[i].transform.rotation);
        }

	}
	
	// Update is called once per frame
	void Update () {
	

	}
}
